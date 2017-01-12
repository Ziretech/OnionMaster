using System;
using System.Collections.Generic;
using EntityLayer;
using UseCaseLayer.Player;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public class UseCaseProvider : IUseCaseProvider
    {
        private readonly MoveControlledCharacterSingleObject _moveControlledObject;

        public UseCaseProvider()
        {
            _moveControlledObject = new MoveControlledCharacterSingleObject();
        }

        public IMovable GetMoveControlledCharacter(GameWorld gameWorld)
        {
            return new MoveControlledCharacter(gameWorld, _moveControlledObject);
        }

        public IRenderable GetShowAllRenderableObjects(GameWorld gameWorld)
        {
            return new ShowAllRenderableObjects(gameWorld);
        }

        public IRenderable GetShowTiledAreaObjects(GameWorld gameWorld)
        {
            return new ShowTiledAreaObjects(gameWorld);
        }

        public IRenderable GetShowAnimatedObjects(GameWorld world, int tick)
        {
            return new ShowAnimatedObjects(world, tick);
        }
    }
}