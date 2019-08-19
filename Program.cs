using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsvHelper;
using Newtonsoft.Json;

namespace GsmArenaDataParser {
    class Program {
        static void Main(string[] args) {
            var startTime = DateTime.Now;
            System.Console.WriteLine($"Started at {startTime}");

            // * Reading all the data from json file
            var file = System.IO.File.ReadAllText(Path.Combine("Results", "AllDevicesDetails.json"));
            var inputDevicesProcessed = JsonConvert
                .DeserializeObject<List<AllDevicesDetails>>(file)
                .Where(p => p?.Data != null)
                .Select(p => p.Data)
                .ToList();

            // * Conversion starts here
            var remodeledDevices = new List<DeviceDetails>();
            var progressCount = 0;
            using(var progress = new ProgressBar()) {
                foreach (var Device in inputDevicesProcessed) {
                    remodeledDevices.Add(new ValuesExtractor(Device).resultDevice);
                    progress.Report((double) progressCount++ / inputDevicesProcessed.Count);
                }
            }

            // * Saving results    
            System.IO.File.WriteAllText(Path.Combine("Results", "FinalResults.json"),
                JsonConvert.SerializeObject(remodeledDevices.OrderByDescending(p => p.Status.AnnouncedDate.Quarter).OrderByDescending(p => p.Status.AnnouncedDate.Month).OrderByDescending(p => p.Status.AnnouncedDate.Year), Formatting.Indented));
            System.IO.File.WriteAllText(Path.Combine("Results", "FinalResultsWithoutNulls.json"),
                JsonConvert.SerializeObject(remodeledDevices.OrderByDescending(p => p.Status.AnnouncedDate.Quarter).OrderByDescending(p => p.Status.AnnouncedDate.Month).OrderByDescending(p => p.Status.AnnouncedDate.Year), Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            // ! Generating additional result files for testing purposes 
            var distinctRawValuesCount = inputDevicesProcessed
                .Where(p => p.Detail.SelfieCamera?.Dual != null)
                // .SelectMany(p => p.Detail.MainCamera?.Single.FirstOrDefault().Split(','))
                // .GroupBy(ph => ph.Trim())
                // .GroupBy(ph => string.Join("  |  ", ph.Detail.MainCamera.Single))
                .GroupBy(ph => ph.Detail.SelfieCamera.Dual)
                .Select(p => new {
                    Value = p.Key + $" (x{p.Count()})"
                })
                .OrderBy(p => p.Value);

            var distinctRemodeledValuesCount = remodeledDevices
                .GroupBy(ph => ph.Status.CurrentStatus)
                .OrderByDescending(p => p.Key)
                .Select(p => {
                    var query = from selectedDevice in p
                    join originalDevice in inputDevicesProcessed
                    on selectedDevice.Basic.GsmArenaId equals originalDevice.PhoneId
                    select originalDevice.Detail.Launch.Status;
                    return new {
                        Key = $"{p.Key} (x{query.Count()})",
                            Values = query.Distinct()
                    };
                })
                // .OrderByDescending(b => b.Key)
                .ToList();
            var distinctRemodeledValuesCount2 = remodeledDevices
                .Where(d => d.Display?.PixelDensity != null)
                .GroupBy(ph => (int) ph.Display.PixelDensity / 100)
                .OrderByDescending(p => p.Key)
                .Select(p => new {
                    Key = $"{p.Key} (x{p.Count()})"

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
                JsonConvert.SerializeObject(inputDevicesProcessed.Where(p => p.Detail.Features?.Sensors != null).SelectMany(p => p.Detail.Features.Sensors.Split(',')).Select(p => p.Trim().ToLowerInvariant()).Distinct().OrderBy(p => p), Formatting.Indented));
            System.IO.File.WriteAllText(Path.Combine("Results", "TestRemodeledResult.json"),
                JsonConvert.SerializeObject(distinctRemodeledValuesCount2, Formatting.Indented));

            // var distinctRemodeledResults = remodeledDevices.SelectMany(p => p.CameraInfo.FrontCameraFeatures).ToList();
            // distinctRemodeledResults.AddRange(remodeledDevices.SelectMany(p => p.CameraInfo.RearCameraFeatures));
            // distinctRemodeledResults.AddRange(remodeledDevices.Where(p => p.CameraInfo.VideoFeatures != null).SelectMany(p => p.CameraInfo.VideoFeatures));
            // distinctRemodeledResults.AddRange(remodeledDevices.SelectMany(p => p.CameraInfo.Cameras.SelectMany(c => c.Features)));
            // System.IO.File.WriteAllText(Path.Combine("Results", "DistinctRemodeledResults.json"), JsonConvert.SerializeObject(distinctRemodeledResults));

            // System.IO.File.WriteAllText(Path.Combine("Results", "TestRawResult.json"),
            //     JsonConvert.SerializeObject(distinctRawValuesCount, Formatting.Indented));if (!Directory.Exists( Path.Combine("Results", "Archived")))
            Directory.CreateDirectory(Path.Combine("Results", "Archived"));
            if (File.Exists(Path.Combine("Results", "TestRawResult.txt")))
                File.Copy(Path.Combine("Results", "TestRawResult.txt"), Path.Combine("Results", "Archived", $"TestRawResult_{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.txt"));

            System.IO.File.WriteAllLines(Path.Combine("Results", "TestRawResult.txt"), distinctRawValuesCount.Select(p => p.Value));
            System.IO.File.WriteAllText(Path.Combine("Results", "InputDevicesProcessed.json"),
                JsonConvert.SerializeObject(inputDevicesProcessed, Formatting.Indented));

            // var distinctResult = inputDevicesProcessed.Select(p => p.Overview.Camera?.Photo)/* .Select(p => p?.ElementAtOrDefault(1)) */.Distinct().OrderByDescending(v => v);
            // System.IO.File.WriteAllLines(Path.Combine("Results", "DistinctResult.txt"), distinctResult);
            // System.IO.File.WriteAllText(Path.Combine("Results", "DistinctResult.json"),
            //     JsonConvert.SerializeObject(distinctResult, Formatting.Indented));

            System.Console.WriteLine($"gud: {inputDevicesProcessed.Count()} devices");
        }
    }
}
