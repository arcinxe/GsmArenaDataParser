// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ArktiPhones;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace ArktiPhones
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PhonesColorsModel
    {
        [JsonProperty("Brand", NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; set; }

        [JsonProperty("Colors", NullValueHandling = NullValueHandling.Ignore)]
        public List<List<string>> Colors { get; set; }

        [JsonProperty("DistinctColors", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DistinctColors { get; set; }
    }
    
}