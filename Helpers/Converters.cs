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
    }
}