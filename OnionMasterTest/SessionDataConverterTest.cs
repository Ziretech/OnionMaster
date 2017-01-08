using System;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using UseCaseLayer.Rendering;
using System.Linq;
using UseCaseLayer.Player;
using EntityLayer;
using AdaptorLayer;

namespace OnionMaster
{

    [TestFixture]
    public class SessionDataConverterTest
    {
        [Test]
        public void Should_create_object_rendered_as_an_area_of_equal_sized_tiles_side_by_side()
        {
            var useCaseProvider = new UseCaseProvider();
            var sessionData = SessionDataConverter.Convert(ReadResourceFile("tiledAreaObject.json"));
            var renderInfos = useCaseProvider.GetShowTiledAreaObjects(new GameWorld(sessionData)).Render();
            Assert.That(renderInfos.Count, Is.EqualTo(4));
            Assert.That(renderInfos.ElementAt(0), Is.EqualTo(new RenderInfo(128, 133, 0, 0, 12, 14, 32, 64)));
            Assert.That(renderInfos.ElementAt(1), Is.EqualTo(new RenderInfo(128+32, 133, 0, 1, 11, 20, 32, 64)));
            Assert.That(renderInfos.ElementAt(2), Is.EqualTo(new RenderInfo(128, 133+64, 0, 1, 11, 20, 32, 64)));
            Assert.That(renderInfos.ElementAt(3), Is.EqualTo(new RenderInfo(128+32, 133+64, 0, 0, 12, 14, 32, 64)));
        }

        [Test]
        public void Should_create_object_that_can_be_controlled_by_the_player()
        {
            var sessionData = SessionDataConverter.Convert(ReadResourceFile("controllableObject.json"));
            var gameWorld = new GameWorld(sessionData);
            var theObject = sessionData.First();
            theObject.IsAt(5, 6).OnLayer(0);
            new MoveControlledCharacter(gameWorld).MoveUp();
            theObject.IsAt(5, 7);
            new MoveControlledCharacter(gameWorld).MoveRight();
            theObject.IsAt(6, 7);
            new MoveControlledCharacter(gameWorld).MoveDown();
            theObject.IsAt(6, 6);
            new MoveControlledCharacter(gameWorld).MoveLeft();
            theObject.IsAt(5, 6);
        }

        [Test]
        public void Should_create_object_that_is_shown_on_screen()
        {
            var sessionData = new GameWorld(SessionDataConverter.Convert(ReadResourceFile("renderableObject.json")));
            var renderInfo = new ShowAllRenderableObjects(sessionData).Render().First();
            renderInfo.WillBeDrawnAtScreenCoordinates(1, 2).AtLayer(3).CutFromTileSet(0).StartingAt(13, 17).WithSize(32, 64);
        }

        [Test]
        public void Should_create_one_empty_object()
        {
            var list  = SessionDataConverter.Convert(ReadResourceFile("emptyObject.json"));
            var gameObject = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.IsNull(gameObject.Name);
            Assert.IsNull(gameObject.Controllable);
            Assert.IsNull(gameObject.Position);
        }

        [Test]
        public void Should_create_empty_list()
        {
            var list = SessionDataConverter.Convert(ReadResourceFile("emptyList.json"));
            Assert.AreEqual(0, list.Count);
        }

        private string ReadResourceFile(string filename)
        {
            var resourceName = "OnionMaster.Resources." + filename;
            try
            {                
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch(ArgumentNullException e)
            {
                var found = String.Join(", ", Assembly.GetExecutingAssembly().GetManifestResourceNames());
                var message = $"Could not find resource: { resourceName }. Found resources: { found }.";
                throw new ArgumentNullException(message, e);
            }
        }
    }
}
