# Baku.LibqiDotNet

Baku/獏(ばく)

2016/March/2

- About
- Environment
- Library Files Preparation
- Hello World
- Use Baku.LibqiDotNet in UnityEngine
- Contact


## About

This project is .NET wrapper library for the messaging framework "qi Framework (libqi)" which originates from Aldebaran robotics. To see about original projects, please visit:

- [libqi](https://github.com/aldebaran/libqi)
- [libqi-capi](https://github.com/aldebaran/libqi-capi)


## Environment

Developed by Windows 10/Visual Studio 2015 Community. Expected environment is:

- Windows 7 or later
- .NET 3.5 or later
- **32bit**

As targetted for .NET 3.5, This library also runs on UnityEngine.


## Library Files Preparation

This library is only a wrapper code, NOT translated implementation of native(C++) libqi, so you have to get original library (*.dll) files. There are two ways to get it.

#### Recommended: use custom builded dlls

Author distributes customed library for Baku.LibqiDotNet. Customization is actually a simple implementatio of [libqi-capi](https://github.com/aldebaran/libqi-capi), please see the detail for [closed issue](https://github.com/malaybaku/BakuLibQiDotNet/issues/1) (sorry that the discussion is written in Japanese, but the most meaningful part is C++ source code so you would understand what I did).

To get the custom library,

1. Download .zip from [Google Drive](https://drive.google.com/folderview?id=0BzVgwIMLJboJeHI1N2pwTlc4ZlE&usp=sharing)
2. Copy ```dlls``` folder in zip archives to your program's working directory

You can change the folder name ```dlls``` to another one, but be carefully to do it, as the the folder name is used in sample code.

#### NOT recommended: use official binary

I can imagine that some of you will hesitate to get and use raw *.dll from an indivisual's Google Drive. OK, you are right, and there is alternative way to get it from Aldebaran Robotics' official source.

CAUTION: Almost all things work well by this way, but binary data (QiByteData class) functions are NOT available when you get *.dlls in this way.

1. Get Pynaoqi SDK from Aldebaran Robotics' web site and install it to your PC
2. After the installation, Python's Libs/site-packages directory (or childs director of it) will have "qi.dll", "qic.dll", and some boost *.dlls
3. Create ```dlls``` directory on your program's working directory, and copy & paste *.dll files into it


## Hello World

Baku.LibqiDotNet allows you to use the qi Framework in a natural way almost same as C++/Python/Java. The basic operation consists of:

- Create and connect session (by static method ```QiSession.Create```)
- Get service from session (by ```QiSession.GetService```). The service is expressed as ```QiObject``` instance.
- Call a method with args (by ```QiObject.Call```)

```
using System;
using System.IO;
using System.Linq;

using Baku.LibqiDotNet;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //By call this, ```dlls``` folder becomes visible when search unmanaged library
            PathModifier.AddEnvironmentPaths(Path.Combine(Environment.CurrentDirectory, "dlls"));

            //Address = "tcp://" + IP + ":" + port (port number is usually 9559)
            string address = "tcp://127.0.0.1:9559";
            var session = QiSession.Create(address);

            Console.WriteLine($"Connected? {session.IsConnected}");
            if (!session.IsConnected)
            {
                Console.WriteLine("end program because there is no connection");
                return;
            }

            //Use most basic service: Text to speech
            var tts = session.GetService("ALTextToSpeech");

            //Call "say" method in ALTextToSpeech, with a String argument.
            tts.Call("say", new QiString("this is test"));

            session.Close();
            session.Destroy();
        }
    }

    static class PathModifier
    {
        public static void AddEnvironmentPaths(params string[] paths)
        {
            var path = new[] { Environment.GetEnvironmentVariable("PATH") ?? "" };

            string newPath = string.Join(Path.PathSeparator.ToString(), path.Concat(paths));

            Environment.SetEnvironmentVariable("PATH", newPath);
        }
    }
}

```

## Use Baku.LibqiDotNet in UnityEngine

Japanese instruction to use this library in UnityEngine can be found at [here](http://www.baku-dreameater.net/archives/10791). Sample Unity package is available in [Google Drive](https://drive.google.com/folderview?id=0BzVgwIMLJboJeWJmaFZ3Q25ENjQ&usp=sharing).

1. Define "UNITY" compile symbol in "Baku.LibqiDotNet" project (in VS 2015, compile symbol can be defined in project's property -> build).
2. Build the project
3. Open and create new Unity Project.
4. Put "Baku.LibqiDotNet.dll" in Assets
5. Create "Plugins" folder in Assets, and "x86" child folder.
6. Copy unmanaged *.dll files, which introduced in "Library Files Preparation", to "x86" folder.

cf. The compile symbol "UNITY" switches ```DllImport``` attributes's argument. The symbol is used in [DllImportSettings.cs](https://github.com/malaybaku/BakuLibQiDotNet/blob/master/Baku.LibqiDotNet/Baku.LibqiDotNet/QiApi/DllImportSettings.cs).



## Contact

- [Blog](https://www.baku-dreameater.net)
- [Twitter](https://twitter.com/baku_dreameater)
