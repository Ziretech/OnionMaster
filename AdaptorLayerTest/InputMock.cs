namespace AdaptorLayer
{
    public class InputMock : IInput
    {
        public bool Down { get; set; }
        public bool Escape { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }

        public InputMock()
        {
        }

        public InputMock(bool escape, bool up, bool down, bool right, bool left)
        {
            Escape = escape;
            Up = up;
            Down = down;
            Right = right;
            Left = left;
        }

        public bool IsMoveDownPressed()
        {
            return Down;
        }

        public bool IsCloseApplicationPressed()
        {
            return Escape;
        }

        public bool IsMoveLeftPressed()
        {
            return Left;
        }

        public bool IsMoveRightPressed()
        {
            return Right;
        }

        public bool IsMoveUpPressed()
        {
            return Up;
        }
    }
}
