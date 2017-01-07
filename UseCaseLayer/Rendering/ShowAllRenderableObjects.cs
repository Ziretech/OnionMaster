using System.Collections.Generic;
using EntityLayer;
using System.Linq;

namespace UseCaseLayer.Rendering
{
    public class ShowAllRenderableObjects : IShowAllRenderableObjects
    {
        private readonly List<GameObject> _renderable;

        public ShowAllRenderableObjects(GameWorld world)
        {
            if(world == null)
            {
                throw new System.ArgumentNullException("GameWorld must not be null");
            }
            _renderable = world.GetObjects().Where(o => IsRenderable(o)).ToList();
        }

        public IEnumerable<RenderInfo> Render()
        {
            return _renderable.Select(r => new RenderInfo(r.Positional, r.Renderable));
        }

        private bool IsRenderable(GameObject gameObject)
        {
            return gameObject.Renderable != null && gameObject.Positional != null;
        }
    }
}
