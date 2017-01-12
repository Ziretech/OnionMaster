using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace UseCaseLayer.Player
{
    public class MoveControlledCharacterSingleObject
    {
        public void MoveUp(GameObject gameObject)
        {
            gameObject.Position.Y += gameObject.Controllable.MoveUp;
        }

        public void MoveRight(GameObject gameObject)
        {
            gameObject.Position.X += gameObject.Controllable.MoveRight;
        }

        public void MoveDown(GameObject gameObject)
        {
            gameObject.Position.Y -= gameObject.Controllable.MoveDown;
        }

        public void MoveLeft(GameObject gameObject)
        {
            gameObject.Position.X -= gameObject.Controllable.MoveLeft;
        }

        public bool IsControllable(GameObject _gameObject)
        {
            return _gameObject.Position != null && _gameObject.Controllable != null;
        }
    }
}
