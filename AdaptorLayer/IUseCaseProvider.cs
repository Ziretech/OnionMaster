using EntityLayer;
using System.Collections.Generic;
using UseCaseLayer.Player;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public interface IUseCaseProvider
    {
        IMoveControlledCharacter GetMoveControlledCharacter(GameWorld gameWorld);
        IShowAllRenderableObjects GetShowAllRenderableObjects(GameWorld gameWorld);
    }
}