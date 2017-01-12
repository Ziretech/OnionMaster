using System.Linq;
using System.Collections.Generic;
using EntityLayer;
using System;

namespace UseCaseLayer.Player
{
    public class MoveControlledCharacter : IMovable
    {
        private readonly List<GameObject> _moveable;
        private readonly MoveControlledCharacterSingleObject _move;

        public MoveControlledCharacter(GameWorld gameWorld)
        {
            _move = new MoveControlledCharacterSingleObject();
            if (gameWorld == null)
            {
                throw new ArgumentNullException("GameWorld must not be null");
            }
            
            _moveable = gameWorld.GetObjects().Where(o => _move.IsControllable(o)).ToList();
            
        }

        public void MoveUp()
        {
            _moveable.ForEach(o => _move.MoveUp(o));
        }

        public void MoveDown()
        {
            _moveable.ForEach(o => _move.MoveDown(o));
        }

        public void MoveRight()
        {
            _moveable.ForEach(o => _move.MoveRight(o));
        }

        public void MoveLeft()
        {
            _moveable.ForEach(o => _move.MoveLeft(o));
        }
    }
}
