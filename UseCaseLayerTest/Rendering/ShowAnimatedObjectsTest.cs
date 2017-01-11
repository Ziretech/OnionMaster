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
        private GameWorld _world;
        private Frame _firstFrame;
        private Frame _secondFrame;
        private RenderInfo _firstFrameRendered;
        private RenderInfo _secondFrameRendered;

        [SetUp]
        public void Setup()
        {
            var position = new Position(5, 6, 7);
            _firstFrame = new Frame(new TileSetCoordinate(10, 11, 12), new TileDimension(13, 14));
            _secondFrame = new Frame(new TileSetCoordinate(20, 21, 22), new TileDimension(23, 24));

            _firstFrameRendered = new RenderInfo(position, _firstFrame.TileSetCoordinate, _firstFrame.TileDimension);
            _secondFrameRendered = new RenderInfo(position, _secondFrame.TileSetCoordinate, _secondFrame.TileDimension);

            _world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    Animation = new List<Frame> { _firstFrame, _secondFrame },
                    Position = position
                }
            });
        }

        [Test]
        public void Should_render_first_frame_in_animation()
        {            
            var renderInfos = new ShowAnimatedObjects(_world, 0).Render();
            Assert.That(renderInfos.First(), Is.EqualTo(_firstFrameRendered));
        }

        [Test]
        public void Should_render_second_frame_in_animation_when_ticks_have_increased()
        {
            var renderInfos = new ShowAnimatedObjects(_world, 1).Render();
            Assert.That(renderInfos.First(), Is.EqualTo(_secondFrameRendered));
        }

        [Test]
        public void Should_render_first_frame_when_ticks_are_one_more_then_number_of_frames()
        {   
            var renderInfos = new ShowAnimatedObjects(_world, 2).Render();
            Assert.That(renderInfos.First(), Is.EqualTo(_firstFrameRendered));
        }

        [Test]
        public void Should_render_first_frame_at_tick_1_when_duration_of_first_frame_is_2()
        {
            _firstFrame.Duration = 2;
            var renderInfos = new ShowAnimatedObjects(_world, 1).Render();
            Assert.That(renderInfos.First(), Is.EqualTo(_firstFrameRendered));
        }

        [Test]
        public void Should_not_render_animations_with_zero_duration()
        {
            var world = new GameWorld(new List<GameObject>
            {
                new GameObject()
                {
                    Animation = new List<Frame> { new Frame(new TileSetCoordinate(0, 1, 2), new TileDimension(3, 4), 0) },
                    Position = new Position(5, 6, 7)
                }
            });
            var renderInfos = new ShowAnimatedObjects(world, 0).Render();
            Assert.That(renderInfos, Is.Empty);
        }

        [Test]
        public void Should_not_render_frames_without_tile_dimension()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject()
                {
                    Animation = new List<Frame> { new Frame(new TileSetCoordinate(0, 1, 2), null, 1) },
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
                    Animation = new List<Frame> { new Frame(null, new TileDimension(3, 4), 1) },
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
