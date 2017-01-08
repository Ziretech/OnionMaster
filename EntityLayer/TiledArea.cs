using System.Collections.Generic;

namespace EntityLayer
{
    public class TiledArea
    {
        public TileDimension TileDimension { get; private set; }
        public List<TileSetCoordinate> TileSetCoordinates { get; private set; }
        public int AreaWidth { get; private set; }
        public List<int> Indices { get; private set; }

        public TiledArea(TileDimension tileDimension, List<TileSetCoordinate> tileSetCoordinates, int areaWidth, List<int> indices)
        {
            TileDimension = tileDimension;
            TileSetCoordinates = tileSetCoordinates;
            AreaWidth = areaWidth;
            Indices = indices;
        }
    }
}
