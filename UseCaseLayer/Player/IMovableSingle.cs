using EntityLayer;

namespace UseCaseLayer.Player
{
    public interface IMovableSingle
    {
        void MoveUp(GameObject gameObject);
        void MoveDown(GameObject gameObject);
        void MoveRight(GameObject gameObject);
        void MoveLeft(GameObject gameObject);
        bool IsControllable(GameObject gameObject);
    }
}