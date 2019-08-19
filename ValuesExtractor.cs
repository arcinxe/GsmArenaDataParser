using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GsmArenaDataParser.Extensions;

namespace GsmArenaDataParser {
    public class ValuesExtractor {
        private GsmArenaDataParser.Data inputDevice { get; set; }
        public DeviceDetails resultDevice { get; set; }
        public ValuesExtractor(GsmArenaDataParser.Data device) {
            inputDevice = device;
            resultDevice = new DeviceDetails();
            DoTheStuff();
        }

        public void DoTheStuff() {
            resultDevice.Name = inputDevice.DeviceName;
            resultDevice.Basic.GsmArenaId = inputDevice.PhoneId;
            resultDevice.Basic.Slug = inputDevice.Slug;
            resultDevice.Basic.ImageUrl = inputDevice.ImageUrl.ToString();
            resultDevice.Brand = inputDevice.Brand;
            resultDevice.Battery.Technology = inputDevice.Overview.Battery.Technology;
            Debug();
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
            SetDeviceType();
        }

        private void SetCameras() {
            var cameras = new List<Camera>();
            resultDevice.CameraInfo.Cameras = cameras;

            var rearCamerasData = new List<string>();
            var frontCamerasData = new List<string>();
            var allCamerasData = new List<List<string>>();
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Single?.FirstOrDefault()))
                rearCamerasData = inputDevice.Detail.MainCamera?.Single;
            else if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Dual?.FirstOrDefault()))
                rearCamerasData = inputDevice.Detail.MainCamera?.Dual;
            else if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Triple?.FirstOrDefault()))
                rearCamerasData = inputDevice.Detail.MainCamera?.Triple;
            else if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Quad?.FirstOrDefault()))
                rearCamerasData = inputDevice.Detail.MainCamera?.Quad;
            else if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Five?.FirstOrDefault()))
                rearCamerasData = inputDevice.Detail.MainCamera?.Five;

            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.SelfieCamera?.Single?.FirstOrDefault()))
                frontCamerasData = inputDevice.Detail.SelfieCamera?.Single;
            else if (!string.IsNullOrWhiteSpace(inputDevice.Detail.SelfieCamera?.Dual?.FirstOrDefault()))
                frontCamerasData = inputDevice.Detail.SelfieCamera?.Dual;
            allCamerasData.Add(rearCamerasData);
            allCamerasData.Add(frontCamerasData);
            for (var k = 0; k < 2; k++) {
                if (allCamerasData.ElementAtOrDefault(k).Count == 0) continue;

                var rawCameras = string
                    .Join("|", allCamerasData.ElementAtOrDefault(k))
                    .Split("|or", StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault()
                    .Split('|')
                    .Select(v => v.Split(',').Select(sv => sv.Trim()));

                var additionalFeatures = new Dictionary<string, int?>();
                foreach (var rawCamera in rawCameras) {
                    double? megapixels = null;
                    int? zoom = null;
                    double? sensorSize = null;
                    double? focalLength = null;
                    double? aperture = null;
                    var camerasAmount = 1;
                    var features = new List<string>();
                    foreach (var value in rawCamera) {
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
                        if (aperture != null ||
                            focalLength != null ||
                            zoom != null ||
                            sensorSize != null ||
                            megapixels != null ||
                            features.Count > 0) {
                            var individualFeatures = new List<string>(features.Select(f => Converters.FormatName(f)));
                            cameras.Add(new Camera {
                                Aperture = aperture,
                                    FocalLength = focalLength,
                                    OpticalZoom = zoom,
                                    SensorSize = sensorSize,
                                    Resolution = megapixels,
                                    Location = k == 0 ? "rear" : "front",
                                    Features = individualFeatures.Select(f => new CameraFeature { Name = f }).ToList()
                            });
                        }

                }

                if (additionalFeatures.Count > 0 && cameras.Count >= additionalFeatures.Sum(f => f.Value)) {
                    var position = 0;
                    for (var i = 0; i < additionalFeatures.Count; i++) {
                        for (var j = 0; j < additionalFeatures.ElementAtOrDefault(i).Value; j++) {
                            cameras.ElementAtOrDefault(position++).Features.Add(new CameraFeature { Name = additionalFeatures.ElementAtOrDefault(i).Key });
                        }
                    }
                }
            }
        }
        private void SetCameraFeatures() {
            var allCamerasFeatures = new List<List<string>>();

            var rearCameraFeatures = new List<string>();
            var frontCameraFeatures = new List<string>();
            allCamerasFeatures.Add(rearCameraFeatures);
            allCamerasFeatures.Add(frontCameraFeatures);
            var rawFeatures = new List<string>();
            rawFeatures.Add(string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Features) ? "" : inputDevice.Detail.MainCamera.Features);
            rawFeatures.Add(string.IsNullOrWhiteSpace(inputDevice.Detail.SelfieCamera?.Features) ? "" : inputDevice.Detail.SelfieCamera.Features);

            var leds = new List<int?>(2) { null, null };
            for (var i = 0; i < 2; i++) {
                if (!string.IsNullOrWhiteSpace(rawFeatures.ElementAtOrDefault(i))) {
                    foreach (var value in rawFeatures.ElementAtOrDefault(i).Split(',').Select(f => f.Trim())) {
                        var match = Regex.Match(value, @"^(?:((?:(?:carl )?zeiss(?: tessar)?)|leica|Schneider[ -]Kreuznach)(?: lens| optics)?)?(?:(xenon|strobe)(?: flash)?(?: &| and)? ?)?(?:((?:dual|tripp?le|3|quad|six|ten)?-?led) ?(rgb|dual[ -]tone)?)?", RegexOptions.IgnoreCase);
                        if (match.Groups[1].Success)
                            allCamerasFeatures.ElementAtOrDefault(i).Add(match.Groups[1].Value + " optics");
                        if (match.Groups[2].Success)
                            allCamerasFeatures.ElementAtOrDefault(i).Add("xenon");
                        if (match.Groups[4].Success)
                            allCamerasFeatures.ElementAtOrDefault(i).Add(match.Groups[4].Value.ToLowerInvariant() == "rgb" ? "RGB LEDs" : "dual-tone LEDs");

                        switch (match.Groups[3].Value.ToLowerInvariant()) {
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

            resultDevice.CameraInfo.RearCameraLeds = leds[0];
            resultDevice.CameraInfo.FrontCameraLeds = leds[1];

            resultDevice.CameraInfo.RearCameraFeatures = rearCameraFeatures.Select(f => new CameraFeature { Name = Converters.FormatName(f) }).ToList();
            resultDevice.CameraInfo.FrontCameraFeatures = frontCameraFeatures.Select(f => new CameraFeature { Name = Converters.FormatName(f) }).ToList();
        }
        private void SetCameraVideoModes() {
            if (string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Video) && string.IsNullOrWhiteSpace(inputDevice.Detail.SelfieCamera?.Video)) return;

            var videoModes = new List<VideoMode>();
            var features = new List<string>();
            for (var j = 0; j < 2; j++) {
                var sides = new List<string[]>();
                sides.Add(string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Video) ? new string[] { } : inputDevice.Detail.MainCamera.Video.Split(','));
                sides.Add(string.IsNullOrWhiteSpace(inputDevice.Detail.SelfieCamera?.Video) ? new string[] { } : inputDevice.Detail.SelfieCamera.Video.Split(','));

                foreach (var value in sides[j]) {
                    var match = Regex.Match(value, @"^ ?(?:(cif|qcif|scif|sqcif|svga|vga|yes|no)?(?:(\d+)x(\d+))?(?:w?([\d\/p]+(?!\d*fps|x|\d*-)))?(?:@?([\d\/~-]+)f?ps)?)", RegexOptions.IgnoreCase);

                    var widths = new List<int?>();
                    var heights = new List<int?>();
                    int?[] frameRates = null;
                    if (!string.IsNullOrWhiteSpace(match.Groups[1].Value)) {
                        var resolution = Converters.ConvertNameToResolution(match.Groups[1].Value.ToLowerInvariant());
                        widths.Add(resolution.Width);
                        heights.Add(resolution.Height);
                    } else if (!string.IsNullOrWhiteSpace(match.Groups[2].Value + match.Groups[3].Value)) {
                        widths.Add(int.Parse(match.Groups[2].Value));
                        heights.Add(int.Parse(match.Groups[3].Value));
                    } else if (!string.IsNullOrWhiteSpace(match.Groups[4].Value)) {
                        foreach (var resolutionName in match.Groups[4].Value.Replace("p", "").Split('/')) {
                            var resolution = Converters.ConvertNameToResolution(resolutionName);
                            widths.Add(resolution.Width);
                            heights.Add(resolution.Height);
                        }

                    }

                    if (string.IsNullOrWhiteSpace(match.Groups[5].Value)) {
                        for (var i = 0; i < heights.Count(); i++)
                            videoModes.Add(new VideoMode { Width = widths[i], Height = heights[i], CameraSide = j == 0 ? "rear" : "front" });
                    } else {
                        frameRates = match.Groups[5].Value
                            .Split('/')
                            .Select(f => (int?) int.Parse(f.Split('-').LastOrDefault().Split('~').LastOrDefault())).ToArray();
                        foreach (var frameRate in frameRates) {
                            for (var i = 0; i < heights.Count(); i++)
                                videoModes.Add(new VideoMode { Width = widths[i], Height = heights[i], CameraSide = j == 0 ? "rear" : "front", FrameRate = frameRate });
                        }
                    }

                }
            }

            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Video)) {
                if (inputDevice.Detail.MainCamera.Video.Contains("stereo sound rec", StringComparison.OrdinalIgnoreCase))
                    features.Add("stereo sound recording");
                if (inputDevice.Detail.MainCamera.Video.Contains("gyro-EIS", StringComparison.OrdinalIgnoreCase))
                    features.Add("gyro-EIS");
                if (inputDevice.Detail.MainCamera.Video.Contains("4x lossless digital zoom", StringComparison.OrdinalIgnoreCase))
                    features.Add("4x lossless digital zoom");
                if (inputDevice.Detail.MainCamera.Video.Contains("HDR", StringComparison.OrdinalIgnoreCase))
                    features.Add("HDR");
                if (inputDevice.Detail.MainCamera.Video.Contains("dual video recording", StringComparison.OrdinalIgnoreCase) || inputDevice.Detail.MainCamera.Video.Contains("dual-video rec", StringComparison.OrdinalIgnoreCase))
                    features.Add("dual video recording");
            }

            resultDevice.CameraInfo.VideoModes = videoModes;
            resultDevice.CameraInfo.VideoFeatures = features.Select(f => new CameraFeature { Name = f }).ToList();
        }
        private void SetGpu() {
            if (string.IsNullOrWhiteSpace(inputDevice.Detail.Platform?.Gpu)) return;
            var match = Regex.Match(inputDevice.Detail.Platform.Gpu, @"^([a-zA-Z]+(?: geforce)?)(?:[ -]((?:(?!adreno|vivante|mali|powervr|gpu|hd graphics|graphics)[\w ])*))?", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                resultDevice.Gpu.Name = match.Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(match.Groups[2].Value))
                resultDevice.Gpu.Model = match.Groups[2].Value;
        }
        private void SetCpu() {
            if (!string.IsNullOrWhiteSpace(inputDevice.Overview.Expansion?.Chipset)) {
                var match = Regex.Match(inputDevice.Overview.Expansion.Chipset, @"^(?:([Аa-zA-Z-]{2,})\b)?(?: (?:([a-zA-Z]{3,})\b))?(?: ?(?:([\w+-]+)))?(?: ?(?:([\w+-]+)))?(?: ?(?:([\w+-]+)))?");
                string name = null;
                string series = null;
                string producer = null;
                string model = null;
                if (match.Success) {
                    if (match.Groups[1].Value.Equals("apple", StringComparison.OrdinalIgnoreCase)) {
                        producer = "Apple";
                        series = match.Groups[3].Value.FirstOrDefault().ToString();
                        model = "Apple " + match.Groups[3].Value;
                        if (!string.IsNullOrWhiteSpace(match.Groups[4].Value))
                            model += $" {match.Groups[4].Value}";
                    } else if (match.Groups[1].Value.Equals("exynos", StringComparison.OrdinalIgnoreCase)) {
                        producer = "Samsung";
                        name = "Exynos";
                        model = string.IsNullOrWhiteSpace(match.Groups[4].Value) ?
                            match.Groups[3].Value :
                            match.Groups[3].Value + " " + match.Groups[4].Value;
                    } else if (match.Groups[1].Value.Equals("helio", StringComparison.OrdinalIgnoreCase) || Regex.IsMatch(inputDevice.Overview.Expansion.Chipset, @"mt\w+", RegexOptions.IgnoreCase)) {
                        var mediatekMatch = Regex.Match(inputDevice.Overview.Expansion.Chipset, @"^(?:mediatek)?(?: ?(?:(mt[\w+-]+)))?(?: or.*)?(?: ?(?:([\w+-]+)))?(?: ?(?:([\w+-]+)))?", RegexOptions.IgnoreCase);
                        producer = "Mediatek";
                        model = string.IsNullOrWhiteSpace(mediatekMatch.Groups[1].Value) ? null : mediatekMatch.Groups[1].Value;
                        model = model != null ? model : (string.IsNullOrWhiteSpace(mediatekMatch.Groups[3].Value) ? null : mediatekMatch.Groups[3].Value);
                        name = string.IsNullOrWhiteSpace(mediatekMatch.Groups[2].Value) ?
                            null :
                            $"{mediatekMatch.Groups[2].Value} {mediatekMatch.Groups[3]}".Trim();
                        series = string.IsNullOrWhiteSpace(mediatekMatch.Groups[2].Value) ? null : mediatekMatch.Groups[2].Value;
                    } else if (match.Groups[1].Value.Equals("hisilicon", StringComparison.OrdinalIgnoreCase) || match.Groups[1].Value.Equals("huawei", StringComparison.OrdinalIgnoreCase)) {
                        producer = "HiSilicon";
                        series = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? null : match.Groups[2].Value;
                        model = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? null : match.Groups[3].Value;
                    } else if (match.Groups[1].Value.Equals("intel", StringComparison.OrdinalIgnoreCase)) {
                        producer = "Intel";
                        series = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? null : match.Groups[2].Value;
                        model = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? null : match.Groups[3].Value;
                    } else if (Regex.IsMatch(inputDevice.Overview.Expansion.Chipset, @"^(?:snapdragon|qualcomm|apq|esc|esm|msm|qsc)", RegexOptions.IgnoreCase)) {
                        var qualcommMatch = Regex.Match(inputDevice.Overview.Expansion.Chipset, @"^(?:snapdragon|qualcomm)?(?: ?(?:((?:[\w+-]+ ?){0,2})))?", RegexOptions.IgnoreCase);
                        producer = "Qualcomm";
                        name = inputDevice.Overview.Expansion.Chipset.Contains("snapdragon", StringComparison.OrdinalIgnoreCase) ? "Snapdragon" : null;
                        model = string.IsNullOrWhiteSpace(qualcommMatch.Groups[1].Value) ? null : qualcommMatch.Groups[1].Value.Trim();
                    } else if (match.Groups[1].Value.Contains("spreadtrum", StringComparison.OrdinalIgnoreCase)) {
                        producer = "Spreadtrum";
                        model = !string.IsNullOrWhiteSpace(match.Groups[3].Value) ?
                            match.Groups[3].Value :
                            (!string.IsNullOrWhiteSpace(match.Groups[2].Value) ? match.Groups[2].Value : null);
                    } else if (match.Groups[1].Value.Equals("nvidia", StringComparison.OrdinalIgnoreCase)) {
                        var nvidiaMatch = Regex.Match(inputDevice.Overview.Expansion.Chipset, @"^nvidia (?:([a-zA-Z]+\b) ?)?(?:([\w]{1,3}\b) ?)?(?:([\w ]+\b) ?)?", RegexOptions.IgnoreCase);
                        producer = "NVIDIA";
                        series = string.IsNullOrWhiteSpace(nvidiaMatch.Groups[1].Value) ? null : nvidiaMatch.Groups[1].Value;
                        model = string.IsNullOrWhiteSpace(nvidiaMatch.Groups[3].Value) ? null : nvidiaMatch.Groups[3].Value;

                    }

                    resultDevice.Cpu.Model = model;
                    resultDevice.Cpu.Name = name;
                    resultDevice.Cpu.Producer = producer;
                    resultDevice.Cpu.Series = series;
                }
            }
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.Platform?.Cpu)) {
                var match = Regex.Match(inputDevice.Detail.Platform.Cpu, @"^(dual|triple|quad|hexa|octa|deca)?", RegexOptions.IgnoreCase);
                int? cores = null;
                switch (match.Groups[1].Value.ToLowerInvariant()) {
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
                resultDevice.Cpu.Cores = cores;
            }

        }
        private void SetWlan() {
            var features = new List<string>();
            var standards = new List<string>();
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.Comms?.Wlan)) {
                var match = Regex.Match(inputDevice.Detail.Comms.Wlan, @"^wi-fi( 802\.11)?,? ?(?:([bgnacdfhiqxyerk\/]+)\b)?(?: ?, ?((?:[a-zA-Z0-9\. -]+\b[,;\/]? )+))?", RegexOptions.IgnoreCase);
                if (match.Groups[2].Success) {
                    standards = match.Groups[2].Value.Split('/').ToList();
                    if (match.Groups[3].Success) {
                        features = match.Groups[3].Value
                            .Replace(";", ",")
                            .Replace("/", ",")
                            .Split(",")
                            .Select(f => f.Trim())
                            .Where(f => !string.IsNullOrWhiteSpace(f))
                            .OrderBy(f => f)
                            .ToList();
                    }
                    resultDevice.Communication.Wlan.Available = true;
                } else
                    resultDevice.Communication.Wlan.Available = inputDevice.Detail.Comms.Wlan.Equals("yes", StringComparison.OrdinalIgnoreCase) ?
                    true :
                    (inputDevice.Detail.Comms.Wlan.Equals("false", StringComparison.OrdinalIgnoreCase) ?
                        false :
                        default(bool));
            }
            resultDevice.Communication.Wlan.Features = features.Select(f => new WlanFeature { Name = f }).ToList();
            resultDevice.Communication.Wlan.Standards = standards.Select(f => new WlanStandard { Name = f }).ToList();
        }
        private void SetAudioJack() {
            if (string.IsNullOrWhiteSpace(inputDevice.Detail.Sound?.The3_5MmJack)) return;
            if (inputDevice.Detail.Sound.The3_5MmJack.Contains("yes", StringComparison.OrdinalIgnoreCase))
                resultDevice.Communication.AudioJack = true;
            else if (inputDevice.Detail.Sound.The3_5MmJack.Contains("no", StringComparison.OrdinalIgnoreCase))
                resultDevice.Communication.AudioJack = false;
        }
        private void SetSensors() {
            var sensors = new List<string>();
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.Features?.Sensors)) {
                if (inputDevice.Detail.Features.Sensors.Contains("accelerometer", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("accelerometer");
                if (inputDevice.Detail.Features.Sensors.Contains("altmeter", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("altmeter");
                if (inputDevice.Detail.Features.Sensors.Contains("barometer", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("barometer");
                if (inputDevice.Detail.Features.Sensors.Contains("compass", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("compass");
                if (inputDevice.Detail.Features.Sensors.Contains("color spectrum", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("spectrum");
                if (inputDevice.Detail.Features.Sensors.Contains("face id", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("face id");
                if (inputDevice.Detail.Features.Sensors.Contains("fingerprint", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("fingerprint");
                if (inputDevice.Detail.Features.Sensors.Contains("gesture", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("gesture");
                if (inputDevice.Detail.Features.Sensors.Contains("gyro", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("gyro");
                if (inputDevice.Detail.Features.Sensors.Contains("heart rate", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("rate");
                if (inputDevice.Detail.Features.Sensors.Contains("humidity", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("humidity");
                if (inputDevice.Detail.Features.Sensors.Contains("infrared face recognition", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("infrared face recognition");
                if (inputDevice.Detail.Features.Sensors.Contains("iris scanner", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("scanner");
                if (inputDevice.Detail.Features.Sensors.Contains("proximity", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("proximity");
                if (inputDevice.Detail.Features.Sensors.Contains("sensor core", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("core");
                if (inputDevice.Detail.Features.Sensors.Contains("spo2", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("spo2");
                if (inputDevice.Detail.Features.Sensors.Contains("temperature", StringComparison.OrdinalIgnoreCase) ||
                    inputDevice.Detail.Features.Sensors.Contains("thermometer", StringComparison.OrdinalIgnoreCase))
                    sensors.Add("thermometer");
            }
            resultDevice.Communication.Sensors = sensors.Select(f => new Sensor { Name = f }).ToList();
        }
        private void SetStatus() {
            var match = Regex.Match(inputDevice.Detail.Launch.Status, @"^(?:(available|cancelled|coming soon|discontinued))", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                resultDevice.Status.CurrentStatus = match.Groups[1].Value.ToLowerInvariant();
        }
        private void SetDisplay() {
            if (string.IsNullOrWhiteSpace(inputDevice.Detail.Display?.Type)) return;
            var match = Regex.Match(inputDevice.Detail.Display.Type, @"(?:(\b[\d]+)([mk ]) ?(?:colors)? ?)(?:\(([\d]+)([mk])? effective)?", RegexOptions.IgnoreCase);
            string displayColorMode = null;
            string touchscreen = null;
            int? colors = null;
            int? effectiveColors = null;
            var multiplier = 1;

            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value) && int.TryParse(match.Groups[1].Value, out var result)) {
                multiplier = match.Groups[2].Value.ToLowerInvariant() == "m" ? 1000000 : match.Groups[2].Value.ToLowerInvariant() == "k" ? 1000 : 1;
                colors = result == 0 ? default(int?) : result * multiplier;
                resultDevice.Display.Colors = colors;
            }
            if (!string.IsNullOrWhiteSpace(match.Groups[3].Value) && int.TryParse(match.Groups[3].Value, out result)) {
                multiplier = match.Groups[4].Value.ToLowerInvariant() == "m" ? 1000000 : match.Groups[4].Value.ToLowerInvariant() == "k" ? 1000 : 1;
                effectiveColors = result == 0 ? default(int?) : result * multiplier;
                resultDevice.Display.EffectiveColors = effectiveColors;
            }
            match = Regex.Match(inputDevice.Detail.Display.Type, @"(?:(mono|gray|grey|single|\bcolor\b)[a-zA-Z ,]*)", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value)) {
                displayColorMode = match.Groups[1].Value.ToLowerInvariant();
            }
            if ((displayColorMode == "mono" && colors != null) || displayColorMode == "gray" || displayColorMode == "grey")
                displayColorMode = "grayscale";
            if (displayColorMode == null && colors > 16)
                displayColorMode = "color";
            if (displayColorMode == "single")
                displayColorMode = "mono";
            resultDevice.Display.ColorMode = displayColorMode;
            if (inputDevice.Detail.Display.Type == "Capacitive touchscreen") { }
            if (inputDevice.Detail.Display.Type.Contains("touch", StringComparison.OrdinalIgnoreCase)) touchscreen = "yes";
            if (inputDevice.Detail.Display.Type.Contains("resistive", StringComparison.OrdinalIgnoreCase)) touchscreen = "resistive";
            if (inputDevice.Detail.Display.Type.Contains("capacitive", StringComparison.OrdinalIgnoreCase)) touchscreen = "capacitive";
            resultDevice.Display.Touchscreen = touchscreen;
            match = Regex.Match(inputDevice.Detail.Display.Type, @"^(lcd|oled|cstn|grayscale lcd|tft|fstn)?(?:([3a-zA-Z][\w +-]*?)(?:grap|capac|resist|touch|toch|,|\())?", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                resultDevice.Display.Type = match.Groups[1].Value.Trim();
            if (!string.IsNullOrWhiteSpace(match.Groups[2].Value) && !match.Groups[2].Value.Contains("capacitive", StringComparison.OrdinalIgnoreCase))
                resultDevice.Display.Type = match.Groups[2].Value.Trim();
        }
        private void SetGps() {
            if (string.IsNullOrWhiteSpace(inputDevice.Detail.Comms?.Gps)) return;
            var match = Regex.Match(inputDevice.Detail.Comms.Gps, @"^(?:(yes|no)[,;]? ?)?(?:with(?: dual-band)? ?)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?(?:(a-gps|b-gps|s-gps|glonass|galileo|bds|bds2|beidou|qzss|gnss|sbas)[,; ]*)?", RegexOptions.IgnoreCase);
            var gps = string.IsNullOrWhiteSpace(match.Groups[1].Value) ? null : match.Groups[1].Value.ToLowerInvariant();
            var features = match.Groups
                .Skip(2)
                .Where(g => !string.IsNullOrWhiteSpace(g.Value))
                .Select(g => g.Value);
            resultDevice.Communication.Gps.Available = gps == "yes" ? true : gps == "no" ? false : default(bool?);
            resultDevice.Communication.Gps.Features = features.Select(f => new GpsFeature { Name = f }).ToList();

        }
        private void SetCameraResolution() {
            // double? photoResoluton = null;
            // double? videoResoluton = null;
            if (!string.IsNullOrWhiteSpace(inputDevice.Overview.Camera?.Photo) && double.TryParse(Regex.Replace(inputDevice.Overview.Camera.Photo, @"[^0-9\.]", ""), out var photoResolution))
                resultDevice.CameraInfo.PhotoResolution = photoResolution >= 0 ? photoResolution : default(double?);
            if (!string.IsNullOrWhiteSpace(inputDevice.Overview.Camera?.Video) && int.TryParse(Regex.Replace(inputDevice.Overview.Camera.Video, @"[^0-9\.]", ""), out var videoResolution))
                resultDevice.CameraInfo.VideoResolution = videoResolution > 0 || videoResolution < 10000 ? videoResolution : default(int?);
        }
        private void SetColors() {
            var match = Regex.Match(inputDevice.Detail.Misc.Colors, @"^\(?(?:[\d]+[ -]+)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?(?:[\( ]*((?:(?! and)[a-zA-Z \.\/&\+-])*)(?:[,;\(\) ]|and ?)*)?", RegexOptions.IgnoreCase);
            var colors = match.Groups.Select(g => g.Value).Skip(1).ToList();
            colors = colors.Where(c => !string.IsNullOrWhiteSpace(c)).ToList();
            // if (colors.Count() == 0) return;
            // colors.Remove(c => p.Contains("model")))
            resultDevice.Build.Colors = colors.Select(c => new DeviceColor { Name = c }).ToList();

        }
        private void SetPrice() {

            double? price = null;
            string currency = null;
            double? priceInEuro = null;
            if (string.IsNullOrWhiteSpace(inputDevice.Detail.Misc.Price)) return;
            var match = Regex.Match(inputDevice.Detail.Misc.Price, @"^(?:About )([\d.]+) (\w+)", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value) && double.TryParse(match.Groups[1].Value, out var result)) {
                price = result;
                currency = match.Groups[2].Value;
                double priceMultiplier = 1;
                switch (currency) {
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
            resultDevice.Price.Value = price;
            resultDevice.Price.Currency = currency;
            resultDevice.Price.EstimatedInEuro = priceInEuro;
        }
        private void SetOs() {
            string os = null;
            string osFlavor = null;
            string osVersion = null;
            string osVersionName = null;
            string osLatestVersion = null;
            string osFlavorVersion = null;

            if (inputDevice.Overview.GeneralInfo.Os.Contains("android", StringComparison.OrdinalIgnoreCase)) {
                var match = Regex.Match(inputDevice.Overview.GeneralInfo.Os, @"^(?:(?:customized )?android(?: wear,?)?(?: os)? ?)(?:([\d\.x]+)(?:[ a-zA-Z]*)\/?,? ?)?(?:([\d\.]+),? ?)?(?:(?:up(?:grad[аa]ble)? to (?:android )?([\d\.]+)(?:[a-zA-Z ]*))?)?(?:not up to [\d\.]+)?(?:planned upgrade to (?:android )?([\d\.]+))?(?:; )*(?:([a-zA-z ]+)([\d\.]+)?)?", RegexOptions.IgnoreCase);
                os = inputDevice.Overview.GeneralInfo.Os.Contains("android wear", StringComparison.OrdinalIgnoreCase) ? "android wear" : "android";
                osVersion = string.IsNullOrWhiteSpace(match.Groups[1].Value) ? null : match.Groups[1].Value;
                osFlavor = string.IsNullOrWhiteSpace(match.Groups[5].Value) ? null : match.Groups[5].Value.Trim();
                osFlavorVersion = string.IsNullOrWhiteSpace(match.Groups[6].Value) ? null : match.Groups[6].Value;
                osVersion = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? osVersion : match.Groups[2].Value;
                osLatestVersion = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? null : match.Groups[3].Value;
            } else if (Regex.Match(inputDevice.Overview.GeneralInfo.Os, @"(?:\bios\b|watchos)", RegexOptions.IgnoreCase).Success) {
                var match = Regex.Match(inputDevice.Overview.GeneralInfo.Os, @"^(ios|watchos) ?(?:([\d\.]+))?(?:,? ?up to )(?:ios )?([\d\.]+)", RegexOptions.IgnoreCase);
                os = string.IsNullOrWhiteSpace(match.Groups[1].Value) ? null : match.Groups[1].Value;
                osVersion = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? null : match.Groups[2].Value;
                osLatestVersion = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? null : match.Groups[3].Value;
            }

            resultDevice.OperatingSystem.Name = os;
            resultDevice.OperatingSystem.Version = osVersion;
            resultDevice.OperatingSystem.LatestVersion = osLatestVersion ?? osVersion;
            resultDevice.OperatingSystem.FlavorName = osFlavor;
            resultDevice.OperatingSystem.FlavorVersion = osFlavorVersion;
            if (!string.IsNullOrWhiteSpace(resultDevice.OperatingSystem.LatestVersion)) {
                var versionMatch = Regex.Match(resultDevice.OperatingSystem.LatestVersion, @"^(\d)(\.\d)?");
                var simpleVersion = versionMatch.Groups[1].Value + versionMatch.Groups[2].Value;
                switch (simpleVersion) {
                    case "1.1":
                        osVersionName = "Petit Four";
                        break;
                    case "1.5":
                        osVersionName = "Cupcake";
                        break;
                    case "1.6":
                        osVersionName = "Donut";
                        break;
                    case "2":
                    case "2.0":
                    case "2.1":
                        osVersionName = "Éclair";
                        break;
                    case "2.2":
                        osVersionName = "Froyo";
                        break;
                    case "2.3":
                        osVersionName = "Gingerbread";
                        break;
                    case "2.4":
                    case "3":
                    case "3.0":
                    case "3.1":
                    case "3.2":
                        osVersionName = "Honeycomb";
                        break;
                    case "4":
                    case "4.0":
                        osVersionName = "Ice Cream Sandwich";
                        break;
                    case "4.1":
                    case "4.2":
                    case "4.3":
                        osVersionName = "Jelly Bean";
                        break;
                    case "4.4":
                        osVersionName = "KitKat";
                        break;
                    case "5":
                    case "5.0":
                    case "5.1":
                    case "5.2":
                        osVersionName = "Lollipop";
                        break;
                    case "6":
                    case "6.0":
                    case "6.1":
                        osVersionName = "Marshmallow";
                        break;
                    case "7":
                    case "7.0":
                    case "7.1":
                        osVersionName = "Nougat";
                        break;
                    case "8":
                    case "8.0":
                    case "8.1":
                        osVersionName = "Oreo";
                        break;
                    case "9":
                    case "9.0":
                    case "9.1":
                        osVersionName = "Pie";
                        break;
                    default:
                        break;
                }
                resultDevice.OperatingSystem.VersionName = osVersionName;
            }
        }
        private void SetUsb() {
            if (string.IsNullOrWhiteSpace(inputDevice.Detail.Comms?.Usb)) return;
            string version = null;
            string connector = null;
            var features = new List<string>();
            var match = Regex.Match(inputDevice.Detail.Comms.Usb, @"^(?:(\d\.\d),? ?)?(?:(?!usb host|usb on-the-go)(miniusb|microusb|type-c|usb|proprietary|pop-port) ?(\d\.\d)?[,;]? ?)?(?:revers[\w ]+[,;]?\s)?(?: ?\(((?:mhl|slimport))? ?.*\),? ?)?(?:(usb host)?,? ?(usb (?:on-the-go|otg))?[;,]? ?(magnetic connector)?)?", RegexOptions.IgnoreCase);
            if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                version = match.Groups[1].Value;
            if (version == null && !string.IsNullOrWhiteSpace(match.Groups[3].Value))
                version = match.Groups[3].Value;

            resultDevice.Communication.Usb.Version = version;
            if (!string.IsNullOrWhiteSpace(match.Groups[2].Value))
                connector = match.Groups[2].Value.ToLowerInvariant();
            resultDevice.Communication.Usb.Connector = connector == "usb" ? null : connector;

            if ($"{match.Groups[4].Value}{match.Groups[5].Value}{match.Groups[6].Value}{match.Groups[7].Value}" != "")
                features = new List<string>();

            if (!string.IsNullOrWhiteSpace(match.Groups[4].Value)) features.Add(match.Groups[4].Value);
            if (!string.IsNullOrWhiteSpace(match.Groups[5].Value)) features.Add(match.Groups[5].Value);
            if (!string.IsNullOrWhiteSpace(match.Groups[6].Value)) features.Add(match.Groups[6].Value);
            if (!string.IsNullOrWhiteSpace(match.Groups[7].Value)) features.Add(match.Groups[7].Value);
            resultDevice.Communication.Usb.Features = features.Select(f => new UsbFeature { Name = f }).ToList();

        }
        private void SetMemory() {
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.Memory?.Internal)) {
                int? internalMemory = null;
                int? readOnlyMemory = null;
                int multiplier = 1;

                var match = Regex.Match(inputDevice.Detail.Memory.Internal, @"^(?:\d*\/)*(?:\d+ ?[KMG]B ram[,;] )?(?:(\d+\.?[\d]*) ?([KMGT])B(?! ram| flash| rom))?", RegexOptions.IgnoreCase);
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value)) {
                    var rawMemory = "";
                    var unit = "";
                    rawMemory = match.Groups[1].Value;
                    unit = match.Groups[2].Value.ToUpperInvariant();
                    multiplier = unit == "K" ? 1 : (unit == "M" ? 1024 : (unit == "G" ? 1048576 : 1073741824));
                    internalMemory = int.TryParse(rawMemory, out int result) ? result : default(int?);
                    internalMemory *= multiplier;
                }
                match = Regex.Match(inputDevice.Detail.Memory.Internal, @"(\d+\.?[\d]*) ?([KMGT])B ROM", RegexOptions.IgnoreCase);
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value)) {
                    var rawMemory = "";
                    var unit = "";
                    rawMemory = match.Groups[1].Value;
                    unit = match.Groups[2].Value;
                    multiplier = unit == "K" ? 1 : (unit == "M" ? 1024 : (unit == "G" ? 1048576 : 1073741824));
                    readOnlyMemory = int.TryParse(rawMemory, out int result) ? result : default(int?);
                    readOnlyMemory *= multiplier;
                }
                resultDevice.Memory.Internal = internalMemory;
                resultDevice.Memory.ReadOnly = readOnlyMemory;
            }
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.Memory?.CardSlot)) {
                var match = Regex.Match(inputDevice.Detail.Memory.CardSlot, @"^(?:(memory stick(?: (?:duo(?: pro)?|micro))?|microsd|micrommc|\bmicro\b|minisd|mmc-micro|mmc|nm|rs-mmc|rs-dv-mmc|sdio|sd|yes|no))(?:\/(memory stick(?: (?:duo(?: pro)?|micro))?|microsd|micrommc|\bmicro\b|minisd|mmc-micro|mmc|nm|rs-mmc|rs-dv-mmc|sdio|sd|yes|no))?(?:.*?up to (\d+) ?([mgt])b)?", RegexOptions.IgnoreCase);
                string cardType = null;
                var multiplier = 1;
                int? maxSize = null;
                string unit = "";
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    cardType = match.Groups[1].Value;
                if (cardType != null && !string.IsNullOrWhiteSpace(match.Groups[2].Value))
                    cardType += "/" + match.Groups[2].Value;
                if (!string.IsNullOrWhiteSpace(match.Groups[3].Value + match.Groups[4].Value) && int.TryParse(match.Groups[3].Value, out var result)) {
                    unit = match.Groups[4].Value.ToLowerInvariant();
                    multiplier = unit == "m" ? 1 : (unit == "g" ? 1024 : 1048576);
                    maxSize = result * multiplier;
                }
                resultDevice.Memory.CardType = cardType;
                resultDevice.Memory.CardMaxSize = maxSize;
            }
        }
        private void SetSimCard() {
            string sim1 = null;
            string sim2 = null;
            string sim3 = null;
            string sim4 = null;
            var match = Regex.Match(inputDevice.Detail.Body.Sim, @"^(?:hybrid )?" +
                @"((?:yes|pre|non|electronic|esim|single|dual|triple|quad|nano|mini|micro))?" +
                @"(?:-sim,? ?(?:card)? ?&? ?(e)(?:sime|lectronic)?)?[\w ]*,? ?(?:\(?((?:e|mini|micro|nano))[- ]?sim)? ?" +
                @"[\/,&]*(?:and)? ?(?:(?:((?:e|mini|micro|nano))[- ]?sim)?)?", RegexOptions.IgnoreCase);
            switch (match.Groups[1].Value.ToLowerInvariant()) {
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

            if (sim1 != null) {
                resultDevice.Communication.SimCards = new List<SimCard>();
                resultDevice.Communication.SimCards.Add(new SimCard { Type = sim1 });
                if (sim2 != null) resultDevice.Communication.SimCards.Add(new SimCard { Type = sim2 });
                if (sim3 != null) resultDevice.Communication.SimCards.Add(new SimCard { Type = sim3 });
                if (sim4 != null) resultDevice.Communication.SimCards.Add(new SimCard { Type = sim4 });
            }
        }
        private void SetBuildMaterials() {
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.Body?.Build)) {
                string frontAndBackMaterial = null;
                string frontMaterial = null;
                string backMaterial = null;
                string frameMaterial = null;
                string bodyMaterial = null;

                var match = Regex.Match(inputDevice.Detail.Body.Build, @"front\/back ([\w \(\)\/]*),?", RegexOptions.IgnoreCase);
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    frontAndBackMaterial = match.Groups[1].Value.Trim();
                resultDevice.Build.Material.Front = frontAndBackMaterial;
                resultDevice.Build.Material.Back = frontAndBackMaterial;

                if (string.IsNullOrWhiteSpace(frontAndBackMaterial)) {
                    match = Regex.Match(inputDevice.Detail.Body.Build, @"front ([\w \(\)&]*),?", RegexOptions.IgnoreCase);
                    if (!string.IsNullOrWhiteSpace(match.Groups[1].Value)) {
                        frontMaterial = match.Groups[1].Value.Trim();
                    }
                    resultDevice.Build.Material.Front = frontMaterial;
                    match = Regex.Match(inputDevice.Detail.Body.Build, @"([\w \(\)\/-]*)? ?back ?([\w \(\)\/]*)?,?", RegexOptions.IgnoreCase);
                    if (match.Groups[1].Success || match.Groups[2].Success) {
                        var choseSecond = match.Groups[1].Value.Contains("Front") ||
                            match.Groups[1].Value.Contains("front") ||
                            match.Groups[1].Value.Length < match.Groups[2].Value.Length;
                        backMaterial = choseSecond ? match.Groups[2].Value : match.Groups[1].Value.Trim();
                        backMaterial = backMaterial.Contains("case/") ? backMaterial.Substring(0, backMaterial.Length - 6) : backMaterial;
                    }
                    match = Regex.Match(inputDevice.Detail.Body.Build, @"([\w \(\)&]*) frame & back", RegexOptions.IgnoreCase);
                    if (!string.IsNullOrWhiteSpace(match.Groups[1].Value)) {
                        backMaterial = match.Groups[1].Value.Trim();
                        frameMaterial = match.Groups[1].Value.Trim();
                    }
                    resultDevice.Build.Material.Back = string.IsNullOrWhiteSpace(backMaterial) || backMaterial.Contains("and") || backMaterial.Contains("128/8 GB model") ? null : backMaterial;
                }
                match = Regex.Match(inputDevice.Detail.Body.Build, @"([\w\ ]+)\s*frame");
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value))
                    frameMaterial = match.Groups[1].Value.Trim();
                resultDevice.Build.Material.Frame = frameMaterial;

                match = Regex.Match(inputDevice.Detail.Body.Build, @"([\w ]+) (?:uni)?body", RegexOptions.IgnoreCase);
                if (!string.IsNullOrWhiteSpace(match.Groups[1].Value)) {
                    bodyMaterial = match.Groups[1].Value;
                    if (bodyMaterial.Contains("urved")) bodyMaterial = null;
                }
                resultDevice.Build.Material.Body = bodyMaterial;
            }
        }
        private void SetDimensions() {
            var match = Regex.Match(inputDevice.Detail.Body.Dimensions, @"^(?:Unfolded:\s)?" +
                @"(?:([\d\.]+)\s*x\s*([\d\.]+)\s*x\s*([\d\.]+)\s*mm,?\s*)?(?:([\d\.]+)\s?cc)?");
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
            resultDevice.Build.Dimension.Height = height;
            resultDevice.Build.Dimension.Width = width;
            resultDevice.Build.Dimension.Thickness = thickness;
            resultDevice.Build.Dimension.Volume = volume;
        }
        private void SetWeight() {
            var match = Regex.Match(inputDevice.Detail.Body.Weight, @"^(?:From\s*)?(?:~\s*)?(?:([\d\.]+)\s*,?\s*g?\s*)?(?:([\d\.]+)\s?cc)?");
            double? weight = null;
            if (double.TryParse(match.Groups[1].Value, out var result))
                weight = result;
            resultDevice.Build.Weight = weight;
        }
        private void SetDisplayResolution() {
            if (inputDevice.Overview.Display.Resolution == null)
                return;
            var match = Regex.Match(inputDevice.Overview.Display.Resolution, @"^(?:up to )?(?:(\d\d+)\s?x(\d\d+)" +
                @"\s*(?:pixels)?,?\s*)?(?:(\d+)\s+lines)?(?:\d+\s?x\d+\s*chars)?");
            int? width = null;
            int? height = null;
            int? lines = null;
            if (int.TryParse(match.Groups[1].Value, out var result))
                width = result;
            if (int.TryParse(match.Groups[2].Value, out result))
                height = result;
            if (int.TryParse(match.Groups[3].Value, out result))
                lines = result;

            resultDevice.Display.ResolutionWidth = width;
            resultDevice.Display.ResolutionHeight = height;
            resultDevice.Display.ResolutionLines = lines;
        }
        private void SetDisplayPixelDensityAndRatio() {
            var match = Regex.Match(inputDevice.Detail.Display.Resolution, @"(?:([\d\.]+):([\d\.]+)\sratio\s?)?" +
                @"(?:\(.(\d+)\sppi(?:\s?pixel)?\sdensity\))?$");
            double? widthRatio = null;
            double? heightRatio = null;
            double? density = null;
            if (double.TryParse(match.Groups[1].Value, out var result)) {
                widthRatio = result;
            }
            if (double.TryParse(match.Groups[2].Value, out result)) {
                heightRatio = result;
            }
            if (double.TryParse(match.Groups[3].Value, out result)) {
                density = result;
            }
            resultDevice.Display.PixelDensity = density;
            resultDevice.Display.WidthRatio = widthRatio;
            resultDevice.Display.HeightRatio = heightRatio;
        }
        public void SetScreenSize() {
            var match = Regex.Match(inputDevice.Detail.Display.Size, @"^(\d+\.?\d*) inches,?\s?(?:-,\s)?(?:\d*\.\d*, )?" +
                @"(?:([\d\.]+\sx\s+[\d\.]+)\smm,?\s)?(?:(\d+\.?\d*)\scm2\s?)?(?:\(~?([\d\.]+)%.*\))?");
            double? size = null;
            double? area = null;
            double? screenToBodyRatio = null;
            if (double.TryParse(match.Groups[1].Value, out var result))
                size = result;
            if (double.TryParse(match.Groups[3].Value, out result))
                area = result;
            if (double.TryParse(match.Groups[4].Value, out result))
                screenToBodyRatio = result;
            resultDevice.Display.Diagonal = size;
            resultDevice.Display.Area = area;
            resultDevice.Display.ScreenToBodyRatio = screenToBodyRatio;
        }

        public void SetRam() {
            if (inputDevice.Overview.Expansion?.Ram == null)
                resultDevice.Memory.RandomAccess = null;
            else {
                var match = Regex.Match(inputDevice.Overview.Expansion?.Ram, @"^(\d*\.?\d*)([MG]B)").Groups;
                resultDevice.Memory.RandomAccess = (int) double.Parse(match[1].Value) * (match[2].Value == "GB" ? 1024 : 1);
            }
        }

        private void SetComms() {
            string bluetooth = Regex.Match(inputDevice.Detail.Comms.Bluetooth, @"^[v\.]*((?:\d+.[\dx]+|Yes|yes|no|No))").Groups[1].Value;
            resultDevice.Communication.Bluetooth = string.IsNullOrWhiteSpace(bluetooth) ? null : bluetooth.ToLowerInvariant();
            resultDevice.Communication.Infrared = inputDevice.Detail.Comms.InfraredPort?.ToLowerInvariant().Contains("yes") == true;
            resultDevice.Communication.Nfc = inputDevice.Detail.Comms.Nfc?.ToLowerInvariant().Contains("yes") == true;
        }

        public void SetBattery() {
            if (!string.IsNullOrWhiteSpace(inputDevice.Overview.Battery?.Capacity))
                resultDevice.Battery.Capacity = int.Parse(Regex.Replace(inputDevice.Overview.Battery?.Capacity, "[^0-9+-]", ""));
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.Tests?.BatteryLife))
                resultDevice.Battery.Endurance = int.Parse(Regex.Match(inputDevice.Detail.Tests.BatteryLife, @"(\d)+").Value);
        }

        public void SetDeviceType() {
            var type = inputDevice.DeviceType.ToLowerInvariant().Contains("phone") ? "phone" : "tablet";
            type = inputDevice.DeviceName.ToLower().Contains("watch") ||
                inputDevice.Overview.GeneralInfo.Os.ToLower().Contains("wear") ?
                "smartwatch" : type;
            type = inputDevice.DeviceName == "Haier C300" ||
                inputDevice.DeviceName == "BLU X Link" ||
                inputDevice.DeviceName == "alcatel CareTime" ||
                inputDevice.DeviceName == "Huawei Fit" ||
                inputDevice.DeviceName == "Samsung Serenata" ?
                "smartwatch" : type;
            type = type == "phone" && resultDevice.Display?.Touchscreen != null? "smartphone": type;
            type = inputDevice.DeviceName == "Samsung Serenata" ? "smartphone" : type;
            resultDevice.Basic.DeviceType = type;
        }
        public void SetDates() {
            if (inputDevice.DeviceName == "Sony Ericsson K700")
                Console.WriteLine();
            var match = Regex.Match(inputDevice.Detail.Launch.Status, @"^(?:(?:available|coming soon)\.? ?)?(?:(?:released|exp\. release) (\d{4})(?:, ((?:[a-z]{3,})|(?:Q\d)))?)", RegexOptions.IgnoreCase);
            var released = Converters.ParseDate(match.Groups[1].Value, match.Groups[2].Value);

            match = Regex.Match(inputDevice.Detail.Launch?.Announced, @"^(?:(\d{4})[,]? ?(?:((?:[a-z]{3,})|(?:[\dq ]{2,}\b))?\.? ?)?)(?:(?:(?: exp\. )?released? *)+(\d{4})(?:,? ((?:[a-z]{3,})|(?:[\dq ]{2,}\b)))?)?", RegexOptions.IgnoreCase);
            var announced = Converters.ParseDate(match.Groups[1].Value, match.Groups[2].Value);

            if (released.Year == null) {
                released = Converters.ParseDate(match.Groups[3].Value, match.Groups[4].Value);
                match = Regex.Match(inputDevice.Overview.GeneralInfo.Launched, @"^(?:(?:released ?|exp\. release)+ +(\d{4})(?:[, ]+((?:[a-z]{3,})|(?:[\dq ]{2,}\b)))?)", RegexOptions.IgnoreCase);

                if (released.Year == null)
                    released = Converters.ParseDate(match.Groups[1].Value, match.Groups[2].Value);
            }
            resultDevice.Status.AnnouncedDate = announced;
            resultDevice.Status.ReleasedDate = released;
        }

        private void Debug() {
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Single?.FirstOrDefault()))
                resultDevice.CameraInfo.CameraOriginalText = "Single: " + string.Join("  |  ", inputDevice.Detail.MainCamera.Single);
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Dual?.FirstOrDefault()))
                resultDevice.CameraInfo.CameraOriginalText = "Dual: " + string.Join("  |  ", inputDevice.Detail.MainCamera.Dual);
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Triple?.FirstOrDefault()))
                resultDevice.CameraInfo.CameraOriginalText = "Triple: " + string.Join("  |  ", inputDevice.Detail.MainCamera.Triple);
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Quad?.FirstOrDefault()))
                resultDevice.CameraInfo.CameraOriginalText = "Quad: " + string.Join("  |  ", inputDevice.Detail.MainCamera.Quad);
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.MainCamera?.Five?.FirstOrDefault()))
                resultDevice.CameraInfo.CameraOriginalText = "Five: " + string.Join("  |  ", inputDevice.Detail.MainCamera.Five);
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.SelfieCamera?.Single?.FirstOrDefault()))
                resultDevice.CameraInfo.CameraOriginalText += "||  Front Single: " + string.Join("  |  ", inputDevice.Detail.SelfieCamera.Single);
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.SelfieCamera?.Dual?.FirstOrDefault()))
                resultDevice.CameraInfo.CameraOriginalText += "||  Front Dual: " + string.Join("  |  ", inputDevice.Detail.SelfieCamera.Dual);

            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.Launch.Status))
                resultDevice.Status.DatesOriginalText += "Detail.Launch.Status: " + inputDevice.Detail.Launch.Status;
            if (!string.IsNullOrWhiteSpace(inputDevice.Detail.Launch?.Announced))
                resultDevice.Status.DatesOriginalText += " |  Detail.Launch?.Announced: " + inputDevice.Detail.Launch?.Announced;
            if (!string.IsNullOrWhiteSpace(inputDevice.Overview.GeneralInfo.Launched))
                resultDevice.Status.DatesOriginalText += " |  Overview.GeneralInfo.Launched: " + inputDevice.Overview.GeneralInfo.Launched;
        }
    }
}
