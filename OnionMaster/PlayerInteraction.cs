using System;
using AdaptorLayer;
using OpenTK.Input;

namespace OnionMaster
{
    internal class PlayerInteraction : IInput
    {
        private KeyboardDevice _keyboard;

        public PlayerInteraction(KeyboardDevice keyboard)
        {
            _keyboard = keyboard;
        }

        public bool IsDownPressed()
        {
            return _keyboard[Key.Down];
        }

        public bool IsEscapePressed()
        {
            return _keyboard[Key.Escape];
        }

        public bool IsLeftPressed()
        {
            return _keyboard[Key.Left];
        }

        public bool IsRightPressed()
        {
            return _keyboard[Key.Right];
        }

        public bool IsUpPressed()
        {
            return _keyboard[Key.Up];
        }
    }
}