using System;

public class PhoneDetails
{
    public int PhoneId { get; set; }
    public string Brand { get; set; }
    public string Name { get; set; }
    public int BatteryCapacity { get; set; }
    public string BatteryTechnology { get; set; }
    public string BatteryStandby { get; set; }// WAITING
    public string BatteryTalk { get; set; }// WAITING
    public string BatteryMusic { get; set; }// WAITING
    public string BodyDimensions { get; set; }// WAITING
    public string BodyBuild { get; set; }// WAITING
    public string Sim { get; set; }// WAITING
    public string Weight { get; set; }// WAITING
    public string Gps { get; set; }// WAITING
    public string Usb { get; set; }// WAITING
    public string Wlan { get; set; }// WAITING
    public string Bluetooth { get; set; }// WAITING
    public string Infrared { get; set; }// WAITING
    public string Resolution { get; set; }// WAITING
    public string DisplaySize { get; set; }// WAITING
    public string DisplayType { get; set; }// WAITING
    public string Sensors { get; set; }// WAITING
    public string Status { get; set; }// WAITING
    public string MemoryCard { get; set; }// WAITING
    public string MemoryInternal { get; set; }// WAITING
    public string Ram { get; set; }// WAITING
    public string ExpansionRam { get; set; }// WAITING
    public string Colors { get; set; }// WAITING
    public string Price { get; set; }// WAITING
    public string OperatingSystem { get; set; }// WAITING
    public string ExpansionChipset { get; set; }// WAITING
    public string Chipset { get; set; }// WAITING
    public string Cpu { get; set; }// WAITING
    public string Gpu { get; set; }// WAITING
    public string AudioMiniJack { get; set; }// WAITING
    public string DeviceType { get; set; }
    public string ImageUrl { get; set; }
    public string NetworkTechnology { get; set; }// WAITING
    public string NetworkSpeed { get; set; }// WAITING
    public string InfoBody { get; set; }// WAITING
    public string InfoLaunched { get; set; }// WAITING
    public string InfoOs { get; set; }// WAITING
    public string InfoStorage { get; set; }// WAITING
    public string InfoTouch { get; set; }// WAITING
    public string InfoDisplaySize { get; set; }// WAITING
    public string InfoDisplayResolution { get; set; }// WAITING
    public string InfoCameraPhoto { get; set; }// WAITING
    public string InfoCameraVideo { get; set; }// WAITING
    public DateTime AnnouncedDate { get; set; }
    public DateTime ReleasedDate { get; set; }
    public string  Test { get; set; }// WAITING
}

class Camera
{
    public int CameraId { get; set; }// WAITING
    public int PhoneId { get; set; }// WAITING

    public string Type { get; set; }// WAITING
    public double Resolution { get; set; }// WAITING
}