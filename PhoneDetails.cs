using System;
using System.Collections.Generic;

public class PhoneDetails
{
    public int PhoneId { get; set; }
    public string Slug { get; set; }
    public string Brand { get; set; }
    public string Name { get; set; }
    public int? BatteryCapacity { get; set; }
    public string BatteryTechnology { get; set; }
    public int? BatteryEndurance { get; set; }
    public string BatteryStandby { get; set; }// WAITING
    public string BatteryTalk { get; set; }// WAITING
    public string BatteryMusic { get; set; }// WAITING
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
    public string Gps { get; set; }// WAITING
    public string UsbVersion { get; set; }
    public string UsbConnector { get; set; }
    public List<string> UsbFeatures { get; set; }
    public string Wlan { get; set; }// WAITING
    public string Bluetooth { get; set; }
    public bool Infrared { get; set; }
    public int? ResolutionWidth { get; set; }
    public int? ResolutionHeight { get; set; }
    public int? ResolutionLines { get; set; }
    public double? DisplayPixelDensity { get; set; }
    public double? WidthRatio { get; set; }
    public double? HeightRatio { get; set; }
    public double? DisplaySize { get; set; }
    public double? DisplayArea { get; set; }
    public double? ScreenToBodyRatio { get; set; }
    public string DisplayType { get; set; }// WAITING
    public string Sensors { get; set; }// WAITING
    public string Status { get; set; }// WAITING
    public string MemoryCard { get; set; }// WAITING
    public int? MemoryInternal { get; set; }// WAITING
    public int? MemoryReadOnly { get; set; }// WAITING
    public int? RamInMb { get; set; }
    public string Colors { get; set; }// WAITING
    public double? EstimatedPriceInEuro { get; set; }
    public double? Price { get; set; }
    public string PriceCurrency { get; set; }
    public string OperatingSystemName { get; set; }
    public string OperatingSystemVersion { get; set; }
    public string OperatingSystemLatestVersion { get; set; }
    public string OperatingSystemFlavorName { get; set; }
    public string OperatingSystemFlavorVersion { get; set; }
    public string ExpansionChipset { get; set; }// WAITING
    public string Chipset { get; set; }// WAITING
    public string Cpu { get; set; }// WAITING
    public string Gpu { get; set; }// WAITING
    public string AudioMiniJack { get; set; }// WAITING
    public string DeviceType { get; set; }
    public string ImageUrl { get; set; }
    public string NetworkTechnology { get; set; }// WAITING
    public string NetworkSpeed { get; set; }// WAITING
    public DateTime AnnouncedDate { get; set; }
    public DateTime ReleasedDate { get; set; }
    public string Test { get; set; }
}

class Camera
{
    public int CameraId { get; set; }// WAITING
    public int PhoneId { get; set; }// WAITING

    public string Type { get; set; }// WAITING
    public double? Resolution { get; set; }// WAITING
}