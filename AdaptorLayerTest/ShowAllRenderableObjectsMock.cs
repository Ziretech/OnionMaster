﻿using System.Collections.Generic;
using System.Linq;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public class ShowAllRenderableObjectsMock : IShowAllRenderableObjects
    {
        public IEnumerable<RenderInfo> RenderInfos { get; set; }        

        public ShowAllRenderableObjectsMock()
        {
            RenderInfos = Enumerable.Empty<RenderInfo>();
        }

        public IEnumerable<RenderInfo> Render()
        {
            return RenderInfos;
        }
    }
}