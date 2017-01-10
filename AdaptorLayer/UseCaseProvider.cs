using System;
using System.Collections.Generic;
using EntityLayer;
using UseCaseLayer.Player;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public class UseCaseProvider : IUseCaseProvider
    {
        public IMovable GetMoveControlledCharacter(GameWorld gameWorld)
        {
            return new MoveControlledCharacter(gameWorld);
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