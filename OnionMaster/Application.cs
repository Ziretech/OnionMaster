using System.Collections.Generic;
using System.IO;
using System.Drawing;
using OpenTK;
using AdaptorLayer;
using OnionMaster.Properties;

namespace OnionMaster
{
    class Application
    {
        public static void Main()
        {
            var config = new ApplicationConfig();
            var sessionData = File.ReadAllText(Settings.Default.ResourceFolder + Settings.Default.SessionDataFilename);
            var gameWindow = getGameWindow();
            var session = new Session(sessionData, new PlayerInteraction(gameWindow.Keyboard), new UseCaseProvider());
            var window = new Window(session, new List<Bitmap> { new Bitmap(config.TilePath) }, gameWindow, new GraphicWrapper());
            window.Show();
        }

        private static GameWindow getGameWindow()
        {
            var gameWindow = new GameWindow();
            gameWindow.Width = Settings.Default.WindowWidth;
            gameWindow.Height = Settings.Default.WindowHeight;
            gameWindow.VSync = Settings.Default.VSync;
            gameWindow.WindowBorder = Settings.Default.WindowBorder;
            gameWindow.WindowState = Settings.Default.WindowState;
            gameWindow.TargetRenderFrequency = Settings.Default.FPS;
            gameWindow.TargetUpdateFrequency = Settings.Default.UPS;
            gameWindow.Title = Settings.Default.Title;
            return gameWindow;
        }        
    }
}
