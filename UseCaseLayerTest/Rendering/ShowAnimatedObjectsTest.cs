using EntityLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseLayer.Rendering
{
    [TestFixture]
    public class ShowAnimatedObjectsTest
    {
        [Test]
        public void Should_render_first_frame_when_ticks_are_one_more_then_number_of_frames()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    Animation = new List<Frame>
                    {
                        new Frame(new TileSetCoordinate(10, 11, 12), new TileDimension(13, 14)),
                        new Frame(new TileSetCoordinate(20, 21, 22), new TileDimension(23, 24))
                    },
                    Position = new Position(5, 6, 7)
                }
            });
            var renderInfos = new ShowAnimatedObjects(world, 2).Render();
            Assert.That(renderInfos.First(), Is.EqualTo(new RenderInfo(5, 6, 7, 10, 11, 12, 13, 14)));
        }

        [Test]
        public void Should_render_second_frame_in_animation_when_ticks_have_increased()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    Animation = new List<Frame>
                    {
                        new Frame(new TileSetCoordinate(10, 11, 12), new TileDimension(13, 14)),
                        new Frame(new TileSetCoordinate(20, 21, 22), new TileDimension(23, 24))
                    },
                    Position = new Position(5, 6, 7)
                }
            });
            var renderInfos = new ShowAnimatedObjects(world, 1).Render();
            Assert.That(renderInfos.First(), Is.EqualTo(new RenderInfo(5, 6, 7, 20, 21, 22, 23, 24)));
        }

        [Test]
        public void Should_render_first_frame_in_animation()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    Animation = new List<Frame> { new Frame(new TileSetCoordinate(0, 1, 2), new TileDimension(3, 4)) },
                    Position = new Position(5, 6, 7)
                }
            });
            var renderInfos = new ShowAnimatedObjects(world, 0).Render();
            Assert.That(renderInfos.First(), Is.EqualTo(new RenderInfo(5, 6, 7, 0, 1, 2, 3, 4)));
        }

        [Test]
        public void Should_not_render_frames_without_tile_dimension()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject()
                {
                    Animation = new List<Frame> { new Frame(new TileSetCoordinate(0, 1, 2), null) },
                    Position = new Position(5, 6, 7)
                }
            });
            var renderInfos = new ShowAnimatedObjects(world, 0).Render();
            Assert.That(renderInfos, Is.Empty);
        }

        [Test]
        public void Should_not_render_frames_without_tile_set_coordinates()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject()
                {
                    Animation = new List<Frame> { new Frame(null, new TileDimension(3, 4)) },
                    Position = new Position(5, 6, 7)
                }
            });
            var renderInfos = new ShowAnimatedObjects(world, 0).Render();
            Assert.That(renderInfos, Is.Empty);
        }

        [Test]
        public void Should_not_render_objects_without_frame_list()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject()
                {
                    Animation = null,
                    Position = new Position(1, 2, 3)
                }
            });
            var renderInfos = new ShowAnimatedObjects(world, 0).Render();
            Assert.That(renderInfos, Is.Empty);
        }

        [Test]
        public void Should_not_render_objects_without_position()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject()
                {
                    Animation = new List<Frame> { new Frame(new TileSetCoordinate(1, 2, 3), new TileDimension(4, 5)) }
                }
            });
            var renderInfos = new ShowAnimatedObjects(world, 0).Render();
            Assert.That(renderInfos, Is.Empty);
        }

        [Test]
        public void Should_not_find_render_info_from_an_empty_world()
        {
            var world = new GameWorld(new List<GameObject>());
            Assert.That(new ShowAnimatedObjects(world, 0).Render(), Is.Empty);
        }

        [Test]
        public void Should_require_game_world_to_be_defined()
        {
            var exception = Assert.Throws<System.ArgumentNullException>(() => new ShowAnimatedObjects(null, 0));
            Assert.That(exception.Message, Does.Contain("GameWorld must be defined"));
        }
    }
}
