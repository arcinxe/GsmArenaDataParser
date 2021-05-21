using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ArktiPhones.Extensions;

namespace ArktiPhones
{
    public static class Converters
    {
        public class Resolution
        {
            public int? Width { get; set; }
            public int? Height { get; set; }
            public double? Megapixels
            {
                get
                {
                    if (Width != null && Height != null)
                        return (double)(Width * Height) / 1000000;
                    return null;
                }
            }
        }
        public static Resolution ConvertNameToResolution(string name)
        {
            var result = new Resolution();
            switch (name.ToLowerInvariant().Replace("p", ""))
            {
                case "cif":
                    result.Width = 352;
                    result.Height = 288;
                    break;

                case "qcif":
                    result.Width = 176;
                    result.Height = 144;
                    break;

                case "sqcif":
                    result.Width = 128;
                    result.Height = 96;
                    break;

                case "vga":
                    result.Width = 640;
                    result.Height = 480;
                    break;

                case "svga":
                    result.Width = 800;
                    result.Height = 600;
                    break;

                case "480":
                    result.Width = 640;
                    result.Height = 480;
                    break;

                case "720":
                    result.Width = 1280;
                    result.Height = 720;
                    break;

                case "1080":
                    result.Width = 1920;
                    result.Height = 1080;
                    break;
                case "2160":
                    result.Width = 3840;
                    result.Height = 2160;
                    break;

                default:
                    break;
            }
            return result;
        }

        public static Date ParseDate(string year, string monthOrQuarter)
        {
            int? resultYear = null;
            int? month = null;
            int? quarter = null;
            if (string.IsNullOrWhiteSpace(year + monthOrQuarter)) return new Date();
            resultYear = year.ToNullableInt();
            quarter = Regex.Replace(monthOrQuarter, @"[a-zA-Z ]", "").ToNullableInt();
            if (quarter == null)
            {
                switch (monthOrQuarter.ToLowerInvariant())
                {
                    case "january":
                        month = 1;
                        break;
                    case "february":
                    case "februray":
                    case "feburary":
                        month = 2;
                        break;
                    case "march":
                        month = 3;
                        break;
                    case "april":
                        month = 4;
                        break;
                    case "may":
                        month = 5;
                        break;
                    case "june":
                        month = 6;
                        break;
                    case "july":
                        month = 7;
                        break;
                    case "august":
                    case "aug":
                        month = 8;
                        break;
                    case "september":
                    case "sep":
                    case "septeber":
                        month = 9;
                        break;
                    case "october":
                    case "oct":
                        month = 10;
                        break;
                    case "november":
                    case "nov":
                        month = 11;
                        break;
                    case "december":
                        month = 12;
                        break;
                    default:
                        break;
                }
            }
            return new Date { Year = resultYear, Month = month, Quarter = quarter };
        }

        public static string FormatName(string name)
        {
            switch (name.ToLowerInvariant())
            {
                case "3-axis ois":
                    name = "3-axis OIS";
                    break;
                case "4-axis ois":
                    name = "4-axis OIS";
                    break;
                case "5-axis ois":
                    name = "5-axis OIS";
                    break;
                case "b/w":
                    name = "B/W";
                    break;
                case "b/w color":
                    name = "B/W color";
                    break;
                case "carl zeiss tessar optics":
                    name = "Carl Zeiss Tessar optics";
                    break;
                case "carl zeiss optics":
                    name = "Carl Zeiss optics";
                    break;
                case "hdr":
                    name = "HDR";
                    break;
                case "leica optics":
                    name = "Leica optics";
                    break;
                case "rgb":
                    name = "RGB";
                    break;
                case "rgb leds":
                    name = "RGB LEDs";
                    break;
                case "schneider kreuznach optics":
                    name = "Schneider Kreuznach optics";
                    break;
                case "schneider-kreuznach optics":
                    name = "Schneider-Kreuznach optics";
                    break;
                case "zeiss optics":
                    name = "Zeiss optics";
                    break;
                case "af":
                    name = "AF";
                    break;
                case "dual pixel pdaf":
                    name = "dual pixel PDAF";
                    break;
                case "dual video call":
                    name = "dual video call";
                    break;
                case "dual video recording":
                    name = "dual video recording";
                    break;
                case "dual-tone leds":
                    name = "dual-tone LEDs";
                    break;
                case "flir thermal camera":
                    name = "FLIR thermal camera";
                    break;
                case "gyro-eis":
                    name = "gyro-EIS";
                    break;
                case "laser af":
                    name = "laser AF";
                    break;
                case "motorized pop-up":
                    name = "motorized pop-up";
                    break;
                case "no af":
                    name = "no AF";
                    break;
                case "ois":
                    name = "OIS";
                    break;
                case "panorama":
                    name = "panorama";
                    break;
                case "pdaf":
                    name = "PDAF";
                    break;
                case "predictive dual pixel pdaf":
                    name = "predictive Dual Pixel PDAF";
                    break;
                case "predictive PDAF":
                    name = "predictive PDAF";
                    break;
                case "tof":
                    name = "ToF";
                    break;
                case "tof 3d":
                    name = "ToF 3d";
                    break;
                case "ultra wide lens":
                    name = "ultrawide lens";
                    break;
                default:
                    break;
            }
            return name;
        }
    }
}