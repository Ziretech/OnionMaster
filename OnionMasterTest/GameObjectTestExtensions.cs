using NUnit.Framework;
using EntityLayer;

namespace OnionMaster
{
    public static class GameObjectTestExtensions
    {
        public static GameObject IsAt(this GameObject o, int x, int y)
        {
            Assert.AreEqual(x, o.Position.X);
            Assert.AreEqual(y, o.Position.Y);
            return o;
        }

        public static GameObject OnLayer(this GameObject o, int layer)
        {
            Assert.AreEqual(layer, o.Position.Z);
            return o;
        }
    }
}
