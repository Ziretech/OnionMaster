namespace AdaptorLayer
{
    class InputMock : IInput
    {
        private readonly bool _down;
        private readonly bool _escape;
        private readonly bool _left;
        private readonly bool _right;
        private readonly bool _up;

        public InputMock()
        {
        }

        public InputMock(bool escape, bool up, bool down, bool right, bool left)
        {
            _escape = escape;
            _up = up;
            _down = down;
            _right = right;
            _left = left;
        }

        public bool IsDownPressed()
        {
            return _down;
        }

        public bool IsEscapePressed()
        {
            return _escape;
        }

        public bool IsLeftPressed()
        {
            return _left;
        }

        public bool IsRightPressed()
        {
            return _right;
        }

        public bool IsUpPressed()
        {
            return _up;
        }
    }
}
