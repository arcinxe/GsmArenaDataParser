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
            var file = System.IO.File.ReadAllText(Path.Combine("Results", "AllPhonesDetails.json"));
            var inputPhonesProcessed = JsonConvert.DeserializeObject<List<AllPhonesDetails>>(file).Select(p => p.Data).ToList();

            var distinctRawValuesCount = inputPhonesProcessed
                .GroupBy(ph => ph.Detail.Body.Build)
                .Select(p => new
                {
                    Value = p.Key + $" (x{p.Count()})"
                })
                .OrderBy(p => p.Value);
            var fastRun = false;
            if (!fastRun)
            {
                var remodeledPhones = inputPhonesProcessed.Select(p => new ValuesExtractor(p).resultPhone);
                var distinctRemodeledValuesCount = remodeledPhones
                    .GroupBy(ph => ph.MaterialFrame)
                    .Select(p =>
                    {
                        var query = from selectedPhone in p
                                    join originalPhone in inputPhonesProcessed
                                    on selectedPhone.PhoneId equals originalPhone.PhoneId
                                    select originalPhone.Detail.Body.Build;
                        return new
                        {
                            Key = $"{p.Key} (x{query.Count()})",
                            Values = query.Distinct()
                        };
                    })
                    .OrderByDescending(b => b.Key).ToList();
                System.IO.File.WriteAllText(Path.Combine("Results", "FinalResults.json"),
                    JsonConvert.SerializeObject(remodeledPhones.OrderByDescending(p => p.AnnouncedDate), Formatting.Indented));
                System.IO.File.WriteAllText(Path.Combine("Results", "TestRemodeledResult.json"),
                    JsonConvert.SerializeObject(distinctRemodeledValuesCount, Formatting.Indented));
            }


            System.IO.File.WriteAllText(Path.Combine("Results", "TestRawResult.json"),
                JsonConvert.SerializeObject(distinctRawValuesCount, Formatting.Indented));

            System.IO.File.WriteAllText(Path.Combine("Results", "DistinctResult.json"),
                JsonConvert.SerializeObject(inputPhonesProcessed.Select(p => p.Detail.Body.Build).Distinct().OrderByDescending(v => v), Formatting.Indented));


            System.IO.File.WriteAllText(Path.Combine("Results", "InputPhonesProcessed.json"),
                JsonConvert.SerializeObject(inputPhonesProcessed, Formatting.Indented));

            System.Console.WriteLine($"gud: {inputPhonesProcessed.Count()} devices");
            System.Console.WriteLine($"DONE IN: ~{(DateTime.Now - startTime).TotalMilliseconds.ToString("##")}ms!");
        }
    }
}
