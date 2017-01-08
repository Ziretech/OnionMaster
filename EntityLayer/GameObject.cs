using System.Collections.Generic;

namespace EntityLayer
{
    public class GameObject
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public Controllable Controllable { get; set; }
        public TiledArea TiledArea { get; set; }
        public TileSetCoordinate TileSetCoordinate { get; set; }
        public TileDimension TileDimension { get; set; }
        public List<Frame> Animation { get; set; }
    }
}
