
// namespace ArktiPhones
// {
//     using System;
//     using System.Collections.Generic;

//     using System.Globalization;
//     using Newtonsoft.Json;
//     using Newtonsoft.Json.Converters;

//     public partial class PhonesApiModel
//     {
//         [JsonProperty("data")]
//         public Data Data { get; set; }

//         [JsonProperty("error")]
//         public object Error { get; set; }
//     }

//     public partial class Data
//     {
//         [JsonProperty("brand")]
//         public string Brand { get; set; }

//         [JsonProperty("device_name")]
//         public string DeviceName { get; set; }

//         [JsonProperty("device_type")]
//         public string DeviceType { get; set; }

//         [JsonProperty("image_url")]
//         public Uri ImageUrl { get; set; }

//         [JsonProperty("overview")]
//         public Overview Overview { get; set; }

//         [JsonProperty("detail")]
//         public Detail Detail { get; set; }
//     }

//     public partial class Detail
//     {
//         [JsonProperty("battery")]
//         public DetailBattery Battery { get; set; }

//         [JsonProperty("body")]
//         public Body Body { get; set; }

//         [JsonProperty("comms")]
//         public Comms Comms { get; set; }

//         [JsonProperty("display")]
//         public DetailDisplay Display { get; set; }

//         [JsonProperty("features")]
//         public Features Features { get; set; }

//         [JsonProperty("launch")]
//         public Launch Launch { get; set; }

//         [JsonProperty("main__camera")]
//         public MainCamera MainCamera { get; set; }

//         [JsonProperty("memory")]
//         public Memory Memory { get; set; }

//         [JsonProperty("misc")]
//         public Misc Misc { get; set; }

//         [JsonProperty("network")]
//         public Network Network { get; set; }

//         [JsonProperty("platform")]
//         public Platform Platform { get; set; }

//         [JsonProperty("selfie_camera")]
//         public SelfieCamera SelfieCamera { get; set; }

//         [JsonProperty("sound")]
//         public Sound Sound { get; set; }
//     }

//     public partial class DetailBattery
//     {
//         [JsonProperty("")]
//         public string Empty { get; set; }
//     }

//     public partial class Body
//     {
//         [JsonProperty("build")]
//         public string Build { get; set; }

//         [JsonProperty("dimensions")]
//         public string Dimensions { get; set; }

//         [JsonProperty("sim")]
//         public string Sim { get; set; }

//         [JsonProperty("weight")]
//         public string Weight { get; set; }
//     }

//     public partial class Comms
//     {
//         [JsonProperty("bluetooth")]
//         public string Bluetooth { get; set; }

//         [JsonProperty("gps")]
//         public string Gps { get; set; }

//         [JsonProperty("infrared_port")]
//         public string InfraredPort { get; set; }

//         [JsonProperty("radio")]
//         public string Radio { get; set; }

//         [JsonProperty("usb")]
//         public string Usb { get; set; }

//         [JsonProperty("wlan")]
//         public string Wlan { get; set; }
//     }

//     public partial class DetailDisplay
//     {
//         [JsonProperty("protection")]
//         public string Protection { get; set; }

//         [JsonProperty("resolution")]
//         public string Resolution { get; set; }

//         [JsonProperty("size")]
//         public string Size { get; set; }

//         [JsonProperty("type")]
//         public string Type { get; set; }
//     }

//     public partial class Features
//     {
//         [JsonProperty("")]
//         public string Empty { get; set; }

//         [JsonProperty("sensors")]
//         public string Sensors { get; set; }
//     }

//     public partial class Launch
//     {
//         [JsonProperty("announced")]
//         public string Announced { get; set; }

//         [JsonProperty("status")]
//         public string Status { get; set; }
//     }

//     public partial class MainCamera
//     {
//         [JsonProperty("dual")]
//         public string[] Dual { get; set; }

//         [JsonProperty("features")]
//         public string Features { get; set; }

//         [JsonProperty("video")]
//         public string Video { get; set; }
//     }

//     public partial class Memory
//     {
//         [JsonProperty("card_slot")]
//         public string CardSlot { get; set; }

//         [JsonProperty("internal")]
//         public string Internal { get; set; }
//     }

//     public partial class Misc
//     {
//         [JsonProperty("colors")]
//         public string Colors { get; set; }

//         [JsonProperty("price")]
//         public string Price { get; set; }

//         [JsonProperty("sar")]
//         public string[] Sar { get; set; }
//     }

//     public partial class Network
//     {
//         [JsonProperty("2g_bands")]
//         public string The2GBands { get; set; }

//         [JsonProperty("3g_bands")]
//         public string The3GBands { get; set; }

//         [JsonProperty("4g_bands")]
//         public string The4GBands { get; set; }

//         [JsonProperty("edge")]
//         public string Edge { get; set; }

//         [JsonProperty("gprs")]
//         public string Gprs { get; set; }

//         [JsonProperty("speed")]
//         public string Speed { get; set; }

//         [JsonProperty("technology")]
//         public string Technology { get; set; }
//     }

//     public partial class Platform
//     {
//         [JsonProperty("chipset")]
//         public string Chipset { get; set; }

//         [JsonProperty("cpu")]
//         public string Cpu { get; set; }

//         [JsonProperty("gpu")]
//         public string Gpu { get; set; }

//         [JsonProperty("os")]
//         public string Os { get; set; }
//     }

//     public partial class SelfieCamera
//     {
//         [JsonProperty("features")]
//         public string Features { get; set; }

//         [JsonProperty("single")]
//         public string Single { get; set; }

//         [JsonProperty("video")]
//         public string Video { get; set; }
//     }

//     public partial class Sound
//     {
//         [JsonProperty("")]
//         public string Empty { get; set; }

//         [JsonProperty("3_5mm_jack")]
//         public string The3_5MmJack { get; set; }

//         [JsonProperty("loudspeaker")]
//         public string Loudspeaker { get; set; }
//     }

//     public partial class Overview
//     {
//         [JsonProperty("general_info")]
//         public GeneralInfo GeneralInfo { get; set; }

//         [JsonProperty("display")]
//         public OverviewDisplay Display { get; set; }

//         [JsonProperty("camera")]
//         public Camera Camera { get; set; }

//         [JsonProperty("expansion")]
//         public Expansion Expansion { get; set; }

//         [JsonProperty("battery")]
//         public OverviewBattery Battery { get; set; }
//     }

//     public partial class OverviewBattery
//     {
//         [JsonProperty("capacity")]
//         public string Capacity { get; set; }

//         [JsonProperty("technology")]
//         public string Technology { get; set; }
//     }

//     public partial class Camera
//     {
//         [JsonProperty("photo")]
//         public string Photo { get; set; }

//         [JsonProperty("video")]
//         public string Video { get; set; }
//     }

//     public partial class OverviewDisplay
//     {
//         [JsonProperty("touchscreen")]
//         public string Touchscreen { get; set; }

//         [JsonProperty("size")]
//         public string Size { get; set; }

//         [JsonProperty("resolution")]
//         public string Resolution { get; set; }
//     }

//     public partial class Expansion
//     {
//         [JsonProperty("ram")]
//         public string Ram { get; set; }

//         [JsonProperty("chipset")]
//         public string Chipset { get; set; }
//     }

//     public partial class GeneralInfo
//     {
//         [JsonProperty("launched")]
//         public string Launched { get; set; }

//         [JsonProperty("body")]
//         public string Body { get; set; }

//         [JsonProperty("os")]
//         public string Os { get; set; }

//         [JsonProperty("storage")]
//         public string Storage { get; set; }
//     }

// }
