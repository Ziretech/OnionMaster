using EntityLayer;
using System.Collections.Generic;

namespace UseCaseLayer.Player
{
    class MoveControlledCharacterSingleObjectMock : IMovableSingle
    {
        public int ControllableCalled { get; private set; }
        public List<bool> Controllable { get; set; }
        public List<GameObject> MoveDownCalled { get; private set; }
        public List<GameObject> MoveLeftCalled { get; private set; }
        public List<GameObject> MoveRightCalled { get; private set; }
        public List<GameObject> MoveUpCalled { get; private set; }

        public MoveControlledCharacterSingleObjectMock()
        {
            MoveDownCalled = new List<GameObject>();
            MoveLeftCalled = new List<GameObject>();
            MoveRightCalled = new List<GameObject>();
            MoveUpCalled = new List<GameObject>();
        }

        public bool IsControllable(GameObject gameObject)
        {
            return Controllable[ControllableCalled++];
        }

        public void MoveDown(GameObject gameObject)
        {
            MoveDownCalled.Add(gameObject);
        }

        public void MoveLeft(GameObject gameObject)
        {
            MoveLeftCalled.Add(gameObject);
        }

        public void MoveRight(GameObject gameObject)
        {
            MoveRightCalled.Add(gameObject);
        }

        public void MoveUp(GameObject gameObject)
        {
            MoveUpCalled.Add(gameObject);
        }
    }
}
