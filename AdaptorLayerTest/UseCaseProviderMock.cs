using System;
using System.Collections.Generic;
using EntityLayer;
using UseCaseLayer.Player;
using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    internal class UseCaseProviderMock : IUseCaseProvider
    {
        public MovableMock MoveControlledCharacterMock { get; set; }
        public RenderableMock ShowAllRenderableObjectsMock { get; set; }
        public RenderableMock ShowTiledAreaObjectsMock { get; set; }

        public UseCaseProviderMock()
        {
            MoveControlledCharacterMock = new MovableMock();
            ShowAllRenderableObjectsMock = new RenderableMock();
            ShowTiledAreaObjectsMock = new RenderableMock();
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
