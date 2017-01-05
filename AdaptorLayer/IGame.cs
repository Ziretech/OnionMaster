namespace AdaptorLayer
{
    public interface IInput
    {
        bool IsCloseApplicationPressed();
        bool IsMoveDownPressed();
        bool IsMoveUpPressed();
        bool IsMoveRightPressed();
        bool IsMoveLeftPressed();
    }
}
