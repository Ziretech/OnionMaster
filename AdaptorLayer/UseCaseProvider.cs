using System;
using System.Collections.Generic;
using EntityLayer;
using UseCaseLayer.Player;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public class UseCaseProvider : IUseCaseProvider
    {
        public IMoveControlledCharacter GetMoveControlledCharacter(GameWorld gameWorld)
        {
            return new MoveControlledCharacter(gameWorld);
        }

        public IShowAllRenderableObjects GetShowAllRenderableObjects(GameWorld gameWorld)
        {
            return new ShowAllRenderableObjects(gameWorld);
        }
    }
}