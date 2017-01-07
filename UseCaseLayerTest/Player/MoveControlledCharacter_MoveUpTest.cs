﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using EntityLayer;

namespace UseCaseLayer.Player
{
    [TestFixture]
    public class MoveControlledCharacter_MoveUpTest
    {
        private GameObject CreateGameObject(int? moveUp, int? y)
        {
            return new GameObject()
            {
                Controllable = moveUp == null ? null : new Controllable((int)moveUp, 0, 0, 0),
                Positional = y == null ? null : new Positional(0, (int)y, 0)
            };
        }

        [Test]
        public void Should_move_object_at_3_to_8_when_moved_5()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(5, 3) };
            new MoveControlledCharacter(gameObjects).MoveUp();
            Assert.That(gameObjects[0].Positional.Y, Is.EqualTo(8));
        }

        [Test]
        public void Should_move_object_at_0_to_3_when_moved_3()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(3, 0) };
            new MoveControlledCharacter(gameObjects).MoveUp();
            Assert.That(gameObjects[0].Positional.Y, Is.EqualTo(3));
        }

        [Test]
        public void Should_move_several_controllables_when_several_are_present()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(3, 0), CreateGameObject(5, 15) };
            new MoveControlledCharacter(gameObjects).MoveUp();
            Assert.That(gameObjects[0].Positional.Y, Is.EqualTo(3));
            Assert.That(gameObjects[1].Positional.Y, Is.EqualTo(20));
        }

        [Test]
        public void Should_move_present_controllables_also_when_non_controllable_are_present()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(null, 0), CreateGameObject(4, 1) };
            new MoveControlledCharacter(gameObjects).MoveUp();
            Assert.That(gameObjects[1].Positional.Y, Is.EqualTo(5));
        }

        [Test]
        public void Should_not_throw_when_moving_object_without_position()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(3, null) };
            new MoveControlledCharacter(gameObjects).MoveUp();
        }

        [Test]
        public void Should_not_throw_when_positional_object_that_is_not_controllable_is_present_when_moving()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(null, null) };
            new MoveControlledCharacter(gameObjects).MoveUp();
        }

        [Test]
        public void Should_throw_ArgumentNullException_when_init_with_null()
        {
            Assert.Throws<ArgumentNullException>(() => new MoveControlledCharacter(null));
        }
    }
}