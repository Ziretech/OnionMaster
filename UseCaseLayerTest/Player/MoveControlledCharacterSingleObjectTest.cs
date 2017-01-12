using EntityLayer;
using NUnit.Framework;
using System;

namespace UseCaseLayer.Player
{
    [TestFixture]
    public class MoveControlledCharacterSingleObjectTest
    {
        private GameObject _gameObject;

        [SetUp]
        public void Setup()
        {
            _gameObject = new GameObject
            {
                Position = new Position(1, 2, 3),
                Controllable = new Controllable(4, 5, 6, 7)
            };
        }

        [Test]
        public void Should_move_object_up_from_0_to_1_when_move_up_1_step()
        {
            _gameObject.Controllable.MoveUp = 1;
            _gameObject.Position.Y = 0;
            new MoveControlledCharacterSingleObject().MoveUp(_gameObject);
            Assert.That(_gameObject.Position.Y, Is.EqualTo(1));
        }

        [Test]
        public void Should_move_object_up_from_1_to_3_when_move_up_2_step()
        {
            _gameObject.Controllable.MoveUp = 2;
            _gameObject.Position.Y = 1;
            new MoveControlledCharacterSingleObject().MoveUp(_gameObject);
            Assert.That(_gameObject.Position.Y, Is.EqualTo(3));
        }

        [Test]
        public void Should_throw_NullReferenceException_when_move_up_gets_null()
        {
            Assert.Throws<NullReferenceException>(() => new MoveControlledCharacterSingleObject().MoveUp(null));
        }

        [Test]
        public void Should_move_object_right_from_0_to_1_when_move_right_1_step()
        {
            _gameObject.Controllable.MoveRight = 1;
            _gameObject.Position.X = 0;
            new MoveControlledCharacterSingleObject().MoveRight(_gameObject);
            Assert.That(_gameObject.Position.X, Is.EqualTo(1));
        }

        [Test]
        public void Should_move_object_right_from_1_to_3_when_move_right_2_step()
        {
            _gameObject.Controllable.MoveRight = 2;
            _gameObject.Position.X = 1;
            new MoveControlledCharacterSingleObject().MoveRight(_gameObject);
            Assert.That(_gameObject.Position.X, Is.EqualTo(3));
        }

        [Test]
        public void Should_throw_NullReferenceException_when_move_right_gets_null()
        {
            Assert.Throws<NullReferenceException>(() => new MoveControlledCharacterSingleObject().MoveRight(null));
        }

        [Test]
        public void Should_move_object_down_from_1_to_0_when_move_down_1_step()
        {
            _gameObject.Controllable.MoveDown = 1;
            _gameObject.Position.Y = 1;
            new MoveControlledCharacterSingleObject().MoveDown(_gameObject);
            Assert.That(_gameObject.Position.Y, Is.EqualTo(0));
        }

        [Test]
        public void Should_move_object_down_from_3_to_1_when_move_down_2_step()
        {
            _gameObject.Controllable.MoveDown = 2;
            _gameObject.Position.Y = 3;
            new MoveControlledCharacterSingleObject().MoveDown(_gameObject);
            Assert.That(_gameObject.Position.Y, Is.EqualTo(1));
        }

        [Test]
        public void Should_throw_NullReferenceException_when_move_down_gets_null()
        {
            Assert.Throws<NullReferenceException>(() => new MoveControlledCharacterSingleObject().MoveDown(null));
        }

        [Test]
        public void Should_move_object_left_from_1_to_0_when_move_down_1_step()
        {
            _gameObject.Controllable.MoveLeft = 1;
            _gameObject.Position.X = 1;
            new MoveControlledCharacterSingleObject().MoveLeft(_gameObject);
            Assert.That(_gameObject.Position.X, Is.EqualTo(0));
        }

        [Test]
        public void Should_move_object_left_from_3_to_1_when_move_left_2_step()
        {
            _gameObject.Controllable.MoveLeft = 2;
            _gameObject.Position.X = 3;
            new MoveControlledCharacterSingleObject().MoveLeft(_gameObject);
            Assert.That(_gameObject.Position.X, Is.EqualTo(1));
        }

        [Test]
        public void Should_throw_NullReferenceException_when_move_left_gets_null()
        {
            Assert.Throws<NullReferenceException>(() => new MoveControlledCharacterSingleObject().MoveLeft(null));
        }

        [Test]
        public void Should_decide_that_an_object_with_position_and_controllable_is_controllable()
        {
            Assert.That(new MoveControlledCharacterSingleObject().IsControllable(_gameObject), Is.True);
        }

        [Test]
        public void Should_decide_that_an_object_without_position_is_not_controllable()
        {
            _gameObject.Position = null;
            Assert.That(new MoveControlledCharacterSingleObject().IsControllable(_gameObject), Is.False);
        }

        [Test]
        public void Should_decide_that_an_object_without_controllable_is_not_controllable()
        {
            _gameObject.Controllable = null;
            Assert.That(new MoveControlledCharacterSingleObject().IsControllable(_gameObject), Is.False);
        }
    }
}
