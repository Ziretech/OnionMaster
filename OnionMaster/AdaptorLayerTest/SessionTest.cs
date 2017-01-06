using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UseCaseLayer.Player;
using EntityLayer;
using System.Collections.Generic;
using UseCaseLayer.Rendering;
using System.Linq;

namespace AdaptorLayer
{
    [TestClass]
    public class SessionTest
    {
        private UseCaseProviderMock _useCasesMock;

        [TestInitialize]
        public void Setup()
        {
            _useCasesMock = new UseCaseProviderMock();
        }

        [TestMethod]
        public void Should_exit_game_when_escape_is_pressed()
        {
            var session = new Session(null, new InputMock(true, false, false, false, false), _useCasesMock);
            session.Update();
            Assert.IsTrue(session.ExitGame);
        }

        [TestMethod]
        public void Should_not_exit_game_when_escape_is_not_pressed()
        {
            var session = new Session(null, new InputMock(false, false, false, false, false), _useCasesMock);
            session.Update();
            Assert.IsFalse(session.ExitGame);
        }

        [TestMethod]
        public void Should_move_character_up_when_up_is_pressed()
        {
            var session = new Session(null, new InputMock(false, true, false, false, false), _useCasesMock);
            session.Update();
            Assert.AreEqual(1, _useCasesMock.MoveControlledCharacterMock.MoveUpCalled);
        }

        [TestMethod]
        public void Should_move_character_down_when_down_is_pressed()
        {
            var session = new Session(null, new InputMock(false, false, true, false, false), _useCasesMock);
            session.Update();
            Assert.AreEqual(1, _useCasesMock.MoveControlledCharacterMock.MoveDownCalled);
        }

        [TestMethod]
        public void Should_move_character_right_when_right_is_pressed()
        {
            var session = new Session(null, new InputMock(false, false, false, true, false), _useCasesMock);
            session.Update();
            Assert.AreEqual(1, _useCasesMock.MoveControlledCharacterMock.MoveRightCalled);
        }

        [TestMethod]
        public void Should_move_character_left_when_left_is_pressed()
        {
            var session = new Session(null, new InputMock(false, false, false, false, true), _useCasesMock);
            session.Update();
            Assert.AreEqual(1, _useCasesMock.MoveControlledCharacterMock.MoveLeftCalled);
        }
        
        [TestMethod]
        public void Should_show_all_renderable_objects_when_draw_to_screen()
        {
            _useCasesMock.ShowAllRenderableObjectsMock.RenderInfos = new List<RenderInfo>() { new RenderInfo(1, 2, 3, 4, 5, 6, 7, 8) };
            var session = new Session(null, new InputMock(), _useCasesMock);
            var commands = session.DrawScreen().ToList();
            Assert.AreEqual(1, commands.Count);
            Assert.AreEqual(new DrawCommand(1, 2, 4, 5, 6, 7, 8), commands[0]);
        }

        [TestMethod]
        public void Should_sort_renderable_objects_by_layer()
        {
            _useCasesMock.ShowAllRenderableObjectsMock.RenderInfos = new List<RenderInfo>() {
                new RenderInfo(1, 9, 3, 9, 9, 9, 9, 9),
                new RenderInfo(2, 9, 1, 9, 9, 9, 9, 9)
            };
            var session = new Session(null, new InputMock(), _useCasesMock);
            var commands = session.DrawScreen().ToList();
            Assert.AreEqual(2, commands.Count);
            Assert.AreEqual(2, commands[0].ScreenX);
            Assert.AreEqual(1, commands[1].ScreenX);
        }
    }
}
