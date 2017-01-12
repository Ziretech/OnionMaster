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
        public RenderableMock ShowAnimatedObjectsMock { get; set; }

        public IMovableSingle MoveControlledObject { get; }

        public UseCaseProviderMock()
        {
            MoveControlledCharacterMock = new MovableMock();
            ShowAllRenderableObjectsMock = new RenderableMock();
            ShowTiledAreaObjectsMock = new RenderableMock();
            ShowAnimatedObjectsMock = new RenderableMock();
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

        public IRenderable GetShowAnimatedObjects(GameWorld gameWorld, int tick)
        {
            ShowAnimatedObjectsMock.LatestCalledTick = tick;
            return ShowAnimatedObjectsMock;
        }
    }
}
