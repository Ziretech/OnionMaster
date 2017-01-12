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
        private IUseCaseProvider _provider;
        private GameWorld _world;

        [SetUp]
        public void Setup()
        {
            _provider = new UseCaseProvider();
            _world = new GameWorld(new List<GameObject>());
        }

        [Test]
        public void Should_create_use_case_to_show_all_renderable_objects()
        {
            
            Assert.That(_provider.GetShowAllRenderableObjects(_world).GetType(), Is.EqualTo(typeof(ShowAllRenderableObjects)));
        }

        [Test]
        public void Should_create_use_case_to_show_tiled_area_objects()
        {
            Assert.That(_provider.GetShowTiledAreaObjects(_world).GetType(), Is.EqualTo(typeof(ShowTiledAreaObjects)));
        }

        [Test]
        public void Should_create_use_case_to_move_controlled_character()
        {
            Assert.That(_provider.GetMoveControlledCharacter(_world).GetType(), Is.EqualTo(typeof(MoveControlledCharacter)));
        }

        [Test]
        public void Should_create_use_case_to_show_animated_objects()
        {
            Assert.That(_provider.GetShowAnimatedObjects(_world, 0).GetType(), Is.EqualTo(typeof(ShowAnimatedObjects)));
        }        

        [Test]
        public void Should_provide_use_case_to_move_controlled_object()
        {
            Assert.That(_provider.MoveControlledObject.GetType(), Is.EqualTo(typeof(MoveControlledCharacterSingleObject)));
        }
    }
}
