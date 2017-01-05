using System.Linq;
using System.Collections.Generic;
using EntityLayer;

namespace UseCaseLayer.Player
{
    public class MoveControlledCharacter : IMoveControlledCharacter
    {
        private List<GameObject> _moveable;

        public MoveControlledCharacter(List<GameObject> gameObjects)
        {
            _moveable = gameObjects.Where(o => IsMovable(o)).ToList();
        }

        public void MoveUp()
        {
            _moveable.ForEach(o => o.Positional.Y += o.Controllable.MoveUp);
        }

        public void MoveUp_()
        {
            _moveable.ForEach(o => o.Positional.Y += o.Controllable.MoveUp);
        }

        public void MoveDown()
        {
            _moveable.ForEach(o => o.Positional.Y -= o.Controllable.MoveDown);
        }

        public void MoveRight()
        {
            _moveable.ForEach(o => o.Positional.X += o.Controllable.MoveRight);
        }

        public void MoveLeft()
        {
            _moveable.ForEach(o => o.Positional.X -= o.Controllable.MoveLeft);
        }

        private bool IsMovable(GameObject gameObject)
        {
            return gameObject.Controllable != null && gameObject.Positional != null;
        }
    }
}
