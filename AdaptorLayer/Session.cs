﻿using System.Collections.Generic;
using EntityLayer;
using System.Linq;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public class Session : ISession
    {
        public bool ExitGame { get; set; }
        private readonly GameWorld _gameWorld;
        private readonly IInput _input;
        private readonly IUseCaseProvider _useCases;
        private int _tick;

        public Session(GameWorld gameWorld, IInput input, IUseCaseProvider useCases)
        {
            _gameWorld = gameWorld;
            _input = input;
            _useCases = useCases;
            _tick = 0;
        }

        public IEnumerable<DrawCommand> DrawScreen()
        {
            return ShowRenderableObject()
                .Concat(ShowTiledAreaObjects())
                .Concat(ShowAnimatedObjects())
                .OrderBy(info => info.ScreenLayer).Select(info => new DrawCommand(info));
        }

        private IEnumerable<RenderInfo> ShowRenderableObject()
        {
            return _useCases.GetShowAllRenderableObjects(_gameWorld).Render();
        }
        private IEnumerable<RenderInfo> ShowTiledAreaObjects()
        {
            return _useCases.GetShowTiledAreaObjects(_gameWorld).Render();
        }
        private IEnumerable<RenderInfo> ShowAnimatedObjects()
        {
            return _useCases.GetShowAnimatedObjects(_gameWorld, _tick).Render();
        }

        public void Update()
        {
            _tick++;            

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
