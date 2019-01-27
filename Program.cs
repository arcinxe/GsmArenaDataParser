using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ArktiPhones
{
    class Program
    {
        static void Main(string[] args)
        {
            Sandbox();
            var file = System.IO.File.ReadAllText("AllPhonesDetails.json");
            var phones = JsonConvert.DeserializeObject<List<AllPhonesDetails>>(file);

            var queriedPhones = phones.Where(p => p.Data.Overview.GeneralInfo.Launched.Contains("Released"));
            // var queriedPhones = phones.Where(p => p.Data.Brand == "Apple" /* && p.Data.Detail.Sound.The3_5MmJack == "Yes" */);
            var resultJson = JsonConvert.SerializeObject(queriedPhones, Formatting.Indented);
            System.IO.File.WriteAllText("Results.json", resultJson);

            System.Console.WriteLine($"gud: {queriedPhones.Count()}");
        }
        public static void Sandbox()
        {
            // var foo = "5\"";
            // foo = foo.Replace("\"", "");
            // var bar = (double.Parse(foo));
            // System.Console.WriteLine($"guud: {bar}");
        }
    }
}
