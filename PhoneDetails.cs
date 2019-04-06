using System;
using System.Collections.Generic;

public class PhoneDetails
{
    public Basics Basics { get; set; }
    public Status Status { get; set; }
    public Battery Battery { get; set; }
    public Display Display { get; set; }
    public Communication Communication { get; set; }
    public Body Body { get; set; }
    public CameraInfo CameraInfo { get; set; }
    public Memory Memory { get; set; }
    public Price Price { get; set; }
    public OperatingSystem OperatingSystem { get; set; }
    public Cpu Cpu { get; set; }
    public Gpu Gpu { get; set; }

    public PhoneDetails()
    {
        Basics = new Basics();
        Status = new Status();
        Battery = new Battery();
        Display = new Display();
        Communication = new Communication();
        Communication.Usb = new Usb();
        Communication.Wlan = new Wlan();
        Communication.Gps = new Gps();
        Body = new Body();
        Body.Dimensions = new Dimensions();
        Body.Material = new Material();
        CameraInfo = new CameraInfo();
        Memory = new Memory();
        Price = new Price();
        OperatingSystem = new OperatingSystem();
        Cpu = new Cpu();
        Gpu = new Gpu();
    }
}
public class Basics
{
    public int PhoneId { get; set; }
    public string Slug { get; set; }
    public string Brand { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string DeviceType { get; set; }
}
public class Status
{
    public string CurrentStatus { get; set; }
    public Date AnnouncedDate { get; set; }
    public Date ReleasedDate { get; set; }
    public string DatesOriginalText { get; set; }
}
public class Display
{
    public int? ResolutionWidth { get; set; }
    public int? ResolutionHeight { get; set; }
    public int? ResolutionLines { get; set; }
    public double? PixelDensity { get; set; }
    public double? WidthRatio { get; set; }
    public double? HeightRatio { get; set; }
    public double? Diagonal { get; set; }
    public double? Area { get; set; }
    public double? ScreenToBodyRatio { get; set; }
    public string Type { get; set; }
    public string ColorMode { get; set; }
    public int? Colors { get; set; }
    public int? EffectiveColors { get; set; }
    public string Touchscreen { get; set; }
}
public class Body
{
    public Dimensions Dimensions { get; set; }
    public Material Material { get; set; }
    public double? Weight { get; set; }
    public List<string> Colors { get; set; }
}
public class Price
{
    public double? Value { get; set; }
    public string Currency { get; set; }
    public double? EstimatedInEuro { get; set; }
}
public class Memory
{
    public string CardType { get; set; }
    public int? CardMaxSize { get; set; }
    public int? Internal { get; set; }
    public int? ReadOnly { get; set; }
    public int? RandomAccess { get; set; }
}
public class CameraInfo
{
    public double? PhotoResolution { get; set; }
    public int? VideoResolution { get; set; }
    public List<VideoMode> VideoModes { get; set; }
    public List<string> VideoFeatures { get; set; }
    public int? FrontCameraLeds { get; set; }
    public int? RearCameraLeds { get; set; }
    public List<string> RearCameraFeatures { get; set; }
    public List<string> FrontCameraFeatures { get; set; }
    public List<Camera> Cameras { get; set; }
    public string CameraOriginalText { get; set; }
}
public class Camera
{
    public string Location { get; set; }
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

public class Battery
{
    public int? Capacity { get; set; }
    public string Technology { get; set; }
    public int? Endurance { get; set; }
}

public class Dimensions
{
    public double? Width { get; set; }
    public double? Height { get; set; }
    public double? Thickness { get; set; }
    public double? Volume { get; set; }
}

public class Material
{
    public string Front { get; set; }
    public string Back { get; set; }
    public string Frame { get; set; }
    public string Body { get; set; }
}

public class Communication
{
    public List<string> SimCards { get; set; }
    public Gps Gps { get; set; }
    public Usb Usb { get; set; }
    public Wlan Wlan { get; set; }
    public bool? AudioJack { get; set; }
    public string Bluetooth { get; set; }
    public bool Infrared { get; set; }
    public bool Nfc { get; set; }
    public List<string> Sensors { get; set; }
}
public class Gps{
    public bool? Available { get; set; }
    public List<string> Features { get; set; }
}
public class Usb
{
    public string Version { get; set; }
    public string Connector { get; set; }
    public List<string> Features { get; set; }
}

public class Wlan
{
    public bool? Available { get; set; }
    public List<string> Standards { get; set; }
    public List<string> Features { get; set; }
}

public class OperatingSystem
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string LatestVersion { get; set; }
    public string FlavorName { get; set; }
    public string FlavorVersion { get; set; }
}

public class Cpu
{
    public string Producer { get; set; }
    public string Name { get; set; }
    public string Series { get; set; }
    public string Model { get; set; }
    public int? Cores { get; set; }
}

public class Gpu
{
    public string Name { get; set; }
    public string Model { get; set; }
}