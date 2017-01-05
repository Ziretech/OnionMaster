﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityLayer;

namespace UseCaseLayer.Player
{
    [TestClass]
    public class MoveControlledCharacter_MoveRightTest
    {
        private GameObject CreateGameObject(int? moveRight, int? x)
        {
            return new GameObject()
            {
                Controllable = moveRight == null ? null : new Controllable(0, 0, (int)moveRight, 0),
                Positional = x == null ? null : new Positional((int)x, 0, 0)
            };
        }

        [TestMethod]
        public void Should_move_object_at_3_to_8_when_moved_5()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(5, 3) };
            new MoveControlledCharacter(gameObjects).MoveRight();
            Assert.AreEqual(8, gameObjects[0].Positional.X);
        }

        [TestMethod]
        public void Should_move_object_at_0_to_3_when_moved_3()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(3, 0) };
            new MoveControlledCharacter(gameObjects).MoveRight();
            Assert.AreEqual(3, gameObjects[0].Positional.X);
        }

        [TestMethod]
        public void Should_move_several_controllables_when_several_are_present()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(3, 0), CreateGameObject(5, 15) };
            new MoveControlledCharacter(gameObjects).MoveRight();
            Assert.AreEqual(3, gameObjects[0].Positional.X);
            Assert.AreEqual(20, gameObjects[1].Positional.X);
        }

        [TestMethod]
        public void Should_move_present_controllables_also_when_non_controllable_are_present()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(null, 0), CreateGameObject(4, 1) };
            new MoveControlledCharacter(gameObjects).MoveRight();
            Assert.AreEqual(5, gameObjects[1].Positional.X);
        }

        [TestMethod]
        public void Should_not_throw_when_moving_object_without_position()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(3, null) };
            new MoveControlledCharacter(gameObjects).MoveRight();
        }

        [TestMethod]
        public void Should_not_throw_when_positional_object_that_is_not_controllable_is_present_when_moving()
        {
            var gameObjects = new List<GameObject>() { CreateGameObject(null, null) };
            new MoveControlledCharacter(gameObjects).MoveRight();
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Should_throw_ArgumentNullException_when_init_with_null()
        {
            new MoveControlledCharacter(null);
        }
    }
}
