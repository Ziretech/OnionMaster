﻿using System;
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
        private IUseCaseProvider _provider;

        [SetUp]
        public void Setup()
        {
            _provider = new UseCaseProvider();
        }

        [Test]
        public void Should_deserialize_json_for_animationObject()
        {
            var sessionData = SessionDataConverter.Convert(ResourceFile.Read("animationObject.json"));
            Assert.That(sessionData.Count, Is.EqualTo(1));
            var animation = sessionData.First().Animation;

            Assert.That(animation.Count, Is.EqualTo(2));
            Assert.That(animation.ElementAt(0).TileSetCoordinate, Is.EqualTo(new TileSetCoordinate(10, 11, 12)));
            Assert.That(animation.ElementAt(0).TileDimension, Is.EqualTo(new TileDimension(13, 14)));
            Assert.That(animation.ElementAt(1).TileSetCoordinate, Is.EqualTo(new TileSetCoordinate(20, 21, 22)));
            Assert.That(animation.ElementAt(1).TileDimension, Is.EqualTo(new TileDimension(23, 24)));
        }

        [Test]
        public void Should_create_object_rendered_as_an_area_of_equal_sized_tiles_side_by_side()
        {
            var sessionData = SessionDataConverter.Convert(ReadResourceFile("tiledAreaObject.json"));
            var renderInfos = _provider.GetShowTiledAreaObjects(new GameWorld(sessionData)).Render();
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
            _provider.GetMoveControlledCharacter(gameWorld).MoveUp();
            theObject.IsAt(5, 7);
            _provider.GetMoveControlledCharacter(gameWorld).MoveRight();
            theObject.IsAt(6, 7);
            _provider.GetMoveControlledCharacter(gameWorld).MoveDown();
            theObject.IsAt(6, 6);
            _provider.GetMoveControlledCharacter(gameWorld).MoveLeft();
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
