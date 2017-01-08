using System.Linq;
using System.Collections.Generic;
using EntityLayer;
using System;

namespace UseCaseLayer.Player
{
    public class MoveControlledCharacter : IMovable
    {
        private readonly List<GameObject> _moveable;

        public MoveControlledCharacter(GameWorld gameWorld)
        {
            if(gameWorld == null)
            {
                throw new ArgumentNullException("GameWorld must not be null");
            }
            _moveable = gameWorld.GetObjects().Where(o => IsMovable(o)).ToList();
        }

        public void MoveUp()
        {
            _moveable.ForEach(o => o.Position.Y += o.Controllable.MoveUp);
        }

        public void MoveDown()
        {
            _moveable.ForEach(o => o.Position.Y -= o.Controllable.MoveDown);
        }

        public void MoveRight()
        {
            _moveable.ForEach(o => o.Position.X += o.Controllable.MoveRight);
        }

        public void MoveLeft()
        {
            _moveable.ForEach(o => o.Position.X -= o.Controllable.MoveLeft);
        }

        private bool IsMovable(GameObject gameObject)
        {
            return gameObject.Controllable != null && gameObject.Position != null;
        }
    }
}
