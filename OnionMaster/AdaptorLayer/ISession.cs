using OpenTK.Input;
using System.Collections.Generic;

namespace AdaptorLayer
{
    public interface ISession
    {
        bool ExitGame { get; }
        IEnumerable<DrawCommand> DrawScreen();
        void Update();
    }
}
