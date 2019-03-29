using System;
using System.Collections.Generic;
using System.Linq;
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
            SetBattery();
            SetRam();
            SetDisplayResolution();
            SetDisplayPixelDensityAndRatio();
            SetDimensions();
            SetWeight();
            SetBuildMaterials();
            SetSimCard();
            SetMemory();
            SetUsb();
            SetOs();
            SetPrice();
            SetColors();
            SetCameraResolution();
            SetGps();
            SetDisplay();
            SetStatus();
            SetSensors();
            SetAudioJack();
            SetWlan();
            SetCpu();
        }

        private void SetCpu()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Overview.Expansion?.Chipset)) return;
            var match = Regex.Match(inputPhone.Overview.Expansion.Chipset, @"^(?:([Аa-zA-Z-]{2,})\b)?(?: (?:([a-zA-Z]{3,})\b))?(?: ?(?:([\w+-]+)))?(?: ?(?:([\w+-]+)))?(?: ?(?:([\w+-]+)))?");
            string name = null;
            string series = null;
            string manufacturer = null;
            string model = null;
            if (match.Success)
            {
            }

        }
        private void SetWlan()
        {
            var features = new List<string>();
            var standards = new List<string>();
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Comms?.Wlan))
            {
                var match = Regex.Match(inputPhone.Detail.Comms.Wlan, @"^wi-fi( 802\.11)?,? ?(?:([bgnacdfhiqxyerk\/]+)\b)?(?: ?, ?((?:[a-zA-Z0-9\. -]+\b[,;\/]? )+))?", RegexOptions.IgnoreCase);
                if (match.Groups[2].Success)
                {
                    standards = match.Groups[2].Value.Split('/').ToList();
                    if (match.Groups[3].Success)
                    {
                        features = match.Groups[3].Value
                            .Replace(";", ",")
                            .Replace("/", ",")
                            .Split(",")
                            .Select(f => f.Trim())
                            .Where(f => !string.IsNullOrWhiteSpace(f))
                            .OrderBy(f => f)
                            .ToList();
                    }
                    resultPhone.Wlan = true;
                }
                else
                    resultPhone.Wlan = inputPhone.Detail.Comms.Wlan.Equals("yes", StringComparison.OrdinalIgnoreCase)
                        ? true
                        : (inputPhone.Detail.Comms.Wlan.Equals("false", StringComparison.OrdinalIgnoreCase)
                            ? false
                            : default(bool));
            }
            resultPhone.WlanFeatures = features;
            resultPhone.WlanStandards = standards;
        }
        private void SetAudioJack()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Sound?.The3_5MmJack)) return;
            if (inputPhone.Detail.Sound.The3_5MmJack.Contains("yes", StringComparison.OrdinalIgnoreCase))
                resultPhone.AudioJack = true;
            else if (inputPhone.Detail.Sound.The3_5MmJack.Contains("no", StringComparison.OrdinalIgnoreCase))
                resultPhone.AudioJack = false;
        }
        private void SetSensors()
        {
            var features = new List<string>();
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Features?.Sensors))
            {
                if (inputPhone.Detail.Features.Sensors.Contains("accelerometer", StringComparison.OrdinalIgnoreCase))
                    features.Add("accelerometer");
                if (inputPhone.Detail.Features.Sensors.Contains("altmeter", StringComparison.OrdinalIgnoreCase))
                    features.Add("altmeter");
                if (inputPhone.Detail.Features.Sensors.Contains("barometer", StringComparison.OrdinalIgnoreCase))
                    features.Add("barometer");
                if (inputPhone.Detail.Features.Sensors.Contains("compass", StringComparison.OrdinalIgnoreCase))
                    features.Add("compass");
                if (inputPhone.Detail.Features.Sensors.Contains("color spectrum", StringComparison.OrdinalIgnoreCase))
                    features.Add("spectrum");
                if (inputPhone.Detail.Features.Sensors.Contains("face id", StringComparison.OrdinalIgnoreCase))
                    features.Add("face id");
                if (inputPhone.Detail.Features.Sensors.Contains("fingerprint", StringComparison.OrdinalIgnoreCase))
                    features.Add("fingerprint");
                if (inputPhone.Detail.Features.Sensors.Contains("gesture", StringComparison.OrdinalIgnoreCase))
                    features.Add("gesture");
                if (inputPhone.Detail.Features.Sensors.Contains("gyro", StringComparison.OrdinalIgnoreCase))
                    features.Add("gyro");
                if (inputPhone.Detail.Features.Sensors.Contains("heart rate", StringComparison.OrdinalIgnoreCase))
                    features.Add("rate");
                if (inputPhone.Detail.Features.Sensors.Contains("humidity", StringComparison.OrdinalIgnoreCase))
                    features.Add("humidity");
                if (inputPhone.Detail.Features.Sensors.Contains("infrared face recognition", StringComparison.OrdinalIgnoreCase))
                    features.Add("infrared face recognition");
                if (inputPhone.Detail.Features.Sensors.Contains("iris scanner", StringComparison.OrdinalIgnoreCase))
                    features.Add("scanner");
                if (inputPhone.Detail.Features.Sensors.Contains("proximity", StringComparison.OrdinalIgnoreCase))
                    features.Add("proximity");
                if (inputPhone.Detail.Features.Sensors.Contains("sensor core", StringComparison.OrdinalIgnoreCase))
                    features.Add("core");
                if (inputPhone.Detail.Features.Sensors.Contains("spo2", StringComparison.OrdinalIgnoreCase))
                    features.Add("spo2");
                if (inputPhone.Detail.Features.Sensors.Contains("temperature", StringComparison.OrdinalIgnoreCase)
                || inputPhone.Detail.Features.Sensors.Contains("thermometer", StringComparison.OrdinalIgnoreCase))
                    features.Add("thermometer");
            }
            resultPhone.Sensors = features;
        }
        private void SetStatus()
        {
            var match = Regex.Match(inputPhone.Detail.Launch.Status, @"^(?:(available|cancelled|coming soon|discontinued))", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                resultPhone.Status = match.Groups[1].Value.ToLowerInvariant();
        }
        private void SetDisplay()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Display?.Type)) return;
            var match = Regex.Match(inputPhone.Detail.Display.Type, @"(?:(\b[\d]+)([mk ]) ?(?:colors)? ?)(?:\(([\d]+)([mk])? effective)?", RegexOptions.IgnoreCase);
            string displayColorMode = null;
            string touchscreen = null;
            int? colors = null;
            int? effectiveColors = null;
            var multiplier = 1;

            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value) && int.TryParse(match.Groups[1].Value, out var result))
            {
                multiplier = match.Groups[2].Value.ToLowerInvariant() == "m" ? 1000000 : match.Groups[2].Value.ToLowerInvariant() == "k" ? 1000 : 1;
                colors = result == 0 ? default(int?) : result * multiplier;
                resultPhone.DisplayColors = colors;
            }
            if (!string.IsNullOrWhiteSpace(match.Groups[3].Value) && int.TryParse(match.Groups[3].Value, out result))
            {
                multiplier = match.Groups[4].Value.ToLowerInvariant() == "m" ? 1000000 : match.Groups[4].Value.ToLowerInvariant() == "k" ? 1000 : 1;
                effectiveColors = result == 0 ? default(int?) : result * multiplier;
                resultPhone.DisplayEffectiveColors = effectiveColors;
            }
            match = Regex.Match(inputPhone.Detail.Display.Type, @"(?:(mono|gray|grey|single|\bcolor\b)[a-zA-Z ,]*)", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
            {
                displayColorMode = match.Groups[1].Value.ToLowerInvariant();
            }
            if ((displayColorMode == "mono" && colors != null) || displayColorMode == "gray" || displayColorMode == "grey")
                displayColorMode = "grayscale";
            if (displayColorMode == null && colors > 16)
                displayColorMode = "color";
            if (displayColorMode == "single")
                displayColorMode = "mono";
            resultPhone.DisplayColorMode = displayColorMode;
            if (inputPhone.Detail.Display.Type == "Capacitive touchscreen")
            { }
            if (inputPhone.Detail.Display.Type.Contains("touch", StringComparison.OrdinalIgnoreCase)) touchscreen = "yes";
            if (inputPhone.Detail.Display.Type.Contains("resistive", StringComparison.OrdinalIgnoreCase)) touchscreen = "resistive";
            if (inputPhone.Detail.Display.Type.Contains("capacitive", StringComparison.OrdinalIgnoreCase)) touchscreen = "capacitive";
            resultPhone.Touchscreen = touchscreen;
            match = Regex.Match(inputPhone.Detail.Display.Type, @"^(lcd|oled|cstn|grayscale lcd|tft|fstn)?(?:([3a-zA-Z][\w +-]*?)(?:grap|capac|resist|touch|toch|,|\())?", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                resultPhone.DisplayType = match.Groups[1].Value.Trim();
            if (!string.IsNullOrWhiteSpace(match.Groups[2].Value) && !match.Groups[2].Value.Contains("capacitive", StringComparison.OrdinalIgnoreCase))
                resultPhone.DisplayType = match.Groups[2].Value.Trim();
            // match = Regex.Match(inputPhone.Detail.Display.Type, @"(?:(mono|gray|grey|\bcolor\b)[a-zA-Z ,]*)?(?:([\d]+) shades)?(?:(\b[\d\.]+)([mk ]) ?(?:colors)? ?)?(?:\(([\d\.]+)([mk])? effective)?", RegexOptions.IgnoreCase);

            // resultPhone.Test = $"{match.Groups[1].Value}, {match.Groups[2].Value}, {match.Groups[3].Value}, {match.Groups[4].Value}, ";
        }
        private void SetGps()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Comms?.Gps)) return;
            var match = Regex.Match(inputPhone.Detail.Comms.Gps, @"^(?:(yes|no)[,;]? ?)?(?:with(?: dual-band)? ?)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?", RegexOptions.IgnoreCase);
            var gps = string.IsNullOrWhiteSpace(match.Groups[1].Value) ? null : match.Groups[1].Value.ToLowerInvariant();
            var features = match.Groups
                .Skip(2)
                .Where(g => !string.IsNullOrWhiteSpace(g.Value))
                .Select(g => g.Value);
            resultPhone.Gps = gps == "yes" ? true : gps == "no" ? false : default(bool?);
            resultPhone.GpsFeatures = features.ToList();

        }
        private void SetCameraResolution()
        {
            // double? photoResoluton = null;
            // double? videoResoluton = null;
            if (!string.IsNullOrWhiteSpace(inputPhone.Overview.Camera?.Photo) && double.TryParse(Regex.Replace(inputPhone.Overview.Camera.Photo, @"[^0-9\.]", ""), out var photoResolution))
                resultPhone.PhotoResolution = photoResolution >= 0 ? photoResolution : default(double?);
            if (!string.IsNullOrWhiteSpace(inputPhone.Overview.Camera?.Video) && int.TryParse(Regex.Replace(inputPhone.Overview.Camera.Video, @"[^0-9\.]", ""), out var videoResolution))
                resultPhone.VideoResolution = videoResolution > 0 || videoResolution < 10000 ? videoResolution : default(int?);
        }
        private void SetColors()
        {
            var match = Regex.Match(inputPhone.Detail.Misc.Colors, @"^\(?(?:[\d]+[ -]+)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?", RegexOptions.IgnoreCase);
            var colors = match.Groups.Select(g => g.Value).Skip(1).ToList();
            colors = colors.Where(c => !string.IsNullOrWhiteSpace(c)).ToList();
            // if (colors.Count() == 0) return;
            // colors.Remove(c => p.Contains("model")))
            resultPhone.Colors = colors;


        }
        private void SetPrice()
        {

            double? price = null;
            string currency = null;
            double? priceInEuro = null;
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Misc.Price)) return;
            var match = Regex.Match(inputPhone.Detail.Misc.Price, @"^(?:About )([\d.]+) (\w+)", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value) && double.TryParse(match.Groups[1].Value, out var result))
            {
                price = result;
                currency = match.Groups[2].Value;
                double priceMultiplier = 1;
                switch (currency)
                {
                    // rates on 2019-03-26
                    case "EUR":
                        priceMultiplier = 1;
                        break;
                    case "USD":
                        priceMultiplier = 0.88;
                        break;
                    case "INR":
                        priceMultiplier = 0.013;
                        break;
                    default:
                        break;
                }
                priceInEuro = Math.Ceiling((price * priceMultiplier).Value);
            }
            resultPhone.Price = price;
            resultPhone.PriceCurrency = currency;
            resultPhone.EstimatedPriceInEuro = priceInEuro;
        }
        private void SetOs()
        {
            string os = null;
            string osFlavor = null;
            string osVersion = null;
            string osLatestVersion = null;
            string osFlavorVersion = null;

            if (inputPhone.Overview.GeneralInfo.Os.Contains("android", StringComparison.OrdinalIgnoreCase))
            {
                var match = Regex.Match(inputPhone.Overview.GeneralInfo.Os, @"^(?:(?:customized )?android(?: wear,?)?(?: os)? ?)(?:([\d\.x]+)(?:[ a-zA-Z]*)\/?,? ?)?(?:([\d\.]+),? ?)?(?:(?:up(?:grad[аa]ble)? to (?:android )?([\d\.]+)(?:[a-zA-Z ]*))?)?(?:not up to [\d\.]+)?(?:planned upgrade to (?:android )?([\d\.]+))?(?:; )*(?:([a-zA-z ]+)([\d\.]+)?)?", RegexOptions.IgnoreCase);
                os = inputPhone.Overview.GeneralInfo.Os.Contains("android wear", StringComparison.OrdinalIgnoreCase) ? "android wear" : "android";
                osVersion = string.IsNullOrWhiteSpace(match.Groups[1].Value) ? null : match.Groups[1].Value;
                osFlavor = string.IsNullOrWhiteSpace(match.Groups[5].Value) ? null : match.Groups[5].Value.Trim();
                osFlavorVersion = string.IsNullOrWhiteSpace(match.Groups[6].Value) ? null : match.Groups[6].Value;
                osVersion = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? osVersion : match.Groups[2].Value;
                osLatestVersion = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? null : match.Groups[3].Value;
            }
            else if (Regex.Match(inputPhone.Overview.GeneralInfo.Os, @"(?:\bios\b|watchos)", RegexOptions.IgnoreCase).Success)
            {
                var match = Regex.Match(inputPhone.Overview.GeneralInfo.Os, @"^(ios|watchos) ?(?:([\d\.]+))?(?:,? ?up to )(?:ios )?([\d\.]+)", RegexOptions.IgnoreCase);
                os = string.IsNullOrWhiteSpace(match.Groups[1].Value) ? null : match.Groups[1].Value;
                osVersion = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? null : match.Groups[2].Value;
                osLatestVersion = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? null : match.Groups[3].Value;
            }
            resultPhone.OperatingSystemName = os;
            resultPhone.OperatingSystemVersion = osVersion;
            resultPhone.OperatingSystemLatestVersion = osLatestVersion;
            resultPhone.OperatingSystemFlavorName = osFlavor;
            resultPhone.OperatingSystemFlavorVersion = osFlavorVersion;
        }
        private void SetUsb()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Comms?.Usb)) return;
            string version = null;
            string connector = null;
            List<string> features = null;
            var match = Regex.Match(inputPhone.Detail.Comms.Usb, @"^(?:(\d\.\d),? ?)?(?:(?!usb host|usb on-the-go)(miniusb|microusb|type-c|usb|proprietary|pop-port) ?(\d\.\d)?[,;]? ?)?(?:revers[\w ]+[,;]?\s)?(?: ?\(((?:mhl|slimport))? ?.*\),? ?)?(?:(usb host)?,? ?(usb (?:on-the-go|otg))?[;,]? ?(magnetic connector)?)?", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                version = match.Groups[1].Value;
            if (version == null && !string.IsNullOrWhiteSpace(match.Groups[3].Value))
                version = match.Groups[3].Value;

            resultPhone.UsbVersion = version;
            if (!string.IsNullOrWhiteSpace(match.Groups[2].Value))
                connector = match.Groups[2].Value.ToLowerInvariant();
            resultPhone.UsbConnector = connector == "usb" ? null : connector;

            if ($"{match.Groups[4].Value}{match.Groups[5].Value}{match.Groups[6].Value}{match.Groups[7].Value}" != "")
                features = new List<string>();

            if (!string.IsNullOrWhiteSpace(match.Groups[4].Value)) features.Add(match.Groups[4].Value);
            if (!string.IsNullOrWhiteSpace(match.Groups[5].Value)) features.Add(match.Groups[5].Value);
            if (!string.IsNullOrWhiteSpace(match.Groups[6].Value)) features.Add(match.Groups[6].Value);
            if (!string.IsNullOrWhiteSpace(match.Groups[7].Value)) features.Add(match.Groups[7].Value);
            resultPhone.UsbFeatures = features;

        }
        private void SetMemory()
        {
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Memory?.Internal))
            {
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
            }
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Memory?.CardSlot))
            {
                var match = Regex.Match(inputPhone.Detail.Memory.CardSlot, @"^(?:(memory stick(?: (?:duo(?: pro)?|micro))?|microsd|micrommc|\bmicro\b|minisd|mmc-micro|mmc|nm|rs-mmc|rs-dv-mmc|sdio|sd|yes|no))(?:\/(memory stick(?: (?:duo(?: pro)?|micro))?|microsd|micrommc|\bmicro\b|minisd|mmc-micro|mmc|nm|rs-mmc|rs-dv-mmc|sdio|sd|yes|no))?(?:.*?up to (\d+) ?([mgt])b)?", RegexOptions.IgnoreCase);
                string cardType = null;
                var multiplier = 1;
                int? maxSize = null;
                string unit = "";
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    cardType = match.Groups[1].Value;
                if (cardType != null && !string.IsNullOrWhiteSpace(match.Groups[2].Value))
                    cardType += "/" + match.Groups[2].Value;
                if (!string.IsNullOrWhiteSpace(match.Groups[3].Value + match.Groups[4].Value) && int.TryParse(match.Groups[3].Value, out var result))
                {
                    unit = match.Groups[4].Value.ToLowerInvariant();
                    multiplier = unit == "m" ? 1 : (unit == "g" ? 1024 : 1048576);
                    maxSize = result * multiplier;
                }
                resultPhone.MemoryCardType = cardType;
                resultPhone.MemoryCardMaxSize = maxSize;
            }
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

            if (sim1 != null)
            {
                resultPhone.SimCards = new List<string>();
                resultPhone.SimCards.Add(sim1);
                if (sim2 != null) resultPhone.SimCards.Add(sim2);
                if (sim3 != null) resultPhone.SimCards.Add(sim3);
                if (sim4 != null) resultPhone.SimCards.Add(sim4);
            }
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
            string bluetooth = Regex.Match(inputPhone.Detail.Comms.Bluetooth, @"^[v\.]*((?:\d+.[\dx]+|Yes|yes|no|No))").Groups[1].Value;
            resultPhone.Bluetooth = string.IsNullOrWhiteSpace(bluetooth) ? null : bluetooth.ToLowerInvariant();
            resultPhone.Infrared = inputPhone.Detail.Comms.InfraredPort?.ToLowerInvariant().Contains("yes") == true;
            resultPhone.Nfc = inputPhone.Detail.Comms.Nfc?.ToLowerInvariant().Contains("yes") == true;
        }

        public void SetBattery()
        {
            if (!string.IsNullOrWhiteSpace(inputPhone.Overview.Battery?.Capacity))
                resultPhone.BatteryCapacity = int.Parse(Regex.Replace(inputPhone.Overview.Battery?.Capacity, "[^0-9+-]", ""));
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Tests?.BatteryLife))
                resultPhone.BatteryEndurance = int.Parse(Regex.Match(inputPhone.Detail.Tests.BatteryLife, @"(\d)+").Value);
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