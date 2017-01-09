using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseLayer.Rendering
{
    public class ShowAnimatedObjects : IRenderable
    {
        private GameWorld _world;
        private int _tick;

        public ShowAnimatedObjects(GameWorld world, int tick)
        {
            if(world == null)
            {
                throw new ArgumentNullException("GameWorld must be defined");
            }
            _world = world;
            _tick = tick;
        }

        public IEnumerable<RenderInfo> Render()
        {
            foreach(var gameObject in _world.GetObjects())
            {
                if (gameObject.Position != null && gameObject.Animation != null)
                {
                    var numberOfFrames = gameObject.Animation.Count;
                    var frame = gameObject.Animation.ElementAt(_tick % numberOfFrames);
                    if(frame.TileSetCoordinate != null && frame.TileDimension != null)
                    {
                        yield return new RenderInfo(gameObject.Position, frame.TileSetCoordinate, frame.TileDimension);
                    }
                    
                }
            }
        }
    }
}
