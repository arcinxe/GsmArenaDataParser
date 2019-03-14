using System;

public class PhoneDetails
{
    public int PhoneId { get; set; }
    public string Brand { get; set; }
    public string Name { get; set; }
    public int BatteryCapacity { get; set; }
    public string BatteryTechnology { get; set; }
    public string BatteryStandby { get; set; }
    public string BatteryTalk { get; set; }
    public string BatteryMusic { get; set; }
    public string BodyDimensions { get; set; }
    public string BodyBuild { get; set; }
    public string Sim { get; set; }
    public string Weight { get; set; }
    public string Gps { get; set; }
    public string Usb { get; set; }
    public string Wlan { get; set; }
    public string Bluetooth { get; set; }
    public string Infrared { get; set; }
    public string Resolution { get; set; }
    public string DisplaySize { get; set; }
    public string DisplayType { get; set; }
    public string Sensors { get; set; }
    public string Status { get; set; }
    public string MemoryCard { get; set; }
    public string MemoryInternal { get; set; }
    public string Ram { get; set; }
    public string ExpansionRam { get; set; }
    public string Colors { get; set; }
    public string Price { get; set; }
    public string OperatingSystem { get; set; }
    public string ExpansionChipset { get; set; }
    public string Chipset { get; set; }
    public string Cpu { get; set; }
    public string Gpu { get; set; }
    public string AudioMiniJack { get; set; }
    public string DeviceType { get; set; }
    public string ImageUrl { get; set; }
    public string NetworkTechnology { get; set; }
    public string NetworkSpeed { get; set; }
    public string InfoBody { get; set; }
    public string InfoLaunched { get; set; }
    public string InfoOs { get; set; }
    public string InfoStorage { get; set; }
    public string InfoTouch { get; set; }
    public string InfoDisplaySize { get; set; }
    public string InfoDisplayResolution { get; set; }
    public string InfoCameraPhoto { get; set; }
    public string InfoCameraVideo { get; set; }
    public DateTime AnnouncedDate { get; set; }
    public DateTime ReleasedDate { get; set; }
    public string  Test { get; set; }
}

class Camera
{
    public int CameraId { get; set; }
    public int PhoneId { get; set; }

    public string Type { get; set; }
    public double Resolution { get; set; }
}