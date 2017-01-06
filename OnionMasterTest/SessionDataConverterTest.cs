using System;
using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace OnionMaster
{
    [TestFixture]
    public class SessionDataConverterTest
    {
        [Test]
        public void Should_create_controllable_object()
        {
            var list = SessionDataConverter.Convert(ReadResourceFile("controllableObject.json"));
            Assert.AreEqual(1, list[0].Controllable.MoveUp);
            Assert.AreEqual(2, list[0].Controllable.MoveDown);
            Assert.AreEqual(3, list[0].Controllable.MoveRight);
            Assert.AreEqual(4, list[0].Controllable.MoveLeft);
        }

        [Test]
        public void Should_create_positional_object()
        {
            var list = SessionDataConverter.Convert(ReadResourceFile("positionalObject.json"));
            Assert.AreEqual(128, list[0].Positional.X);
            Assert.AreEqual(3, list[0].Positional.Y);
            Assert.AreEqual(10, list[0].Positional.Z);
        }

        [Test]
        public void Should_create_renderable_object()
        {
            var list = SessionDataConverter.Convert(ReadResourceFile("renderableObject.json"));
            Assert.AreEqual(0, list[0].Renderable.TileSetId);
            Assert.AreEqual(13, list[0].Renderable.TileSetX);
            Assert.AreEqual(17, list[0].Renderable.TileSetY);
            Assert.AreEqual(32, list[0].Renderable.TileWidth);
            Assert.AreEqual(64, list[0].Renderable.TileHeight);
        }

        [Test]
        public void Should_create_one_empty_object()
        {
            var list  = SessionDataConverter.Convert(ReadResourceFile("emptyObject.json"));
            var gameObject = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.IsNull(gameObject.Name);
            Assert.IsNull(gameObject.Controllable);
            Assert.IsNull(gameObject.Positional);
            Assert.IsNull(gameObject.Renderable);
        }

        [Test]
        public void Should_create_empty_list()
        {
            var list = SessionDataConverter.Convert(ReadResourceFile("emptyList.json"));
            Assert.AreEqual(0, list.Count);
        }

        private string ReadResourceFile(string filename)
        {
            var resourceName = "OnionMasterTest.Resources." + filename;
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
