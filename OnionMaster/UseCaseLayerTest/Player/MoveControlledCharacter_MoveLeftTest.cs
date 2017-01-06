using System;
using System.Collections.Generic;
using NUnit.Framework;
using EntityLayer;

namespace UseCaseLayer.Player
{
    [TestFixture]
    public class MoveControlledCharacter_MoveLeftTest
    {
        private GameObject CreateGameObject(int? moveLeft, int? x)
        {
            return new GameObject()
            {
                Controllable = moveLeft == null ? null : new Controllable(0, 0, 0, (int)moveLeft),
                Positional = x == null ? null : new Positional((int)x, 0, 0)
            };
        }

        [Test]
        public void Should_move_object_at_8_to_3_when_moved_5()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(5, 8) };
            new MoveControlledCharacter(gameObjects).MoveLeft();
            Assert.That(gameObjects[0].Positional.X, Is.EqualTo(3));
        }

        [Test]
        public void Should_move_object_at_3_to_0_when_moved_3()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(3, 3) };
            new MoveControlledCharacter(gameObjects).MoveLeft();
            Assert.That(gameObjects[0].Positional.X, Is.EqualTo(0));
        }

        [Test]
        public void Should_move_several_controllables_when_several_are_present()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(3, 3), CreateGameObject(5, 20) };
            new MoveControlledCharacter(gameObjects).MoveLeft();
            Assert.That(gameObjects[0].Positional.X, Is.EqualTo(0));
            Assert.That(gameObjects[1].Positional.X, Is.EqualTo(15));
        }

        [Test]
        public void Should_move_present_controllables_also_when_non_controllable_are_present()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(null, 0), CreateGameObject(4, 5) };
            new MoveControlledCharacter(gameObjects).MoveLeft();
            Assert.That(gameObjects[1].Positional.X, Is.EqualTo(1));
        }

        [Test]
        public void Should_not_throw_when_moving_object_without_position()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(3, null) };
            new MoveControlledCharacter(gameObjects).MoveLeft();
        }

        [Test]
        public void Should_not_throw_when_positional_object_that_is_not_controllable_is_present_when_moving()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(null, null) };
            new MoveControlledCharacter(gameObjects).MoveLeft();
        }

        [Test]
        public void Should_throw_ArgumentNullException_when_init_with_null()
        {
            Assert.Throws<ArgumentNullException>(() => new MoveControlledCharacter(null));
        }
    }
}
