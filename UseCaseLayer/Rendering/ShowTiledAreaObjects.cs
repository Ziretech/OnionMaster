using System.Collections.Generic;
using EntityLayer;

namespace UseCaseLayer.Rendering
{
    public class ShowTiledAreaObjects : IRenderable
    {
        private GameWorld _world;

        public ShowTiledAreaObjects(GameWorld world)
        {
            _world = world;
        }

        public IEnumerable<RenderInfo> Render()
        {
            foreach(var gameObject in _world.GetObjects())
            {
                if (IsRenderable(gameObject))
                {
                    foreach(var info in GetRenderInfo(gameObject.Position, gameObject.TiledArea))
                    {
                        yield return info;
                    }
                }
            }
        }

        private IEnumerable<RenderInfo> GetRenderInfo(Position position, TiledArea area)
        {
            var dimension = area.TileDimension;
            var currentIndex = 0;
            foreach(var index in area.Indices)
            {
                var x = currentIndex % area.AreaWidth;
                var y = currentIndex / area.AreaWidth;
                var nextPosition = NextPosition(position, x, y, dimension);
                yield return new RenderInfo(nextPosition, area.TileSetCoordinates[index], dimension);
                currentIndex++;
            }
            
        }

        private Position NextPosition(Position areaPosition, int x, int y, TileDimension dimension)
        {
            return new Position(
                areaPosition.X + x * dimension.Width, 
                areaPosition.Y + y * dimension.Height,
                areaPosition.Z);
        }

        private bool IsRenderable(GameObject gameObject)
        {
            return gameObject.TiledArea != null && gameObject.Position != null;
        }
    }
}
