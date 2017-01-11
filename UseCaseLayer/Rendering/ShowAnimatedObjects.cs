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
                    var info = RenderAnimation(gameObject.Position, gameObject.Animation);
                    if(info != null)
                    {
                        yield return info;
                    }
                    
                }
            }
        }

        private RenderInfo RenderAnimation(Position position, List<Frame> animation)
        {
            var animationDuration = animation.Sum(f => f.Duration);
            var currentTimeInAnimation = _tick % animationDuration;
            var frame = FindCurrentFrame(animation, currentTimeInAnimation);
            //var numberOfFrames = animation.Count;
            //var frame = animation.ElementAt(_tick % numberOfFrames);
            return RenderFrame(position, frame);
        }

        public static Frame FindCurrentFrame(List<Frame> animation, int time)
        {
            var currentTime = 0;
            foreach(var frame in animation)
            {
                currentTime += frame.Duration;
                if (currentTime > time)
                {
                    return frame;
                }                
            }
            return animation.ElementAt(0);
        }

        private RenderInfo RenderFrame(Position position, Frame frame)
        {
            if (frame.TileSetCoordinate != null && frame.TileDimension != null)
            {
                return new RenderInfo(position, frame.TileSetCoordinate, frame.TileDimension);
            }
            return null;
        }
    }
}
