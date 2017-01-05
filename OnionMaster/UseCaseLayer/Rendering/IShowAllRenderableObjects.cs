using System.Collections.Generic;

namespace UseCaseLayer.Rendering
{
    public interface IShowAllRenderableObjects
    {
        IEnumerable<RenderInfo> Render();
    }
}