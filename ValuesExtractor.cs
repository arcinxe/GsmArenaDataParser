using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ArktiPhones.Extensions;

namespace ArktiPhones
{
    public class ValuesExtractor
    {
        private ArktiPhones.Data inputPhone { get; set; }
        public PhoneDetails resultPhone { get; set; }
        public ValuesExtractor(ArktiPhones.Data phone)
        {
            inputPhone = phone;
            resultPhone = new PhoneDetails();
            DoTheStuff();
        }

        public void DoTheStuff()
        {
            resultPhone.Basics.Name = inputPhone.DeviceName;
            resultPhone.Basics.PhoneId = inputPhone.PhoneId;
            resultPhone.Basics.Slug = inputPhone.Slug;
            resultPhone.Basics.ImageUrl = inputPhone.ImageUrl.ToString();
            resultPhone.Basics.Brand = inputPhone.Brand;
            resultPhone.Battery.Technology = inputPhone.Overview.Battery.Technology;
            Debug();
            SetDeviceType();
            SetComms();
            SetDates();
            SetScreenSize();
            SetBattery();
            SetRam();
            SetDisplayResolution();
            SetDisplayPixelDensityAndRatio();
            SetDimensions();
            SetWeight();
            SetBuildMaterials();
            SetSimCard();
            SetMemory();
            SetUsb();
            SetOs();
            SetPrice();
            SetColors();
            SetCameraResolution();
            SetGps();
            SetDisplay();
            SetStatus();
            SetSensors();
            SetAudioJack();
            SetWlan();
            SetCpu();
            SetGpu();
            SetCameraVideoModes();
            SetCameraFeatures();
            SetCameras();
        }

