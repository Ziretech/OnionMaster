using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class GameWorld
    {
        List<GameObject> _gameObjects;

        public GameWorld(List<GameObject> gameObjects)
        {
            _gameObjects = gameObjects;
        }

        public List<GameObject> GetObjects()
        {
            return _gameObjects;
        }
    }
}
