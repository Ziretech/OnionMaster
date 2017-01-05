using System;
using System.Collections.Generic;
using System.Drawing;
using AdaptorLayer;

namespace OnionMaster
{
    class Renderer
    {
        private readonly IGraphic _graphic;
        private TileSets _tileSets;
        private int _activeTileSet;

        public Renderer(IGraphic graphic)
        {
            _graphic = graphic;
            _activeTileSet = -1;
        }

        public void Render(IEnumerable<DrawCommand> commands)
        {
            _graphic.Clear();
            foreach (var command in commands)
            {
                ActivateTileSet(command.TileSetId);
                _graphic.Draw(command.TileSetX, command.TileSetY, command.ScreenX, command.ScreenY, command.TileWidth, command.TileHeight);
            }
        }

        private void ActivateTileSet(int tileSetIndex)
        {
            if (_activeTileSet != tileSetIndex)
            {
                if (_tileSets.Contains(tileSetIndex))
                {
                    _graphic.ActivateTileTexture(_tileSets.getTexture(tileSetIndex), _tileSets.getWidth(tileSetIndex), _tileSets.getHeight(tileSetIndex));
                    _activeTileSet = tileSetIndex;
                }
                else
                {
                    throw new Exception("TileSet " + tileSetIndex + " have not been loaded.");
                }
            }
        }

        internal void LoadTextures(List<Bitmap> bitmaps)
        {
            _tileSets = new TileSets();
            bitmaps.ForEach(bitmap => _tileSets.Add(_graphic.InitTileTexture(bitmap), bitmap.Width, bitmap.Height));
        }
    }
}
