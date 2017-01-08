using System.Collections.Generic;

namespace UseCaseLayer.Rendering
{
    public interface IShowTiledAreaObjects
    {
        IEnumerable<RenderInfo> Render();
    }
}