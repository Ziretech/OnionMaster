using EntityLayer;
using NUnit.Framework;
using System.Collections.Generic;

namespace UseCaseLayer.Player
{
    [TestFixture]
    public class MoveControlledCharacterTest
    {
        private MoveControlledCharacterSingleObjectMock _movableSingleMock;
        private GameWorld _world;
        private GameObject _firstObject;
        private GameObject _secondObject;

        [SetUp]
        public void Setup()
        {
            _movableSingleMock = new MoveControlledCharacterSingleObjectMock();
            _firstObject = new GameObject();
            _secondObject = new GameObject();
            _world = new GameWorld(new List<GameObject> { _firstObject, _secondObject });
        }

        [Test]
        public void Should_move_second_object_down_if_it_is_controllable()
        {
            _movableSingleMock.Controllable = new List<bool> { false, true };
            new MoveControlledCharacter(_world, _movableSingleMock).MoveDown();
            Assert.That(_movableSingleMock.MoveDownCalled, Is.EquivalentTo(new List<GameObject> { _secondObject }));
        }

        [Test]
        public void Should_move_both_objects_down_if_they_are_controllable()
        {
            _movableSingleMock.Controllable = new List<bool> { true, true };
            new MoveControlledCharacter(_world, _movableSingleMock).MoveDown();
            Assert.That(_movableSingleMock.MoveDownCalled, Is.EquivalentTo(new List<GameObject> { _firstObject, _secondObject }));
        }

        [Test]
        public void Should_move_second_object_up_if_it_is_controllable()
        {
            _movableSingleMock.Controllable = new List<bool> { false, true };
            new MoveControlledCharacter(_world, _movableSingleMock).MoveUp();
            Assert.That(_movableSingleMock.MoveUpCalled, Is.EquivalentTo(new List<GameObject> { _secondObject }));
        }

        [Test]
        public void Should_move_both_objects_up_if_they_are_controllable()
        {
            _movableSingleMock.Controllable = new List<bool> { true, true };
            new MoveControlledCharacter(_world, _movableSingleMock).MoveUp();
            Assert.That(_movableSingleMock.MoveUpCalled, Is.EquivalentTo(new List<GameObject> { _firstObject, _secondObject }));
        }

        [Test]
        public void Should_move_second_object_right_if_it_is_controllable()
        {
            _movableSingleMock.Controllable = new List<bool> { false, true };
            new MoveControlledCharacter(_world, _movableSingleMock).MoveRight();
            Assert.That(_movableSingleMock.MoveRightCalled, Is.EquivalentTo(new List<GameObject> { _secondObject }));
        }

        [Test]
        public void Should_move_both_objects_right_if_they_are_controllable()
        {
            _movableSingleMock.Controllable = new List<bool> { true, true };
            new MoveControlledCharacter(_world, _movableSingleMock).MoveRight();
            Assert.That(_movableSingleMock.MoveRightCalled, Is.EquivalentTo(new List<GameObject> { _firstObject, _secondObject }));
        }

        [Test]
        public void Should_move_second_object_left_if_it_is_controllable()
        {
            _movableSingleMock.Controllable = new List<bool> { false, true };
            new MoveControlledCharacter(_world, _movableSingleMock).MoveLeft();
            Assert.That(_movableSingleMock.MoveLeftCalled, Is.EquivalentTo(new List<GameObject> { _secondObject }));
        }

        [Test]
        public void Should_move_both_objects_left_if_they_are_controllable()
        {
            _movableSingleMock.Controllable = new List<bool> { true, true };
            new MoveControlledCharacter(_world, _movableSingleMock).MoveLeft();
            Assert.That(_movableSingleMock.MoveLeftCalled, Is.EquivalentTo(new List<GameObject> { _firstObject, _secondObject }));
        }
    }
}
