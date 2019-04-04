using System;
using System.Collections.Generic;

public class PhoneDetails
{
    public int PhoneId { get; set; }
    public string Slug { get; set; }
    public string Brand { get; set; }
    public string Name { get; set; }
    public Date AnnouncedDate { get; set; }
    public Date ReleasedDate { get; set; }
    public string DatesOriginalText { get; set; }
    public string Status { get; set; }
    public int? BatteryCapacity { get; set; }
    public string BatteryTechnology { get; set; }
    public int? BatteryEndurance { get; set; }
    public double? BodyWidth { get; set; }
    public double? BodyHeight { get; set; }
    public double? BodyThickness { get; set; }
    public double? BodyVolume { get; set; }
    public string MaterialFront { get; set; }
    public string MaterialBack { get; set; }
    public string MaterialFrame { get; set; }
    public string MaterialBody { get; set; }
    public List<string> SimCards { get; set; }
    public double? Weight { get; set; }
    public bool? Gps { get; set; }
    public List<string> GpsFeatures { get; set; }
    public string UsbVersion { get; set; }
    public string UsbConnector { get; set; }
    public List<string> UsbFeatures { get; set; }
    public bool? Wlan { get; set; }
    public List<string> WlanStandards { get; set; }
    public List<string> WlanFeatures { get; set; }
    public string Bluetooth { get; set; }
    public bool Infrared { get; set; }
    public bool Nfc { get; set; }
    public int? ResolutionWidth { get; set; }
    public int? ResolutionHeight { get; set; }
    public int? ResolutionLines { get; set; }
    public double? DisplayPixelDensity { get; set; }
    public double? WidthRatio { get; set; }
    public double? HeightRatio { get; set; }
    public double? DisplaySize { get; set; }
    public double? DisplayArea { get; set; }
    public double? ScreenToBodyRatio { get; set; }
    public string DisplayType { get; set; }
    public string DisplayColorMode { get; set; }
    public int? DisplayColors { get; set; }
    public int? DisplayEffectiveColors { get; set; }
    public string Touchscreen { get; set; }
    public double? PhotoResolution { get; set; }
    public int? VideoResolution { get; set; }
    public List<VideoMode> VideoModes { get; set; }
    public List<string> VideoFeatures { get; set; }
    public int? CameraLeds { get; set; }
    public List<string> CameraFeatures { get; set; }
    public List<string> Sensors { get; set; }
    public string MemoryCardType { get; set; }
    public int? MemoryCardMaxSize { get; set; }
    public int? MemoryInternal { get; set; }
    public int? MemoryReadOnly { get; set; }
    public int? RamInMb { get; set; }
    public List<string> Colors { get; set; }
    public double? EstimatedPriceInEuro { get; set; }
    public double? Price { get; set; }
    public string PriceCurrency { get; set; }
    public string OperatingSystemName { get; set; }
    public string OperatingSystemVersion { get; set; }
    public string OperatingSystemLatestVersion { get; set; }
    public string OperatingSystemFlavorName { get; set; }
    public string OperatingSystemFlavorVersion { get; set; }
    public string CpuProducer { get; set; }
    public string CpuName { get; set; }
    public string CpuSeries { get; set; }
    public string CpuModel { get; set; }
    public int? CpuCores { get; set; }
    public string GpuName { get; set; }
    public string GpuModel { get; set; }
    public bool? AudioJack { get; set; }
    public string DeviceType { get; set; }
    public string ImageUrl { get; set; }
    public string NetworkTechnology { get; set; }// WAITING
    public string NetworkSpeed { get; set; }// WAITING
    public List<Camera> Cameras { get; set; }
    public string CameraOriginalText { get; set; }
    public string Test { get; set; }
}

public class Camera
{
    public string Location { get; set; }// WAITING
    public double? Resolution { get; set; }
    public int? OpticalZoom { get; set; }
    public double? SensorSize { get; set; }  // 1/x.xx"
    public double? FocalLength { get; set; }  // x.xx mm
    public double? Aperture { get; set; }  // f/x.xx
    public List<string> Features { get; set; }
}

public class VideoMode
{
    public int? Width { get; set; }
    public int? Height { get; set; }
    public int? FrameRate { get; set; }
    public string CameraSide { get; set; }

}

public class Date
{
    public int? Year { get; set; }
    public int? Month { get; set; }
    public int? Quarter { get; set; }
}