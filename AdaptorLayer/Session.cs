using System.Collections.Generic;
using Newtonsoft.Json;
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

        public Session(string data, IInput input, IUseCaseProvider useCases)
        {
            _gameObjects = JsonConvert.DeserializeObject<List<GameObject>>(data);
            _input = input;
            _useCases = useCases;
        }

        public IEnumerable<DrawCommand> DrawScreen()
        {
            return _useCases.GetShowAllRenderableObjects(_gameObjects).Render().OrderBy(info => info.ScreenLayer).Select(info => new DrawCommand(info));
        }

        public void Update()
        {
            if (_input.IsEscapePressed())
            {
                ExitGame = true;
            }
            if (_input.IsUpPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameObjects).MoveUp();
            }
            if (_input.IsDownPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameObjects).MoveDown();
            }
            if (_input.IsRightPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameObjects).MoveRight();
            }
            if (_input.IsLeftPressed())
            {
                _useCases.GetMoveControlledCharacter(_gameObjects).MoveLeft();
            }
        }
    }
}
