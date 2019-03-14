namespace ArktiPhones
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class AllPhonesDetails
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Data Data { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }

    public partial class Data
    {
        public int PhoneId { get; set; }
        [JsonProperty("brand", NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; set; }

        [JsonProperty("device_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceName { get; set; }

        [JsonProperty("device_type", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceType { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ImageUrl { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public Overview Overview { get; set; }

        [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
        public Detail Detail { get; set; }
    }

    public partial class Detail
    {
        [JsonProperty("battery", NullValueHandling = NullValueHandling.Ignore)]
        public DetailBattery Battery { get; set; }

        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public Body Body { get; set; }

        [JsonProperty("comms", NullValueHandling = NullValueHandling.Ignore)]
        public Comms Comms { get; set; }

        [JsonProperty("display", NullValueHandling = NullValueHandling.Ignore)]
        public DetailDisplay Display { get; set; }

        [JsonProperty("features", NullValueHandling = NullValueHandling.Ignore)]
        public Features Features { get; set; }

        [JsonProperty("launch", NullValueHandling = NullValueHandling.Ignore)]
        public Launch Launch { get; set; }

        [JsonProperty("main__camera", NullValueHandling = NullValueHandling.Ignore)]
        public MainCamera MainCamera { get; set; }

        [JsonProperty("memory", NullValueHandling = NullValueHandling.Ignore)]
        public Memory Memory { get; set; }

        [JsonProperty("misc", NullValueHandling = NullValueHandling.Ignore)]
        public Misc Misc { get; set; }

        [JsonProperty("network", NullValueHandling = NullValueHandling.Ignore)]
        public Network Network { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public Platform Platform { get; set; }

        [JsonProperty("selfie_camera", NullValueHandling = NullValueHandling.Ignore)]
        public SelfieCamera SelfieCamera { get; set; }

        [JsonProperty("sound", NullValueHandling = NullValueHandling.Ignore)]
        public Sound Sound { get; set; }

        [JsonProperty("tests", NullValueHandling = NullValueHandling.Ignore)]
        public Tests Tests { get; set; }

        [JsonProperty("camera", NullValueHandling = NullValueHandling.Ignore)]
        public DetailCamera Camera { get; set; }
    }

    public partial class DetailBattery
    {
        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        public string Empty { get; set; }

        [JsonProperty("talk_time", NullValueHandling = NullValueHandling.Ignore)]
        public string TalkTime { get; set; }

        [JsonProperty("stand-by", NullValueHandling = NullValueHandling.Ignore)]
        public string StandBy { get; set; }

        [JsonProperty("charging", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Charging { get; set; }

        [JsonProperty("music_play", NullValueHandling = NullValueHandling.Ignore)]
        public string MusicPlay { get; set; }
    }

    public partial class Body
    {
        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Empty { get; set; }

        [JsonProperty("dimensions", NullValueHandling = NullValueHandling.Ignore)]
        public string Dimensions { get; set; }

        [JsonProperty("sim", NullValueHandling = NullValueHandling.Ignore)]
        public string Sim { get; set; }

        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public string Weight { get; set; }

        [JsonProperty("keyboard", NullValueHandling = NullValueHandling.Ignore)]
        public string Keyboard { get; set; }

        [JsonProperty("build", NullValueHandling = NullValueHandling.Ignore)]
        public string Build { get; set; }
    }

    public partial class DetailCamera
    {
        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        public string Empty { get; set; }
    }

    public partial class Comms
    {
        [JsonProperty("bluetooth", NullValueHandling = NullValueHandling.Ignore)]
        public string Bluetooth { get; set; }

        [JsonProperty("gps", NullValueHandling = NullValueHandling.Ignore)]
        public string Gps { get; set; }

        [JsonProperty("radio", NullValueHandling = NullValueHandling.Ignore)]
        public string Radio { get; set; }

        [JsonProperty("usb", NullValueHandling = NullValueHandling.Ignore)]
        public string Usb { get; set; }

        [JsonProperty("wlan", NullValueHandling = NullValueHandling.Ignore)]
        public string Wlan { get; set; }

        [JsonProperty("nfc", NullValueHandling = NullValueHandling.Ignore)]
        public string Nfc { get; set; }

        [JsonProperty("infrared_port", NullValueHandling = NullValueHandling.Ignore)]
        public string InfraredPort { get; set; }
    }

    public partial class DetailDisplay
    {
        [JsonProperty("resolution", NullValueHandling = NullValueHandling.Ignore)]
        public string Resolution { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public string Size { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("protection", NullValueHandling = NullValueHandling.Ignore)]
        public string Protection { get; set; }

        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Empty { get; set; }
    }

    public partial class Features
    {
        [JsonProperty("sensors", NullValueHandling = NullValueHandling.Ignore)]
        public string Sensors { get; set; }

        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Empty { get; set; }

        [JsonProperty("browser", NullValueHandling = NullValueHandling.Ignore)]
        public string Browser { get; set; }

        [JsonProperty("games", NullValueHandling = NullValueHandling.Ignore)]
        public string Games { get; set; }

        [JsonProperty("java", NullValueHandling = NullValueHandling.Ignore)]
        public string Java { get; set; }

        [JsonProperty("messaging", NullValueHandling = NullValueHandling.Ignore)]
        public string Messaging { get; set; }

        [JsonProperty("alarm", NullValueHandling = NullValueHandling.Ignore)]
        public string Alarm { get; set; }

        [JsonProperty("clock", NullValueHandling = NullValueHandling.Ignore)]
        public string Clock { get; set; }

        [JsonProperty("languages", NullValueHandling = NullValueHandling.Ignore)]
        public string Languages { get; set; }
    }

    public partial class Launch
    {
        [JsonProperty("announced", NullValueHandling = NullValueHandling.Ignore)]
        public string Announced { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }

    public partial class MainCamera
    {
        [JsonProperty("single", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Single { get; set; }

        [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
        public string Video { get; set; }

        [JsonProperty("features", NullValueHandling = NullValueHandling.Ignore)]
        public string Features { get; set; }

        [JsonProperty("dual", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Dual { get; set; }

        [JsonProperty("triple", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Triple { get; set; }

        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        public string Empty { get; set; }

        [JsonProperty("quad", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Quad { get; set; }

        [JsonProperty("five", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Five { get; set; }
    }

    public partial class Memory
    {
        [JsonProperty("card_slot", NullValueHandling = NullValueHandling.Ignore)]
        public string CardSlot { get; set; }

        [JsonProperty("internal", NullValueHandling = NullValueHandling.Ignore)]
        public string Internal { get; set; }

        [JsonProperty("call_records", NullValueHandling = NullValueHandling.Ignore)]
        public string CallRecords { get; set; }

        [JsonProperty("phonebook", NullValueHandling = NullValueHandling.Ignore)]
        public string Phonebook { get; set; }

        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Empty { get; set; }
    }

    public partial class Misc
    {
        [JsonProperty("colors", NullValueHandling = NullValueHandling.Ignore)]
        public string Colors { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public string Price { get; set; }

        [JsonProperty("sar_eu", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> SarEu { get; set; }

        [JsonProperty("sar", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Sar { get; set; }
    }

    public partial class Network
    {
        [JsonProperty("2g_bands", NullValueHandling = NullValueHandling.Ignore)]
        public string The2GBands { get; set; }

        [JsonProperty("edge", NullValueHandling = NullValueHandling.Ignore)]
        public string Edge { get; set; }

        [JsonProperty("gprs", NullValueHandling = NullValueHandling.Ignore)]
        public string Gprs { get; set; }

        [JsonProperty("technology", NullValueHandling = NullValueHandling.Ignore)]
        public string Technology { get; set; }

        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        public string Empty { get; set; }

        [JsonProperty("3g_bands", NullValueHandling = NullValueHandling.Ignore)]
        public string The3GBands { get; set; }

        [JsonProperty("4g_bands", NullValueHandling = NullValueHandling.Ignore)]
        public string The4GBands { get; set; }

        [JsonProperty("speed", NullValueHandling = NullValueHandling.Ignore)]
        public string Speed { get; set; }
    }

    public partial class Platform
    {
        [JsonProperty("chipset", NullValueHandling = NullValueHandling.Ignore)]
        public string Chipset { get; set; }

        [JsonProperty("cpu", NullValueHandling = NullValueHandling.Ignore)]
        public string Cpu { get; set; }

        [JsonProperty("os", NullValueHandling = NullValueHandling.Ignore)]
        public string Os { get; set; }

        [JsonProperty("gpu", NullValueHandling = NullValueHandling.Ignore)]
        public string Gpu { get; set; }
    }

    public partial class SelfieCamera
    {
        [JsonProperty("single", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Single { get; set; }

        [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
        public string Video { get; set; }

        [JsonProperty("features", NullValueHandling = NullValueHandling.Ignore)]
        public string Features { get; set; }

        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        public string Empty { get; set; }

        [JsonProperty("dual", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Dual { get; set; }
    }

    public partial class Sound
    {
        [JsonProperty("3_5mm_jack", NullValueHandling = NullValueHandling.Ignore)]
        public string The3_5MmJack { get; set; }

        [JsonProperty("loudspeaker", NullValueHandling = NullValueHandling.Ignore)]
        public string Loudspeaker { get; set; }

        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Empty { get; set; }

        [JsonProperty("alert_types", NullValueHandling = NullValueHandling.Ignore)]
        public string AlertTypes { get; set; }
    }

    public partial class Tests
    {
        [JsonProperty("audio_quality", NullValueHandling = NullValueHandling.Ignore)]
        public string AudioQuality { get; set; }

        [JsonProperty("battery_life", NullValueHandling = NullValueHandling.Ignore)]
        public string BatteryLife { get; set; }

        [JsonProperty("camera", NullValueHandling = NullValueHandling.Ignore)]
        public string Camera { get; set; }

        [JsonProperty("display", NullValueHandling = NullValueHandling.Ignore)]
        public string Display { get; set; }

        [JsonProperty("loudspeaker", NullValueHandling = NullValueHandling.Ignore)]
        public string Loudspeaker { get; set; }

        [JsonProperty("performance", NullValueHandling = NullValueHandling.Ignore)]
        public string Performance { get; set; }
    }

    public partial class Overview
    {
        [JsonProperty("general_info", NullValueHandling = NullValueHandling.Ignore)]
        public GeneralInfo GeneralInfo { get; set; }

        [JsonProperty("display", NullValueHandling = NullValueHandling.Ignore)]
        public OverviewDisplay Display { get; set; }

        [JsonProperty("camera", NullValueHandling = NullValueHandling.Ignore)]
        public OverviewCamera Camera { get; set; }

        [JsonProperty("expansion", NullValueHandling = NullValueHandling.Ignore)]
        public Expansion Expansion { get; set; }

        [JsonProperty("battery", NullValueHandling = NullValueHandling.Ignore)]
        public OverviewBattery Battery { get; set; }
    }

    public partial class OverviewBattery
    {
        [JsonProperty("capacity", NullValueHandling = NullValueHandling.Ignore)]
        public string Capacity { get; set; }

        [JsonProperty("technology", NullValueHandling = NullValueHandling.Ignore)]
        public string Technology { get; set; }
    }

    public partial class OverviewCamera
    {
        [JsonProperty("photo", NullValueHandling = NullValueHandling.Ignore)]
        public string Photo { get; set; }

        [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
        public string Video { get; set; }
    }

    public partial class OverviewDisplay
    {
        [JsonProperty("touchscreen", NullValueHandling = NullValueHandling.Ignore)]
        public string Touchscreen { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public string Size { get; set; }

        [JsonProperty("resolution", NullValueHandling = NullValueHandling.Ignore)]
        public string Resolution { get; set; }
    }

    public partial class Expansion
    {
        [JsonProperty("ram", NullValueHandling = NullValueHandling.Ignore)]
        public string Ram { get; set; }

        [JsonProperty("chipset", NullValueHandling = NullValueHandling.Ignore)]
        public string Chipset { get; set; }
    }

    public partial class GeneralInfo
    {
        [JsonProperty("launched", NullValueHandling = NullValueHandling.Ignore)]
        public string Launched { get; set; }

        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        [JsonProperty("os", NullValueHandling = NullValueHandling.Ignore)]
        public string Os { get; set; }

        [JsonProperty("storage", NullValueHandling = NullValueHandling.Ignore)]
        public string Storage { get; set; }
    }

    public partial struct Charging
    {
        public string String;
        public List<string> StringArray;

        public static implicit operator Charging(string String) => new Charging { String = String };
        public static implicit operator Charging(List<string> StringArray) => new Charging { StringArray = StringArray };
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ChargingConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ChargingConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Charging) || t == typeof(Charging?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Charging { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<string>>(reader);
                    return new Charging { StringArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Charging");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Charging)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.StringArray != null)
            {
                serializer.Serialize(writer, value.StringArray);
                return;
            }
            throw new Exception("Cannot marshal type Charging");
        }

        public static readonly ChargingConverter Singleton = new ChargingConverter();
    }
}
