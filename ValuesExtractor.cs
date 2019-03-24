using System;
using System.Text.RegularExpressions;

namespace ArktiPhones
{
    public class ValuesExtractor
    {
        private ArktiPhones.Data inputPhone { get; set; }
        public PhoneDetails resultPhone { get; set; }
        public ValuesExtractor(ArktiPhones.Data phone)
        {
            inputPhone = phone;
            resultPhone = new PhoneDetails();
            DoTheStuff();
        }

        public void DoTheStuff()
        {
            resultPhone.Name = inputPhone.DeviceName;
            resultPhone.PhoneId = inputPhone.PhoneId;
            resultPhone.Slug = inputPhone.Slug;
            resultPhone.ImageUrl = inputPhone.ImageUrl.ToString();
            resultPhone.Brand = inputPhone.Brand;
            resultPhone.BatteryTechnology = inputPhone.Overview.Battery.Technology;
            SetDeviceType();
            SetComms();
            SetDates();
            SetScreenSize();
            SetBatteryCapacity();
            SetRam();
            SetDisplayResolution();
            SetDisplayPixelDensityAndRatio();
            SetDimensions();
            SetWeight();
            SetBuildMaterials();
            SetSimCard();
            SetMemory();
        }

        private void SetMemory()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Memory?.Internal)) return;
            int? internalMemory = null;
            int? readOnlyMemory = null;
            int multiplier = 1;

            var match = Regex.Match(inputPhone.Detail.Memory.Internal, @"^(?:\d*\/)*(?:\d+ ?[KMG]B ram[,;] )?(?:(\d+\.?[\d]*) ?([KMGT])B(?! ram| flash| rom))?", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
            {
                var rawMemory = "";
                var unit = "";
                rawMemory = match.Groups[1].Value;
                unit = match.Groups[2].Value.ToUpperInvariant();
                multiplier = unit == "K" ? 1 : (unit == "M" ? 1024 : (unit == "G" ? 1048576 : 1073741824));
                internalMemory = int.TryParse(rawMemory, out int result) ? result : default(int?);
                internalMemory *= multiplier;
            }
            match = Regex.Match(inputPhone.Detail.Memory.Internal, @"(\d+\.?[\d]*) ?([KMGT])B ROM", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
            {
                var rawMemory = "";
                var unit = "";
                rawMemory = match.Groups[1].Value;
                unit = match.Groups[2].Value;
                multiplier = unit == "K" ? 1 : (unit == "M" ? 1024 : (unit == "G" ? 1048576 : 1073741824));
                readOnlyMemory = int.TryParse(rawMemory, out int result) ? result : default(int?);
                readOnlyMemory *= multiplier;
            }
            resultPhone.MemoryInternal = internalMemory;
            resultPhone.MemoryReadOnly = readOnlyMemory;
            // resultPhone.MemoryInternal = $"{rawInternalMemory} {rawInternalMemoryUnit}, {rawReadOnlyMemory} {rawReadOnlyMemoryUnit}";
        }
        private void SetSimCard()
        {
            string sim1 = null;
            string sim2 = null;
            string sim3 = null;
            string sim4 = null;
            var match = Regex.Match(inputPhone.Detail.Body.Sim, @"^(?:hybrid )?"
              + @"((?:yes|pre|non|electronic|esim|single|dual|triple|quad|nano|mini|micro))?"
              + @"(?:-sim,? ?(?:card)? ?&? ?(e)(?:sime|lectronic)?)?[\w ]*,? ?(?:\(?((?:e|mini|micro|nano))[- ]?sim)? ?"
              + @"[\/,&]*(?:and)? ?(?:(?:((?:e|mini|micro|nano))[- ]?sim)?)?", RegexOptions.IgnoreCase);
            switch (match.Groups[1].Value.ToLowerInvariant())
            {
                case "mini":
                case "micro":
                case "nano":
                case "esim":
                case "electronic":
                    sim1 = match.Groups[1].Value.ToLowerInvariant();
                    sim1 = sim1 == "esim" ? "electronic" : sim1;
                    if (!string.IsNullOrWhiteSpace(match.Groups[2].Value)) sim2 = match.Groups[2].Value.ToLowerInvariant();
                    sim2 = sim2 == "e" || sim2 == "esim" ? "electronic" : sim2;
                    break;
                case "yes":
                case "pre":
                case "non":
                    sim1 = "yes";
                    break;
                case "single":
                    sim1 = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? "yes" : match.Groups[3].Value.ToLowerInvariant();
                    break;
                case "dual":
                    sim1 = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? "yes" : match.Groups[3].Value.ToLowerInvariant();
                    sim2 = string.IsNullOrWhiteSpace(match.Groups[4].Value) ? sim1 : match.Groups[4].Value.ToLowerInvariant();
                    break;
                case "triple":
                    sim1 = sim2 = sim3 = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? "yes" : match.Groups[3].Value.ToLowerInvariant();
                    break;
                case "quad":
                    sim1 = sim2 = sim3 = sim4 = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? "yes" : match.Groups[3].Value.ToLowerInvariant();
                    break;
                default:
                    break;

            }

            resultPhone.Sim1 = sim1;
            resultPhone.Sim2 = sim2;
            resultPhone.Sim3 = sim3;
            resultPhone.Sim4 = sim4;
        }
        private void SetBuildMaterials()
        {
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Body?.Build))
            {
                string frontAndBackMaterial = null;
                string frontMaterial = null;
                string backMaterial = null;
                string frameMaterial = null;
                string bodyMaterial = null;

                var match = Regex.Match(inputPhone.Detail.Body.Build, @"front\/back ([\w \(\)\/]*),?", RegexOptions.IgnoreCase);
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    frontAndBackMaterial = match.Groups[1].Value.Trim();
                resultPhone.MaterialFront = frontAndBackMaterial;
                resultPhone.MaterialBack = frontAndBackMaterial;

                if (string.IsNullOrWhiteSpace(frontAndBackMaterial))
                {
                    match = Regex.Match(inputPhone.Detail.Body.Build, @"front ([\w \(\)&]*),?", RegexOptions.IgnoreCase);
                    if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    {
                        frontMaterial = match.Groups[1].Value.Trim();
                    }
                    resultPhone.MaterialFront = frontMaterial;
                    match = Regex.Match(inputPhone.Detail.Body.Build, @"([\w \(\)\/-]*)? ?back ?([\w \(\)\/]*)?,?", RegexOptions.IgnoreCase);
                    if (match.Groups[1].Success || match.Groups[2].Success)
                    {
                        var choseSecond = match.Groups[1].Value.Contains("Front")
                            || match.Groups[1].Value.Contains("front")
                            || match.Groups[1].Value.Length < match.Groups[2].Value.Length;
                        backMaterial = choseSecond ? match.Groups[2].Value : match.Groups[1].Value.Trim();
                        backMaterial = backMaterial.Contains("case/") ? backMaterial.Substring(0, backMaterial.Length - 6) : backMaterial;
                    }
                    match = Regex.Match(inputPhone.Detail.Body.Build, @"([\w \(\)&]*) frame & back", RegexOptions.IgnoreCase);
                    if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    {
                        backMaterial = match.Groups[1].Value.Trim();
                        frameMaterial = match.Groups[1].Value.Trim();
                    }
                    resultPhone.MaterialBack = string.IsNullOrWhiteSpace(backMaterial) || backMaterial.Contains("and") || backMaterial.Contains("128/8 GB model") ? null : backMaterial;
                }
                match = Regex.Match(inputPhone.Detail.Body.Build, @"([\w\ ]+)\s*frame");
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    frameMaterial = match.Groups[1].Value.Trim();
                resultPhone.MaterialFrame = frameMaterial;

                match = Regex.Match(inputPhone.Detail.Body.Build, @"([\w ]+) (?:uni)?body", RegexOptions.IgnoreCase);
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                {
                    bodyMaterial = match.Groups[1].Value;
                    if (bodyMaterial.Contains("urved")) bodyMaterial = null;
                }
                resultPhone.MaterialBody = bodyMaterial;
            }
        }
        private void SetDimensions()
        {
            var match = Regex.Match(inputPhone.Detail.Body.Dimensions, @"^(?:Unfolded:\s)?"
              + @"(?:([\d\.]+)\s*x\s*([\d\.]+)\s*x\s*([\d\.]+)\s*mm,?\s*)?(?:([\d\.]+)\s?cc)?");
            double? height = null;
            double? width = null;
            double? thickness = null;
            double? volume = null;
            if (match.Groups[1].Success && double.TryParse(match.Groups[1].Value, out var result))
                height = result;
            if (match.Groups[2].Success && double.TryParse(match.Groups[2].Value, out result))
                width = result;
            if (match.Groups[3].Success && double.TryParse(match.Groups[3].Value, out result))
                thickness = result;
            if (match.Groups[4].Success && double.TryParse(match.Groups[4].Value, out result))
                volume = result;
            resultPhone.BodyHeight = height;
            resultPhone.BodyWidth = width;
            resultPhone.BodyThickness = thickness;
            resultPhone.BodyVolume = volume;
        }
        private void SetWeight()
        {
            var match = Regex.Match(inputPhone.Detail.Body.Weight, @"^(?:From\s*)?(?:~\s*)?(?:([\d\.]+)\s*,?\s*g?\s*)?(?:([\d\.]+)\s?cc)?");
            double? weight = null;
            if (double.TryParse(match.Groups[1].Value, out var result))
                weight = result;
            resultPhone.Weight = weight;
        }
        private void SetDisplayResolution()
        {
            if (inputPhone.Overview.Display.Resolution == null)
                return;
            var match = Regex.Match(inputPhone.Overview.Display.Resolution, @"^(?:up to )?(?:(\d\d+)\s?x(\d\d+)"
              + @"\s*(?:pixels)?,?\s*)?(?:(\d+)\s+lines)?(?:\d+\s?x\d+\s*chars)?");
            int? width = null;
            int? height = null;
            int? lines = null;
            if (int.TryParse(match.Groups[1].Value, out var result))
                width = result;
            if (int.TryParse(match.Groups[2].Value, out result))
                height = result;
            if (int.TryParse(match.Groups[3].Value, out result))
                lines = result;

            resultPhone.ResolutionWidth = width;
            resultPhone.ResolutionHeight = height;
            resultPhone.ResolutionLines = lines;
        }
        private void SetDisplayPixelDensityAndRatio()
        {
            var match = Regex.Match(inputPhone.Detail.Display.Resolution, @"(?:([\d\.]+):([\d\.]+)\sratio\s?)?"
              + @"(?:\(.(\d+)\sppi(?:\s?pixel)?\sdensity\))?$");
            double? widthRatio = null;
            double? heightRatio = null;
            double? density = null;
            if (double.TryParse(match.Groups[1].Value, out var result))
            {
                widthRatio = result;
            }
            if (double.TryParse(match.Groups[2].Value, out result))
            {
                heightRatio = result;
            }
            if (double.TryParse(match.Groups[3].Value, out result))
            {
                density = result;
            }
            resultPhone.DisplayPixelDensity = density;
            resultPhone.WidthRatio = widthRatio;
            resultPhone.HeightRatio = heightRatio;
        }
        public void SetScreenSize()
        {
            var match = Regex.Match(inputPhone.Detail.Display.Size, @"^(\d+\.?\d*) inches,?\s?(?:-,\s)?(?:\d*\.\d*, )?"
              + @"(?:([\d\.]+\sx\s+[\d\.]+)\smm,?\s)?(?:(\d+\.?\d*)\scm2\s?)?(?:\(~?([\d\.]+)%.*\))?");
            double? size = null;
            double? area = null;
            double? screenToBodyRatio = null;
            if (double.TryParse(match.Groups[1].Value, out var result))
                size = result;
            if (double.TryParse(match.Groups[3].Value, out result))
                area = result;
            if (double.TryParse(match.Groups[4].Value, out result))
                screenToBodyRatio = result;
            resultPhone.DisplaySize = size;
            resultPhone.DisplayArea = area;
            resultPhone.ScreenToBodyRatio = screenToBodyRatio;
        }
        public void SetRam()
        {
            if (inputPhone.Overview.Expansion?.Ram == null)
                resultPhone.RamInMb = null;
            else
            {
                var match = Regex.Match(inputPhone.Overview.Expansion?.Ram, @"^(\d*\.?\d*)([MG]B)").Groups;
                resultPhone.RamInMb = (int)double.Parse(match[1].Value) * (match[2].Value == "GB" ? 1024 : 1);
            }
        }

        private void SetComms()
        {
            resultPhone.Bluetooth = Regex.Match(inputPhone.Detail.Comms.Bluetooth, @"^[v\.]*((?:\d+.[\dx]+|Yes|yes))").Groups[1].Value;
            resultPhone.Infrared = inputPhone.Detail.Comms.InfraredPort?.ToLowerInvariant().Contains("yes") == true;
        }

        public void SetBatteryCapacity()
        {
            if (inputPhone.Overview.Battery?.Capacity == null)
                resultPhone.BatteryCapacity = null;
            else
                resultPhone.BatteryCapacity = int.Parse(Regex.Replace(inputPhone.Overview.Battery?.Capacity, "[^0-9+-]", ""));
        }

        public void SetDeviceType()
        {
            var type = inputPhone.DeviceType.ToLowerInvariant().Contains("phone") ? "phone" : "tablet";
            type = inputPhone.DeviceName.ToLower().Contains("watch")
                || inputPhone.Overview.GeneralInfo.Os.ToLower().Contains("wear")
                    ? "smartwatch" : type;
            type = inputPhone.DeviceName == "Haier C300"
                || inputPhone.DeviceName == "BLU X Link"
                || inputPhone.DeviceName == "alcatel CareTime"
                || inputPhone.DeviceName == "Huawei Fit"
                || inputPhone.DeviceName == "Samsung Serenata"
                    ? "smartwatch" : type;
            resultPhone.DeviceType = type;
        }
        public void SetDates()
        {
            var regex = new Regex(@"^(\d{4})?[,.; ]*(Q\d)?(\w+)?[,.; ]*(?:Released\s*)*(?:Exp. release )?(\d{4})?[,.; ]*(Q\d)?(\w+)? ?(\d+)?(?:st|nd|rd|th)?$", RegexOptions.IgnoreCase);
            var match = regex.Match(inputPhone.Detail.Launch.Announced);
            var yearAnnounced = 1;
            var monthAnnounced = 1;
            var yearReleased = 1;
            var monthReleased = 1;
            var dayReleased = 1;
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value) && int.TryParse(match.Groups[1].Value, out var result))
            {
                yearAnnounced = result;
                switch (match.Groups[2].Value)
                {
                    case "Q1":
                        monthAnnounced = 2;
                        break;
                    case "Q2":
                        monthAnnounced = 5;
                        break;
                    case "Q3":
                        monthAnnounced = 8;
                        break;
                    case "Q4":
                        monthAnnounced = 11;
                        break;

                    default:
                        break;
                }

                switch (match.Groups[3].Value)
                {
                    case "January":
                        monthAnnounced = 1;
                        break;
                    case "February":
                    case "Februray":
                    case "Feburary":
                        monthAnnounced = 2;
                        break;
                    case "March":
                        monthAnnounced = 3;
                        break;
                    case "April":
                        monthAnnounced = 4;
                        break;
                    case "May":
                        monthAnnounced = 5;
                        break;
                    case "June":
                        monthAnnounced = 6;
                        break;
                    case "July":
                        monthAnnounced = 7;
                        break;
                    case "August":
                    case "Aug":
                        monthAnnounced = 8;
                        break;
                    case "September":
                    case "Sep":
                        monthAnnounced = 9;
                        break;
                    case "October":
                    case "Oct":
                        monthAnnounced = 10;
                        break;
                    case "November":
                    case "Nov":
                        monthAnnounced = 11;
                        break;
                    case "December":
                        monthAnnounced = 12;
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrWhiteSpace(match.Groups[4].Value) && int.TryParse(match.Groups[1].Value, out result))
            {
                yearReleased = result;
                switch (match.Groups[5].Value)
                {
                    case "Q1":
                        monthReleased = 2;
                        break;
                    case "Q2":
                        monthReleased = 5;
                        break;
                    case "Q3":
                        monthReleased = 8;
                        break;
                    case "Q4":
                        monthReleased = 11;
                        break;

                    default:
                        break;
                }

                switch (match.Groups[6].Value)
                {
                    case "January":
                        monthReleased = 1;
                        break;
                    case "February":
                    case "Februray":
                    case "Feburary":
                        monthReleased = 2;
                        break;
                    case "March":
                        monthReleased = 3;
                        break;
                    case "April":
                        monthReleased = 4;
                        break;
                    case "May":
                        monthReleased = 5;
                        break;
                    case "June":
                        monthReleased = 6;
                        break;
                    case "July":
                        monthReleased = 7;
                        break;
                    case "August":
                    case "Aug":
                        monthReleased = 8;
                        break;
                    case "September":
                    case "Sep":
                        monthReleased = 9;
                        break;
                    case "October":
                    case "Oct":
                        monthReleased = 10;
                        break;
                    case "November":
                    case "Nov":
                        monthReleased = 11;
                        break;
                    case "December":
                        monthReleased = 12;
                        break;
                    default:
                        break;
                }
                if (!string.IsNullOrWhiteSpace(match.Groups[7].Value) && int.TryParse(match.Groups[1].Value, out result))
                    dayReleased = result < 32 ? result : 1;
            }

            resultPhone.AnnouncedDate = new DateTime(yearAnnounced, monthAnnounced, 1);
            resultPhone.ReleasedDate = new DateTime(yearReleased, monthReleased, dayReleased);
        }
    }
}