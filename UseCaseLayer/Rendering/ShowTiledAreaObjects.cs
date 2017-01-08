using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace UseCaseLayer.Rendering
{
    public class ShowTiledAreaObjects : IShowTiledAreaObjects
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
                    foreach(var info in GetRenderInfo(gameObject))
                    {
                        yield return info;
                    }
                }
            }
        }

        private IEnumerable<RenderInfo> GetRenderInfo(GameObject gameObject)
        {
            var position = gameObject.Position;
            var dimension = gameObject.TiledArea.TileDimension;
            var currentIndex = 0;
            foreach(var index in gameObject.TiledArea.Indices)
            {
                var coordinates = gameObject.TiledArea.TileSetCoordinates[index];
                
                var newPosition = new Position(position.X + currentIndex * dimension.Width, position.Y, position.Z);
                yield return new RenderInfo(newPosition, coordinates, dimension);
                currentIndex++;
            }
            
        }

        private bool IsRenderable(GameObject gameObject)
        {
            return gameObject.TiledArea != null && gameObject.Position != null;
        }
    }
}
