using NUnit.Framework;

namespace EntityLayer
{
    [TestFixture]
    public class TileSetCoordinateTest
    {
        private TileSetCoordinate _coordinate;

        [SetUp]
        public void Setup()
        {
            _coordinate = new TileSetCoordinate(1, 2, 3);
        }

        [Test]
        public void Should_have_a_constructor_to_set_id_x_y()
        {
            Assert.That(_coordinate.Id, Is.EqualTo(1));
            Assert.That(_coordinate.X, Is.EqualTo(2));
            Assert.That(_coordinate.Y, Is.EqualTo(3));
        }

        [Test]
        public void Should_consider_two_coordinates_with_same_value_as_equal()
        {
            Assert.That(_coordinate, Is.EqualTo(new TileSetCoordinate(1, 2, 3)));
        }

        [Test]
        public void Should_convert_to_string()
        {
            Assert.That(_coordinate.ToString(), Is.EqualTo("1@2,3"));
        }
    }
}
