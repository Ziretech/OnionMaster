using NUnit.Framework;

namespace EntityLayer
{
    [TestFixture]
    public class TileDimensionTest
    {
        private TileDimension _dimension;

        [SetUp]
        public void Setup()
        {
            _dimension = new TileDimension(1, 2);
        }

        [Test]
        public void Should_have_a_constructor_to_set_width_height()
        {
            Assert.That(_dimension.Width, Is.EqualTo(1));
            Assert.That(_dimension.Height, Is.EqualTo(2));
        }

        [Test]
        public void Should_consider_two_coordinates_with_same_value_as_equal()
        {
            Assert.That(_dimension, Is.EqualTo(new TileDimension(1, 2)));
        }

        [Test]
        public void Should_convert_to_string()
        {
            Assert.That(_dimension.ToString(), Is.EqualTo("1x2"));
        }
    }
}
