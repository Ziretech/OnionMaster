using System;
using System.Collections.Generic;
using OpenTK;
using AdaptorLayer;
using System.Drawing;

namespace OnionMaster
{
    public class Window
    {
        public readonly ISession _session;
        private readonly List<Bitmap> _textureBitmapList;
        private readonly IGraphic _graphic;
        private readonly GameWindow _gameWindow;
        private readonly Renderer _renderer;

        public Window(ISession session, List<Bitmap> textureBitmaps, GameWindow gameWindow, IGraphic graphic)
        {
            _graphic = graphic;
            _session = session;
            _textureBitmapList = textureBitmaps;

            _gameWindow = gameWindow;
            _gameWindow.Load += Load;
            _gameWindow.Resize += Resize;
            _gameWindow.UpdateFrame += UpdateFrame;
            _gameWindow.RenderFrame += RenderFrame;

            _renderer = new Renderer(_graphic);
        }

        public void Show()
        {
            _gameWindow.Run(30.0);
        }

        private void Load(object sender, EventArgs e)
        {
            _graphic.Init();
            _renderer.LoadTextures(_textureBitmapList);
        }

        private void Resize(object sender, EventArgs e)
        {
            _graphic.Resize(_gameWindow.Width, _gameWindow.Height);
        }

        private void UpdateFrame(object sender, FrameEventArgs e)
        {
            _session.Update();
            if (_session.ExitGame)
            {
                _gameWindow.Exit();
            }
        }

        private void RenderFrame(object sender, FrameEventArgs e)
        {
            _renderer.Render(_session.DrawScreen());
            _gameWindow.SwapBuffers();
        }
    }
}
