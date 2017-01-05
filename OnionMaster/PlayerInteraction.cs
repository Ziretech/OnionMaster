using System;
using AdaptorLayer;
using OpenTK.Input;
using OnionMaster.Properties;

namespace OnionMaster
{
    internal class PlayerInteraction : IInput
    {
        private KeyboardDevice _keyboard;

        public PlayerInteraction(KeyboardDevice keyboard)
        {
            _keyboard = keyboard;
        }

        public bool IsMoveDownPressed()
        {
            return _keyboard[Settings.Default.KeyMoveDown];
        }

        public bool IsCloseApplicationPressed()
        {
            return _keyboard[Settings.Default.KeyCloseApplication];
        }

        public bool IsMoveLeftPressed()
        {
            return _keyboard[Settings.Default.KeyMoveLeft];
        }

        public bool IsMoveRightPressed()
        {
            return _keyboard[Settings.Default.KeyMoveRight];
        }

        public bool IsMoveUpPressed()
        {
            return _keyboard[Settings.Default.KeyMoveUp];
        }
    }
}