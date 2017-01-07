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

        public UseCaseProviderMock()
        {
            MoveControlledCharacterMock = new MoveControlledCharacterMock();
            ShowAllRenderableObjectsMock = new ShowAllRenderableObjectsMock();
        }

        public IMoveControlledCharacter GetMoveControlledCharacter(List<GameObject> _gameObjects)
        {
            return MoveControlledCharacterMock;
        }

        public IShowAllRenderableObjects GetShowAllRenderableObjects(List<GameObject> _gameObjects)
        {
            return ShowAllRenderableObjectsMock;
        }
    }
}
