using NUnit.Framework;
using System.Collections.Generic;
using UseCaseLayer.Rendering;
using System.Linq;

namespace AdaptorLayer
{
    [TestFixture]
    public class SessionTest
    {
        private UseCaseProviderMock _useCasesMock;

        [SetUp]
        public void Setup()
        {
            _useCasesMock = new UseCaseProviderMock();
        }

        [Test]
        public void Should_exit_game_when_escape_is_pressed()
        {
            var session = new Session(null, new InputMock(true, false, false, false, false), _useCasesMock);
            session.Update();
            Assert.That(session.ExitGame);
        }

        [Test]
        public void Should_not_exit_game_when_escape_is_not_pressed()
        {
            var session = new Session(null, new InputMock(false, false, false, false, false), _useCasesMock);
            session.Update();
            Assert.That(!session.ExitGame);
        }

        [Test]
        public void Should_move_character_up_when_up_is_pressed()
        {
            var session = new Session(null, new InputMock(false, true, false, false, false), _useCasesMock);
            session.Update();
            Assert.That(_useCasesMock.MoveControlledCharacterMock.MoveUpCalled, Is.EqualTo(1));
        }

        [Test]
        public void Should_move_character_down_when_down_is_pressed()
        {
            var session = new Session(null, new InputMock(false, false, true, false, false), _useCasesMock);
            session.Update();
            Assert.That(_useCasesMock.MoveControlledCharacterMock.MoveDownCalled, Is.EqualTo(1));
        }

        [Test]
        public void Should_move_character_right_when_right_is_pressed()
        {
            var session = new Session(null, new InputMock(false, false, false, true, false), _useCasesMock);
            session.Update();
            Assert.That(_useCasesMock.MoveControlledCharacterMock.MoveRightCalled, Is.EqualTo(1));
        }

        [Test]
        public void Should_move_character_left_when_left_is_pressed()
        {
            var session = new Session(null, new InputMock(false, false, false, false, true), _useCasesMock);
            session.Update();
            Assert.That(_useCasesMock.MoveControlledCharacterMock.MoveLeftCalled, Is.EqualTo(1));
        }
        
        [Test]
        public void Should_show_all_renderable_objects_when_draw_to_screen()
        {
            _useCasesMock.ShowAllRenderableObjectsMock.RenderInfos = new List<RenderInfo>() { new RenderInfo(1, 2, 3, 4, 5, 6, 7, 8) };
            var session = new Session(null, new InputMock(), _useCasesMock);
            var commands = session.DrawScreen().ToList();
            Assert.That(commands.Count, Is.EqualTo(1));
            Assert.That(commands[0], Is.EqualTo(new DrawCommand(1, 2, 4, 5, 6, 7, 8)));
        }

        [Test]
        public void Should_show_all_tiled_area_objects_when_draw_to_screen()
        {
            _useCasesMock.ShowTiledAreaObjectsMock.RenderInfos = new List<RenderInfo>() { new RenderInfo(1, 2, 3, 4, 5, 6, 7, 8) };
            var session = new Session(null, new InputMock(), _useCasesMock);
            var commands = session.DrawScreen();
            Assert.That(commands.Count, Is.EqualTo(1));
            Assert.That(commands.ElementAt(0), Is.EqualTo(new DrawCommand(1, 2, 4, 5, 6, 7, 8)));
        }

        [Test]
        public void Should_sort_renderable_objects_by_layer()
        {
            _useCasesMock.ShowAllRenderableObjectsMock.RenderInfos = new List<RenderInfo>() {
                new RenderInfo(1, 9, 3, 9, 9, 9, 9, 9),
                new RenderInfo(2, 9, 1, 9, 9, 9, 9, 9)
            };
            var session = new Session(null, new InputMock(), _useCasesMock);
            var commands = session.DrawScreen().ToList();
            Assert.That(commands.Count, Is.EqualTo(2));
            Assert.That(commands[0].ScreenX, Is.EqualTo(2));
            Assert.That(commands[1].ScreenX, Is.EqualTo(1));
        }
    }
}
