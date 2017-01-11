using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [TestFixture]
    public class FrameTest
    {
        private Frame _frame;
        private TileSetCoordinate _coordinate;
        private TileDimension _dimension;

        [SetUp]
        public void Setup()
        {
            _coordinate = new TileSetCoordinate(1, 2, 3);
            _dimension = new TileDimension(4, 5);
            _frame = new Frame(_coordinate, _dimension, 3);
        }

        [Test]
        public void Should_have_coordinates()
        {
            Assert.That(_frame.TileSetCoordinate, Is.EqualTo(_coordinate));
        }

        [Test]
        public void Should_have_dimension()
        {
            Assert.That(_frame.TileDimension, Is.EqualTo(_dimension));
        }

        [Test]
        public void Should_have_time()
        {
            Assert.That(_frame.Duration, Is.EqualTo(3));
        }

        [Test]
        public void Should_consider_two_frames_with_equals_values_as_equal()
        {
            Assert.That(_frame, Is.EqualTo(new Frame(new TileSetCoordinate(1, 2, 3), new TileDimension(4, 5), 3)));
            Assert.That(_frame, Is.Not.EqualTo(new Frame(new TileSetCoordinate(1, 2, 4), new TileDimension(4, 5), 3)));
            Assert.That(_frame, Is.Not.EqualTo(new Frame(new TileSetCoordinate(1, 2, 3), new TileDimension(5, 5), 3)));
            Assert.That(_frame, Is.Not.EqualTo(new Frame(null, new TileDimension(4, 5), 3)));
            Assert.That(_frame, Is.Not.EqualTo(new Frame(new TileSetCoordinate(1, 2, 3), null, 3)));
            Assert.That(_frame, Is.Not.EqualTo(new Frame(new TileSetCoordinate(1, 2, 3), new TileDimension(4, 5), 2)));
        }

        [Test]
        public void Should_generelly_have_different_hashcode_when_values_differ()
        {
            Assert.That(_frame.GetHashCode(), Is.EqualTo(new Frame(new TileSetCoordinate(1, 2, 3), new TileDimension(4, 5), 3).GetHashCode()));
            Assert.That(_frame.GetHashCode(), Is.Not.EqualTo(new Frame(new TileSetCoordinate(0, 2, 3), new TileDimension(4, 5), 3).GetHashCode()));
            Assert.That(_frame.GetHashCode(), Is.Not.EqualTo(new Frame(new TileSetCoordinate(1, 2, 3), new TileDimension(0, 5), 3).GetHashCode()));
            Assert.That(_frame.GetHashCode(), Is.Not.EqualTo(new Frame(new TileSetCoordinate(1, 2, 3), new TileDimension(4, 5), 0).GetHashCode()));
        }

        [Test]
        public void Should_convert_to_string()
        {
            Assert.That(_frame.ToString(), Is.EqualTo("1@2,3 4x5 :3"));
        }
    }
}
