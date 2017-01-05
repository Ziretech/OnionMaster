namespace AdaptorLayer
{
    public interface IInput
    {
        bool IsEscapePressed();
        bool IsDownPressed();
        bool IsUpPressed();
        bool IsRightPressed();
        bool IsLeftPressed();
    }
}
