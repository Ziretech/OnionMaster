using System;
using System.Collections.Generic;

namespace OnionMaster
{
    class TileSets
    {
        private List<TileSet> _tileSets;

        public TileSets()
        {
            _tileSets = new List<TileSet>();
        }

        public void Add(int texture, int width, int height)
        {
            _tileSets.Add(new TileSet(texture, width, height));
        }

        public bool Contains(int tileSetIndex)
        {
            return tileSetIndex >= 0 && tileSetIndex < _tileSets.Count;
        }

        public int getTexture(int index)
        {
            return _tileSets[index].Texture;
        }

        public int getWidth(int index)
        {
            return _tileSets[index].Width;
        }

        public int getHeight(int index)
        {
            return _tileSets[index].Height;
        }
    }
}
