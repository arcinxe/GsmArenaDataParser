# GsmArenaDataParser

This application splits multiple values of of the devices details returned by [GsmArenaDataSucker](https://github.com/arcinxe/GsmArenaDataSucker).

#### Requirements:

* [.NET Core](https://dotnet.microsoft.com/download)

#### Usage

1. Copy result file from [GsmArenaDataSucker](https://github.com/arcinxe/GsmArenaDataSucker) (AllDevicesDetails.json) to the "Results" directory of the parser.

2. Run GsmArenaDataParser

``` bash
cd GsmArenaDataParser
dotnet run
# After about 30 seconds of working all details will be saved in FinalResults.json and FinalResultsWithoutNulls.json files
```

#### Example

The example below shows the capability of this application.
<details>
<summary>Input data</summary> 

``` json
{
    "data": {
        "id": "9536",
        "slug": "samsung_galaxy_s10-9536",
        "brand": "Samsung",
        "device_name": "Samsung Galaxy S10",
        "device_type": "Phone",
        "image_url": "https://fdn2.gsmarena.com/vv/bigpic/samsung-galaxy-s10.jpg",
        "overview": {
            "general_info": {
                "launched": "Released 2019, March",
                "body": "157g, 7.8mm thickness",
                "os": "Android 9.0; One UI",
                "storage": "128/512GB storage, microSD card slot"
            },
            "display": {
                "touchscreen": "Yes",
                "size": "6.1\"",
                "resolution": "1440x3040 pixels"
            },
            "camera": {
                "photo": "16MP",
                "video": "2160p"
            },
            "expansion": {
                "ram": "8GB RAM",
                "chipset": "Exynos 9820"
            },
            "battery": {
                "capacity": "3400mAh",
                "technology": "Li-Ion"
            }
        },
        "detail": {
            "battery": {
                "": "Non-removable Li-Ion 3400 mAh battery",
                "charging": [
                    "Fast battery charging 15W",
                    "Fast wireless charging 15W",
                    "Power bank/Reverse wireless charging 9W"
                ]
            },
            "body": {
                "": [
                    "Samsung Pay (Visa, MasterCard certified)",
                    "IP68 dust/water proof (up to 1.5m for 30 mins)"
                ],
                "build": "Back glass (Gorilla Glass 5), aluminum frame",
                "dimensions": "149.9 x 70.4 x 7.8 mm (5.90 x 2.77 x 0.31 in)",
                "sim": "Single SIM (Nano-SIM) or Hybrid Dual SIM (Nano-SIM, dual stand-by)",
                "weight": "157 g (5.54 oz)"
            },
            "comms": {
                "bluetooth": "5.0, A2DP, LE, aptX",
                "gps": "Yes, with A-GPS, GLONASS, BDS, GALILEO",
                "nfc": "Yes",
                "radio": "FM radio (USA \u0026 Canada only)",
                "usb": "3.1, Type-C 1.0 reversible connector",
                "wlan": "Wi-Fi 802.11 a/b/g/n/ac/ax, dual-band, Wi-Fi Direct, hotspot"
            },
            "display": {
                "": [
                    "HDR10+",
                    "Always-on display"
                ],
                "protection": "Corning Gorilla Glass 6",
                "resolution": "1440 x 3040 pixels, 19:9 ratio (~550 ppi density)",
                "size": "6.1 inches, 93.2 cm2 (~88.3% screen-to-body ratio)",
                "type": "Dynamic AMOLED capacitive touchscreen, 16M colors"
            },
            "features": {
                "": [
                    "ANT+",
                    "Bixby natural language commands and dictation",
                    "Samsung DeX (desktop experience support)"
                ],
                "sensors": "Fingerprint (under display), accelerometer, gyro, proximity, compass, barometer, heart rate, SpO2"
            },
            "launch": {
                "announced": "2019, February",
                "status": "Available. Released 2019, March"
            },
            "main__camera": {
                "features": "LED flash, auto-HDR, panorama",
                "triple": [
                    "12 MP, f/1.5-2.4, 26mm (wide), 1/2.55\", 1.4m, Dual Pixel PDAF, OIS",
                    "12 MP, f/2.4, 52mm (telephoto), 1/3.6\", 1.0m, AF, OIS, 2x optical zoom",
                    "16 MP, f/2.2, 12mm (ultrawide), 1.0m"
                ],
                "video": "2160p@60fps, 1080p@240fps, 720p@960fps, HDR, dual-video rec."
            },
            "memory": {
                "card_slot": "microSD, up to 1 TB (uses shared SIM slot) - dual SIM model only",
                "internal": "128/512 GB, 8 GB RAM"
            },
            "misc": {
                "colors": "Prism White, Prism Black, Prism Green, Prism Blue, Canary Yellow, Flamingo Pink, Cardinal Red, Smoke Blue",
                "models": "SM-G973F, SM-G973U, SM-G973W, SM-G973U1, SM-G9730, SM-G973N",
                "price": "About 660 EUR",
                "sar": [
                    "0.93 W/kg (head)",
                    "0.79 W/kg (body)"
                ],
                "sar_eu": [
                    "0.48 W/kg (head)",
                    "1.59 W/kg (body)"
                ]
            },
            "network": {
                "": "LTE band 1(2100), 2(1900), 3(1800), 4(1700/2100), 5(850), 7(2600), 8(900), 12(700), 13(700), 14(700), 17(700), 18(800), 19(800), 20(800), 25(1900), 26(850), 28(700), 29(700), 30(2300), 38(2600), 39(1900), 40(2300), 41(2500), 46, 66(1700/2100), 71(600) - USA",
                "2g_bands": "GSM 850 / 900 / 1800 / 1900 - SIM 1 \u0026 SIM 2 (dual-SIM model only)",
                "3g_bands": "HSDPA 850 / 900 / 1700(AWS) / 1900 / 2100 - Global, USA",
                "4g_bands": "LTE band 1(2100), 2(1900), 3(1800), 4(1700/2100), 5(850), 7(2600), 8(900), 12(700), 13(700), 17(700), 18(800), 19(800), 20(800), 25(1900), 26(850), 28(700), 32(1500), 38(2600), 39(1900), 40(2300), 41(2500), 66(1700/2100) - Global",
                "speed": "HSPA 42.2/5.76 Mbps, LTE-A (7CA) Cat20 2000/150 Mbps",
                "technology": "GSM / CDMA / HSPA / EVDO / LTE"
            },
            "platform": {
                "chipset": "Exynos 9820 (8 nm) - EMEA/LATAMQualcomm SDM855 Snapdragon 855 (7 nm) - USA/China",
                "cpu": "Octa-core (2x2.73 GHz Mongoose M4 \u0026 2x2.31 GHz Cortex-A75 \u0026 4x1.95 GHz Cortex-A55) - EMEA/LATAMOcta-core (1x2.84 GHz Kryo 485 \u0026 3x2.41 GHz Kryo 485 \u0026 4x1.78 GHz Kryo 485) - USA/China",
                "gpu": "Mali-G76 MP12 - EMEA/LATAM Adreno 640 - USA/China",
                "os": "Android 9.0 (Pie); One UI"
            },
            "selfie_camera": {
                "features": "Dual video call, Auto-HDR",
                "single": "10 MP, f/1.9, 26mm (wide), 1.22m, Dual Pixel PDAF",
                "video": "2160p@30fps, 1080p@30fps"
            },
            "sound": {
                "": [
                    "32-bit/384kHz audio",
                    "Active noise cancellation with dedicated mic",
                    "Dolby Atmos/AKG sound"
                ],
                "3_5mm_jack": "Yes",
                "loudspeaker": "Yes, with stereo speakers"
            },
            "tests": {
                "audio_quality": "Noise -92.2dB / Crosstalk -92.7dB",
                "battery_life": "Endurance rating 79h",
                "camera": "Photo / Video",
                "display": "Contrast ratio: Infinite (nominal), 4.498 (sunlight)",
                "loudspeaker": "Voice 82dB / Noise 74dB / Ring 85dB",
                "performance": "Basemark OS II: 4539 / Basemark OS II 2.0: 4465Basemark X: 44097"
            }
        }
    },
    "error": null
}   
```

</details>

<details>
<summary>Parsed parameters</summary> 

``` json
{
    "Brand": "Samsung",
    "Name": "Samsung Galaxy S10",
    "Basic": {
      "GsmArenaId": 9536,
      "Slug": "samsung_galaxy_s10-9536",
      "ImageUrl": "https://fdn2.gsmarena.com/vv/bigpic/samsung-galaxy-s10.jpg",
      "DeviceType": "smartphone"
    },
    "Status": {
      "CurrentStatus": "available",
      "AnnouncedDate": {
        "Year": 2019,
        "Month": 2,
        "Quarter": null
      },
      "ReleasedDate": {
        "Year": 2019,
        "Month": 3,
        "Quarter": null
      }
    },
    "Battery": {
      "Capacity": 3400,
      "Technology": "Li-Ion",
      "Endurance": 79
    },
    "Display": {
      "ResolutionWidth": 1440,
      "ResolutionHeight": 3040,
      "ResolutionLines": null,
      "PixelDensity": 550.0,
      "WidthRatio": 19.0,
      "HeightRatio": 9.0,
      "Diagonal": 6.1,
      "Area": 93.2,
      "ScreenToBodyRatio": 88.3,
      "Type": "Dynamic AMOLED",
      "ColorMode": "color",
      "Colors": 16000000,
      "EffectiveColors": null,
      "Touchscreen": "capacitive"
    },
    "Communication": {
      "SimCards": [
        {
          "Type": "nano"
        }
      ],
      "Gps": {
        "Available": true,
        "Features": [
          {
            "Name": "A-GPS"
          },
          {
            "Name": "GLONASS"
          },
          {
            "Name": "BDS"
          },
          {
            "Name": "GALILEO"
          }
        ]
      },
      "Usb": {
        "Version": "3.1",
        "Connector": "type-c",
        "Features": []
      },
      "Wlan": {
        "Available": true,
        "Standards": [
          {
            "Name": "a"
          },
          {
            "Name": "b"
          },
          {
            "Name": "g"
          },
          {
            "Name": "n"
          },
          {
            "Name": "ac"
          },
          {
            "Name": "ax"
          }
        ],
        "Features": [
          {
            "Name": "dual-band"
          },
          {
            "Name": "Wi-Fi Direct"
          }
        ]
      },
      "AudioJack": true,
      "Bluetooth": "5.0",
      "Infrared": false,
      "Nfc": true,
      "Sensors": [
        {
          "Name": "accelerometer"
        },
        {
          "Name": "barometer"
        },
        {
          "Name": "compass"
        },
        {
          "Name": "fingerprint"
        },
        {
          "Name": "gyro"
        },
        {
          "Name": "heart rate"
        },
        {
          "Name": "proximity"
        },
        {
          "Name": "spo2"
        }
      ]
    },
    "Build": {
      "Dimension": {
        "Width": 70.4,
        "Height": 149.9,
        "Thickness": 7.8,
        "Volume": null
      },
      "Material": {
        "Front": null,
        "Back": "glass (Gorilla Glass 5)",
        "Frame": "aluminum",
        "Body": null
      },
      "Weight": 157.0,
      "Colors": [
        {
          "Name": "Prism White"
        },
        {
          "Name": "Prism Black"
        },
        {
          "Name": "Prism Green"
        },
        {
          "Name": "Prism Blue"
        },
        {
          "Name": "Canary Yellow"
        },
        {
          "Name": "Flamingo Pink"
        },
        {
          "Name": "Cardinal Red"
        },
        {
          "Name": "Smoke Blue"
        }
      ]
    },
    "CameraInfo": {
      "PhotoResolution": 16.0,
      "VideoResolution": 2160,
      "VideoModes": [
        {
          "Width": 3840,
          "Height": 2160,
          "FrameRate": 60,
          "CameraSide": "rear"
        },
        {
          "Width": 1920,
          "Height": 1080,
          "FrameRate": 240,
          "CameraSide": "rear"
        },
        {
          "Width": 1280,
          "Height": 720,
          "FrameRate": 960,
          "CameraSide": "rear"
        },
        {
          "Width": 3840,
          "Height": 2160,
          "FrameRate": 30,
          "CameraSide": "front"
        },
        {
          "Width": 1920,
          "Height": 1080,
          "FrameRate": 30,
          "CameraSide": "front"
        }
      ],
      "VideoFeatures": [
        {
          "Name": "HDR"
        },
        {
          "Name": "dual video recording"
        }
      ],
      "FrontCameraLeds": null,
      "RearCameraLeds": 1,
      "RearCameraFeatures": [
        {
          "Name": "HDR"
        },
        {
          "Name": "panorama"
        }
      ],
      "FrontCameraFeatures": [
        {
          "Name": "HDR"
        },
        {
          "Name": "dual video call"
        }
      ],
      "Cameras": [
        {
          "Location": "rear",
          "Resolution": 12.0,
          "OpticalZoom": null,
          "SensorSize": 2.55,
          "FocalLength": 1.4,
          "Aperture": 1.5,
          "Features": [
            {
              "Name": "wide lens"
            },
            {
              "Name": "dual pixel PDAF"
            },
            {
              "Name": "OIS"
            }
          ]
        },
        {
          "Location": "rear",
          "Resolution": 12.0,
          "OpticalZoom": 2,
          "SensorSize": 3.6,
          "FocalLength": 1.0,
          "Aperture": 2.4,
          "Features": [
            {
              "Name": "telephoto lens"
            },
            {
              "Name": "AF"
            },
            {
              "Name": "OIS"
            }
          ]
        },
        {
          "Location": "rear",
          "Resolution": 16.0,
          "OpticalZoom": null,
          "SensorSize": null,
          "FocalLength": 1.0,
          "Aperture": 2.2,
          "Features": [
            {
              "Name": "ultrawide lens"
            }
          ]
        },
        {
          "Location": "front",
          "Resolution": 10.0,
          "OpticalZoom": null,
          "SensorSize": null,
          "FocalLength": 1.22,
          "Aperture": 1.9,
          "Features": [
            {
              "Name": "wide lens"
            },
            {
              "Name": "dual pixel PDAF"
            }
          ]
        }
      ],
      "CameraOriginalText": "Triple: 12 MP, f/1.5-2.4, 26mm (wide), 1/2.55\", 1.4m, Dual Pixel PDAF, OIS  |  12 MP, f/2.4, 52mm (telephoto), 1/3.6\", 1.0m, AF, OIS, 2x optical zoom  |  16 MP, f/2.2, 12mm (ultrawide), 1.0m||  Front Single: 10 MP, f/1.9, 26mm (wide), 1.22m, Dual Pixel PDAF"
    },
    "Memory": {
      "CardType": "microSD",
      "CardMaxSize": 1048576,
      "Internal": 536870912,
      "ReadOnly": null,
      "RandomAccess": 8192
    },
    "Price": {
      "Value": 660.0,
      "Currency": "EUR",
      "EstimatedInEuro": 660.0
    },
    "OperatingSystem": {
      "Name": "android",
      "Version": "9.0",
      "VersionName": "Pie",
      "LatestVersion": "9.0",
      "FlavorName": "One UI",
      "FlavorVersion": null
    },
    "Cpu": {
      "Producer": "Samsung",
      "Name": "Exynos",
      "Series": null,
      "Model": "9820",
      "Cores": 8
    },
    "Gpu": {
      "Name": "Mali",
      "Model": "G76 MP12 "
    }
  }
  ```

</details>

#### Supported parameters

* Dates
* Screen size
* Battery
* RAM
* Display
* Display resolution
* Display pixel density 
* Display ratio
* Dimensions
* Weight
* Build materials
* SIM card
* Memory
* Usb
* OS
* Price
* Colors
* Gps
* Sensors
* Audio jack
* WLAN
* CPU
* GPU
* Camera resolution
* Camera video modes
* Camera features
* Cameras
* Device type

    
    
    
    
    
    
    
    

#### Related projects

[arcinxe/GsmArenaDataSucker](https://github.com/arcinxe/GsmArenaDataSucker) 

[xpresservers/gsm](https://github.com/xpresservers/gsm#quick-start)

