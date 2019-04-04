using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
    }
}