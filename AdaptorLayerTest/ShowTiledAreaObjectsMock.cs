using System;
using System.Collections.Generic;
using System.Linq;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    internal class ShowTiledAreaObjectsMock : IShowTiledAreaObjects
    {
        public IEnumerable<RenderInfo> RenderInfos { get; set; }

        public ShowTiledAreaObjectsMock()
        {
            RenderInfos = Enumerable.Empty<RenderInfo>();
        }

        public IEnumerable<RenderInfo> Render()
        {
            return RenderInfos;
        }
    }
}