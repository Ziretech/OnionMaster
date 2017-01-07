using System.Collections.Generic;
using EntityLayer;
using System.Linq;

namespace AdaptorLayer
{
    public class Session : ISession
    {
        public bool ExitGame { get; set; }
        private readonly List<GameObject> _gameObjects;
        private readonly IInput _input;
        private readonly IUseCaseProvider _useCases;

        public Session(List<GameObject> data, IInput input, IUseCaseProvider useCases)
        {
            _gameObjects = data;
            _input = input;
            _useCases = useCases;
        }

        public IEnumerable<DrawCommand> DrawScreen()
        {
            return _useCases.GetShowAllRenderableObjects(_gameObjects).Render().OrderBy(info => info.ScreenLayer).Select(info => new DrawCommand(info));
        }

        public void Update()
        {
            if (_input.IsCloseApplicationPressed())
            {
                ExitGame = true;
            }
            if (_input.IsMoveUpPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameObjects).MoveUp();
            }
            if (_input.IsMoveDownPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameObjects).MoveDown();
            }
            if (_input.IsMoveRightPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameObjects).MoveRight();
            }
            if (_input.IsMoveLeftPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameObjects).MoveLeft();
            }
        }
    }
}
