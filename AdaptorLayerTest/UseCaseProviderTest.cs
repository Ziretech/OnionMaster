using EntityLayer;
using NUnit.Framework;
using System.Collections.Generic;
using UseCaseLayer.Player;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    [TestFixture]
    class UseCaseProviderTest
    {
        [Test]
        public void Should_create_use_case_to_show_all_renderable_objects()
        {
            var provider = new UseCaseProvider();
            var world = new GameWorld(new List<GameObject>());
            Assert.That(provider.GetShowAllRenderableObjects(world).GetType(), Is.EqualTo(typeof(ShowAllRenderableObjects)));
        }

        [Test]
        public void Should_create_use_case_to_show_tiled_area_objects()
        {
            var provider = new UseCaseProvider();
            var world = new GameWorld(new List<GameObject>());
            Assert.That(provider.GetShowTiledAreaObjects(world).GetType(), Is.EqualTo(typeof(ShowTiledAreaObjects)));
        }

        [Test]
        public void Should_create_use_case_to_move_controlled_character()
        {
            var provider = new UseCaseProvider();
            var world = new GameWorld(new List<GameObject>());
            Assert.That(provider.GetMoveControlledCharacter(world).GetType(), Is.EqualTo(typeof(MoveControlledCharacter)));
        }

        [Test]
        public void Should_create_use_case_to_show_animated_objects()
        {
            var provider = new UseCaseProvider();
            var world = new GameWorld(new List<GameObject>());
            Assert.That(provider.GetShowAnimatedObjects(world, 0).GetType(), Is.EqualTo(typeof(ShowAnimatedObjects)));
        }

        private IUseCaseProvider _provider;

        [SetUp]
        public void Setup()
        {
            _provider = new UseCaseProvider();
        }

        [Test]
        public void Should_provide_use_case_to_move_controlled_object()
        {
            Assert.That(_provider.MoveControlledObject.GetType(), Is.EqualTo(typeof(MoveControlledCharacterSingleObject)));
        }
    }
}
