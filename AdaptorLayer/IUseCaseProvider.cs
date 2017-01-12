using EntityLayer;
using System.Collections.Generic;
using UseCaseLayer.Player;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public interface IUseCaseProvider
    {
        IMovableSingle MoveControlledObject { get; }

        IMovable GetMoveControlledCharacter(GameWorld gameWorld);
        IRenderable GetShowAllRenderableObjects(GameWorld gameWorld);
        IRenderable GetShowTiledAreaObjects(GameWorld gameWorld);
        IRenderable GetShowAnimatedObjects(GameWorld gameWorld, int tick);
    }
}