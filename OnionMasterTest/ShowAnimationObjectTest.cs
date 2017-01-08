using AdaptorLayer;
using NUnit.Framework;
using EntityLayer;
using System.Linq;

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
            Assert.That(tick1.Count, Is.EqualTo(1));
            Assert.That(tick1.First(), Is.EqualTo(new DrawCommand(1, 2, 10, 11, 12, 13, 14)));

            session.Update();

            var tick2 = session.DrawScreen();
            Assert.That(tick2.Count, Is.EqualTo(1));
            Assert.That(tick2.First(), Is.EqualTo(new DrawCommand(1, 2, 20, 21, 22, 23, 24)));
        }
        
    }
}
