using System;
using System.Collections.Generic;
using EntityLayer;
using UseCaseLayer.Player;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public class UseCaseProvider : IUseCaseProvider
    {
        public IMoveControlledCharacter GetMoveControlledCharacter(List<GameObject> gameObjects)
        {
            return new MoveControlledCharacter(gameObjects);
        }

        public IShowAllRenderableObjects GetShowAllRenderableObjects(List<GameObject> gameObjects)
        {
            return new ShowAllRenderableObjects(gameObjects);
        }
    }
}