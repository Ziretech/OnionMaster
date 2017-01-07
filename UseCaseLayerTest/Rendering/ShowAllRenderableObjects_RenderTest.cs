using System;
using System.Collections.Generic;
using System.Linq;
using EntityLayer;
using NUnit.Framework;

namespace UseCaseLayer.Rendering
{
    [TestFixture]
    public class ShowAllRenderableObjects_RenderTest
    {
        [Test]
        public void Should_find_render_info_from_object_that_can_be_rendered()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    Renderable = new Renderable(0, 24, 17, 32, 64),
                    Positional = new Positional(1, 2, 3)
                }
            });

            var renderInfos = new ShowAllRenderableObjects(world).Render();
            Assert.That(renderInfos.Count, Is.EqualTo(1));
            var info = renderInfos.First();
            Assert.That(renderInfos.First().TileSetId, Is.EqualTo(0));
            Assert.That(renderInfos.First().TileSetX, Is.EqualTo(24));
            Assert.That(renderInfos.First().TileSetY, Is.EqualTo(17));
            Assert.That(renderInfos.First().TileWidth, Is.EqualTo(32));
            Assert.That(renderInfos.First().TileHeight, Is.EqualTo(64));

            Assert.That(renderInfos.First().ScreenX, Is.EqualTo(1));
            Assert.That(renderInfos.First().ScreenY, Is.EqualTo(2));
            Assert.That(renderInfos.First().ScreenLayer, Is.EqualTo(3));
        }

        [Test]
        public void Should_not_find_any_render_info_from_not_renderable_object()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    Renderable = null,
                    Positional = new Positional(1, 2, 3)
                }
            });

            Assert.That(new ShowAllRenderableObjects(world).Render(), Is.Empty);
        }

        [Test]
        public void Should_not_find_any_render_info_from_renderable_objects_without_position()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    Renderable = new Renderable(0, 11, 54, 12, 14),
                    Positional = null
                }
            });
            Assert.That(new ShowAllRenderableObjects(world).Render(), Is.Empty);
        }

        [Test]
        public void Should_not_find_render_info_when_there_is_no_objects()
        {
            var world = new GameWorld(new List<GameObject>());
            var renderInfo = new ShowAllRenderableObjects(world).Render();
            Assert.That(renderInfo, Is.Empty);
        }

        [Test]
        public void Should_throw_ArgumentNullException_when_object_list_is_null()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new ShowAllRenderableObjects(null));
            Assert.That(exception.Message, Does.Contain("GameWorld must not be null"));
        }
    }
}
