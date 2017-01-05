using System;
using OpenTK;
using OnionMaster.Properties;

namespace OnionMaster
{
    public class ApplicationConfig
    {
        public string SessionDataPath { get { return Resources.ResourceFolder + Resources.SessionDataFilename; } }
        public string TilePath { get { return Resources.ResourceFolder + Resources.TileFilename; } }
        public int WindowWidth { get { return Int32.Parse(Resources.WindowedWidth); } }
        public int WindowHeight { get { return Int32.Parse(Resources.WindowedHeight); } }
        public VSyncMode VSync { get { return GetVSync(Resources.VSync); } }
        public bool Fullscreen { get { return Resources.ScreenMode == "fullscreen"; } }

        private VSyncMode GetVSync(string value)
        {
            switch (value)
            {
                default:
                case "on":
                    return VSyncMode.On;
                case "off":
                    return VSyncMode.Off;
                case "adaptive":
                    return VSyncMode.Adaptive;
            }
        }
    }
}
