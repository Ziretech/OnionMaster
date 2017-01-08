using UseCaseLayer.Player;

namespace AdaptorLayer
{
    internal class MovableMock : IMovable
    {
        public int MoveUpCalled { get; private set; }
        public int MoveDownCalled { get; private set; }
        public int MoveRightCalled { get; private set; }
        public int MoveLeftCalled { get; private set; }

        public MovableMock() { }

        public void MoveUp()
        {
            MoveUpCalled++;
        }

        public void MoveDown()
        {
            MoveDownCalled++;
        }

        public void MoveRight()
        {
            MoveRightCalled++;
        }

        public void MoveLeft()
        {
            MoveLeftCalled++;
        }
    }
}
