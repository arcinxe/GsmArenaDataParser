using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsvHelper;
using Newtonsoft.Json;

namespace ArktiPhones
{
    class Program
    {
        static void Main(string[] args)
        {
            Sandbox();
            var file = System.IO.File.ReadAllText("AllPhonesDetails.json");
            var phones = JsonConvert.DeserializeObject<List<AllPhonesDetails>>(file).Select(p => p.Data);
            phones = ExtractValues(phones);
            // var query = phones.Where(p => p.Overview.GeneralInfo.Launched.Contains("Released")).Select(p => p.Overview.GeneralInfo.Launched).GroupBy(p => p).Distinct();
            //     var query = phones
            //     .OrderByDescending(p => p.Auxiliary.ReleaseYear)
            //     .GroupBy(p => p.Auxiliary.ReleaseYear)
            //     .Select(p => new
            //    {
            //        Year = p.Key,
            //        Jack = p.Where(ph => ph.Detail.Sound.The3_5MmJack == "Yes").Select(ph => ph.Detail.Sound).Distinct().Count(),
            //        NoJack = p.Where(ph => ph.Detail.Sound.The3_5MmJack != "Yes").Select(ph => ph.Detail.Sound).Distinct().Count()
            //    });

            //      var query = phones
            //     .OrderByDescending(p => p.Auxiliary.ReleaseYear)
            //     .GroupBy(p => p.Auxiliary.ReleaseYear)
            //     .Select(p => new
            //    {
            //        Year = p.Key,
            //        Irda = p.Where(ph => ph.Detail.Comms.InfraredPort == "Yes").Select(ph => ph.Detail.Comms).Distinct().Count(),
            //        NoIrda = p.Where(ph => ph.Detail.Comms.InfraredPort != "Yes").Select(ph => ph.Detail.Comms).Distinct().Count()
            //    });

            //  var query = phones
            //             .OrderByDescending(p => p.Auxiliary.ReleaseYear)
            //             .GroupBy(p => p.Auxiliary.ReleaseYear)
            //             .Select(p => new
            //            {
            //                Year = p.Key,
            //                Irda = p.Where(ph => ph.Detail.Comms.InfraredPort == "Yes").Select(ph => ph.Detail.Comms).Distinct().Count(),
            //                NoIrda = p.Where(ph => ph.Detail.Comms.InfraredPort != "Yes").Select(ph => ph.Detail.Comms).Distinct().Count()
            //            });

            // var query = phones.Where(p => p.Auxiliary.ReleaseYear==2017
            //  && p.Detail.Sound.The3_5MmJack=="Yes");
            // var query = phones.Where(p => p.Overview.GeneralInfo.Launched.Contains("Released")).Select(p => p.Auxiliary.ReleaseYear).GroupBy(p => p).Distinct();
            var query = phones.Select(p => p.Auxiliary.OperatingSystem).Distinct().OrderBy(x => x);
            // var query = phones.Where(p => p.Overview.GeneralInfo.Os == "Android Wear OS");
            // var query = phones
            // .Where(p => p.Brand == "Apple" && p.Detail.Sound.The3_5MmJack == "Yes")
            // .Select(p => new {p.Brand, p.DeviceName, p.Overview.GeneralInfo});
            // var query = phones.Where(p => p.Auxiliary.ReleaseYear >= 2017);
            // var query = phones
            // .GroupBy(j => j.Detail.Sound.The3_5MmJack)
            // .Select(p => new
            // {
            //     Jack = p.Key,
            //     Count = p.Select(j => j.Detail.Sound).Distinct().Count()
            // });

            // var query = phones.Where(p => p.Detail.Comms.InfraredPort == "Yes" && p.Overview.GeneralInfo.Launched.Contains("2017")).Select(p => new {p.Brand, p.Overview.GeneralInfo});
            // var query = phones
            // .Where(p => p.Detail.Comms.InfraredPort == "Yes" && p.Overview.GeneralInfo.Launched.Contains("2017"))
            // .Select(p => new { p.Brand, p.Overview.GeneralInfo });

            var resultJson = JsonConvert.SerializeObject(query, Formatting.Indented);
            System.IO.File.WriteAllText("Results.json", resultJson);
            // using (var writer = new StreamWriter("results.csv"))
            // using (var csv = new CsvWriter(writer))
            // {
            //     csv.WriteRecords(query);
            // }

            System.Console.WriteLine($"gud: {query.Count()}");
        }

        public static IEnumerable<ArktiPhones.Data> ExtractValues(IEnumerable<ArktiPhones.Data> phones)
        {
            phones = phones.Where(p => p.DeviceType == "Phone");
            // TODO: Remove smartwatches
            foreach (var phone in phones)
            {
                phone.Auxiliary = new Auxiliary();
                // Release year
                phone.Auxiliary.ReleaseYear = phone.Overview.GeneralInfo.Launched
                .Contains("Released ")
                ? int.Parse(Regex.Replace(Regex.Replace(phone.Overview.GeneralInfo.Launched, "Q(1|2|3|4)", ""), "[^0-9+-]", "")
                .Substring(0, 4)) : -1;
                // Screen diameter
                phone.Auxiliary.ScreenDiameterInInches = double.Parse(phone.Overview.Display.Size != null ? Regex.Replace(phone.Overview.Display.Size, "[^0-9.+-]", "") : "-1");
                // Weight
                double.TryParse(Regex.Replace(phone.Detail.Body.Weight.Split(' ').FirstOrDefault(), "[^0-9.+-]", ""), out var weight);
                phone.Auxiliary.WeightInGrams = weight;
                // OS
                phone.Auxiliary.OperatingSystem = phone.Overview.GeneralInfo.Os.Split(',').FirstOrDefault()?.Split(';').FirstOrDefault().Split('/').FirstOrDefault();
                // Battery
                phone.Auxiliary.BatteryInMiliAh = phone.Overview.Battery?.Capacity != null ? double.Parse(Regex.Replace(phone.Overview.Battery?.Capacity, "[^0-9+-]", "")) : double.NaN;
            }
            return phones;
        }
        public static void Sandbox()
        {
            var foo = "Released Exp. release 2012, Q1";
            var bar = "";
            bar = Regex.Replace(Regex.Replace(foo, "Q(1|2|3|4)", ""), "[^0-9+-]", "");
            // var bar = (double.Parse(foo));
            System.Console.WriteLine($"guud: {bar}");
        }
    }
}
