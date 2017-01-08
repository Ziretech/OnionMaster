using System.Collections.Generic;
using EntityLayer;
using System.Linq;
using System;

namespace UseCaseLayer.Rendering
{
    public class ShowAllRenderableObjects : IShowAllRenderableObjects
    {
        private readonly GameWorld _gameWorld;

        public ShowAllRenderableObjects(GameWorld world)
        {
            if(world == null)
            {
                throw new ArgumentNullException("GameWorld must not be null");
            }
            _gameWorld = world;
        }

        public IEnumerable<RenderInfo> Render()
        {
            return _gameWorld
                .GetObjects()
                .Where(o => IsRenderable(o))
                .Select(o => new RenderInfo(o.Position, o.TileSetCoordinate, o.TileDimension));
        }

        private bool IsRenderable(GameObject gameObject)
        {
            return gameObject.Position != null &&
                gameObject.TileSetCoordinate != null &&
                gameObject.TileDimension != null;
        }
    }
}
