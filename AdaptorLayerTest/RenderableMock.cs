using System.Collections.Generic;
using System.Linq;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public class RenderableMock : IRenderable
    {
        public IEnumerable<RenderInfo> RenderInfos { get; set; }        

        public RenderableMock()
        {
            RenderInfos = Enumerable.Empty<RenderInfo>();
        }

        public IEnumerable<RenderInfo> Render()
        {
            return RenderInfos;
        }
    }
}