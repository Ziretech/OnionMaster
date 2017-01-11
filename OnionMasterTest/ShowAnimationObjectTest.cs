using AdaptorLayer;
using NUnit.Framework;
using EntityLayer;
using System.Linq;
using System.Collections.Generic;

namespace OnionMaster
{
    [TestFixture]
    class ShowAnimationObjectTest
    {
        [Test]
        public void Animated_object_is_displayed()
        {
            GameWorld gameWorld = new GameWorld(SessionDataConverter.Convert(ResourceFile.Read("animationObject.json")));
            InputMock input = new InputMock();
            ISession session = new Session(gameWorld, input, new UseCaseProvider());

            var tick1 = session.DrawScreen();
            Assert.That(tick1, Is.EquivalentTo(new List<DrawCommand> { new DrawCommand(1, 2, 10, 11, 12, 13, 14) }));

            session.Update();

            var tick2 = session.DrawScreen();
            Assert.That(tick2, Is.EquivalentTo(new List<DrawCommand> { new DrawCommand(1, 2, 20, 21, 22, 23, 24) }));

            session.Update();

            var tick3 = session.DrawScreen();
            Assert.That(tick3, Is.EquivalentTo(new List<DrawCommand> { new DrawCommand(1, 2, 20, 21, 22, 23, 24) }));

            session.Update();

            var tick4 = session.DrawScreen();
            Assert.That(tick4, Is.EquivalentTo(new List<DrawCommand> { new DrawCommand(1, 2, 10, 11, 12, 13, 14) }));
        }
    }
}
