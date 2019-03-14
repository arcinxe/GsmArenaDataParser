using System;
using System.Text.RegularExpressions;

namespace ArktiPhones
{
    public class ValuesExtractor
    {
        private ArktiPhones.Data _phone { get; set; }
        public PhoneDetails resultPhone { get; set; }
        public ValuesExtractor(ArktiPhones.Data phone)
        {
            _phone = phone;
            resultPhone = new PhoneDetails();
            DoTheStuff();
        }

        public void DoTheStuff()
        {
            resultPhone.BatteryCapacity = GetBatteryCapacity();
            resultPhone.DeviceType = GetDeviceType();
            resultPhone.ImageUrl = GetImageUrl();
            resultPhone.Name = GetName();
            resultPhone.Brand = GetBrand();
            resultPhone.PhoneId = GetId();
            var dates = GetDates();
            resultPhone.AnnouncedDate = dates[0];
            resultPhone.ReleasedDate = dates[1];
        }
        public int GetBatteryCapacity()
        {
            return _phone.Overview.Battery?.Capacity != null ? int.Parse(Regex.Replace(_phone.Overview.Battery?.Capacity, "[^0-9+-]", "")) : -1;
        }
        public int GetId()
        {
            return _phone.PhoneId;
        }
        public string GetDeviceType()
        {
            var type = _phone.DeviceType.ToLowerInvariant().Contains("phone") ? "phone" : "tablet";
            type = _phone.DeviceName.ToLower().Contains("watch")
                || _phone.Overview.GeneralInfo.Os.ToLower().Contains("wear")
                    ? "smartwatch" : type;
            type = _phone.DeviceName == "Haier C300"
                || _phone.DeviceName == "BLU X Link"
                || _phone.DeviceName == "alcatel CareTime"
                || _phone.DeviceName == "Huawei Fit"
                || _phone.DeviceName == "Samsung Serenata"
                    ? "smartwatch" : type;
            return type;
        }

        public string GetImageUrl() => _phone.ImageUrl.ToString();
        public string GetName() => _phone.DeviceName;
        public string GetBrand() => _phone.Brand;


        public DateTime[] GetDates()
        {
            var regex = new Regex(@"^(\d{4})?[,.; ]*(Q\d)?(\w+)?[,.; ]*(?:Released\s*)*(?:Exp. release )?(\d{4})?[,.; ]*(Q\d)?(\w+)? ?(\d+)?(?:st|nd|rd|th)?$", RegexOptions.IgnoreCase);
            var match = regex.Match(_phone.Detail.Launch.Announced);
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

            return new DateTime[] {
                new DateTime(yearAnnounced, monthAnnounced, 1),
                new DateTime(yearReleased, monthReleased, dayReleased) };
        }
        public DateTime GetReleaseDate()
        {
            var date = _phone.Detail.Launch.Announced
               .Contains("Released ")
               ? int.Parse(Regex.Replace(Regex.Replace(_phone.Overview.GeneralInfo.Launched, "Q(1|2|3|4)", ""), "[^0-9+-]", "")
               .Substring(0, 4)) : 1;
            return new DateTime(date, 1, 1);
        }

        public string GetAnnouncedDate()
        {
            var regex = new Regex(@"^(\d{4})[,\s]*");
            var match = regex.Match(_phone.Detail.Launch.Announced);
            var result = match.Groups[1].Value;
            // result = 
            // var date = _phone.Detail.Launch.Announced
            //    .Contains("Released ")
            //    ? int.Parse(Regex.Replace(Regex.Replace(_phone.Overview.GeneralInfo.Launched, "Q(1|2|3|4)", ""), "[^0-9+-]", "")
            //    .Substring(0, 4)) : -1;
            return result;
            // return new DateTime(date, 1, 1);
        }
    }
}