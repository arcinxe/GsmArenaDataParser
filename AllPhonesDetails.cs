using System;
using System.Collections.Generic;


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
        [JsonProperty("brand", NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; set; }

        [JsonProperty("device_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceName { get; set; }

        [JsonProperty("device_type", NullValueHandling = NullValueHandling.Ignore)]
        public DeviceType? DeviceType { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ImageUrl { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public Overview Overview { get; set; }

        [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
        public Detail Detail { get; set; }

        [JsonProperty("auxiliary", NullValueHandling = NullValueHandling.Ignore)]
        public Auxiliary Auxiliary { get; set; }
        
    }
    public partial class Auxiliary
    {
        [JsonProperty("releaseYear", NullValueHandling = NullValueHandling.Ignore)]
        public int ReleaseYear { get; set; }

        [JsonProperty("screenDiameterInInches", NullValueHandling = NullValueHandling.Ignore)]
        public double ScreenDiameterInInches { get; set; }

        [JsonProperty("weightInGrams", NullValueHandling = NullValueHandling.Ignore)]
        public double WeightInGrams { get; set; }

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

        [JsonProperty("music_play", NullValueHandling = NullValueHandling.Ignore)]
        public string MusicPlay { get; set; }
    }

    public partial class Body
    {
        // [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        // public DualUnion? Empty { get; set; }

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
        public Enum? Empty { get; set; }
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

        // [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        // public DualUnion? Empty { get; set; }
    }

    public partial class Features
    {
        [JsonProperty("sensors", NullValueHandling = NullValueHandling.Ignore)]
        public string Sensors { get; set; }

        // [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        // public DualUnion? Empty { get; set; }

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

        // [JsonProperty("dual", NullValueHandling = NullValueHandling.Ignore)]
        // public DualUnion? Dual { get; set; }

        [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        public string Empty { get; set; }

        [JsonProperty("triple", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Triple { get; set; }
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

        // [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        // public DualUnion? Empty { get; set; }
    }

    public partial class Misc
    {
        [JsonProperty("colors", NullValueHandling = NullValueHandling.Ignore)]
        public string Colors { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public string Price { get; set; }

        // [JsonProperty("sar_eu", NullValueHandling = NullValueHandling.Ignore)]
        // public DualUnion? SarEu { get; set; }

        // [JsonProperty("sar", NullValueHandling = NullValueHandling.Ignore)]
        // public DualUnion? Sar { get; set; }
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

        // [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        // public SelfieCameraUnion? Empty { get; set; }

        [JsonProperty("dual", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Dual { get; set; }
    }

    public partial class Sound
    {
        [JsonProperty("3_5mm_jack", NullValueHandling = NullValueHandling.Ignore)]
        public string The3_5MmJack { get; set; }

        [JsonProperty("loudspeaker", NullValueHandling = NullValueHandling.Ignore)]
        public string Loudspeaker { get; set; }

        // [JsonProperty("", NullValueHandling = NullValueHandling.Ignore)]
        // public DualUnion? Empty { get; set; }

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

    public enum Keyboard { HalfQwerty, Qwerty };

    public enum Enum { Cif, CifVideocallCamera, Empty, Hd, No, NoUsesMainCamera, Vga, VideocallCamera, VideocallViaSwUpdate, Yes };

    public enum InfraredPort { Empty, Midp20, No, Yes, YesDoJa, YesDoJa15, YesDoJa25, YesMidp10, YesMidp12, YesMidp20, YesMidp20Cldc10, YesMidp20Cldc11, YesMidp20MyC32JOnly, YesMidp21, YesViaJavaMidpEmulator };

    public enum Edge { Class10, Class10D600EOnly, Class10E340EOnly, Class10Sim1DownloadOnly, Class11, Class112368Kbps, Class12, Class122961776Kbits, Class12Sim1, Class12TMobile, Class32, Class322368Kbits, Class322961776Kbits, Class322961788Kbits, Class32296Kbits, Class32296Kbps, Class32296KbpsDtmClass11177Kbps, Class32296KbpsDtmClass111788Kbps, Class32296KbpsDtmClass112368Kbps, Class32UpTo177Kbits, Class33, Class4, Class6, Class6DownlinkOnly, Class6UpTo1776Kbps, Class8, ClassB, Empty, No, UpTo177Kbps, UpTo200Kbps, UpTo225Kbps, UpTo2368Kbps, UpTo236Kbps, UpTo237Kbps, UpTo247Kbps, UpTo296Kbps, UpTo384Kbps, UpTo480Kbps, UpTo560Kbps, UpTo60Kbps, W958COnly, Yes, Yes1184Kbps, Yes3GModel, YesDlOnly, YesInD500EVersionOnly, YesSchI605SphL900, YesSghT779SghI497, YesSim1Only };

    public enum Gprs { Class10, Class11, Class111184Kbits, Class11536Kbps, Class12, Class12Sim1Class10Sim2, Class12TMobile, Class2, Class32, Class32100Kbps, Class321072642Kbps, Class32107642Kbps, Class32107Kbps, Class32123Kbps, Class32526Kbps, Class32536Kbps, Class3288Kbps, Class33, Class4, Class5, Class6, Class7, Class8, ClassB, Empty, GprsClass32536Kbps, No, NoPlannedGprsVersionForQ42012, The9600Bps, UpTo100Kbps, UpTo107Kbps, UpTo114Kbps, UpTo115Kbps, UpTo428Kbps, UpTo42Kbps, UpTo48Kbps, UpTo536Kbps, UpTo592Kbps, UpTo60Kbps, UpTo704Kbps, UpTo80Kbps, UpTo856Kbps, UpTo85Kbps, UpTo86Kbps, Yes, Yes3GModel, YesMy202XOnly, YesMyX22MOnly, YesSchI605SphL900, YesSghT779SghI497 };

    public enum NetworkTechnology { Cdma, CdmaCdma2000, CdmaEvdo, CdmaEvdoLte, CdmaHspa, CdmaHspaEvdo, CdmaHspaEvdoLte, CdmaHspaLte, CdmaLte, Gsm, GsmCdma, GsmCdma2000, GsmCdmaEvdo, GsmCdmaEvdoLte, GsmCdmaHspa, GsmCdmaHspaEvdo, GsmCdmaHspaEvdoLte, GsmCdmaHspaLte, GsmCdmaLte, GsmCdmaUmtsCdma2000, GsmCdmaUmtsEvdo, GsmHspa, GsmHspaCdma2000, GsmHspaCdma2000Lte, GsmHspaEvdo, GsmHspaEvdoLte, GsmHspaLte, GsmLte, GsmUmts, GsmUmtsHspa, GsmUmtsLte, Hspa, HspaLte, Lte, NoCellularConnectivity };

    public enum SelfieCameraVideo { Empty, Qvga15Fps, The1080P, The1080P25Fps, The1080P3060Fps, The1080P30Fps, The1080P30Fps480P120Fps, The1080P30Fps5AxisGyroEis, The1080P30FpsGyroEis, The1080P30Ps, The1080P60Fps, The1080PGyroEis, The1440P, The1440P30Fps, The2160P, The2160P30Fps, The2160P30Fps1080P30Fps, The320P, The480P, The480P30Fps, The720P, The720P30Fps, Vga15Fps, Vga30Fps, Video1080P30FpsGyroEis };

    public enum Loudspeaker { No, Yes, Yes21StereoSurroundSound2Tweeters1BassLoudspeaker, YesBuiltInAmplifier, YesDualMonoSpeakers, YesDualSpeakers, YesWithDolbyAtmosStereoSpeakers, YesWithDolbyAtmosStereoSpeakersThxCertifiedAmplifiers, YesWithDualSpeakers, YesWithFourSpeakers, YesWithFrontStereoSpeakers, YesWithMultipleSpeakers, YesWithQuadSpeakers, YesWithStereoSpeakers, YesWithStereoSpeakers15Watt, YesWithStereoSpeakers16Mm22KhzWithVibration, YesWithStereoSpeakers22KhzWithVibration, YesWithStereoSpeakers3GModelsOnly, YesWithStereoSpeakers4Speakers, YesWithStereoSpeakersBangOlufsen };

    public enum The3_5MmJack { NO, No, NoIncludedAdaptorFor35Mm, Tbd, ToBeConfirmed, Yes };

    public enum CameraEnum { Photo, PhotoVideo, Video };

    public enum DeviceType { Phone, Tablet };

    public enum BatteryTechnology { LiIon, LiPo, NiMh };

    public enum Photo { No, Photo12Mp, Photo13Mp, Photo19Mp, Photo21Mp, Photo22Mp, The01Mp, The03Mp, The05Mp, The08Mp, The09Mp, The10Mp, The12Mp, The13Mp, The16Mp, The18Mp, The19Mp, The1Mp, The20Mp, The21Mp, The225Mp, The22Mp, The23Mp, The24Mp, The2Mp, The3Mp, The40Mp, The41Mp, The48Mp, The4Mp, The5Mp, The67Mp, The8Mp };

    public enum CameraVideo { NoVideoRecorder, The1080P, The120P, The128P, The1440P, The144P, The160P, The180P, The2160P, The240P, The288P, The300000P, The320P, The448P, The480P, The600P, The720P, The96P, VideoRecorder };

    public enum Ram { The10GbRam, The128MbRam, The12GbRam, The140MbRam, The150MbRam, The156MbRam, The15GbRam, The168MbRam, The16MbRam, The192MbRam, The1GbRam, The24MbRam, The256MbRam, The270MbRam, The278MbRam, The288MbRam, The290MbRam, The2GbRam, The2MbRam, The30MbRam, The32MbRam, The336MbRam, The384MbRam, The3GbRam, The448MbRam, The478MbRam, The4GbRam, The4MbRam, The50MbRam, The512MbRam, The521MbRam, The576MbRam, The592MbRam, The600MbRam, The60MbRam, The640MbRam, The64MbRam, The6GbRam, The70MbRam, The768MbRam, The8GbRam, The8MbRam, The96MbRam };

    public partial struct DualUnion
    {
        public string String;
        public List<string> StringArray;

        public static implicit operator DualUnion(string String) => new DualUnion { String = String };
        public static implicit operator DualUnion(List<string> StringArray) => new DualUnion { StringArray = StringArray };
    }

    public partial struct SelfieCameraUnion
    {
        public Enum? Enum;
        public long? Integer;

        public static implicit operator SelfieCameraUnion(Enum Enum) => new SelfieCameraUnion { Enum = Enum };
        public static implicit operator SelfieCameraUnion(long Integer) => new SelfieCameraUnion { Integer = Integer };
    }

    public partial class Welcome
    {
        public static List<Welcome> FromJson(string json) => JsonConvert.DeserializeObject<List<Welcome>>(json, ArktiPhones.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Welcome> self) => JsonConvert.SerializeObject(self, ArktiPhones.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DualUnionConverter.Singleton,
                KeyboardConverter.Singleton,
                EnumConverter.Singleton,
                InfraredPortConverter.Singleton,
                EdgeConverter.Singleton,
                GprsConverter.Singleton,
                NetworkTechnologyConverter.Singleton,
                SelfieCameraUnionConverter.Singleton,
                SelfieCameraVideoConverter.Singleton,
                The35MmJackConverter.Singleton,
                LoudspeakerConverter.Singleton,
                CameraEnumConverter.Singleton,
                DeviceTypeConverter.Singleton,
                BatteryTechnologyConverter.Singleton,
                PhotoConverter.Singleton,
                CameraVideoConverter.Singleton,
                RamConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DualUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DualUnion) || t == typeof(DualUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new DualUnion { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<string>>(reader);
                    return new DualUnion { StringArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type DualUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (DualUnion)untypedValue;
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
            throw new Exception("Cannot marshal type DualUnion");
        }

        public static readonly DualUnionConverter Singleton = new DualUnionConverter();
    }

    internal class KeyboardConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Keyboard) || t == typeof(Keyboard?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Half-QWERTY":
                    return Keyboard.HalfQwerty;
                case "QWERTY":
                    return Keyboard.Qwerty;
            }
            throw new Exception("Cannot unmarshal type Keyboard");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Keyboard)untypedValue;
            switch (value)
            {
                case Keyboard.HalfQwerty:
                    serializer.Serialize(writer, "Half-QWERTY");
                    return;
                case Keyboard.Qwerty:
                    serializer.Serialize(writer, "QWERTY");
                    return;
            }
            throw new Exception("Cannot marshal type Keyboard");
        }

        public static readonly KeyboardConverter Singleton = new KeyboardConverter();
    }

    internal class EnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Enum) || t == typeof(Enum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return Enum.Empty;
                case "CIF":
                    return Enum.Cif;
                case "CIF videocall camera":
                    return Enum.CifVideocallCamera;
                case "HD":
                    return Enum.Hd;
                case "No":
                    return Enum.No;
                case "No - uses main camera":
                    return Enum.NoUsesMainCamera;
                case "VGA":
                    return Enum.Vga;
                case "Videocall camera":
                    return Enum.VideocallCamera;
                case "Videocall, via SW update":
                    return Enum.VideocallViaSwUpdate;
                case "Yes":
                    return Enum.Yes;
            }
            throw new Exception("Cannot unmarshal type Enum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Enum)untypedValue;
            switch (value)
            {
                case Enum.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case Enum.Cif:
                    serializer.Serialize(writer, "CIF");
                    return;
                case Enum.CifVideocallCamera:
                    serializer.Serialize(writer, "CIF videocall camera");
                    return;
                case Enum.Hd:
                    serializer.Serialize(writer, "HD");
                    return;
                case Enum.No:
                    serializer.Serialize(writer, "No");
                    return;
                case Enum.NoUsesMainCamera:
                    serializer.Serialize(writer, "No - uses main camera");
                    return;
                case Enum.Vga:
                    serializer.Serialize(writer, "VGA");
                    return;
                case Enum.VideocallCamera:
                    serializer.Serialize(writer, "Videocall camera");
                    return;
                case Enum.VideocallViaSwUpdate:
                    serializer.Serialize(writer, "Videocall, via SW update");
                    return;
                case Enum.Yes:
                    serializer.Serialize(writer, "Yes");
                    return;
            }
            throw new Exception("Cannot marshal type Enum");
        }

        public static readonly EnumConverter Singleton = new EnumConverter();
    }

    internal class InfraredPortConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(InfraredPort) || t == typeof(InfraredPort?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return InfraredPort.Empty;
                case "MIDP 2.0":
                    return InfraredPort.Midp20;
                case "No":
                    return InfraredPort.No;
                case "Yes":
                    return InfraredPort.Yes;
                case "Yes, DoJa":
                    return InfraredPort.YesDoJa;
                case "Yes, DoJa 1.5":
                    return InfraredPort.YesDoJa15;
                case "Yes, DoJa 2.5":
                    return InfraredPort.YesDoJa25;
                case "Yes, MIDP 1.0":
                    return InfraredPort.YesMidp10;
                case "Yes, MIDP 1.2":
                    return InfraredPort.YesMidp12;
                case "Yes, MIDP 2.0":
                    return InfraredPort.YesMidp20;
                case "Yes, MIDP 2.0 (MY C3-2j only)":
                    return InfraredPort.YesMidp20MyC32JOnly;
                case "Yes, MIDP 2.0, CLDC 1.1":
                    return InfraredPort.YesMidp20Cldc11;
                case "Yes, MIDP 2.0; CLDC 1.0":
                    return InfraredPort.YesMidp20Cldc10;
                case "Yes, MIDP 2.1":
                    return InfraredPort.YesMidp21;
                case "Yes, via Java MIDP emulator":
                    return InfraredPort.YesViaJavaMidpEmulator;
            }
            throw new Exception("Cannot unmarshal type InfraredPort");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (InfraredPort)untypedValue;
            switch (value)
            {
                case InfraredPort.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case InfraredPort.Midp20:
                    serializer.Serialize(writer, "MIDP 2.0");
                    return;
                case InfraredPort.No:
                    serializer.Serialize(writer, "No");
                    return;
                case InfraredPort.Yes:
                    serializer.Serialize(writer, "Yes");
                    return;
                case InfraredPort.YesDoJa:
                    serializer.Serialize(writer, "Yes, DoJa");
                    return;
                case InfraredPort.YesDoJa15:
                    serializer.Serialize(writer, "Yes, DoJa 1.5");
                    return;
                case InfraredPort.YesDoJa25:
                    serializer.Serialize(writer, "Yes, DoJa 2.5");
                    return;
                case InfraredPort.YesMidp10:
                    serializer.Serialize(writer, "Yes, MIDP 1.0");
                    return;
                case InfraredPort.YesMidp12:
                    serializer.Serialize(writer, "Yes, MIDP 1.2");
                    return;
                case InfraredPort.YesMidp20:
                    serializer.Serialize(writer, "Yes, MIDP 2.0");
                    return;
                case InfraredPort.YesMidp20MyC32JOnly:
                    serializer.Serialize(writer, "Yes, MIDP 2.0 (MY C3-2j only)");
                    return;
                case InfraredPort.YesMidp20Cldc11:
                    serializer.Serialize(writer, "Yes, MIDP 2.0, CLDC 1.1");
                    return;
                case InfraredPort.YesMidp20Cldc10:
                    serializer.Serialize(writer, "Yes, MIDP 2.0; CLDC 1.0");
                    return;
                case InfraredPort.YesMidp21:
                    serializer.Serialize(writer, "Yes, MIDP 2.1");
                    return;
                case InfraredPort.YesViaJavaMidpEmulator:
                    serializer.Serialize(writer, "Yes, via Java MIDP emulator");
                    return;
            }
            throw new Exception("Cannot marshal type InfraredPort");
        }

        public static readonly InfraredPortConverter Singleton = new InfraredPortConverter();
    }

    internal class EdgeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Edge) || t == typeof(Edge?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return Edge.Empty;
                case "Class 10":
                    return Edge.Class10;
                case "Class 10 (D600E only)":
                    return Edge.Class10D600EOnly;
                case "Class 10 (E340E only)":
                    return Edge.Class10E340EOnly;
                case "Class 10 (SIM 1, download only)":
                    return Edge.Class10Sim1DownloadOnly;
                case "Class 11":
                    return Edge.Class11;
                case "Class 11, 236.8 kbps":
                    return Edge.Class112368Kbps;
                case "Class 12":
                    return Edge.Class12;
                case "Class 12 (SIM 1)":
                    return Edge.Class12Sim1;
                case "Class 12 (T-Mobile)":
                    return Edge.Class12TMobile;
                case "Class 12, 296 / 177.6 kbits":
                    return Edge.Class122961776Kbits;
                case "Class 32":
                    return Edge.Class32;
                case "Class 32,  up to 177 kbits":
                    return Edge.Class32UpTo177Kbits;
                case "Class 32, 236.8 kbits":
                    return Edge.Class322368Kbits;
                case "Class 32, 296 / 177.6 kbits":
                    return Edge.Class322961776Kbits;
                case "Class 32, 296 / 178.8 kbits":
                    return Edge.Class322961788Kbits;
                case "Class 32, 296 kbits":
                    return Edge.Class32296Kbits;
                case "Class 32, 296 kbps":
                    return Edge.Class32296Kbps;
                case "Class 32, 296 kbps; DTM Class 11, 177 kbps":
                    return Edge.Class32296KbpsDtmClass11177Kbps;
                case "Class 32, 296 kbps; DTM Class 11, 178.8 kbps":
                    return Edge.Class32296KbpsDtmClass111788Kbps;
                case "Class 32, 296 kbps; DTM Class 11, 236.8 kbps":
                    return Edge.Class32296KbpsDtmClass112368Kbps;
                case "Class 33":
                    return Edge.Class33;
                case "Class 4":
                    return Edge.Class4;
                case "Class 6":
                    return Edge.Class6;
                case "Class 6 (Up to 177.6 kbps)":
                    return Edge.Class6UpTo1776Kbps;
                case "Class 6 (downlink only)":
                    return Edge.Class6DownlinkOnly;
                case "Class 8":
                    return Edge.Class8;
                case "Class B":
                    return Edge.ClassB;
                case "No":
                    return Edge.No;
                case "Up to 177 kbps":
                    return Edge.UpTo177Kbps;
                case "Up to 200 kbps":
                    return Edge.UpTo200Kbps;
                case "Up to 225 kbps":
                    return Edge.UpTo225Kbps;
                case "Up to 236 kbps":
                    return Edge.UpTo236Kbps;
                case "Up to 236.8 kbps":
                    return Edge.UpTo2368Kbps;
                case "Up to 237 kbps":
                    return Edge.UpTo237Kbps;
                case "Up to 247 kbps":
                    return Edge.UpTo247Kbps;
                case "Up to 296 kbps":
                    return Edge.UpTo296Kbps;
                case "Up to 384 kbps":
                    return Edge.UpTo384Kbps;
                case "Up to 480 kbps":
                    return Edge.UpTo480Kbps;
                case "Up to 560 kbps":
                    return Edge.UpTo560Kbps;
                case "Up to 60 kbps":
                    return Edge.UpTo60Kbps;
                case "W958c only":
                    return Edge.W958COnly;
                case "Yes":
                    return Edge.Yes;
                case "Yes (SIM 1 only)":
                    return Edge.YesSim1Only;
                case "Yes (in D500E version only)":
                    return Edge.YesInD500EVersionOnly;
                case "Yes - 3G model":
                    return Edge.Yes3GModel;
                case "Yes - SCH-I605, SPH-L900":
                    return Edge.YesSchI605SphL900;
                case "Yes -SGH-T779, SGH-I497":
                    return Edge.YesSghT779SghI497;
                case "Yes, 118.4 kbps":
                    return Edge.Yes1184Kbps;
                case "Yes, DL only":
                    return Edge.YesDlOnly;
            }
            throw new Exception("Cannot unmarshal type Edge");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Edge)untypedValue;
            switch (value)
            {
                case Edge.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case Edge.Class10:
                    serializer.Serialize(writer, "Class 10");
                    return;
                case Edge.Class10D600EOnly:
                    serializer.Serialize(writer, "Class 10 (D600E only)");
                    return;
                case Edge.Class10E340EOnly:
                    serializer.Serialize(writer, "Class 10 (E340E only)");
                    return;
                case Edge.Class10Sim1DownloadOnly:
                    serializer.Serialize(writer, "Class 10 (SIM 1, download only)");
                    return;
                case Edge.Class11:
                    serializer.Serialize(writer, "Class 11");
                    return;
                case Edge.Class112368Kbps:
                    serializer.Serialize(writer, "Class 11, 236.8 kbps");
                    return;
                case Edge.Class12:
                    serializer.Serialize(writer, "Class 12");
                    return;
                case Edge.Class12Sim1:
                    serializer.Serialize(writer, "Class 12 (SIM 1)");
                    return;
                case Edge.Class12TMobile:
                    serializer.Serialize(writer, "Class 12 (T-Mobile)");
                    return;
                case Edge.Class122961776Kbits:
                    serializer.Serialize(writer, "Class 12, 296 / 177.6 kbits");
                    return;
                case Edge.Class32:
                    serializer.Serialize(writer, "Class 32");
                    return;
                case Edge.Class32UpTo177Kbits:
                    serializer.Serialize(writer, "Class 32,  up to 177 kbits");
                    return;
                case Edge.Class322368Kbits:
                    serializer.Serialize(writer, "Class 32, 236.8 kbits");
                    return;
                case Edge.Class322961776Kbits:
                    serializer.Serialize(writer, "Class 32, 296 / 177.6 kbits");
                    return;
                case Edge.Class322961788Kbits:
                    serializer.Serialize(writer, "Class 32, 296 / 178.8 kbits");
                    return;
                case Edge.Class32296Kbits:
                    serializer.Serialize(writer, "Class 32, 296 kbits");
                    return;
                case Edge.Class32296Kbps:
                    serializer.Serialize(writer, "Class 32, 296 kbps");
                    return;
                case Edge.Class32296KbpsDtmClass11177Kbps:
                    serializer.Serialize(writer, "Class 32, 296 kbps; DTM Class 11, 177 kbps");
                    return;
                case Edge.Class32296KbpsDtmClass111788Kbps:
                    serializer.Serialize(writer, "Class 32, 296 kbps; DTM Class 11, 178.8 kbps");
                    return;
                case Edge.Class32296KbpsDtmClass112368Kbps:
                    serializer.Serialize(writer, "Class 32, 296 kbps; DTM Class 11, 236.8 kbps");
                    return;
                case Edge.Class33:
                    serializer.Serialize(writer, "Class 33");
                    return;
                case Edge.Class4:
                    serializer.Serialize(writer, "Class 4");
                    return;
                case Edge.Class6:
                    serializer.Serialize(writer, "Class 6");
                    return;
                case Edge.Class6UpTo1776Kbps:
                    serializer.Serialize(writer, "Class 6 (Up to 177.6 kbps)");
                    return;
                case Edge.Class6DownlinkOnly:
                    serializer.Serialize(writer, "Class 6 (downlink only)");
                    return;
                case Edge.Class8:
                    serializer.Serialize(writer, "Class 8");
                    return;
                case Edge.ClassB:
                    serializer.Serialize(writer, "Class B");
                    return;
                case Edge.No:
                    serializer.Serialize(writer, "No");
                    return;
                case Edge.UpTo177Kbps:
                    serializer.Serialize(writer, "Up to 177 kbps");
                    return;
                case Edge.UpTo200Kbps:
                    serializer.Serialize(writer, "Up to 200 kbps");
                    return;
                case Edge.UpTo225Kbps:
                    serializer.Serialize(writer, "Up to 225 kbps");
                    return;
                case Edge.UpTo236Kbps:
                    serializer.Serialize(writer, "Up to 236 kbps");
                    return;
                case Edge.UpTo2368Kbps:
                    serializer.Serialize(writer, "Up to 236.8 kbps");
                    return;
                case Edge.UpTo237Kbps:
                    serializer.Serialize(writer, "Up to 237 kbps");
                    return;
                case Edge.UpTo247Kbps:
                    serializer.Serialize(writer, "Up to 247 kbps");
                    return;
                case Edge.UpTo296Kbps:
                    serializer.Serialize(writer, "Up to 296 kbps");
                    return;
                case Edge.UpTo384Kbps:
                    serializer.Serialize(writer, "Up to 384 kbps");
                    return;
                case Edge.UpTo480Kbps:
                    serializer.Serialize(writer, "Up to 480 kbps");
                    return;
                case Edge.UpTo560Kbps:
                    serializer.Serialize(writer, "Up to 560 kbps");
                    return;
                case Edge.UpTo60Kbps:
                    serializer.Serialize(writer, "Up to 60 kbps");
                    return;
                case Edge.W958COnly:
                    serializer.Serialize(writer, "W958c only");
                    return;
                case Edge.Yes:
                    serializer.Serialize(writer, "Yes");
                    return;
                case Edge.YesSim1Only:
                    serializer.Serialize(writer, "Yes (SIM 1 only)");
                    return;
                case Edge.YesInD500EVersionOnly:
                    serializer.Serialize(writer, "Yes (in D500E version only)");
                    return;
                case Edge.Yes3GModel:
                    serializer.Serialize(writer, "Yes - 3G model");
                    return;
                case Edge.YesSchI605SphL900:
                    serializer.Serialize(writer, "Yes - SCH-I605, SPH-L900");
                    return;
                case Edge.YesSghT779SghI497:
                    serializer.Serialize(writer, "Yes -SGH-T779, SGH-I497");
                    return;
                case Edge.Yes1184Kbps:
                    serializer.Serialize(writer, "Yes, 118.4 kbps");
                    return;
                case Edge.YesDlOnly:
                    serializer.Serialize(writer, "Yes, DL only");
                    return;
            }
            throw new Exception("Cannot marshal type Edge");
        }

        public static readonly EdgeConverter Singleton = new EdgeConverter();
    }

    internal class GprsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Gprs) || t == typeof(Gprs?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return Gprs.Empty;
                case "9600 bps":
                    return Gprs.The9600Bps;
                case "Class 10":
                    return Gprs.Class10;
                case "Class 11":
                    return Gprs.Class11;
                case "Class 11,  53.6 kbps":
                    return Gprs.Class11536Kbps;
                case "Class 11, 118.4 kbits":
                    return Gprs.Class111184Kbits;
                case "Class 12":
                    return Gprs.Class12;
                case "Class 12 (SIM 1), Class 10 (SIM 2)":
                    return Gprs.Class12Sim1Class10Sim2;
                case "Class 12 (T-Mobile)":
                    return Gprs.Class12TMobile;
                case "Class 2":
                    return Gprs.Class2;
                case "Class 32":
                    return Gprs.Class32;
                case "Class 32,  123 kbps":
                    return Gprs.Class32123Kbps;
                case "Class 32,  53.6 kbps":
                    return Gprs.GprsClass32536Kbps;
                case "Class 32,  88 kbps":
                    return Gprs.Class3288Kbps;
                case "Class 32, 100 kbps":
                    return Gprs.Class32100Kbps;
                case "Class 32, 107 / 64.2 kbps":
                    return Gprs.Class32107642Kbps;
                case "Class 32, 107 kbps":
                    return Gprs.Class32107Kbps;
                case "Class 32, 107.2/64.2 kbps":
                    return Gprs.Class321072642Kbps;
                case "Class 32, 52.6 kbps":
                    return Gprs.Class32526Kbps;
                case "Class 32, 53.6 kbps":
                    return Gprs.Class32536Kbps;
                case "Class 33":
                    return Gprs.Class33;
                case "Class 4":
                    return Gprs.Class4;
                case "Class 5":
                    return Gprs.Class5;
                case "Class 6":
                    return Gprs.Class6;
                case "Class 7":
                    return Gprs.Class7;
                case "Class 8":
                    return Gprs.Class8;
                case "Class B":
                    return Gprs.ClassB;
                case "No":
                    return Gprs.No;
                case "No  (Planned GPRS version for Q4 2012)":
                    return Gprs.NoPlannedGprsVersionForQ42012;
                case "Up to 100 kbps":
                    return Gprs.UpTo100Kbps;
                case "Up to 107 kbps":
                    return Gprs.UpTo107Kbps;
                case "Up to 114 kbps":
                    return Gprs.UpTo114Kbps;
                case "Up to 115 kbps":
                    return Gprs.UpTo115Kbps;
                case "Up to 42 kbps":
                    return Gprs.UpTo42Kbps;
                case "Up to 42.8 kbps":
                    return Gprs.UpTo428Kbps;
                case "Up to 48 kbps":
                    return Gprs.UpTo48Kbps;
                case "Up to 53.6 kbps":
                    return Gprs.UpTo536Kbps;
                case "Up to 59.2 kbps":
                    return Gprs.UpTo592Kbps;
                case "Up to 60 kbps":
                    return Gprs.UpTo60Kbps;
                case "Up to 70.4 kbps":
                    return Gprs.UpTo704Kbps;
                case "Up to 80 kbps":
                    return Gprs.UpTo80Kbps;
                case "Up to 85 kbps":
                    return Gprs.UpTo85Kbps;
                case "Up to 85.6 kbps":
                    return Gprs.UpTo856Kbps;
                case "Up to 86 kbps":
                    return Gprs.UpTo86Kbps;
                case "Yes":
                    return Gprs.Yes;
                case "Yes (my202x only)":
                    return Gprs.YesMy202XOnly;
                case "Yes (myX2-2m only)":
                    return Gprs.YesMyX22MOnly;
                case "Yes - 3G model":
                    return Gprs.Yes3GModel;
                case "Yes - SCH-I605, SPH-L900":
                    return Gprs.YesSchI605SphL900;
                case "Yes - SGH-T779, SGH-I497":
                    return Gprs.YesSghT779SghI497;
            }
            throw new Exception("Cannot unmarshal type Gprs");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Gprs)untypedValue;
            switch (value)
            {
                case Gprs.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case Gprs.The9600Bps:
                    serializer.Serialize(writer, "9600 bps");
                    return;
                case Gprs.Class10:
                    serializer.Serialize(writer, "Class 10");
                    return;
                case Gprs.Class11:
                    serializer.Serialize(writer, "Class 11");
                    return;
                case Gprs.Class11536Kbps:
                    serializer.Serialize(writer, "Class 11,  53.6 kbps");
                    return;
                case Gprs.Class111184Kbits:
                    serializer.Serialize(writer, "Class 11, 118.4 kbits");
                    return;
                case Gprs.Class12:
                    serializer.Serialize(writer, "Class 12");
                    return;
                case Gprs.Class12Sim1Class10Sim2:
                    serializer.Serialize(writer, "Class 12 (SIM 1), Class 10 (SIM 2)");
                    return;
                case Gprs.Class12TMobile:
                    serializer.Serialize(writer, "Class 12 (T-Mobile)");
                    return;
                case Gprs.Class2:
                    serializer.Serialize(writer, "Class 2");
                    return;
                case Gprs.Class32:
                    serializer.Serialize(writer, "Class 32");
                    return;
                case Gprs.Class32123Kbps:
                    serializer.Serialize(writer, "Class 32,  123 kbps");
                    return;
                case Gprs.GprsClass32536Kbps:
                    serializer.Serialize(writer, "Class 32,  53.6 kbps");
                    return;
                case Gprs.Class3288Kbps:
                    serializer.Serialize(writer, "Class 32,  88 kbps");
                    return;
                case Gprs.Class32100Kbps:
                    serializer.Serialize(writer, "Class 32, 100 kbps");
                    return;
                case Gprs.Class32107642Kbps:
                    serializer.Serialize(writer, "Class 32, 107 / 64.2 kbps");
                    return;
                case Gprs.Class32107Kbps:
                    serializer.Serialize(writer, "Class 32, 107 kbps");
                    return;
                case Gprs.Class321072642Kbps:
                    serializer.Serialize(writer, "Class 32, 107.2/64.2 kbps");
                    return;
                case Gprs.Class32526Kbps:
                    serializer.Serialize(writer, "Class 32, 52.6 kbps");
                    return;
                case Gprs.Class32536Kbps:
                    serializer.Serialize(writer, "Class 32, 53.6 kbps");
                    return;
                case Gprs.Class33:
                    serializer.Serialize(writer, "Class 33");
                    return;
                case Gprs.Class4:
                    serializer.Serialize(writer, "Class 4");
                    return;
                case Gprs.Class5:
                    serializer.Serialize(writer, "Class 5");
                    return;
                case Gprs.Class6:
                    serializer.Serialize(writer, "Class 6");
                    return;
                case Gprs.Class7:
                    serializer.Serialize(writer, "Class 7");
                    return;
                case Gprs.Class8:
                    serializer.Serialize(writer, "Class 8");
                    return;
                case Gprs.ClassB:
                    serializer.Serialize(writer, "Class B");
                    return;
                case Gprs.No:
                    serializer.Serialize(writer, "No");
                    return;
                case Gprs.NoPlannedGprsVersionForQ42012:
                    serializer.Serialize(writer, "No  (Planned GPRS version for Q4 2012)");
                    return;
                case Gprs.UpTo100Kbps:
                    serializer.Serialize(writer, "Up to 100 kbps");
                    return;
                case Gprs.UpTo107Kbps:
                    serializer.Serialize(writer, "Up to 107 kbps");
                    return;
                case Gprs.UpTo114Kbps:
                    serializer.Serialize(writer, "Up to 114 kbps");
                    return;
                case Gprs.UpTo115Kbps:
                    serializer.Serialize(writer, "Up to 115 kbps");
                    return;
                case Gprs.UpTo42Kbps:
                    serializer.Serialize(writer, "Up to 42 kbps");
                    return;
                case Gprs.UpTo428Kbps:
                    serializer.Serialize(writer, "Up to 42.8 kbps");
                    return;
                case Gprs.UpTo48Kbps:
                    serializer.Serialize(writer, "Up to 48 kbps");
                    return;
                case Gprs.UpTo536Kbps:
                    serializer.Serialize(writer, "Up to 53.6 kbps");
                    return;
                case Gprs.UpTo592Kbps:
                    serializer.Serialize(writer, "Up to 59.2 kbps");
                    return;
                case Gprs.UpTo60Kbps:
                    serializer.Serialize(writer, "Up to 60 kbps");
                    return;
                case Gprs.UpTo704Kbps:
                    serializer.Serialize(writer, "Up to 70.4 kbps");
                    return;
                case Gprs.UpTo80Kbps:
                    serializer.Serialize(writer, "Up to 80 kbps");
                    return;
                case Gprs.UpTo85Kbps:
                    serializer.Serialize(writer, "Up to 85 kbps");
                    return;
                case Gprs.UpTo856Kbps:
                    serializer.Serialize(writer, "Up to 85.6 kbps");
                    return;
                case Gprs.UpTo86Kbps:
                    serializer.Serialize(writer, "Up to 86 kbps");
                    return;
                case Gprs.Yes:
                    serializer.Serialize(writer, "Yes");
                    return;
                case Gprs.YesMy202XOnly:
                    serializer.Serialize(writer, "Yes (my202x only)");
                    return;
                case Gprs.YesMyX22MOnly:
                    serializer.Serialize(writer, "Yes (myX2-2m only)");
                    return;
                case Gprs.Yes3GModel:
                    serializer.Serialize(writer, "Yes - 3G model");
                    return;
                case Gprs.YesSchI605SphL900:
                    serializer.Serialize(writer, "Yes - SCH-I605, SPH-L900");
                    return;
                case Gprs.YesSghT779SghI497:
                    serializer.Serialize(writer, "Yes - SGH-T779, SGH-I497");
                    return;
            }
            throw new Exception("Cannot marshal type Gprs");
        }

        public static readonly GprsConverter Singleton = new GprsConverter();
    }

    internal class NetworkTechnologyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(NetworkTechnology) || t == typeof(NetworkTechnology?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CDMA":
                    return NetworkTechnology.Cdma;
                case "CDMA / CDMA2000":
                    return NetworkTechnology.CdmaCdma2000;
                case "CDMA / EVDO":
                    return NetworkTechnology.CdmaEvdo;
                case "CDMA / EVDO / LTE":
                    return NetworkTechnology.CdmaEvdoLte;
                case "CDMA / HSPA":
                    return NetworkTechnology.CdmaHspa;
                case "CDMA / HSPA / EVDO":
                    return NetworkTechnology.CdmaHspaEvdo;
                case "CDMA / HSPA / EVDO / LTE":
                    return NetworkTechnology.CdmaHspaEvdoLte;
                case "CDMA / HSPA / LTE":
                    return NetworkTechnology.CdmaHspaLte;
                case "CDMA / LTE":
                    return NetworkTechnology.CdmaLte;
                case "GSM":
                    return NetworkTechnology.Gsm;
                case "GSM / CDMA":
                    return NetworkTechnology.GsmCdma;
                case "GSM / CDMA / EVDO":
                    return NetworkTechnology.GsmCdmaEvdo;
                case "GSM / CDMA / EVDO / LTE":
                    return NetworkTechnology.GsmCdmaEvdoLte;
                case "GSM / CDMA / HSPA":
                    return NetworkTechnology.GsmCdmaHspa;
                case "GSM / CDMA / HSPA / EVDO":
                    return NetworkTechnology.GsmCdmaHspaEvdo;
                case "GSM / CDMA / HSPA / EVDO / LTE":
                    return NetworkTechnology.GsmCdmaHspaEvdoLte;
                case "GSM / CDMA / HSPA / LTE":
                    return NetworkTechnology.GsmCdmaHspaLte;
                case "GSM / CDMA / LTE":
                    return NetworkTechnology.GsmCdmaLte;
                case "GSM / CDMA / UMTS / CDMA2000":
                    return NetworkTechnology.GsmCdmaUmtsCdma2000;
                case "GSM / CDMA / UMTS / EVDO":
                    return NetworkTechnology.GsmCdmaUmtsEvdo;
                case "GSM / CDMA2000":
                    return NetworkTechnology.GsmCdma2000;
                case "GSM / HSPA":
                    return NetworkTechnology.GsmHspa;
                case "GSM / HSPA / CDMA2000":
                    return NetworkTechnology.GsmHspaCdma2000;
                case "GSM / HSPA / CDMA2000 / LTE":
                    return NetworkTechnology.GsmHspaCdma2000Lte;
                case "GSM / HSPA / EVDO":
                    return NetworkTechnology.GsmHspaEvdo;
                case "GSM / HSPA / EVDO / LTE":
                    return NetworkTechnology.GsmHspaEvdoLte;
                case "GSM / HSPA / LTE":
                    return NetworkTechnology.GsmHspaLte;
                case "GSM / LTE":
                    return NetworkTechnology.GsmLte;
                case "GSM / UMTS":
                    return NetworkTechnology.GsmUmts;
                case "GSM / UMTS / HSPA":
                    return NetworkTechnology.GsmUmtsHspa;
                case "GSM / UMTS / LTE":
                    return NetworkTechnology.GsmUmtsLte;
                case "HSPA":
                    return NetworkTechnology.Hspa;
                case "HSPA / LTE":
                    return NetworkTechnology.HspaLte;
                case "LTE":
                    return NetworkTechnology.Lte;
                case "No cellular connectivity":
                    return NetworkTechnology.NoCellularConnectivity;
            }
            throw new Exception("Cannot unmarshal type NetworkTechnology");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (NetworkTechnology)untypedValue;
            switch (value)
            {
                case NetworkTechnology.Cdma:
                    serializer.Serialize(writer, "CDMA");
                    return;
                case NetworkTechnology.CdmaCdma2000:
                    serializer.Serialize(writer, "CDMA / CDMA2000");
                    return;
                case NetworkTechnology.CdmaEvdo:
                    serializer.Serialize(writer, "CDMA / EVDO");
                    return;
                case NetworkTechnology.CdmaEvdoLte:
                    serializer.Serialize(writer, "CDMA / EVDO / LTE");
                    return;
                case NetworkTechnology.CdmaHspa:
                    serializer.Serialize(writer, "CDMA / HSPA");
                    return;
                case NetworkTechnology.CdmaHspaEvdo:
                    serializer.Serialize(writer, "CDMA / HSPA / EVDO");
                    return;
                case NetworkTechnology.CdmaHspaEvdoLte:
                    serializer.Serialize(writer, "CDMA / HSPA / EVDO / LTE");
                    return;
                case NetworkTechnology.CdmaHspaLte:
                    serializer.Serialize(writer, "CDMA / HSPA / LTE");
                    return;
                case NetworkTechnology.CdmaLte:
                    serializer.Serialize(writer, "CDMA / LTE");
                    return;
                case NetworkTechnology.Gsm:
                    serializer.Serialize(writer, "GSM");
                    return;
                case NetworkTechnology.GsmCdma:
                    serializer.Serialize(writer, "GSM / CDMA");
                    return;
                case NetworkTechnology.GsmCdmaEvdo:
                    serializer.Serialize(writer, "GSM / CDMA / EVDO");
                    return;
                case NetworkTechnology.GsmCdmaEvdoLte:
                    serializer.Serialize(writer, "GSM / CDMA / EVDO / LTE");
                    return;
                case NetworkTechnology.GsmCdmaHspa:
                    serializer.Serialize(writer, "GSM / CDMA / HSPA");
                    return;
                case NetworkTechnology.GsmCdmaHspaEvdo:
                    serializer.Serialize(writer, "GSM / CDMA / HSPA / EVDO");
                    return;
                case NetworkTechnology.GsmCdmaHspaEvdoLte:
                    serializer.Serialize(writer, "GSM / CDMA / HSPA / EVDO / LTE");
                    return;
                case NetworkTechnology.GsmCdmaHspaLte:
                    serializer.Serialize(writer, "GSM / CDMA / HSPA / LTE");
                    return;
                case NetworkTechnology.GsmCdmaLte:
                    serializer.Serialize(writer, "GSM / CDMA / LTE");
                    return;
                case NetworkTechnology.GsmCdmaUmtsCdma2000:
                    serializer.Serialize(writer, "GSM / CDMA / UMTS / CDMA2000");
                    return;
                case NetworkTechnology.GsmCdmaUmtsEvdo:
                    serializer.Serialize(writer, "GSM / CDMA / UMTS / EVDO");
                    return;
                case NetworkTechnology.GsmCdma2000:
                    serializer.Serialize(writer, "GSM / CDMA2000");
                    return;
                case NetworkTechnology.GsmHspa:
                    serializer.Serialize(writer, "GSM / HSPA");
                    return;
                case NetworkTechnology.GsmHspaCdma2000:
                    serializer.Serialize(writer, "GSM / HSPA / CDMA2000");
                    return;
                case NetworkTechnology.GsmHspaCdma2000Lte:
                    serializer.Serialize(writer, "GSM / HSPA / CDMA2000 / LTE");
                    return;
                case NetworkTechnology.GsmHspaEvdo:
                    serializer.Serialize(writer, "GSM / HSPA / EVDO");
                    return;
                case NetworkTechnology.GsmHspaEvdoLte:
                    serializer.Serialize(writer, "GSM / HSPA / EVDO / LTE");
                    return;
                case NetworkTechnology.GsmHspaLte:
                    serializer.Serialize(writer, "GSM / HSPA / LTE");
                    return;
                case NetworkTechnology.GsmLte:
                    serializer.Serialize(writer, "GSM / LTE");
                    return;
                case NetworkTechnology.GsmUmts:
                    serializer.Serialize(writer, "GSM / UMTS");
                    return;
                case NetworkTechnology.GsmUmtsHspa:
                    serializer.Serialize(writer, "GSM / UMTS / HSPA");
                    return;
                case NetworkTechnology.GsmUmtsLte:
                    serializer.Serialize(writer, "GSM / UMTS / LTE");
                    return;
                case NetworkTechnology.Hspa:
                    serializer.Serialize(writer, "HSPA");
                    return;
                case NetworkTechnology.HspaLte:
                    serializer.Serialize(writer, "HSPA / LTE");
                    return;
                case NetworkTechnology.Lte:
                    serializer.Serialize(writer, "LTE");
                    return;
                case NetworkTechnology.NoCellularConnectivity:
                    serializer.Serialize(writer, "No cellular connectivity");
                    return;
            }
            throw new Exception("Cannot marshal type NetworkTechnology");
        }

        public static readonly NetworkTechnologyConverter Singleton = new NetworkTechnologyConverter();
    }

    internal class SelfieCameraUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SelfieCameraUnion) || t == typeof(SelfieCameraUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "":
                            return new SelfieCameraUnion { Enum = Enum.Empty };
                        case "CIF":
                            return new SelfieCameraUnion { Enum = Enum.Cif };
                        case "CIF videocall camera":
                            return new SelfieCameraUnion { Enum = Enum.CifVideocallCamera };
                        case "HD":
                            return new SelfieCameraUnion { Enum = Enum.Hd };
                        case "No":
                            return new SelfieCameraUnion { Enum = Enum.No };
                        case "No - uses main camera":
                            return new SelfieCameraUnion { Enum = Enum.NoUsesMainCamera };
                        case "VGA":
                            return new SelfieCameraUnion { Enum = Enum.Vga };
                        case "Videocall camera":
                            return new SelfieCameraUnion { Enum = Enum.VideocallCamera };
                        case "Videocall, via SW update":
                            return new SelfieCameraUnion { Enum = Enum.VideocallViaSwUpdate };
                        case "Yes":
                            return new SelfieCameraUnion { Enum = Enum.Yes };
                    }
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return new SelfieCameraUnion { Integer = l };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type SelfieCameraUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (SelfieCameraUnion)untypedValue;
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case Enum.Empty:
                        serializer.Serialize(writer, "");
                        return;
                    case Enum.Cif:
                        serializer.Serialize(writer, "CIF");
                        return;
                    case Enum.CifVideocallCamera:
                        serializer.Serialize(writer, "CIF videocall camera");
                        return;
                    case Enum.Hd:
                        serializer.Serialize(writer, "HD");
                        return;
                    case Enum.No:
                        serializer.Serialize(writer, "No");
                        return;
                    case Enum.NoUsesMainCamera:
                        serializer.Serialize(writer, "No - uses main camera");
                        return;
                    case Enum.Vga:
                        serializer.Serialize(writer, "VGA");
                        return;
                    case Enum.VideocallCamera:
                        serializer.Serialize(writer, "Videocall camera");
                        return;
                    case Enum.VideocallViaSwUpdate:
                        serializer.Serialize(writer, "Videocall, via SW update");
                        return;
                    case Enum.Yes:
                        serializer.Serialize(writer, "Yes");
                        return;
                }
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            throw new Exception("Cannot marshal type SelfieCameraUnion");
        }

        public static readonly SelfieCameraUnionConverter Singleton = new SelfieCameraUnionConverter();
    }

    internal class SelfieCameraVideoConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SelfieCameraVideo) || t == typeof(SelfieCameraVideo?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return SelfieCameraVideo.Empty;
                case "1080p":
                    return SelfieCameraVideo.The1080P;
                case "1080p (gyro-EIS)":
                    return SelfieCameraVideo.The1080PGyroEis;
                case "1080p@25fps":
                    return SelfieCameraVideo.The1080P25Fps;
                case "1080p@30/60fps":
                    return SelfieCameraVideo.The1080P3060Fps;
                case "1080p@30fps":
                    return SelfieCameraVideo.The1080P30Fps;
                case "1080p@30fps (5-axis gyro-EIS)":
                    return SelfieCameraVideo.The1080P30Fps5AxisGyroEis;
                case "1080p@30fps (gyro-EIS)":
                    return SelfieCameraVideo.The1080P30FpsGyroEis;
                case "1080p@30fps, (gyro-EIS)":
                    return SelfieCameraVideo.Video1080P30FpsGyroEis;
                case "1080p@30fps, 480p@120fps":
                    return SelfieCameraVideo.The1080P30Fps480P120Fps;
                case "1080p@30ps":
                    return SelfieCameraVideo.The1080P30Ps;
                case "1080p@60fps":
                    return SelfieCameraVideo.The1080P60Fps;
                case "1440p":
                    return SelfieCameraVideo.The1440P;
                case "1440p@30fps":
                    return SelfieCameraVideo.The1440P30Fps;
                case "2160p":
                    return SelfieCameraVideo.The2160P;
                case "2160p@30fps":
                    return SelfieCameraVideo.The2160P30Fps;
                case "2160p@30fps, 1080p@30fps":
                    return SelfieCameraVideo.The2160P30Fps1080P30Fps;
                case "320p":
                    return SelfieCameraVideo.The320P;
                case "480p":
                    return SelfieCameraVideo.The480P;
                case "480p@30fps":
                    return SelfieCameraVideo.The480P30Fps;
                case "720p":
                    return SelfieCameraVideo.The720P;
                case "720p@30fps":
                    return SelfieCameraVideo.The720P30Fps;
                case "QVGA@15fps":
                    return SelfieCameraVideo.Qvga15Fps;
                case "VGA@15fps":
                    return SelfieCameraVideo.Vga15Fps;
                case "VGA@30fps":
                    return SelfieCameraVideo.Vga30Fps;
            }
            throw new Exception("Cannot unmarshal type SelfieCameraVideo");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SelfieCameraVideo)untypedValue;
            switch (value)
            {
                case SelfieCameraVideo.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case SelfieCameraVideo.The1080P:
                    serializer.Serialize(writer, "1080p");
                    return;
                case SelfieCameraVideo.The1080PGyroEis:
                    serializer.Serialize(writer, "1080p (gyro-EIS)");
                    return;
                case SelfieCameraVideo.The1080P25Fps:
                    serializer.Serialize(writer, "1080p@25fps");
                    return;
                case SelfieCameraVideo.The1080P3060Fps:
                    serializer.Serialize(writer, "1080p@30/60fps");
                    return;
                case SelfieCameraVideo.The1080P30Fps:
                    serializer.Serialize(writer, "1080p@30fps");
                    return;
                case SelfieCameraVideo.The1080P30Fps5AxisGyroEis:
                    serializer.Serialize(writer, "1080p@30fps (5-axis gyro-EIS)");
                    return;
                case SelfieCameraVideo.The1080P30FpsGyroEis:
                    serializer.Serialize(writer, "1080p@30fps (gyro-EIS)");
                    return;
                case SelfieCameraVideo.Video1080P30FpsGyroEis:
                    serializer.Serialize(writer, "1080p@30fps, (gyro-EIS)");
                    return;
                case SelfieCameraVideo.The1080P30Fps480P120Fps:
                    serializer.Serialize(writer, "1080p@30fps, 480p@120fps");
                    return;
                case SelfieCameraVideo.The1080P30Ps:
                    serializer.Serialize(writer, "1080p@30ps");
                    return;
                case SelfieCameraVideo.The1080P60Fps:
                    serializer.Serialize(writer, "1080p@60fps");
                    return;
                case SelfieCameraVideo.The1440P:
                    serializer.Serialize(writer, "1440p");
                    return;
                case SelfieCameraVideo.The1440P30Fps:
                    serializer.Serialize(writer, "1440p@30fps");
                    return;
                case SelfieCameraVideo.The2160P:
                    serializer.Serialize(writer, "2160p");
                    return;
                case SelfieCameraVideo.The2160P30Fps:
                    serializer.Serialize(writer, "2160p@30fps");
                    return;
                case SelfieCameraVideo.The2160P30Fps1080P30Fps:
                    serializer.Serialize(writer, "2160p@30fps, 1080p@30fps");
                    return;
                case SelfieCameraVideo.The320P:
                    serializer.Serialize(writer, "320p");
                    return;
                case SelfieCameraVideo.The480P:
                    serializer.Serialize(writer, "480p");
                    return;
                case SelfieCameraVideo.The480P30Fps:
                    serializer.Serialize(writer, "480p@30fps");
                    return;
                case SelfieCameraVideo.The720P:
                    serializer.Serialize(writer, "720p");
                    return;
                case SelfieCameraVideo.The720P30Fps:
                    serializer.Serialize(writer, "720p@30fps");
                    return;
                case SelfieCameraVideo.Qvga15Fps:
                    serializer.Serialize(writer, "QVGA@15fps");
                    return;
                case SelfieCameraVideo.Vga15Fps:
                    serializer.Serialize(writer, "VGA@15fps");
                    return;
                case SelfieCameraVideo.Vga30Fps:
                    serializer.Serialize(writer, "VGA@30fps");
                    return;
            }
            throw new Exception("Cannot marshal type SelfieCameraVideo");
        }

        public static readonly SelfieCameraVideoConverter Singleton = new SelfieCameraVideoConverter();
    }

    internal class The35MmJackConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(The3_5MmJack) || t == typeof(The3_5MmJack?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "No":
                    return The3_5MmJack.No;
                case "No, included adaptor for 3.5mm":
                    return The3_5MmJack.NoIncludedAdaptorFor35Mm;
                case "TBD":
                    return The3_5MmJack.Tbd;
                case "To be confirmed":
                    return The3_5MmJack.ToBeConfirmed;
                case "Yes":
                    return The3_5MmJack.Yes;
                case "nO":
                    return The3_5MmJack.NO;
            }
            throw new Exception("Cannot unmarshal type The3_5MmJack");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (The3_5MmJack)untypedValue;
            switch (value)
            {
                case The3_5MmJack.No:
                    serializer.Serialize(writer, "No");
                    return;
                case The3_5MmJack.NoIncludedAdaptorFor35Mm:
                    serializer.Serialize(writer, "No, included adaptor for 3.5mm");
                    return;
                case The3_5MmJack.Tbd:
                    serializer.Serialize(writer, "TBD");
                    return;
                case The3_5MmJack.ToBeConfirmed:
                    serializer.Serialize(writer, "To be confirmed");
                    return;
                case The3_5MmJack.Yes:
                    serializer.Serialize(writer, "Yes");
                    return;
                case The3_5MmJack.NO:
                    serializer.Serialize(writer, "nO");
                    return;
            }
            throw new Exception("Cannot marshal type The3_5MmJack");
        }

        public static readonly The35MmJackConverter Singleton = new The35MmJackConverter();
    }

    internal class LoudspeakerConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Loudspeaker) || t == typeof(Loudspeaker?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "No":
                    return Loudspeaker.No;
                case "Yes":
                    return Loudspeaker.Yes;
                case "Yes, 2.1 Stereo Surround Sound (2 tweeters + 1 bass loudspeaker)":
                    return Loudspeaker.Yes21StereoSurroundSound2Tweeters1BassLoudspeaker;
                case "Yes, built-in amplifier":
                    return Loudspeaker.YesBuiltInAmplifier;
                case "Yes, dual mono speakers":
                    return Loudspeaker.YesDualMonoSpeakers;
                case "Yes, dual speakers":
                    return Loudspeaker.YesDualSpeakers;
                case "Yes, with Dolby Atmos stereo speakers":
                    return Loudspeaker.YesWithDolbyAtmosStereoSpeakers;
                case "Yes, with Dolby Atmos stereo speakers (THX-certified amplifiers)":
                    return Loudspeaker.YesWithDolbyAtmosStereoSpeakersThxCertifiedAmplifiers;
                case "Yes, with dual speakers":
                    return Loudspeaker.YesWithDualSpeakers;
                case "Yes, with four speakers":
                    return Loudspeaker.YesWithFourSpeakers;
                case "Yes, with front stereo speakers":
                    return Loudspeaker.YesWithFrontStereoSpeakers;
                case "Yes, with multiple speakers":
                    return Loudspeaker.YesWithMultipleSpeakers;
                case "Yes, with quad speakers":
                    return Loudspeaker.YesWithQuadSpeakers;
                case "Yes, with stereo speakers":
                    return Loudspeaker.YesWithStereoSpeakers;
                case "Yes, with stereo speakers (1.5 Watt)":
                    return Loudspeaker.YesWithStereoSpeakers15Watt;
                case "Yes, with stereo speakers (16 mm, 22 Khz with vibration)":
                    return Loudspeaker.YesWithStereoSpeakers16Mm22KhzWithVibration;
                case "Yes, with stereo speakers (22 Khz with vibration)":
                    return Loudspeaker.YesWithStereoSpeakers22KhzWithVibration;
                case "Yes, with stereo speakers (3G models only)":
                    return Loudspeaker.YesWithStereoSpeakers3GModelsOnly;
                case "Yes, with stereo speakers (4 speakers)":
                    return Loudspeaker.YesWithStereoSpeakers4Speakers;
                case "Yes, with stereo speakers (Bang&Olufsen)":
                    return Loudspeaker.YesWithStereoSpeakersBangOlufsen;
            }
            throw new Exception("Cannot unmarshal type Loudspeaker");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Loudspeaker)untypedValue;
            switch (value)
            {
                case Loudspeaker.No:
                    serializer.Serialize(writer, "No");
                    return;
                case Loudspeaker.Yes:
                    serializer.Serialize(writer, "Yes");
                    return;
                case Loudspeaker.Yes21StereoSurroundSound2Tweeters1BassLoudspeaker:
                    serializer.Serialize(writer, "Yes, 2.1 Stereo Surround Sound (2 tweeters + 1 bass loudspeaker)");
                    return;
                case Loudspeaker.YesBuiltInAmplifier:
                    serializer.Serialize(writer, "Yes, built-in amplifier");
                    return;
                case Loudspeaker.YesDualMonoSpeakers:
                    serializer.Serialize(writer, "Yes, dual mono speakers");
                    return;
                case Loudspeaker.YesDualSpeakers:
                    serializer.Serialize(writer, "Yes, dual speakers");
                    return;
                case Loudspeaker.YesWithDolbyAtmosStereoSpeakers:
                    serializer.Serialize(writer, "Yes, with Dolby Atmos stereo speakers");
                    return;
                case Loudspeaker.YesWithDolbyAtmosStereoSpeakersThxCertifiedAmplifiers:
                    serializer.Serialize(writer, "Yes, with Dolby Atmos stereo speakers (THX-certified amplifiers)");
                    return;
                case Loudspeaker.YesWithDualSpeakers:
                    serializer.Serialize(writer, "Yes, with dual speakers");
                    return;
                case Loudspeaker.YesWithFourSpeakers:
                    serializer.Serialize(writer, "Yes, with four speakers");
                    return;
                case Loudspeaker.YesWithFrontStereoSpeakers:
                    serializer.Serialize(writer, "Yes, with front stereo speakers");
                    return;
                case Loudspeaker.YesWithMultipleSpeakers:
                    serializer.Serialize(writer, "Yes, with multiple speakers");
                    return;
                case Loudspeaker.YesWithQuadSpeakers:
                    serializer.Serialize(writer, "Yes, with quad speakers");
                    return;
                case Loudspeaker.YesWithStereoSpeakers:
                    serializer.Serialize(writer, "Yes, with stereo speakers");
                    return;
                case Loudspeaker.YesWithStereoSpeakers15Watt:
                    serializer.Serialize(writer, "Yes, with stereo speakers (1.5 Watt)");
                    return;
                case Loudspeaker.YesWithStereoSpeakers16Mm22KhzWithVibration:
                    serializer.Serialize(writer, "Yes, with stereo speakers (16 mm, 22 Khz with vibration)");
                    return;
                case Loudspeaker.YesWithStereoSpeakers22KhzWithVibration:
                    serializer.Serialize(writer, "Yes, with stereo speakers (22 Khz with vibration)");
                    return;
                case Loudspeaker.YesWithStereoSpeakers3GModelsOnly:
                    serializer.Serialize(writer, "Yes, with stereo speakers (3G models only)");
                    return;
                case Loudspeaker.YesWithStereoSpeakers4Speakers:
                    serializer.Serialize(writer, "Yes, with stereo speakers (4 speakers)");
                    return;
                case Loudspeaker.YesWithStereoSpeakersBangOlufsen:
                    serializer.Serialize(writer, "Yes, with stereo speakers (Bang&Olufsen)");
                    return;
            }
            throw new Exception("Cannot marshal type Loudspeaker");
        }

        public static readonly LoudspeakerConverter Singleton = new LoudspeakerConverter();
    }

    internal class CameraEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CameraEnum) || t == typeof(CameraEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Photo":
                    return CameraEnum.Photo;
                case "Photo / Video":
                    return CameraEnum.PhotoVideo;
                case "Video":
                    return CameraEnum.Video;
            }
            throw new Exception("Cannot unmarshal type CameraEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CameraEnum)untypedValue;
            switch (value)
            {
                case CameraEnum.Photo:
                    serializer.Serialize(writer, "Photo");
                    return;
                case CameraEnum.PhotoVideo:
                    serializer.Serialize(writer, "Photo / Video");
                    return;
                case CameraEnum.Video:
                    serializer.Serialize(writer, "Video");
                    return;
            }
            throw new Exception("Cannot marshal type CameraEnum");
        }

        public static readonly CameraEnumConverter Singleton = new CameraEnumConverter();
    }

    internal class DeviceTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DeviceType) || t == typeof(DeviceType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Phone":
                    return DeviceType.Phone;
                case "Tablet":
                    return DeviceType.Tablet;
            }
            throw new Exception("Cannot unmarshal type DeviceType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DeviceType)untypedValue;
            switch (value)
            {
                case DeviceType.Phone:
                    serializer.Serialize(writer, "Phone");
                    return;
                case DeviceType.Tablet:
                    serializer.Serialize(writer, "Tablet");
                    return;
            }
            throw new Exception("Cannot marshal type DeviceType");
        }

        public static readonly DeviceTypeConverter Singleton = new DeviceTypeConverter();
    }

    internal class BatteryTechnologyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BatteryTechnology) || t == typeof(BatteryTechnology?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Li-Ion":
                    return BatteryTechnology.LiIon;
                case "Li-Po":
                    return BatteryTechnology.LiPo;
                case "NiMH":
                    return BatteryTechnology.NiMh;
            }
            throw new Exception("Cannot unmarshal type BatteryTechnology");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BatteryTechnology)untypedValue;
            switch (value)
            {
                case BatteryTechnology.LiIon:
                    serializer.Serialize(writer, "Li-Ion");
                    return;
                case BatteryTechnology.LiPo:
                    serializer.Serialize(writer, "Li-Po");
                    return;
                case BatteryTechnology.NiMh:
                    serializer.Serialize(writer, "NiMH");
                    return;
            }
            throw new Exception("Cannot marshal type BatteryTechnology");
        }

        public static readonly BatteryTechnologyConverter Singleton = new BatteryTechnologyConverter();
    }

    internal class PhotoConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Photo) || t == typeof(Photo?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "0.1MP":
                    return Photo.The01Mp;
                case "0.3MP":
                    return Photo.The03Mp;
                case "0.5MP":
                    return Photo.The05Mp;
                case "0.8MP":
                    return Photo.The08Mp;
                case "0.9MP":
                    return Photo.The09Mp;
                case "1.2MP":
                    return Photo.Photo12Mp;
                case "1.3MP":
                    return Photo.Photo13Mp;
                case "1.9MP":
                    return Photo.The19Mp;
                case "10MP":
                    return Photo.The10Mp;
                case "12MP":
                    return Photo.The12Mp;
                case "13MP":
                    return Photo.The13Mp;
                case "16MP":
                    return Photo.The16Mp;
                case "18MP":
                    return Photo.The18Mp;
                case "19MP":
                    return Photo.Photo19Mp;
                case "1MP":
                    return Photo.The1Mp;
                case "2.1MP":
                    return Photo.Photo21Mp;
                case "2.2MP":
                    return Photo.Photo22Mp;
                case "20MP":
                    return Photo.The20Mp;
                case "21MP":
                    return Photo.The21Mp;
                case "22.5MP":
                    return Photo.The225Mp;
                case "22MP":
                    return Photo.The22Mp;
                case "23MP":
                    return Photo.The23Mp;
                case "24MP":
                    return Photo.The24Mp;
                case "2MP":
                    return Photo.The2Mp;
                case "3MP":
                    return Photo.The3Mp;
                case "40MP":
                    return Photo.The40Mp;
                case "41MP":
                    return Photo.The41Mp;
                case "48MP":
                    return Photo.The48Mp;
                case "4MP":
                    return Photo.The4Mp;
                case "5MP":
                    return Photo.The5Mp;
                case "6.7MP":
                    return Photo.The67Mp;
                case "8MP":
                    return Photo.The8Mp;
                case "NO":
                    return Photo.No;
            }
            throw new Exception("Cannot unmarshal type Photo");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Photo)untypedValue;
            switch (value)
            {
                case Photo.The01Mp:
                    serializer.Serialize(writer, "0.1MP");
                    return;
                case Photo.The03Mp:
                    serializer.Serialize(writer, "0.3MP");
                    return;
                case Photo.The05Mp:
                    serializer.Serialize(writer, "0.5MP");
                    return;
                case Photo.The08Mp:
                    serializer.Serialize(writer, "0.8MP");
                    return;
                case Photo.The09Mp:
                    serializer.Serialize(writer, "0.9MP");
                    return;
                case Photo.Photo12Mp:
                    serializer.Serialize(writer, "1.2MP");
                    return;
                case Photo.Photo13Mp:
                    serializer.Serialize(writer, "1.3MP");
                    return;
                case Photo.The19Mp:
                    serializer.Serialize(writer, "1.9MP");
                    return;
                case Photo.The10Mp:
                    serializer.Serialize(writer, "10MP");
                    return;
                case Photo.The12Mp:
                    serializer.Serialize(writer, "12MP");
                    return;
                case Photo.The13Mp:
                    serializer.Serialize(writer, "13MP");
                    return;
                case Photo.The16Mp:
                    serializer.Serialize(writer, "16MP");
                    return;
                case Photo.The18Mp:
                    serializer.Serialize(writer, "18MP");
                    return;
                case Photo.Photo19Mp:
                    serializer.Serialize(writer, "19MP");
                    return;
                case Photo.The1Mp:
                    serializer.Serialize(writer, "1MP");
                    return;
                case Photo.Photo21Mp:
                    serializer.Serialize(writer, "2.1MP");
                    return;
                case Photo.Photo22Mp:
                    serializer.Serialize(writer, "2.2MP");
                    return;
                case Photo.The20Mp:
                    serializer.Serialize(writer, "20MP");
                    return;
                case Photo.The21Mp:
                    serializer.Serialize(writer, "21MP");
                    return;
                case Photo.The225Mp:
                    serializer.Serialize(writer, "22.5MP");
                    return;
                case Photo.The22Mp:
                    serializer.Serialize(writer, "22MP");
                    return;
                case Photo.The23Mp:
                    serializer.Serialize(writer, "23MP");
                    return;
                case Photo.The24Mp:
                    serializer.Serialize(writer, "24MP");
                    return;
                case Photo.The2Mp:
                    serializer.Serialize(writer, "2MP");
                    return;
                case Photo.The3Mp:
                    serializer.Serialize(writer, "3MP");
                    return;
                case Photo.The40Mp:
                    serializer.Serialize(writer, "40MP");
                    return;
                case Photo.The41Mp:
                    serializer.Serialize(writer, "41MP");
                    return;
                case Photo.The48Mp:
                    serializer.Serialize(writer, "48MP");
                    return;
                case Photo.The4Mp:
                    serializer.Serialize(writer, "4MP");
                    return;
                case Photo.The5Mp:
                    serializer.Serialize(writer, "5MP");
                    return;
                case Photo.The67Mp:
                    serializer.Serialize(writer, "6.7MP");
                    return;
                case Photo.The8Mp:
                    serializer.Serialize(writer, "8MP");
                    return;
                case Photo.No:
                    serializer.Serialize(writer, "NO");
                    return;
            }
            throw new Exception("Cannot marshal type Photo");
        }

        public static readonly PhotoConverter Singleton = new PhotoConverter();
    }

    internal class CameraVideoConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CameraVideo) || t == typeof(CameraVideo?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "1080p":
                    return CameraVideo.The1080P;
                case "120p":
                    return CameraVideo.The120P;
                case "128p":
                    return CameraVideo.The128P;
                case "1440p":
                    return CameraVideo.The1440P;
                case "144p":
                    return CameraVideo.The144P;
                case "160p":
                    return CameraVideo.The160P;
                case "180p":
                    return CameraVideo.The180P;
                case "2160p":
                    return CameraVideo.The2160P;
                case "240p":
                    return CameraVideo.The240P;
                case "288p":
                    return CameraVideo.The288P;
                case "300000p":
                    return CameraVideo.The300000P;
                case "320p":
                    return CameraVideo.The320P;
                case "448p":
                    return CameraVideo.The448P;
                case "480p":
                    return CameraVideo.The480P;
                case "600p":
                    return CameraVideo.The600P;
                case "720p":
                    return CameraVideo.The720P;
                case "96p":
                    return CameraVideo.The96P;
                case "No video recorder":
                    return CameraVideo.NoVideoRecorder;
                case "Video recorder":
                    return CameraVideo.VideoRecorder;
            }
            throw new Exception("Cannot unmarshal type CameraVideo");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CameraVideo)untypedValue;
            switch (value)
            {
                case CameraVideo.The1080P:
                    serializer.Serialize(writer, "1080p");
                    return;
                case CameraVideo.The120P:
                    serializer.Serialize(writer, "120p");
                    return;
                case CameraVideo.The128P:
                    serializer.Serialize(writer, "128p");
                    return;
                case CameraVideo.The1440P:
                    serializer.Serialize(writer, "1440p");
                    return;
                case CameraVideo.The144P:
                    serializer.Serialize(writer, "144p");
                    return;
                case CameraVideo.The160P:
                    serializer.Serialize(writer, "160p");
                    return;
                case CameraVideo.The180P:
                    serializer.Serialize(writer, "180p");
                    return;
                case CameraVideo.The2160P:
                    serializer.Serialize(writer, "2160p");
                    return;
                case CameraVideo.The240P:
                    serializer.Serialize(writer, "240p");
                    return;
                case CameraVideo.The288P:
                    serializer.Serialize(writer, "288p");
                    return;
                case CameraVideo.The300000P:
                    serializer.Serialize(writer, "300000p");
                    return;
                case CameraVideo.The320P:
                    serializer.Serialize(writer, "320p");
                    return;
                case CameraVideo.The448P:
                    serializer.Serialize(writer, "448p");
                    return;
                case CameraVideo.The480P:
                    serializer.Serialize(writer, "480p");
                    return;
                case CameraVideo.The600P:
                    serializer.Serialize(writer, "600p");
                    return;
                case CameraVideo.The720P:
                    serializer.Serialize(writer, "720p");
                    return;
                case CameraVideo.The96P:
                    serializer.Serialize(writer, "96p");
                    return;
                case CameraVideo.NoVideoRecorder:
                    serializer.Serialize(writer, "No video recorder");
                    return;
                case CameraVideo.VideoRecorder:
                    serializer.Serialize(writer, "Video recorder");
                    return;
            }
            throw new Exception("Cannot marshal type CameraVideo");
        }

        public static readonly CameraVideoConverter Singleton = new CameraVideoConverter();
    }

    internal class RamConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Ram) || t == typeof(Ram?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "1.5GB RAM":
                    return Ram.The15GbRam;
                case "10GB RAM":
                    return Ram.The10GbRam;
                case "128MB RAM":
                    return Ram.The128MbRam;
                case "12GB RAM":
                    return Ram.The12GbRam;
                case "140MB RAM":
                    return Ram.The140MbRam;
                case "150MB RAM":
                    return Ram.The150MbRam;
                case "156MB RAM":
                    return Ram.The156MbRam;
                case "168MB RAM":
                    return Ram.The168MbRam;
                case "16MB RAM":
                    return Ram.The16MbRam;
                case "192MB RAM":
                    return Ram.The192MbRam;
                case "1GB RAM":
                    return Ram.The1GbRam;
                case "24MB RAM":
                    return Ram.The24MbRam;
                case "256MB RAM":
                    return Ram.The256MbRam;
                case "270MB RAM":
                    return Ram.The270MbRam;
                case "278MB RAM":
                    return Ram.The278MbRam;
                case "288MB RAM":
                    return Ram.The288MbRam;
                case "290MB RAM":
                    return Ram.The290MbRam;
                case "2GB RAM":
                    return Ram.The2GbRam;
                case "2MB RAM":
                    return Ram.The2MbRam;
                case "30MB RAM":
                    return Ram.The30MbRam;
                case "32MB RAM":
                    return Ram.The32MbRam;
                case "336MB RAM":
                    return Ram.The336MbRam;
                case "384MB RAM":
                    return Ram.The384MbRam;
                case "3GB RAM":
                    return Ram.The3GbRam;
                case "448MB RAM":
                    return Ram.The448MbRam;
                case "478MB RAM":
                    return Ram.The478MbRam;
                case "4GB RAM":
                    return Ram.The4GbRam;
                case "4MB RAM":
                    return Ram.The4MbRam;
                case "50MB RAM":
                    return Ram.The50MbRam;
                case "512MB RAM":
                    return Ram.The512MbRam;
                case "521MB RAM":
                    return Ram.The521MbRam;
                case "576MB RAM":
                    return Ram.The576MbRam;
                case "592MB RAM":
                    return Ram.The592MbRam;
                case "600MB RAM":
                    return Ram.The600MbRam;
                case "60MB RAM":
                    return Ram.The60MbRam;
                case "640MB RAM":
                    return Ram.The640MbRam;
                case "64MB RAM":
                    return Ram.The64MbRam;
                case "6GB RAM":
                    return Ram.The6GbRam;
                case "70MB RAM":
                    return Ram.The70MbRam;
                case "768MB RAM":
                    return Ram.The768MbRam;
                case "8GB RAM":
                    return Ram.The8GbRam;
                case "8MB RAM":
                    return Ram.The8MbRam;
                case "96MB RAM":
                    return Ram.The96MbRam;
            }
            throw new Exception("Cannot unmarshal type Ram");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Ram)untypedValue;
            switch (value)
            {
                case Ram.The15GbRam:
                    serializer.Serialize(writer, "1.5GB RAM");
                    return;
                case Ram.The10GbRam:
                    serializer.Serialize(writer, "10GB RAM");
                    return;
                case Ram.The128MbRam:
                    serializer.Serialize(writer, "128MB RAM");
                    return;
                case Ram.The12GbRam:
                    serializer.Serialize(writer, "12GB RAM");
                    return;
                case Ram.The140MbRam:
                    serializer.Serialize(writer, "140MB RAM");
                    return;
                case Ram.The150MbRam:
                    serializer.Serialize(writer, "150MB RAM");
                    return;
                case Ram.The156MbRam:
                    serializer.Serialize(writer, "156MB RAM");
                    return;
                case Ram.The168MbRam:
                    serializer.Serialize(writer, "168MB RAM");
                    return;
                case Ram.The16MbRam:
                    serializer.Serialize(writer, "16MB RAM");
                    return;
                case Ram.The192MbRam:
                    serializer.Serialize(writer, "192MB RAM");
                    return;
                case Ram.The1GbRam:
                    serializer.Serialize(writer, "1GB RAM");
                    return;
                case Ram.The24MbRam:
                    serializer.Serialize(writer, "24MB RAM");
                    return;
                case Ram.The256MbRam:
                    serializer.Serialize(writer, "256MB RAM");
                    return;
                case Ram.The270MbRam:
                    serializer.Serialize(writer, "270MB RAM");
                    return;
                case Ram.The278MbRam:
                    serializer.Serialize(writer, "278MB RAM");
                    return;
                case Ram.The288MbRam:
                    serializer.Serialize(writer, "288MB RAM");
                    return;
                case Ram.The290MbRam:
                    serializer.Serialize(writer, "290MB RAM");
                    return;
                case Ram.The2GbRam:
                    serializer.Serialize(writer, "2GB RAM");
                    return;
                case Ram.The2MbRam:
                    serializer.Serialize(writer, "2MB RAM");
                    return;
                case Ram.The30MbRam:
                    serializer.Serialize(writer, "30MB RAM");
                    return;
                case Ram.The32MbRam:
                    serializer.Serialize(writer, "32MB RAM");
                    return;
                case Ram.The336MbRam:
                    serializer.Serialize(writer, "336MB RAM");
                    return;
                case Ram.The384MbRam:
                    serializer.Serialize(writer, "384MB RAM");
                    return;
                case Ram.The3GbRam:
                    serializer.Serialize(writer, "3GB RAM");
                    return;
                case Ram.The448MbRam:
                    serializer.Serialize(writer, "448MB RAM");
                    return;
                case Ram.The478MbRam:
                    serializer.Serialize(writer, "478MB RAM");
                    return;
                case Ram.The4GbRam:
                    serializer.Serialize(writer, "4GB RAM");
                    return;
                case Ram.The4MbRam:
                    serializer.Serialize(writer, "4MB RAM");
                    return;
                case Ram.The50MbRam:
                    serializer.Serialize(writer, "50MB RAM");
                    return;
                case Ram.The512MbRam:
                    serializer.Serialize(writer, "512MB RAM");
                    return;
                case Ram.The521MbRam:
                    serializer.Serialize(writer, "521MB RAM");
                    return;
                case Ram.The576MbRam:
                    serializer.Serialize(writer, "576MB RAM");
                    return;
                case Ram.The592MbRam:
                    serializer.Serialize(writer, "592MB RAM");
                    return;
                case Ram.The600MbRam:
                    serializer.Serialize(writer, "600MB RAM");
                    return;
                case Ram.The60MbRam:
                    serializer.Serialize(writer, "60MB RAM");
                    return;
                case Ram.The640MbRam:
                    serializer.Serialize(writer, "640MB RAM");
                    return;
                case Ram.The64MbRam:
                    serializer.Serialize(writer, "64MB RAM");
                    return;
                case Ram.The6GbRam:
                    serializer.Serialize(writer, "6GB RAM");
                    return;
                case Ram.The70MbRam:
                    serializer.Serialize(writer, "70MB RAM");
                    return;
                case Ram.The768MbRam:
                    serializer.Serialize(writer, "768MB RAM");
                    return;
                case Ram.The8GbRam:
                    serializer.Serialize(writer, "8GB RAM");
                    return;
                case Ram.The8MbRam:
                    serializer.Serialize(writer, "8MB RAM");
                    return;
                case Ram.The96MbRam:
                    serializer.Serialize(writer, "96MB RAM");
                    return;
            }
            throw new Exception("Cannot marshal type Ram");
        }

        public static readonly RamConverter Singleton = new RamConverter();
    }
}