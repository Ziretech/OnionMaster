using System.Collections.Generic;
using EntityLayer;
using System.Linq;

namespace AdaptorLayer
{
    public class Session : ISession
    {
        public bool ExitGame { get; set; }
        private readonly GameWorld _gameWorld;
        private readonly IInput _input;
        private readonly IUseCaseProvider _useCases;

        public Session(GameWorld gameWorld, IInput input, IUseCaseProvider useCases)
        {
            _gameWorld = gameWorld;
            _input = input;
            _useCases = useCases;
        }

        public IEnumerable<DrawCommand> DrawScreen()
        {
            return _useCases.GetShowAllRenderableObjects(_gameWorld).Render().OrderBy(info => info.ScreenLayer).Select(info => new DrawCommand(info));
        }

        public void Update()
        {
            if (_input.IsCloseApplicationPressed())
            {
                ExitGame = true;
            }
            if (_input.IsMoveUpPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameWorld).MoveUp();
            }
            if (_input.IsMoveDownPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameWorld).MoveDown();
            }
            if (_input.IsMoveRightPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameWorld).MoveRight();
            }
            if (_input.IsMoveLeftPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameWorld).MoveLeft();
            }
        }
    }
}
