using EntityLayer;
using NUnit.Framework;
using System.Collections.Generic;

namespace UseCaseLayer.Rendering
{
    [TestFixture]
    public class ShowAnimatedObjects_FindCurrentFrameTest
    {
        private List<Frame> _frames;
        private Frame _firstFrame;
        private Frame _secondFrame;

        [SetUp]
        public void Setup()
        {
            _firstFrame = new Frame(new TileSetCoordinate(10, 11, 12), new TileDimension(13, 14), 1);
            _secondFrame = new Frame(new TileSetCoordinate(20, 21, 22), new TileDimension(23, 24), 1);
            _frames = new List<Frame> { _firstFrame, _secondFrame };
        }

        [Test]
        public void Should_find_first_frame_at_tick_0()
        {
            var frame = ShowAnimatedObjects.FindCurrentFrame(_frames, 0);
            Assert.That(frame, Is.EqualTo(_firstFrame));
        }

        [Test]
        public void Should_find_second_frame_at_tick_1_when_duration_of_first_frame_is_1()
        {
            var frame = ShowAnimatedObjects.FindCurrentFrame(_frames, 1);
            Assert.That(frame, Is.EqualTo(_secondFrame));
        }

        [Test]
        public void Should_find_first_frame_at_tick_1_when_duration_of_first_frame_is_2()
        {
            _firstFrame.Duration = 2;
            var frame = ShowAnimatedObjects.FindCurrentFrame(_frames, 1);
            Assert.That(frame, Is.EqualTo(_firstFrame));
        }

        [Test]
        public void Should_find_second_frame_at_tick_2_when_duration_of_first_frame_is_2()
        {
            _firstFrame.Duration = 2;
            var frame = ShowAnimatedObjects.FindCurrentFrame(_frames, 2);
            Assert.That(frame, Is.EqualTo(_secondFrame));
        }
    }
}
