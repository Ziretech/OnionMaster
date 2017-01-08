using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace UseCaseLayer.Rendering
{
    public class ShowTiledAreaObjects
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
            var indices = gameObject.TiledArea.Indices;
            var coordinates = gameObject.TiledArea.TileSetCoordinates[indices.First()];            
            yield return new RenderInfo(position, coordinates, dimension);
        }

        private bool IsRenderable(GameObject gameObject)
        {
            return gameObject.TiledArea != null && gameObject.Position != null;
        }
    }
}
