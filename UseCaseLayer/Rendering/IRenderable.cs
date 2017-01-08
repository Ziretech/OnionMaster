using System.Collections.Generic;

namespace UseCaseLayer.Rendering
{
    public interface IRenderable
    {
        IEnumerable<RenderInfo> Render();
    }
}