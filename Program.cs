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
            var startTime = DateTime.Now;
            System.Console.WriteLine($"Started at {startTime}");
            var file = System.IO.File.ReadAllText(Path.Combine("Results", "AllPhonesDetails.json"));
            var inputPhonesProcessed = JsonConvert
                .DeserializeObject<List<AllPhonesDetails>>(file)
                .Where(p => p?.Data != null)
                .Select(p => p.Data)
                .ToList();

            var distinctRawValuesCount = inputPhonesProcessed
                .Where(p => p.Detail.SelfieCamera?.Dual != null)
                // .SelectMany(p => p.Detail.MainCamera?.Single.FirstOrDefault().Split(','))
                // .GroupBy(ph => ph.Trim())
                // .GroupBy(ph => string.Join("  |  ", ph.Detail.MainCamera.Single))
                .GroupBy(ph => ph.Detail.SelfieCamera.Dual)
                .Select(p => new
                {
                    Value = p.Key + $" (x{p.Count()})"
                })
                .OrderBy(p => p.Value);
            var fastRun = false;
            if (!fastRun)
            {
                var remodeledPhones = new List<PhoneDetails>(); //inputPhonesProcessed.Select(p => new ValuesExtractor(p).resultPhone);
                var progressCount = 0;
                using (var progress = new ProgressBar())
                {
                    foreach (var phone in inputPhonesProcessed)
                    {
                        remodeledPhones.Add(new ValuesExtractor(phone).resultPhone);
                        progress.Report((double)progressCount++ / inputPhonesProcessed.Count);
                    }
                }
                var distinctRemodeledValuesCount = remodeledPhones
                    .GroupBy(ph => ph.Status)
                    .OrderByDescending(p => p.Key)
                    .Select(p =>
                    {
                        var query = from selectedPhone in p
                                    join originalPhone in inputPhonesProcessed
                                    on selectedPhone.PhoneId equals originalPhone.PhoneId
                                    select originalPhone.Detail.Launch.Status;
                        return new
                        {
                            Key = $"{p.Key} (x{query.Count()})",
                            Values = query.Distinct()
                        };
                    })
                    // .OrderByDescending(b => b.Key)
                    .ToList();
                if (!Directory.Exists(Path.Combine("Results", "Archived")))
                    Directory.CreateDirectory(Path.Combine("Results", "Archived"));
                if (File.Exists(Path.Combine("Results", "CombinedUniqueResults.json")))
                    File.Copy(Path.Combine("Results", "CombinedUniqueResults.json"), Path.Combine("Results", "Archived", $"CombinedUniqueResults_{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.json"));
                if (File.Exists(Path.Combine("Results", "TestRemodeledResult.json")))
                    File.Copy(Path.Combine("Results", "TestRemodeledResult.json"), Path.Combine("Results", "Archived", $"TestRemodeledResult_{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.json"));

                System.IO.File.WriteAllText(Path.Combine("Results", "CombinedUniqueResults.json"),
                   JsonConvert.SerializeObject(inputPhonesProcessed.Where(p => p.Detail.Features?.Sensors != null).SelectMany(p => p.Detail.Features.Sensors.Split(',')).Select(p => p.Trim().ToLowerInvariant()).Distinct().OrderBy(p => p), Formatting.Indented));
                System.IO.File.WriteAllText(Path.Combine("Results", "TestRemodeledResult.json"),
                    JsonConvert.SerializeObject(distinctRemodeledValuesCount, Formatting.Indented));
                System.IO.File.WriteAllText(Path.Combine("Results", "FinalResults.json"),
                    JsonConvert.SerializeObject(remodeledPhones.OrderByDescending(p => p.AnnouncedDate.Quarter).OrderByDescending(p => p.AnnouncedDate.Month).OrderByDescending(p => p.AnnouncedDate.Year), Formatting.Indented));
                System.IO.File.WriteAllText(Path.Combine("Results", "FinalResultsWithoutNulls.json"),
                    JsonConvert.SerializeObject(remodeledPhones.OrderByDescending(p => p.AnnouncedDate.Quarter).OrderByDescending(p => p.AnnouncedDate.Month).OrderByDescending(p => p.AnnouncedDate.Year), Formatting.Indented,
                      new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            }


            // System.IO.File.WriteAllText(Path.Combine("Results", "TestRawResult.json"),
            //     JsonConvert.SerializeObject(distinctRawValuesCount, Formatting.Indented));if (!Directory.Exists( Path.Combine("Results", "Archived")))
            Directory.CreateDirectory(Path.Combine("Results", "Archived"));
            if (File.Exists(Path.Combine("Results", "TestRawResult.txt")))
                File.Copy(Path.Combine("Results", "TestRawResult.txt"), Path.Combine("Results", "Archived", $"TestRawResult_{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.txt"));

            System.IO.File.WriteAllLines(Path.Combine("Results", "TestRawResult.txt"), distinctRawValuesCount.Select(p => p.Value));

            // var distinctResult = inputPhonesProcessed.Select(p => p.Overview.Camera?.Photo)/* .Select(p => p?.ElementAtOrDefault(1)) */.Distinct().OrderByDescending(v => v);
            // System.IO.File.WriteAllLines(Path.Combine("Results", "DistinctResult.txt"), distinctResult);
            // System.IO.File.WriteAllText(Path.Combine("Results", "DistinctResult.json"),
            //     JsonConvert.SerializeObject(distinctResult, Formatting.Indented));


            System.IO.File.WriteAllText(Path.Combine("Results", "InputPhonesProcessed.json"),
                JsonConvert.SerializeObject(inputPhonesProcessed, Formatting.Indented));

            System.Console.WriteLine($"gud: {inputPhonesProcessed.Count()} devices");
            System.Console.WriteLine($"Done in ~{(DateTime.Now - startTime):mm\\m\\:ss\\s\\:fff\\m\\s}!");
        }
    }
}
