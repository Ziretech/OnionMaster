using System.Collections.Generic;
using System.IO;
using System.Drawing;
using OpenTK;
using AdaptorLayer;

namespace OnionMaster
{
    class Application
    {
        public static void Main()
        {
            var config = new ApplicationConfig();
            var sessionData = File.ReadAllText(config.SessionDataPath);
            var gameWindow = getGameWindow(config);
            var session = new Session(sessionData, new PlayerInteraction(gameWindow.Keyboard), new UseCaseProvider());
            var window = new Window(session, new List<Bitmap> { new Bitmap(config.TilePath) }, gameWindow, new GraphicWrapper());
            window.Show();
        }

        private static GameWindow getGameWindow(ApplicationConfig config)
        {
            var gameWindow = new GameWindow();
            gameWindow.Width = config.WindowWidth;
            gameWindow.Height = config.WindowHeight;
            gameWindow.VSync = config.VSync;
            if (config.Fullscreen)
            {
                gameWindow.WindowBorder = WindowBorder.Hidden;
                gameWindow.WindowState = WindowState.Fullscreen;
            }
            return gameWindow;
        }        
    }
}
