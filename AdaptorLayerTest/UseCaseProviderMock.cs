using System;
using System.Collections.Generic;
using EntityLayer;
using UseCaseLayer.Player;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    internal class UseCaseProviderMock : IUseCaseProvider
    {
        public MoveControlledCharacterMock MoveControlledCharacterMock { get; set; }
        public ShowAllRenderableObjectsMock ShowAllRenderableObjectsMock { get; set; }
        public ShowTiledAreaObjectsMock ShowTiledAreaObjectsMock { get; set; }

        public UseCaseProviderMock()
        {
            MoveControlledCharacterMock = new MoveControlledCharacterMock();
            ShowAllRenderableObjectsMock = new ShowAllRenderableObjectsMock();
            ShowTiledAreaObjectsMock = new ShowTiledAreaObjectsMock();
        }

        public IMovable GetMoveControlledCharacter(GameWorld gameWorld)
        {
            return MoveControlledCharacterMock;
        }

        public IRenderable GetShowAllRenderableObjects(GameWorld gameWorld)
        {
            return ShowAllRenderableObjectsMock;
        }

        public IRenderable GetShowTiledAreaObjects(GameWorld gameWorld)
        {
            return ShowTiledAreaObjectsMock;
        }
    }
}
