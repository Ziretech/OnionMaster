using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using EntityLayer;

namespace UseCaseLayer.Rendering
{
    [TestClass]
    public class ShowAllRenderableObjects_RenderTest
    {
        [TestMethod]
        public void Should_find_render_info_from_object_that_can_be_rendered()
        {
            var objects = new List<GameObject> {
                new GameObject
                {
                    Renderable = new Renderable(0, 24, 17, 32, 64),
                    Positional = new Positional(1, 2, 3)
                }
            };

            var renderInfos = new ShowAllRenderableObjects(objects).Render();
            Assert.AreEqual(1, renderInfos.ToList().Count, "Count");
            var info = renderInfos.First();
            Assert.AreEqual(0, info.TileSetId, "TileSetId");
            Assert.AreEqual(24, info.TileSetX, "TileSetX");
            Assert.AreEqual(17, info.TileSetY, "TileSetY");
            Assert.AreEqual(32, info.TileWidth, "TileWidth");
            Assert.AreEqual(64, info.TileHeight, "TileHeight");
            Assert.AreEqual(1, info.ScreenX, "ScreenX");
            Assert.AreEqual(2, info.ScreenY, "ScreenY");
            Assert.AreEqual(3, info.ScreenLayer, "ScreenLayer");
        }

        [TestMethod]
        public void Should_not_find_any_render_info_from_not_renderable_object()
        {
            var objects = new List<GameObject> {
                new GameObject
                {
                    Renderable = null,
                    Positional = new Positional(1, 2, 3)
                }
            };
            Assert.IsFalse(new ShowAllRenderableObjects(objects).Render().Any());
        }

        [TestMethod]
        public void Should_not_find_any_render_info_from_renderable_objects_without_position()
        {
            var objects = new List<GameObject> {
                new GameObject
                {
                    Renderable = new Renderable(0, 11, 54, 12, 14),
                    Positional = null
                }
            };
            Assert.IsFalse(new ShowAllRenderableObjects(objects).Render().Any());
        }

        [TestMethod]
        public void Should_not_find_render_info_when_there_is_no_objects()
        {
            var objects = new List<GameObject>();
            var renderInfo = new ShowAllRenderableObjects(objects).Render();
            Assert.IsFalse(renderInfo.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_ArgumentNullException_when_object_list_is_null()
        {
            new ShowAllRenderableObjects(null);
        }
    }
}
