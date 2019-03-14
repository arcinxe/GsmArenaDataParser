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
            System.Console.WriteLine("SHITSTORM STARTED!");
            var startTime = DateTime.Now;
            // Sandbox();
            // return;
            var file = System.IO.File.ReadAllText(Path.Combine("Results", "AllPhonesDetails.json"));
            var phoneId = 1;
            var inputPhonesProcessed = JsonConvert.DeserializeObject<List<AllPhonesDetails>>(file).Select(p => p.Data).ToList();
            inputPhonesProcessed.ForEach(p => p.PhoneId = phoneId++);
            // phones = ExtractValues(phones);
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

            // var query = phones.Where(p => p.Auxiliary.ScreenDiameterInInches > 2.9);


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
            //                single = p.Where(ph => ph.Detail?.MainCamera?.Single != null).Count(),
            //                dual = p.Where(ph => ph.Detail?.MainCamera?.Dual != null).Count(),
            //                triple = p.Where(ph => ph.Detail?.MainCamera?.Triple != null).Count()
            //            });


            // var query = phones
            //             .Where(p => p.Auxiliary.ScreenDiameterInInches > 2.9)
            //             .OrderByDescending(p => p.Brand)
            //             .GroupBy(p => p.Brand)
            //             .Select(p => new
            //             {
            //                 Brand = p.Key,
            //                 Colors = p.Select(ph => ph.Auxiliary.Colors).Distinct()
            //                 //    NoIrda = p.Where(ph => ph.Detail.Comms.InfraredPort != "Yes").Select(ph => ph.Detail.Comms).Distinct().Count()
            //             });

            // var query = phones
            // .Where(p => p.Auxiliary.ReleaseYear > 2016)
            //            .OrderByDescending(p => p.Brand)
            //            .GroupBy(p => p.Brand)
            //            .Select(p => new
            //            {
            //                Brand = p.Key,
            //                MostExpensive = p.OrderByDescending(ph => ph.Auxiliary.PriceInEuro).Select(ph => new { ph.DeviceName, ph.Auxiliary.PriceInEuro }).FirstOrDefault()
            //                //    NoIrda = p.Where(ph => ph.Detail.Comms.InfraredPort != "Yes").Select(ph => ph.Detail.Comms).Distinct().Count()
            //            });

            // var query = phones.Where(p => p.Auxiliary.ReleaseYear==2017
            //  && p.Detail.Sound.The3_5MmJack=="Yes");
            // var query = phones.Where(p => p.Overview.GeneralInfo.Launched.Contains("Released")).Select(p => p.Auxiliary.ReleaseYear).GroupBy(p => p).Distinct();
            // var query = phones.Select(p => p.Auxiliary.OperatingSystem).Distinct().OrderBy(x => x);
            // var query = phones.Where(p => p.Overview.GeneralInfo.Os == "Android Wear OS");
            // var query = phones.Where(p => p.Auxiliary.ScreenDiameterInInches > 2.9);
            // var query = phones
            // .Where(p => p.Brand == "Apple" && p.Detail.Sound.The3_5MmJack == "Yes")
            // .Select(p => new {p.Brand, p.DeviceName, p.Overview.GeneralInfo});
            // var query = phones.OrderBy(p => p.Auxiliary.ScreenDiameterInInches);
            // var query = phones.Where(p => p.Auxiliary.ReleaseYear >= 2017);
            // var query = phones
            // .GroupBy(j => j.Detail.Sound.The3_5MmJack)
            // .Select(p => new
            // {
            //     Jack = p.Key,
            //     Count = p.Select(j => j.Detail.Sound).Distinct().Count()
            // });

            //     var query = phones
            //   .GroupBy(j => j.Detail.Misc.Price)
            //   .Select(p => new
            //   {
            //       Jack = p.Key,
            //       Count = p.Select(j => j.Detail.Misc.Price).Distinct().Count()
            //   });

            // var query = phones.Where(p => p.Detail.Comms.InfraredPort == "Yes" && p.Overview.GeneralInfo.Launched.Contains("2017")).Select(p => new {p.Brand, p.Overview.GeneralInfo});
            // var query = phones
            // .Where(p => p.Detail.Comms.InfraredPort == "Yes" && p.Overview.GeneralInfo.Launched.Contains("2017"))
            // .Select(p => new { p.Brand, p.Overview.GeneralInfo });

            // var resultJson = JsonConvert.SerializeObject(query, Formatting.Indented);
            // System.IO.File.WriteAllText("Results.json", resultJson);
            // using (var writer = new StreamWriter("results.csv"))
            // using (var csv = new CsvWriter(writer))
            // {
            //     csv.WriteRecords(query);
            // }
            //   var query = phones
            //                 .OrderByDescending(p => p.Auxiliary.ReleaseYear)
            //                 .GroupBy(p => p.Auxiliary.ReleaseYear)
            //                 .Select(p => new
            //                {
            //                    Irda = p.Where(ph => ph.Detail.Comms.InfraredPort == "Yes").Select(ph => ph.Detail.Comms).Distinct().Count(),
            //                    NoIrda = p.Where(ph => ph.Detail.Comms.InfraredPort != "Yes").Select(ph => ph.Detail.Comms).Distinct().Count()
            //                });
            // var tempList = new List<List<string>>();
            // for (int i = 0; i < 7; i++)
            // {
            //     tempList.Add(new List<string>());
            // }
            // var regex = new Regex(@"^(\d{4})?[,.; ]*(Q\d)?(\w+)?[,.; ]*(?:Released\s*)*(?:Exp. release )?(\d{4})?[,.; ]*(Q\d)?(\w+)? ?(\d+)?(?:st|nd|rd|th)?$", RegexOptions.IgnoreCase);
            // foreach (var pho in inputPhonesProcessed)
            // {
            //     System.Console.WriteLine(pho.DeviceName);
            //     // System.Console.WriteLine("Reached the hell!");
            //     var match = regex.Match(pho.Detail.Launch.Announced);
            //     // System.Console.WriteLine("Left the hell!");
            //     for (int i = 1; i < 8; i++)
            //     {
            //         tempList[i - 1].Add(match.Groups[i].Value);
            //     }
            //     // break;
            // }
            // // tempList.ForEach(l => l.ToList().Distinct());
            // var tempList2 = new List<List<string>>();
            // foreach (var lis in tempList)
            // {
            //     tempList2.Add(lis.Distinct().OrderBy(l => l).ToList());
            // }
            // // System.Console.WriteLine("Reached the hell!");
            // System.IO.File.WriteAllText("RegexResults.json", JsonConvert.SerializeObject(tempList2, Formatting.Indented));
            // // System.Console.WriteLine("Left the hell!");
            var remodeledPhones = inputPhonesProcessed
                .Select(p => new ValuesExtractor(p).resultPhone);
            var distinctValuesCount = remodeledPhones
                .GroupBy(ph => ph.AnnouncedDate)
                .Select(p => new
                {
                    Key = p.Key,
                    Count =
                    (from selectedPhone in p
                     join originalPhone in inputPhonesProcessed on selectedPhone.PhoneId equals originalPhone.PhoneId
                     select originalPhone.Detail.Launch.Announced).Count(),
                    Values =
                    (from selectedPhone in p
                     join originalPhone in inputPhonesProcessed on selectedPhone.PhoneId equals originalPhone.PhoneId
                     select originalPhone.Detail.Launch.Announced).Distinct()
                })
                .OrderByDescending(b => b.Key).ToList();

            System.IO.File.WriteAllText(Path.Combine("Results", "TestResult.json"),
                JsonConvert.SerializeObject(distinctValuesCount, Formatting.Indented));
            System.IO.File.WriteAllText(Path.Combine("Results", "DistinctResult.json"),
                JsonConvert.SerializeObject(inputPhonesProcessed.Select(p => p.Overview.Display.Resolution).Distinct().OrderByDescending(v => v), Formatting.Indented));
            System.IO.File.WriteAllText(Path.Combine("Results", "FinalResults.json"),
                JsonConvert.SerializeObject(remodeledPhones, Formatting.Indented));
            System.IO.File.WriteAllText(Path.Combine("Results", "InputPhonesProcessed.json"),
                JsonConvert.SerializeObject(inputPhonesProcessed, Formatting.Indented));

            System.Console.WriteLine($"gud: {inputPhonesProcessed.Count()} devices");
            System.Console.WriteLine($"DONE IN: ~{(DateTime.Now - startTime).TotalMilliseconds.ToString("##")}ms!");
        }

        public static IEnumerable<ArktiPhones.Data> ExtractValues(IEnumerable<ArktiPhones.Data> phones)
        {
            // phones = phones.Where(p => p.DeviceType == "Phone");
            // phones = phones.Where(p => !p.DeviceName.ToLower().Contains("watch") && !p.Overview.GeneralInfo.Os.ToLower().Contains("wear"));
            // phones = phones.Where(p => p.DeviceName != "Haier C300" && p.DeviceName != "BLU X Link" && p.DeviceName != "alcatel CareTime" && p.DeviceName != "Huawei Fit" && p.DeviceName != "Samsung Serenata");
            // // TODO: Remove smartwatches
            // foreach (var phone in phones)
            // {
            //    
            //     // Screen diameter
            //     phone.Auxiliary.ScreenDiameterInInches = double.Parse(phone.Overview.Display.Size != null ? Regex.Replace(phone.Overview.Display.Size, "[^0-9.+-]", "") : "-1");
            //     // Weight
            //     double.TryParse(Regex.Replace(phone.Detail.Body.Weight.Split(' ').FirstOrDefault(), "[^0-9.+-]", ""), out var weight);
            //     phone.Auxiliary.WeightInGrams = weight;
            //     // OS
            //     phone.Auxiliary.OperatingSystem = phone.Overview.GeneralInfo.Os.Split(',').FirstOrDefault()?.Split(';').FirstOrDefault().Split('/').FirstOrDefault();
            //     // Battery
            //     phone.Auxiliary.BatteryInMiliAh = phone.Overview.Battery?.Capacity != null ? double.Parse(Regex.Replace(phone.Overview.Battery?.Capacity, "[^0-9+-]", "")) : double.NaN;
            //     // Price
            //     if (phone.Detail.Misc.Price != null)
            //     {

            //         var currency = "EUR";
            //         currency = phone.Detail.Misc.Price.Split(' ').LastOrDefault();
            //         var price = Regex.Replace(phone.Detail.Misc.Price, "[^0-9+-]", "");
            //         var multiplier = 1.0;
            //         switch (currency)
            //         {
            //             case "EUR":
            //                 break;
            //             case "USD":
            //                 multiplier = 0.876;
            //                 break;
            //             case "INR":
            //                 multiplier = 0.012;
            //                 break;
            //             default:
            //                 price = "-1";
            //                 break;

            //         }
            //         phone.Auxiliary.PriceInEuro = double.Parse(price)*multiplier;
            //     }
            //     // Colors
            //     phone.Auxiliary.Colors = phone.Detail.Misc.Colors.Split(", ").ToList();
            // }
            return phones;
        }
        public static void Sandbox()
        {
            // var file = System.IO.File.ReadAllText("Colors.json");
            // var phones = JsonConvert.DeserializeObject<List<PhonesColorsModel>>(file);
            // foreach (var phone in phones)
            // {
            //     var distinctColors = new List<string>();
            //     foreach (var colors in phone.Colors)
            //     {
            //         foreach (var color in colors)
            //         {
            //             distinctColors.Add(color);
            //         }
            //     }
            //     phone.DistinctColors = distinctColors.Distinct().ToList();
            // }
            // // phones = ;
            // var resultJson = JsonConvert.SerializeObject(phones.Select(p => new { p.Brand, p.DistinctColors.Count, p.DistinctColors }), Formatting.Indented);
            // System.IO.File.WriteAllText("ColorsResult.json", resultJson);
            // using (var writer = new StreamWriter("ColorsResult.csv"))
            // using (var csv = new CsvWriter(writer))
            // {
            //     csv.WriteRecords(phones.Select(p => new { p.Brand, p.DistinctColors.Count, p.DistinctColors }));
            // }
        }
    }
}
