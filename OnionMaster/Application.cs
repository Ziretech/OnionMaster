using System.Collections.Generic;
using System.IO;
using System.Drawing;
using OpenTK;
using AdaptorLayer;

namespace OnionMaster
{
    class Application
    {
        //[STAThread]
        public static void Main()
        {
            var sessionData = File.ReadAllText(@"Resources\SessionData.json");
            var gameWindow = getGameWindow();

            var session = new Session(sessionData, new PlayerInteraction(gameWindow.Keyboard), new UseCaseProvider());


            var window = new Window(session, new List<Bitmap> { new Bitmap(@"Resources\tiles.png") }, gameWindow, new GraphicWrapper());
            window.Show();
        }

        private static GameWindow getGameWindow()
        {
            var gameWindow = new GameWindow();
            gameWindow.Width = 16 * 32;
            gameWindow.Height = 16 * 32;
            gameWindow.VSync = VSyncMode.On;
            if (true)
            {
                gameWindow.WindowBorder = WindowBorder.Hidden;
                gameWindow.WindowState = WindowState.Fullscreen;
            }
            return gameWindow;
        }
    }
}