        private void SetCameras()
        {
            var cameras = new List<Camera>();
            resultPhone.CameraInfo.Cameras = cameras;

            var rearCamerasData = new List<string>();
            var frontCamerasData = new List<string>();
            var allCamerasData = new List<List<string>>();
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Single?.FirstOrDefault()))
                rearCamerasData = inputPhone.Detail.MainCamera?.Single;
            else if (!string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Dual?.FirstOrDefault()))
                rearCamerasData = inputPhone.Detail.MainCamera?.Dual;
            else if (!string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Triple?.FirstOrDefault()))
                rearCamerasData = inputPhone.Detail.MainCamera?.Triple;
            else if (!string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Quad?.FirstOrDefault()))
                rearCamerasData = inputPhone.Detail.MainCamera?.Quad;
            else if (!string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Five?.FirstOrDefault()))
                rearCamerasData = inputPhone.Detail.MainCamera?.Five;

            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.SelfieCamera?.Single?.FirstOrDefault()))
                frontCamerasData = inputPhone.Detail.SelfieCamera?.Single;
            else if (!string.IsNullOrWhiteSpace(inputPhone.Detail.SelfieCamera?.Dual?.FirstOrDefault()))
                frontCamerasData = inputPhone.Detail.SelfieCamera?.Dual;
            allCamerasData.Add(rearCamerasData);
            allCamerasData.Add(frontCamerasData);
            for (var k = 0; k < 2; k++)
            {
                if (allCamerasData.ElementAtOrDefault(k).Count == 0) continue;

                var rawCameras = string
                    .Join("|", allCamerasData.ElementAtOrDefault(k))
                    .Split("|or", StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault()
                    .Split('|')
                    .Select(v => v.Split(',').Select(sv => sv.Trim()));
                // if (inputPhone.Slug == "nokia_9_pureview-8867")
                //     System.Console.WriteLine();
                var additionalFeatures = new Dictionary<string, int?>();
                foreach (var rawCamera in rawCameras)
                {
                    double? megapixels = null;
                    int? zoom = null;
                    double? sensorSize = null;
                    double? focalLength = null;
                    double? aperture = null;
                    var camerasAmount = 1;
                    var features = new List<string>();
                    foreach (var value in rawCamera)
                    {
                        var match = Regex.Match(value, @"^(?:([sq]?vga|cif|yes))?(?:(?:(\d)x )?(?:motorized pop-up |cover camera: )?(\d+(?:\.\d*)?) mp)?(?: (b\/w))?(?:(\d+\.?\d*) ?mm?\b)?(?:\d\/(\d(?:\.\d+)?)""?)?(?: ?\((ultra ?wide|wide|standard|telephoto)\)?)?(?:(\d+\.?\d*)(?:x|kh) (?:optical|lossless)? ?zoom)?(?:f\/?(\d\.\d+))?", RegexOptions.IgnoreCase);
                        if (match.Groups[1].Success)
                            megapixels = Converters.ConvertNameToResolution(match.Groups[1].Value).Megapixels;
                        else if (match.Groups[3].Success)
                            megapixels = match.Groups[3].Value.ToNullableDouble();
                        else if (match.Groups[5].Success)
                            focalLength = match.Groups[5].Value.ToNullableDouble();
                        else if (match.Groups[6].Success)
                            sensorSize = match.Groups[6].Value.ToNullableDouble();
                        else if (match.Groups[8].Success)
                            zoom = match.Groups[8].Value.ToNullableInt();
                        else if (match.Groups[9].Success)
                            aperture = match.Groups[9].Value.ToNullableDouble();
                        if (match.Groups[4].Success)
                            features.Add($"{match.Groups[4].Value.ToUpperInvariant()} color");
                        if (match.Groups[7].Success)
                            features.Add($"{match.Groups[7].Value.ToLowerInvariant()} lens");
                        if (match.Groups[2].Success && int.TryParse(match.Groups[2].Value, out var result))
                            camerasAmount = result;

                        match = Regex.Match(value, @"^((?:predictive )?dual pixel pdaf|(?:no )?af|motorized pop-up|flir thermal camera|TOF 3D|tof|depth(?: & motion tracking)? sensors?|(?:\d-axis )?ois|pdaf|predictive pdaf|laser af|laser)?(?:(?: & |\/)?(laser af|pdaf))?(?:\(?(\d)x (?:(rgb|b\/w)) & (\d)x (?:(rgb|b\/w)))?", RegexOptions.IgnoreCase);
                        if (match.Groups[1].Success)
                            features.Add(match.Groups[1].Value.ToLowerInvariant());
                        if (match.Groups[2].Success)
                            features.Add(match.Groups[2].Value.ToLowerInvariant());
                        if (match.Groups[3].Success && match.Groups[4].Success && int.TryParse(match.Groups[3].Value, out result))
                            additionalFeatures.Add(match.Groups[4].Value.ToUpperInvariant(), match.Groups[3].Value.ToNullableInt());
                        if (match.Groups[5].Success && match.Groups[6].Success && int.TryParse(match.Groups[5].Value, out result))
                            additionalFeatures.Add(match.Groups[6].Value.ToUpperInvariant(), match.Groups[5].Value.ToNullableInt());

                    }


                    for (var i = 0; i < camerasAmount; i++)
                        if (aperture != null
                            || focalLength != null
                            || zoom != null
                            || sensorSize != null
                            || megapixels != null
                            || features.Count > 0)
                        {
                            var individualFeatures = new List<string>(features);
                            cameras.Add(new Camera
                            {
                                Aperture = aperture,
                                FocalLength = focalLength,
                                OpticalZoom = zoom,
                                SensorSize = sensorSize,
                                Resolution = megapixels,
                                Location = k == 0 ? "rear" : "front",
                                Features = individualFeatures
                            });
                        }

                }

                if (additionalFeatures.Count > 0 && cameras.Count >= additionalFeatures.Sum(f => f.Value))
                {
                    var position = 0;
                    for (var i = 0; i < additionalFeatures.Count; i++)
                    {
                        for (var j = 0; j < additionalFeatures.ElementAtOrDefault(i).Value; j++)
                        {
                            cameras.ElementAtOrDefault(position++).Features.Add(additionalFeatures.ElementAtOrDefault(i).Key);
                        }
                    }
                }
            }
        }
        private void SetCameraFeatures()
        {
            var allCamerasFeatures = new List<List<string>>();

            var rearCameraFeatures = new List<string>();
            var frontCameraFeatures = new List<string>();
            allCamerasFeatures.Add(rearCameraFeatures);
            allCamerasFeatures.Add(frontCameraFeatures);
            var rawFeatures = new List<string>();
            rawFeatures.Add(string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Features) ? "" : inputPhone.Detail.MainCamera.Features);
            rawFeatures.Add(string.IsNullOrWhiteSpace(inputPhone.Detail.SelfieCamera?.Features) ? "" : inputPhone.Detail.SelfieCamera.Features);

            var leds = new List<int?>(2) { null, null };
            for (var i = 0; i < 2; i++)
            {
                if (!string.IsNullOrWhiteSpace(rawFeatures.ElementAtOrDefault(i)))
                {
                    foreach (var value in rawFeatures.ElementAtOrDefault(i).Split(',').Select(f => f.Trim()))
                    {
                        var match = Regex.Match(value, @"^(?:((?:(?:carl )?zeiss(?: tessar)?)|leica|Schneider[ -]Kreuznach)(?: lens| optics)?)?(?:(xenon|strobe)(?: flash)?(?: &| and)? ?)?(?:((?:dual|tripp?le|3|quad|six|ten)?-?led) ?(rgb|dual[ -]tone)?)?", RegexOptions.IgnoreCase);
                        if (match.Groups[1].Success)
                            allCamerasFeatures.ElementAtOrDefault(i).Add(match.Groups[1].Value + " optics");
                        if (match.Groups[2].Success)
                            allCamerasFeatures.ElementAtOrDefault(i).Add("xenon");
                        if (match.Groups[4].Success)
                            allCamerasFeatures.ElementAtOrDefault(i).Add(match.Groups[4].Value.ToLowerInvariant() == "rgb" ? "RGB LEDs" : "dual-tone LEDs");

                        switch (match.Groups[3].Value.ToLowerInvariant())
                        {
                            case "flash":
                            case "falsh":
                            case "led":
                                leds[i] = 1;
                                break;
                            case "dual-led":
                                leds[i] = 2;
                                break;
                            case "triple-led":
                            case "tripple-led":
                            case "3led":
                                leds[i] = 3;
                                break;
                            case "quad-led":
                                leds[i] = 4;
                                break;
                            case "six-led":
                                leds[i] = 6;
                                break;
                            case "ten-led":
                                leds[i] = 10;
                                break;
                            default:
                                break;
                        }
                    }
                    if (rawFeatures.ElementAtOrDefault(i).Contains("depth & motion tracking", StringComparison.OrdinalIgnoreCase))
                        allCamerasFeatures.ElementAtOrDefault(i).Add("depth & motion tracking");
                    if (rawFeatures.ElementAtOrDefault(i).Contains("hdr", StringComparison.OrdinalIgnoreCase))
                        allCamerasFeatures.ElementAtOrDefault(i).Add("HDR");
                    if (rawFeatures.ElementAtOrDefault(i).Contains("rotating lens", StringComparison.OrdinalIgnoreCase))
                        allCamerasFeatures.ElementAtOrDefault(i).Add("rotating lens");
                    if (rawFeatures.ElementAtOrDefault(i).Contains("panorama", StringComparison.OrdinalIgnoreCase))
                        allCamerasFeatures.ElementAtOrDefault(i).Add("panorama");
                    if (rawFeatures.ElementAtOrDefault(i).Contains("thermal imaging", StringComparison.OrdinalIgnoreCase))
                        allCamerasFeatures.ElementAtOrDefault(i).Add("thermal imaging");
                    if (rawFeatures.ElementAtOrDefault(i).Contains("face detection", StringComparison.OrdinalIgnoreCase))
                        allCamerasFeatures.ElementAtOrDefault(i).Add("face detection");
                    if (rawFeatures.ElementAtOrDefault(i).Contains("dual video call", StringComparison.OrdinalIgnoreCase))
                        allCamerasFeatures.ElementAtOrDefault(i).Add("dual video call");
                }
            }

            resultPhone.CameraInfo.RearCameraLeds = leds[0];
            resultPhone.CameraInfo.FrontCameraLeds = leds[1];

            resultPhone.CameraInfo.RearCameraFeatures = rearCameraFeatures;
            resultPhone.CameraInfo.FrontCameraFeatures = frontCameraFeatures;
        }
        private void SetCameraVideoModes()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Video) && string.IsNullOrWhiteSpace(inputPhone.Detail.SelfieCamera?.Video)) return;

            var videoModes = new List<VideoMode>();
            var features = new List<string>();
            for (var j = 0; j < 2; j++)
            {
                var sides = new List<string[]>();
                sides.Add(string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Video) ? new string[] { } : inputPhone.Detail.MainCamera.Video.Split(','));
                sides.Add(string.IsNullOrWhiteSpace(inputPhone.Detail.SelfieCamera?.Video) ? new string[] { } : inputPhone.Detail.SelfieCamera.Video.Split(','));

                foreach (var value in sides[j])
                {
                    var match = Regex.Match(value, @"^ ?(?:(cif|qcif|scif|sqcif|svga|vga|yes|no)?(?:(\d+)x(\d+))?(?:w?([\d\/p]+(?!\d*fps|x|\d*-)))?(?:@?([\d\/~-]+)f?ps)?)", RegexOptions.IgnoreCase);

                    var widths = new List<int?>();
                    var heights = new List<int?>();
                    int?[] frameRates = null;
                    if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    {
                        var resolution = Converters.ConvertNameToResolution(match.Groups[1].Value.ToLowerInvariant());
                        widths.Add(resolution.Width);
                        heights.Add(resolution.Height);
                    }
                    else if (!string.IsNullOrWhiteSpace(match.Groups[2].Value + match.Groups[3].Value))
                    {
                        widths.Add(int.Parse(match.Groups[2].Value));
                        heights.Add(int.Parse(match.Groups[3].Value));
                    }
                    else if (!string.IsNullOrWhiteSpace(match.Groups[4].Value))
                    {
                        foreach (var resolutionName in match.Groups[4].Value.Replace("p", "").Split('/'))
                        {
                            var resolution = Converters.ConvertNameToResolution(resolutionName);
                            widths.Add(resolution.Width);
                            heights.Add(resolution.Height);
                        }

                    }

                    if (string.IsNullOrWhiteSpace(match.Groups[5].Value))
                    {
                        for (var i = 0; i < heights.Count(); i++)
                            videoModes.Add(new VideoMode { Width = widths[i], Height = heights[i], CameraSide = j == 0 ? "rear" : "front" });
                    }
                    else
                    {
                        frameRates = match.Groups[5].Value
                            .Split('/')
                            .Select(f => (int?)int.Parse(f.Split('-').LastOrDefault().Split('~').LastOrDefault())
                            ).ToArray();
                        foreach (var frameRate in frameRates)
                        {
                            for (var i = 0; i < heights.Count(); i++)
                                videoModes.Add(new VideoMode { Width = widths[i], Height = heights[i], CameraSide = j == 0 ? "rear" : "front", FrameRate = frameRate });
                        }
                    }


                }
            }

            if (inputPhone.Detail.MainCamera.Video.Contains("stereo sound rec", StringComparison.OrdinalIgnoreCase))
                features.Add("stereo sound recording");
            if (inputPhone.Detail.MainCamera.Video.Contains("gyro-EIS", StringComparison.OrdinalIgnoreCase))
                features.Add("gyro-EIS");
            if (inputPhone.Detail.MainCamera.Video.Contains("4x lossless digital zoom", StringComparison.OrdinalIgnoreCase))
                features.Add("4x lossless digital zoom");
            if (inputPhone.Detail.MainCamera.Video.Contains("HDR", StringComparison.OrdinalIgnoreCase))
                features.Add("HDR");
            if (inputPhone.Detail.MainCamera.Video.Contains("dual video recording", StringComparison.OrdinalIgnoreCase) || inputPhone.Detail.MainCamera.Video.Contains("dual-video rec", StringComparison.OrdinalIgnoreCase))
                features.Add("dual video recording");




            resultPhone.CameraInfo.VideoModes = videoModes;
            resultPhone.CameraInfo.VideoFeatures = features;
        }
        private void SetGpu()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Platform?.Gpu)) return;
            var match = Regex.Match(inputPhone.Detail.Platform.Gpu, @"^([a-zA-Z]+(?: geforce)?)(?:[ -]((?:(?!adreno|vivante|mali|powervr|gpu|hd graphics|graphics)[\w ])*))?", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                resultPhone.Gpu.Name = match.Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(match.Groups[2].Value))
                resultPhone.Gpu.Model = match.Groups[2].Value;
        }
        private void SetCpu()
        {
            if (!string.IsNullOrWhiteSpace(inputPhone.Overview.Expansion?.Chipset))
            {
                var match = Regex.Match(inputPhone.Overview.Expansion.Chipset, @"^(?:([Аa-zA-Z-]{2,})\b)?(?: (?:([a-zA-Z]{3,})\b))?(?: ?(?:([\w+-]+)))?(?: ?(?:([\w+-]+)))?(?: ?(?:([\w+-]+)))?");
                string name = null;
                string series = null;
                string producer = null;
                string model = null;
                if (match.Success)
                {
                    if (match.Groups[1].Value.Equals("apple", StringComparison.OrdinalIgnoreCase))
                    {
                        producer = "Apple";
                        series = match.Groups[3].Value.FirstOrDefault().ToString();
                        model = "Apple " + match.Groups[3].Value;
                        if (!string.IsNullOrWhiteSpace(match.Groups[4].Value))
                            model += $" {match.Groups[4].Value}";
                    }
                    else if (match.Groups[1].Value.Equals("exynos", StringComparison.OrdinalIgnoreCase))
                    {
                        producer = "Samsung";
                        name = "Exynos";
                        model = string.IsNullOrWhiteSpace(match.Groups[4].Value)
                            ? match.Groups[3].Value
                            : match.Groups[3].Value + " " + match.Groups[4].Value;
                    }
                    else if (match.Groups[1].Value.Equals("helio", StringComparison.OrdinalIgnoreCase) || Regex.IsMatch(inputPhone.Overview.Expansion.Chipset, @"mt\w+", RegexOptions.IgnoreCase))
                    {
                        var mediatekMatch = Regex.Match(inputPhone.Overview.Expansion.Chipset, @"^(?:mediatek)?(?: ?(?:(mt[\w+-]+)))?(?: or.*)?(?: ?(?:([\w+-]+)))?(?: ?(?:([\w+-]+)))?", RegexOptions.IgnoreCase);
                        producer = "Mediatek";
                        model = string.IsNullOrWhiteSpace(mediatekMatch.Groups[1].Value) ? null : mediatekMatch.Groups[1].Value;
                        model = model != null ? model : (string.IsNullOrWhiteSpace(mediatekMatch.Groups[3].Value) ? null : mediatekMatch.Groups[3].Value);
                        name = string.IsNullOrWhiteSpace(mediatekMatch.Groups[2].Value)
                            ? null
                            : $"{mediatekMatch.Groups[2].Value} {mediatekMatch.Groups[3]}".Trim();
                        series = string.IsNullOrWhiteSpace(mediatekMatch.Groups[2].Value) ? null : mediatekMatch.Groups[2].Value;
                    }
                    else if (match.Groups[1].Value.Equals("hisilicon", StringComparison.OrdinalIgnoreCase) || match.Groups[1].Value.Equals("huawei", StringComparison.OrdinalIgnoreCase))
                    {
                        producer = "HiSilicon";
                        series = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? null : match.Groups[2].Value;
                        model = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? null : match.Groups[3].Value;
                    }
                    else if (match.Groups[1].Value.Equals("intel", StringComparison.OrdinalIgnoreCase))
                    {
                        producer = "Intel";
                        series = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? null : match.Groups[2].Value;
                        model = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? null : match.Groups[3].Value;
                    }
                    else if (Regex.IsMatch(inputPhone.Overview.Expansion.Chipset, @"^(?:snapdragon|qualcomm|apq|esc|esm|msm|qsc)", RegexOptions.IgnoreCase))
                    {
                        var qualcommMatch = Regex.Match(inputPhone.Overview.Expansion.Chipset, @"^(?:snapdragon|qualcomm)?(?: ?(?:((?:[\w+-]+ ?){0,2})))?", RegexOptions.IgnoreCase);
                        producer = "Qualcomm";
                        name = inputPhone.Overview.Expansion.Chipset.Contains("snapdragon", StringComparison.OrdinalIgnoreCase) ? "Snapdragon" : null;
                        model = string.IsNullOrWhiteSpace(qualcommMatch.Groups[1].Value) ? null : qualcommMatch.Groups[1].Value.Trim();
                    }
                    else if (match.Groups[1].Value.Contains("spreadtrum", StringComparison.OrdinalIgnoreCase))
                    {
                        producer = "Spreadtrum";
                        model = !string.IsNullOrWhiteSpace(match.Groups[3].Value)
                            ? match.Groups[3].Value
                            : (!string.IsNullOrWhiteSpace(match.Groups[2].Value) ? match.Groups[2].Value : null);
                    }
                    else if (match.Groups[1].Value.Equals("nvidia", StringComparison.OrdinalIgnoreCase))
                    {
                        var nvidiaMatch = Regex.Match(inputPhone.Overview.Expansion.Chipset, @"^nvidia (?:([a-zA-Z]+\b) ?)?(?:([\w]{1,3}\b) ?)?(?:([\w ]+\b) ?)?", RegexOptions.IgnoreCase);
                        producer = "NVIDIA";
                        series = string.IsNullOrWhiteSpace(nvidiaMatch.Groups[1].Value) ? null : nvidiaMatch.Groups[1].Value;
                        model = string.IsNullOrWhiteSpace(nvidiaMatch.Groups[3].Value) ? null : nvidiaMatch.Groups[3].Value;

                    }

                    resultPhone.Cpu.Model = model;
                    resultPhone.Cpu.Name = name;
                    resultPhone.Cpu.Producer = producer;
                    resultPhone.Cpu.Series = series;
                }
            }
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Platform?.Cpu))
            {
                var match = Regex.Match(inputPhone.Detail.Platform.Cpu, @"^(dual|triple|quad|hexa|octa|deca)?", RegexOptions.IgnoreCase);
                int? cores = null;
                switch (match.Groups[1].Value.ToLowerInvariant())
                {
                    case "dual":
                        cores = 2;
                        break;
                    case "triple":
                        cores = 3;
                        break;
                    case "quad":
                        cores = 4;
                        break;
                    case "hexa":
                        cores = 6;
                        break;
                    case "octa":
                        cores = 8;
                        break;
                    case "deca":
                        cores = 10;
                        break;
                    default:
                        break;
                }
                resultPhone.Cpu.Cores = cores;
            }

        }
        private void SetWlan()
        {
            var features = new List<string>();
            var standards = new List<string>();
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Comms?.Wlan))
            {
                var match = Regex.Match(inputPhone.Detail.Comms.Wlan, @"^wi-fi( 802\.11)?,? ?(?:([bgnacdfhiqxyerk\/]+)\b)?(?: ?, ?((?:[a-zA-Z0-9\. -]+\b[,;\/]? )+))?", RegexOptions.IgnoreCase);
                if (match.Groups[2].Success)
                {
                    standards = match.Groups[2].Value.Split('/').ToList();
                    if (match.Groups[3].Success)
                    {
                        features = match.Groups[3].Value
                            .Replace(";", ",")
                            .Replace("/", ",")
                            .Split(",")
                            .Select(f => f.Trim())
                            .Where(f => !string.IsNullOrWhiteSpace(f))
                            .OrderBy(f => f)
                            .ToList();
                    }
                    resultPhone.Communication.Wlan.Available = true;
                }
                else
                    resultPhone.Communication.Wlan.Available = inputPhone.Detail.Comms.Wlan.Equals("yes", StringComparison.OrdinalIgnoreCase)
                        ? true
                        : (inputPhone.Detail.Comms.Wlan.Equals("false", StringComparison.OrdinalIgnoreCase)
                            ? false
                            : default(bool));
            }
            resultPhone.Communication.Wlan.Features = features;
            resultPhone.Communication.Wlan.Standards = standards;
        }
        private void SetAudioJack()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Sound?.The3_5MmJack)) return;
            if (inputPhone.Detail.Sound.The3_5MmJack.Contains("yes", StringComparison.OrdinalIgnoreCase))
                resultPhone.Communication.AudioJack = true;
            else if (inputPhone.Detail.Sound.The3_5MmJack.Contains("no", StringComparison.OrdinalIgnoreCase))
                resultPhone.Communication.AudioJack = false;
        }
        private void SetSensors()
        {
            var features = new List<string>();
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Features?.Sensors))
            {
                if (inputPhone.Detail.Features.Sensors.Contains("accelerometer", StringComparison.OrdinalIgnoreCase))
                    features.Add("accelerometer");
                if (inputPhone.Detail.Features.Sensors.Contains("altmeter", StringComparison.OrdinalIgnoreCase))
                    features.Add("altmeter");
                if (inputPhone.Detail.Features.Sensors.Contains("barometer", StringComparison.OrdinalIgnoreCase))
                    features.Add("barometer");
                if (inputPhone.Detail.Features.Sensors.Contains("compass", StringComparison.OrdinalIgnoreCase))
                    features.Add("compass");
                if (inputPhone.Detail.Features.Sensors.Contains("color spectrum", StringComparison.OrdinalIgnoreCase))
                    features.Add("spectrum");
                if (inputPhone.Detail.Features.Sensors.Contains("face id", StringComparison.OrdinalIgnoreCase))
                    features.Add("face id");
                if (inputPhone.Detail.Features.Sensors.Contains("fingerprint", StringComparison.OrdinalIgnoreCase))
                    features.Add("fingerprint");
                if (inputPhone.Detail.Features.Sensors.Contains("gesture", StringComparison.OrdinalIgnoreCase))
                    features.Add("gesture");
                if (inputPhone.Detail.Features.Sensors.Contains("gyro", StringComparison.OrdinalIgnoreCase))
                    features.Add("gyro");
                if (inputPhone.Detail.Features.Sensors.Contains("heart rate", StringComparison.OrdinalIgnoreCase))
                    features.Add("rate");
                if (inputPhone.Detail.Features.Sensors.Contains("humidity", StringComparison.OrdinalIgnoreCase))
                    features.Add("humidity");
                if (inputPhone.Detail.Features.Sensors.Contains("infrared face recognition", StringComparison.OrdinalIgnoreCase))
                    features.Add("infrared face recognition");
                if (inputPhone.Detail.Features.Sensors.Contains("iris scanner", StringComparison.OrdinalIgnoreCase))
                    features.Add("scanner");
                if (inputPhone.Detail.Features.Sensors.Contains("proximity", StringComparison.OrdinalIgnoreCase))
                    features.Add("proximity");
                if (inputPhone.Detail.Features.Sensors.Contains("sensor core", StringComparison.OrdinalIgnoreCase))
                    features.Add("core");
                if (inputPhone.Detail.Features.Sensors.Contains("spo2", StringComparison.OrdinalIgnoreCase))
                    features.Add("spo2");
                if (inputPhone.Detail.Features.Sensors.Contains("temperature", StringComparison.OrdinalIgnoreCase)
                || inputPhone.Detail.Features.Sensors.Contains("thermometer", StringComparison.OrdinalIgnoreCase))
                    features.Add("thermometer");
            }
            resultPhone.Communication.Sensors = features;
        }
        private void SetStatus()
        {
            var match = Regex.Match(inputPhone.Detail.Launch.Status, @"^(?:(available|cancelled|coming soon|discontinued))", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                resultPhone.Status.CurrentStatus = match.Groups[1].Value.ToLowerInvariant();
        }
        private void SetDisplay()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Display?.Type)) return;
            var match = Regex.Match(inputPhone.Detail.Display.Type, @"(?:(\b[\d]+)([mk ]) ?(?:colors)? ?)(?:\(([\d]+)([mk])? effective)?", RegexOptions.IgnoreCase);
            string displayColorMode = null;
            string touchscreen = null;
            int? colors = null;
            int? effectiveColors = null;
            var multiplier = 1;

            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value) && int.TryParse(match.Groups[1].Value, out var result))
            {
                multiplier = match.Groups[2].Value.ToLowerInvariant() == "m" ? 1000000 : match.Groups[2].Value.ToLowerInvariant() == "k" ? 1000 : 1;
                colors = result == 0 ? default(int?) : result * multiplier;
                resultPhone.Display.Colors = colors;
            }
            if (!string.IsNullOrWhiteSpace(match.Groups[3].Value) && int.TryParse(match.Groups[3].Value, out result))
            {
                multiplier = match.Groups[4].Value.ToLowerInvariant() == "m" ? 1000000 : match.Groups[4].Value.ToLowerInvariant() == "k" ? 1000 : 1;
                effectiveColors = result == 0 ? default(int?) : result * multiplier;
                resultPhone.Display.EffectiveColors = effectiveColors;
            }
            match = Regex.Match(inputPhone.Detail.Display.Type, @"(?:(mono|gray|grey|single|\bcolor\b)[a-zA-Z ,]*)", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
            {
                displayColorMode = match.Groups[1].Value.ToLowerInvariant();
            }
            if ((displayColorMode == "mono" && colors != null) || displayColorMode == "gray" || displayColorMode == "grey")
                displayColorMode = "grayscale";
            if (displayColorMode == null && colors > 16)
                displayColorMode = "color";
            if (displayColorMode == "single")
                displayColorMode = "mono";
            resultPhone.Display.ColorMode = displayColorMode;
            if (inputPhone.Detail.Display.Type == "Capacitive touchscreen")
            { }
            if (inputPhone.Detail.Display.Type.Contains("touch", StringComparison.OrdinalIgnoreCase)) touchscreen = "yes";
            if (inputPhone.Detail.Display.Type.Contains("resistive", StringComparison.OrdinalIgnoreCase)) touchscreen = "resistive";
            if (inputPhone.Detail.Display.Type.Contains("capacitive", StringComparison.OrdinalIgnoreCase)) touchscreen = "capacitive";
            resultPhone.Display.Touchscreen = touchscreen;
            match = Regex.Match(inputPhone.Detail.Display.Type, @"^(lcd|oled|cstn|grayscale lcd|tft|fstn)?(?:([3a-zA-Z][\w +-]*?)(?:grap|capac|resist|touch|toch|,|\())?", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                resultPhone.Display.Type = match.Groups[1].Value.Trim();
            if (!string.IsNullOrWhiteSpace(match.Groups[2].Value) && !match.Groups[2].Value.Contains("capacitive", StringComparison.OrdinalIgnoreCase))
                resultPhone.Display.Type = match.Groups[2].Value.Trim();
            // match = Regex.Match(inputPhone.Detail.Display.Type, @"(?:(mono|gray|grey|\bcolor\b)[a-zA-Z ,]*)?(?:([\d]+) shades)?(?:(\b[\d\.]+)([mk ]) ?(?:colors)? ?)?(?:\(([\d\.]+)([mk])? effective)?", RegexOptions.IgnoreCase);

            // resultPhone.Test = $"{match.Groups[1].Value}, {match.Groups[2].Value}, {match.Groups[3].Value}, {match.Groups[4].Value}, ";
        }
        private void SetGps()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Comms?.Gps)) return;
            var match = Regex.Match(inputPhone.Detail.Comms.Gps, @"^(?:(yes|no)[,;]? ?)?(?:with(?: dual-band)? ?)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?", RegexOptions.IgnoreCase);
            var gps = string.IsNullOrWhiteSpace(match.Groups[1].Value) ? null : match.Groups[1].Value.ToLowerInvariant();
            var features = match.Groups
                .Skip(2)
                .Where(g => !string.IsNullOrWhiteSpace(g.Value))
                .Select(g => g.Value);
            resultPhone.Communication.Gps.Available = gps == "yes" ? true : gps == "no" ? false : default(bool?);
            resultPhone.Communication.Gps.Features = features.ToList();

        }
        private void SetCameraResolution()
        {
            // double? photoResoluton = null;
            // double? videoResoluton = null;
            if (!string.IsNullOrWhiteSpace(inputPhone.Overview.Camera?.Photo) && double.TryParse(Regex.Replace(inputPhone.Overview.Camera.Photo, @"[^0-9\.]", ""), out var photoResolution))
                resultPhone.CameraInfo.PhotoResolution = photoResolution >= 0 ? photoResolution : default(double?);
            if (!string.IsNullOrWhiteSpace(inputPhone.Overview.Camera?.Video) && int.TryParse(Regex.Replace(inputPhone.Overview.Camera.Video, @"[^0-9\.]", ""), out var videoResolution))
                resultPhone.CameraInfo.VideoResolution = videoResolution > 0 || videoResolution < 10000 ? videoResolution : default(int?);
        }
        private void SetColors()
        {
            var match = Regex.Match(inputPhone.Detail.Misc.Colors, @"^\(?(?:[\d]+[ -]+)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?", RegexOptions.IgnoreCase);
            var colors = match.Groups.Select(g => g.Value).Skip(1).ToList();
            colors = colors.Where(c => !string.IsNullOrWhiteSpace(c)).ToList();
            // if (colors.Count() == 0) return;
            // colors.Remove(c => p.Contains("model")))
            resultPhone.Body.Colors = colors;


        }
        private void SetPrice()
        {

            double? price = null;
            string currency = null;
            double? priceInEuro = null;
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Misc.Price)) return;
            var match = Regex.Match(inputPhone.Detail.Misc.Price, @"^(?:About )([\d.]+) (\w+)", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value) && double.TryParse(match.Groups[1].Value, out var result))
            {
                price = result;
                currency = match.Groups[2].Value;
                double priceMultiplier = 1;
                switch (currency)
                {
                    // rates on 2019-03-26
                    case "EUR":
                        priceMultiplier = 1;
                        break;
                    case "USD":
                        priceMultiplier = 0.88;
                        break;
                    case "INR":
                        priceMultiplier = 0.013;
                        break;
                    default:
                        break;
                }
                priceInEuro = Math.Ceiling((price * priceMultiplier).Value);
            }
            resultPhone.Price.Value = price;
            resultPhone.Price.Currency = currency;
            resultPhone.Price.EstimatedInEuro = priceInEuro;
        }
        private void SetOs()
        {
            string os = null;
            string osFlavor = null;
            string osVersion = null;
            string osLatestVersion = null;
            string osFlavorVersion = null;

            if (inputPhone.Overview.GeneralInfo.Os.Contains("android", StringComparison.OrdinalIgnoreCase))
            {
                var match = Regex.Match(inputPhone.Overview.GeneralInfo.Os, @"^(?:(?:customized )?android(?: wear,?)?(?: os)? ?)(?:([\d\.x]+)(?:[ a-zA-Z]*)\/?,? ?)?(?:([\d\.]+),? ?)?(?:(?:up(?:grad[аa]ble)? to (?:android )?([\d\.]+)(?:[a-zA-Z ]*))?)?(?:not up to [\d\.]+)?(?:planned upgrade to (?:android )?([\d\.]+))?(?:; )*(?:([a-zA-z ]+)([\d\.]+)?)?", RegexOptions.IgnoreCase);
                os = inputPhone.Overview.GeneralInfo.Os.Contains("android wear", StringComparison.OrdinalIgnoreCase) ? "android wear" : "android";
                osVersion = string.IsNullOrWhiteSpace(match.Groups[1].Value) ? null : match.Groups[1].Value;
                osFlavor = string.IsNullOrWhiteSpace(match.Groups[5].Value) ? null : match.Groups[5].Value.Trim();
                osFlavorVersion = string.IsNullOrWhiteSpace(match.Groups[6].Value) ? null : match.Groups[6].Value;
                osVersion = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? osVersion : match.Groups[2].Value;
                osLatestVersion = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? null : match.Groups[3].Value;
            }
            else if (Regex.Match(inputPhone.Overview.GeneralInfo.Os, @"(?:\bios\b|watchos)", RegexOptions.IgnoreCase).Success)
            {
                var match = Regex.Match(inputPhone.Overview.GeneralInfo.Os, @"^(ios|watchos) ?(?:([\d\.]+))?(?:,? ?up to )(?:ios )?([\d\.]+)", RegexOptions.IgnoreCase);
                os = string.IsNullOrWhiteSpace(match.Groups[1].Value) ? null : match.Groups[1].Value;
                osVersion = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? null : match.Groups[2].Value;
                osLatestVersion = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? null : match.Groups[3].Value;
            }
            resultPhone.OperatingSystem.Name = os;
            resultPhone.OperatingSystem.Version = osVersion;
            resultPhone.OperatingSystem.LatestVersion = osLatestVersion;
            resultPhone.OperatingSystem.FlavorName = osFlavor;
            resultPhone.OperatingSystem.FlavorVersion = osFlavorVersion;
        }
        private void SetUsb()
        {
            if (string.IsNullOrWhiteSpace(inputPhone.Detail.Comms?.Usb)) return;
            string version = null;
            string connector = null;
            List<string> features = null;
            var match = Regex.Match(inputPhone.Detail.Comms.Usb, @"^(?:(\d\.\d),? ?)?(?:(?!usb host|usb on-the-go)(miniusb|microusb|type-c|usb|proprietary|pop-port) ?(\d\.\d)?[,;]? ?)?(?:revers[\w ]+[,;]?\s)?(?: ?\(((?:mhl|slimport))? ?.*\),? ?)?(?:(usb host)?,? ?(usb (?:on-the-go|otg))?[;,]? ?(magnetic connector)?)?", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                version = match.Groups[1].Value;
            if (version == null && !string.IsNullOrWhiteSpace(match.Groups[3].Value))
                version = match.Groups[3].Value;

            resultPhone.Communication.Usb.Version = version;
            if (!string.IsNullOrWhiteSpace(match.Groups[2].Value))
                connector = match.Groups[2].Value.ToLowerInvariant();
            resultPhone.Communication.Usb.Connector = connector == "usb" ? null : connector;

            if ($"{match.Groups[4].Value}{match.Groups[5].Value}{match.Groups[6].Value}{match.Groups[7].Value}" != "")
                features = new List<string>();

            if (!string.IsNullOrWhiteSpace(match.Groups[4].Value)) features.Add(match.Groups[4].Value);
            if (!string.IsNullOrWhiteSpace(match.Groups[5].Value)) features.Add(match.Groups[5].Value);
            if (!string.IsNullOrWhiteSpace(match.Groups[6].Value)) features.Add(match.Groups[6].Value);
            if (!string.IsNullOrWhiteSpace(match.Groups[7].Value)) features.Add(match.Groups[7].Value);
            resultPhone.Communication.Usb.Features = features;

        }
        private void SetMemory()
        {
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Memory?.Internal))
            {
                int? internalMemory = null;
                int? readOnlyMemory = null;
                int multiplier = 1;

                var match = Regex.Match(inputPhone.Detail.Memory.Internal, @"^(?:\d*\/)*(?:\d+ ?[KMG]B ram[,;] )?(?:(\d+\.?[\d]*) ?([KMGT])B(?! ram| flash| rom))?", RegexOptions.IgnoreCase);
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                {
                    var rawMemory = "";
                    var unit = "";
                    rawMemory = match.Groups[1].Value;
                    unit = match.Groups[2].Value.ToUpperInvariant();
                    multiplier = unit == "K" ? 1 : (unit == "M" ? 1024 : (unit == "G" ? 1048576 : 1073741824));
                    internalMemory = int.TryParse(rawMemory, out int result) ? result : default(int?);
                    internalMemory *= multiplier;
                }
                match = Regex.Match(inputPhone.Detail.Memory.Internal, @"(\d+\.?[\d]*) ?([KMGT])B ROM", RegexOptions.IgnoreCase);
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                {
                    var rawMemory = "";
                    var unit = "";
                    rawMemory = match.Groups[1].Value;
                    unit = match.Groups[2].Value;
                    multiplier = unit == "K" ? 1 : (unit == "M" ? 1024 : (unit == "G" ? 1048576 : 1073741824));
                    readOnlyMemory = int.TryParse(rawMemory, out int result) ? result : default(int?);
                    readOnlyMemory *= multiplier;
                }
                resultPhone.Memory.Internal = internalMemory;
                resultPhone.Memory.ReadOnly = readOnlyMemory;
            }
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Memory?.CardSlot))
            {
                var match = Regex.Match(inputPhone.Detail.Memory.CardSlot, @"^(?:(memory stick(?: (?:duo(?: pro)?|micro))?|microsd|micrommc|\bmicro\b|minisd|mmc-micro|mmc|nm|rs-mmc|rs-dv-mmc|sdio|sd|yes|no))(?:\/(memory stick(?: (?:duo(?: pro)?|micro))?|microsd|micrommc|\bmicro\b|minisd|mmc-micro|mmc|nm|rs-mmc|rs-dv-mmc|sdio|sd|yes|no))?(?:.*?up to (\d+) ?([mgt])b)?", RegexOptions.IgnoreCase);
                string cardType = null;
                var multiplier = 1;
                int? maxSize = null;
                string unit = "";
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    cardType = match.Groups[1].Value;
                if (cardType != null && !string.IsNullOrWhiteSpace(match.Groups[2].Value))
                    cardType += "/" + match.Groups[2].Value;
                if (!string.IsNullOrWhiteSpace(match.Groups[3].Value + match.Groups[4].Value) && int.TryParse(match.Groups[3].Value, out var result))
                {
                    unit = match.Groups[4].Value.ToLowerInvariant();
                    multiplier = unit == "m" ? 1 : (unit == "g" ? 1024 : 1048576);
                    maxSize = result * multiplier;
                }
                resultPhone.Memory.CardType = cardType;
                resultPhone.Memory.CardMaxSize = maxSize;
            }
            // resultPhone.MemoryInternal = $"{rawInternalMemory} {rawInternalMemoryUnit}, {rawReadOnlyMemory} {rawReadOnlyMemoryUnit}";
        }
        private void SetSimCard()
        {
            string sim1 = null;
            string sim2 = null;
            string sim3 = null;
            string sim4 = null;
            var match = Regex.Match(inputPhone.Detail.Body.Sim, @"^(?:hybrid )?"
              + @"((?:yes|pre|non|electronic|esim|single|dual|triple|quad|nano|mini|micro))?"
              + @"(?:-sim,? ?(?:card)? ?&? ?(e)(?:sime|lectronic)?)?[\w ]*,? ?(?:\(?((?:e|mini|micro|nano))[- ]?sim)? ?"
              + @"[\/,&]*(?:and)? ?(?:(?:((?:e|mini|micro|nano))[- ]?sim)?)?", RegexOptions.IgnoreCase);
            switch (match.Groups[1].Value.ToLowerInvariant())
            {
                case "mini":
                case "micro":
                case "nano":
                case "esim":
                case "electronic":
                    sim1 = match.Groups[1].Value.ToLowerInvariant();
                    sim1 = sim1 == "esim" ? "electronic" : sim1;
                    if (!string.IsNullOrWhiteSpace(match.Groups[2].Value)) sim2 = match.Groups[2].Value.ToLowerInvariant();
                    sim2 = sim2 == "e" || sim2 == "esim" ? "electronic" : sim2;
                    break;
                case "yes":
                case "pre":
                case "non":
                    sim1 = "yes";
                    break;
                case "single":
                    sim1 = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? "yes" : match.Groups[3].Value.ToLowerInvariant();
                    break;
                case "dual":
                    sim1 = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? "yes" : match.Groups[3].Value.ToLowerInvariant();
                    sim2 = string.IsNullOrWhiteSpace(match.Groups[4].Value) ? sim1 : match.Groups[4].Value.ToLowerInvariant();
                    break;
                case "triple":
                    sim1 = sim2 = sim3 = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? "yes" : match.Groups[3].Value.ToLowerInvariant();
                    break;
                case "quad":
                    sim1 = sim2 = sim3 = sim4 = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? "yes" : match.Groups[3].Value.ToLowerInvariant();
                    break;
                default:
                    break;

            }

            if (sim1 != null)
            {
                resultPhone.Communication.SimCards = new List<string>();
                resultPhone.Communication.SimCards.Add(sim1);
                if (sim2 != null) resultPhone.Communication.SimCards.Add(sim2);
                if (sim3 != null) resultPhone.Communication.SimCards.Add(sim3);
                if (sim4 != null) resultPhone.Communication.SimCards.Add(sim4);
            }
        }
        private void SetBuildMaterials()
        {
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Body?.Build))
            {
                string frontAndBackMaterial = null;
                string frontMaterial = null;
                string backMaterial = null;
                string frameMaterial = null;
                string bodyMaterial = null;

                var match = Regex.Match(inputPhone.Detail.Body.Build, @"front\/back ([\w \(\)\/]*),?", RegexOptions.IgnoreCase);
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    frontAndBackMaterial = match.Groups[1].Value.Trim();
                resultPhone.Body.Material.Front = frontAndBackMaterial;
                resultPhone.Body.Material.Back = frontAndBackMaterial;

                if (string.IsNullOrWhiteSpace(frontAndBackMaterial))
                {
                    match = Regex.Match(inputPhone.Detail.Body.Build, @"front ([\w \(\)&]*),?", RegexOptions.IgnoreCase);
                    if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    {
                        frontMaterial = match.Groups[1].Value.Trim();
                    }
                    resultPhone.Body.Material.Front = frontMaterial;
                    match = Regex.Match(inputPhone.Detail.Body.Build, @"([\w \(\)\/-]*)? ?back ?([\w \(\)\/]*)?,?", RegexOptions.IgnoreCase);
                    if (match.Groups[1].Success || match.Groups[2].Success)
                    {
                        var choseSecond = match.Groups[1].Value.Contains("Front")
                            || match.Groups[1].Value.Contains("front")
                            || match.Groups[1].Value.Length < match.Groups[2].Value.Length;
                        backMaterial = choseSecond ? match.Groups[2].Value : match.Groups[1].Value.Trim();
                        backMaterial = backMaterial.Contains("case/") ? backMaterial.Substring(0, backMaterial.Length - 6) : backMaterial;
                    }
                    match = Regex.Match(inputPhone.Detail.Body.Build, @"([\w \(\)&]*) frame & back", RegexOptions.IgnoreCase);
                    if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    {
                        backMaterial = match.Groups[1].Value.Trim();
                        frameMaterial = match.Groups[1].Value.Trim();
                    }
                    resultPhone.Body.Material.Back = string.IsNullOrWhiteSpace(backMaterial) || backMaterial.Contains("and") || backMaterial.Contains("128/8 GB model") ? null : backMaterial;
                }
                match = Regex.Match(inputPhone.Detail.Body.Build, @"([\w\ ]+)\s*frame");
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    frameMaterial = match.Groups[1].Value.Trim();
                resultPhone.Body.Material.Frame = frameMaterial;

                match = Regex.Match(inputPhone.Detail.Body.Build, @"([\w ]+) (?:uni)?body", RegexOptions.IgnoreCase);
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                {
                    bodyMaterial = match.Groups[1].Value;
                    if (bodyMaterial.Contains("urved")) bodyMaterial = null;
                }
                resultPhone.Body.Material.Body = bodyMaterial;
            }
        }
        private void SetDimensions()
        {
            var match = Regex.Match(inputPhone.Detail.Body.Dimensions, @"^(?:Unfolded:\s)?"
              + @"(?:([\d\.]+)\s*x\s*([\d\.]+)\s*x\s*([\d\.]+)\s*mm,?\s*)?(?:([\d\.]+)\s?cc)?");
            double? height = null;
            double? width = null;
            double? thickness = null;
            double? volume = null;
            if (match.Groups[1].Success && double.TryParse(match.Groups[1].Value, out var result))
                height = result;
            if (match.Groups[2].Success && double.TryParse(match.Groups[2].Value, out result))
                width = result;
            if (match.Groups[3].Success && double.TryParse(match.Groups[3].Value, out result))
                thickness = result;
            if (match.Groups[4].Success && double.TryParse(match.Groups[4].Value, out result))
                volume = result;
            resultPhone.Body.Dimensions.Height = height;
            resultPhone.Body.Dimensions.Width = width;
            resultPhone.Body.Dimensions.Thickness = thickness;
            resultPhone.Body.Dimensions.Volume = volume;
        }
        private void SetWeight()
        {
            var match = Regex.Match(inputPhone.Detail.Body.Weight, @"^(?:From\s*)?(?:~\s*)?(?:([\d\.]+)\s*,?\s*g?\s*)?(?:([\d\.]+)\s?cc)?");
            double? weight = null;
            if (double.TryParse(match.Groups[1].Value, out var result))
                weight = result;
            resultPhone.Body.Weight = weight;
        }
        private void SetDisplayResolution()
        {
            if (inputPhone.Overview.Display.Resolution == null)
                return;
            var match = Regex.Match(inputPhone.Overview.Display.Resolution, @"^(?:up to )?(?:(\d\d+)\s?x(\d\d+)"
              + @"\s*(?:pixels)?,?\s*)?(?:(\d+)\s+lines)?(?:\d+\s?x\d+\s*chars)?");
            int? width = null;
            int? height = null;
            int? lines = null;
            if (int.TryParse(match.Groups[1].Value, out var result))
                width = result;
            if (int.TryParse(match.Groups[2].Value, out result))
                height = result;
            if (int.TryParse(match.Groups[3].Value, out result))
                lines = result;

            resultPhone.Display.ResolutionWidth = width;
            resultPhone.Display.ResolutionHeight = height;
            resultPhone.Display.ResolutionLines = lines;
        }
        private void SetDisplayPixelDensityAndRatio()
        {
            var match = Regex.Match(inputPhone.Detail.Display.Resolution, @"(?:([\d\.]+):([\d\.]+)\sratio\s?)?"
              + @"(?:\(.(\d+)\sppi(?:\s?pixel)?\sdensity\))?$");
            double? widthRatio = null;
            double? heightRatio = null;
            double? density = null;
            if (double.TryParse(match.Groups[1].Value, out var result))
            {
                widthRatio = result;
            }
            if (double.TryParse(match.Groups[2].Value, out result))
            {
                heightRatio = result;
            }
            if (double.TryParse(match.Groups[3].Value, out result))
            {
                density = result;
            }
            resultPhone.Display.PixelDensity = density;
            resultPhone.Display.WidthRatio = widthRatio;
            resultPhone.Display.HeightRatio = heightRatio;
        }
        public void SetScreenSize()
        {
            var match = Regex.Match(inputPhone.Detail.Display.Size, @"^(\d+\.?\d*) inches,?\s?(?:-,\s)?(?:\d*\.\d*, )?"
              + @"(?:([\d\.]+\sx\s+[\d\.]+)\smm,?\s)?(?:(\d+\.?\d*)\scm2\s?)?(?:\(~?([\d\.]+)%.*\))?");
            double? size = null;
            double? area = null;
            double? screenToBodyRatio = null;
            if (double.TryParse(match.Groups[1].Value, out var result))
                size = result;
            if (double.TryParse(match.Groups[3].Value, out result))
                area = result;
            if (double.TryParse(match.Groups[4].Value, out result))
                screenToBodyRatio = result;
            resultPhone.Display.Diagonal = size;
            resultPhone.Display.Area = area;
            resultPhone.Display.ScreenToBodyRatio = screenToBodyRatio;
        }

        public void SetRam()
        {
            if (inputPhone.Overview.Expansion?.Ram == null)
                resultPhone.Memory.ReadOnly = null;
            else
            {
                var match = Regex.Match(inputPhone.Overview.Expansion?.Ram, @"^(\d*\.?\d*)([MG]B)").Groups;
                resultPhone.Memory.ReadOnly = (int)double.Parse(match[1].Value) * (match[2].Value == "GB" ? 1024 : 1);
            }
        }

        private void SetComms()
        {
            string bluetooth = Regex.Match(inputPhone.Detail.Comms.Bluetooth, @"^[v\.]*((?:\d+.[\dx]+|Yes|yes|no|No))").Groups[1].Value;
            resultPhone.Communication.Bluetooth = string.IsNullOrWhiteSpace(bluetooth) ? null : bluetooth.ToLowerInvariant();
            resultPhone.Communication.Infrared = inputPhone.Detail.Comms.InfraredPort?.ToLowerInvariant().Contains("yes") == true;
            resultPhone.Communication.Nfc = inputPhone.Detail.Comms.Nfc?.ToLowerInvariant().Contains("yes") == true;
        }

        public void SetBattery()
        {
            if (!string.IsNullOrWhiteSpace(inputPhone.Overview.Battery?.Capacity))
                resultPhone.Battery.Capacity = int.Parse(Regex.Replace(inputPhone.Overview.Battery?.Capacity, "[^0-9+-]", ""));
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Tests?.BatteryLife))
                resultPhone.Battery.Endurance = int.Parse(Regex.Match(inputPhone.Detail.Tests.BatteryLife, @"(\d)+").Value);
        }

        public void SetDeviceType()
        {
            var type = inputPhone.DeviceType.ToLowerInvariant().Contains("phone") ? "phone" : "tablet";
            type = inputPhone.DeviceName.ToLower().Contains("watch")
                || inputPhone.Overview.GeneralInfo.Os.ToLower().Contains("wear")
                    ? "smartwatch" : type;
            type = inputPhone.DeviceName == "Haier C300"
                || inputPhone.DeviceName == "BLU X Link"
                || inputPhone.DeviceName == "alcatel CareTime"
                || inputPhone.DeviceName == "Huawei Fit"
                || inputPhone.DeviceName == "Samsung Serenata"
                    ? "smartwatch" : type;
            resultPhone.Basics.DeviceType = type;
        }
        public void SetDates()
        {
            var match = Regex.Match(inputPhone.Detail.Launch.Status, @"^(?:(?:available|coming soon)\.? ?)?(?:(?:released|exp\. release) (\d{4})(?:, ((?:[a-z]{3,})|(?:Q\d)))?)", RegexOptions.IgnoreCase);
            var released = Converters.ParseDate(match.Groups[1].Value, match.Groups[2].Value);

            match = Regex.Match(inputPhone.Detail.Launch?.Announced, @"^(?:(\d{4})[,]? ?(?:((?:[a-z]{3,})|(?:[\dq ]{2,}\b))?\.? ?)?)(?:(?:(?: exp\. )?released? *)+(\d{4})(?:,? ((?:[a-z]{3,})|(?:[\dq ]{2,}\b)))?)?", RegexOptions.IgnoreCase);
            var announced = Converters.ParseDate(match.Groups[1].Value, match.Groups[2].Value);

            if (released.Year == null)
            {
                released = Converters.ParseDate(match.Groups[3].Value, match.Groups[4].Value);
                match = Regex.Match(inputPhone.Overview.GeneralInfo.Launched, @"^(?:(?:released ?|exp\. release)+ +(\d{4})(?:[, ]+((?:[a-z]{3,})|(?:[\dq ]{2,}\b)))?)", RegexOptions.IgnoreCase);

                if (released.Year == null)
                    released = Converters.ParseDate(match.Groups[3].Value, match.Groups[4].Value);
            }
            resultPhone.Status.AnnouncedDate = announced;
            resultPhone.Status.ReleasedDate = released;
        }

        private void Debug()
        {
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Single?.FirstOrDefault()))
                resultPhone.CameraInfo.CameraOriginalText = "Single: " + string.Join("  |  ", inputPhone.Detail.MainCamera.Single);
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Dual?.FirstOrDefault()))
                resultPhone.CameraInfo.CameraOriginalText = "Dual: " + string.Join("  |  ", inputPhone.Detail.MainCamera.Dual);
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Triple?.FirstOrDefault()))
                resultPhone.CameraInfo.CameraOriginalText = "Triple: " + string.Join("  |  ", inputPhone.Detail.MainCamera.Triple);
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Quad?.FirstOrDefault()))
                resultPhone.CameraInfo.CameraOriginalText = "Quad: " + string.Join("  |  ", inputPhone.Detail.MainCamera.Quad);
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.MainCamera?.Five?.FirstOrDefault()))
                resultPhone.CameraInfo.CameraOriginalText = "Five: " + string.Join("  |  ", inputPhone.Detail.MainCamera.Five);
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.SelfieCamera?.Single?.FirstOrDefault()))
                resultPhone.CameraInfo.CameraOriginalText += "||  Front Single: " + string.Join("  |  ", inputPhone.Detail.SelfieCamera.Single);
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.SelfieCamera?.Dual?.FirstOrDefault()))
                resultPhone.CameraInfo.CameraOriginalText += "||  Front Dual: " + string.Join("  |  ", inputPhone.Detail.SelfieCamera.Dual);

            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Launch.Status))
                resultPhone.Status.DatesOriginalText += "Detail.Launch.Status: " + inputPhone.Detail.Launch.Status;
            if (!string.IsNullOrWhiteSpace(inputPhone.Detail.Launch?.Announced))
                resultPhone.Status.DatesOriginalText += " |  Detail.Launch?.Announced: " + inputPhone.Detail.Launch?.Announced;
            if (!string.IsNullOrWhiteSpace(inputPhone.Overview.GeneralInfo.Launched))
                resultPhone.Status.DatesOriginalText += " |  Overview.GeneralInfo.Launched: " + inputPhone.Overview.GeneralInfo.Launched;
        }
    }
}