namespace EntityLayer
{
    public class Controllable
    {
        public int MoveUp { get; set; }
        public int MoveDown { get; set; }
        public int MoveRight { get; set; }
        public int MoveLeft { get; set; }

        public Controllable(int moveUp, int moveDown, int moveRight, int moveLeft)
        {
            MoveUp = moveUp;
            MoveDown = moveDown;
            MoveRight = moveRight;
            MoveLeft = moveLeft;
        }
    }
}