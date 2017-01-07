using System.Collections.Generic;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public class ShowAllRenderableObjectsMock : IShowAllRenderableObjects
    {
        public IEnumerable<RenderInfo> RenderInfos { get; set; }        

        public IEnumerable<RenderInfo> Render()
        {
            return RenderInfos;
        }
    }
}