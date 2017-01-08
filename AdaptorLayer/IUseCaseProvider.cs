using EntityLayer;
using System.Collections.Generic;
using UseCaseLayer.Player;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public interface IUseCaseProvider
    {
        IMovable GetMoveControlledCharacter(GameWorld gameWorld);
        IRenderable GetShowAllRenderableObjects(GameWorld gameWorld);
        IRenderable GetShowTiledAreaObjects(GameWorld gameWorld);
    }
}