using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField]
        private PlayerController playerController;

        private readonly CommandInvoker CommandInvoker = new();
        private readonly Dictionary<KeyCode, Func<ICommand>> keyBindings = new Dictionary<KeyCode, Func<ICommand>>();

        private Func<ICommand> WCommand;
        private Func<ICommand> ACommand;
        private Func<ICommand> SCommand;
        private Func<ICommand> DCommand;

        private Func<ICommand> QCommand;
        private Func<ICommand> ECommand;
        private Func<ICommand> RCommand;
        private Func<ICommand> FCommand;

        private void Start()
        {
            WCommand = MoveForwardCommand;
            ACommand = MoveLeftCommand;
            SCommand = MoveBackCommand;
            DCommand = MoveRightCommand;

            QCommand = DefaultCommand;
            ECommand = DefaultCommand;
            RCommand = DefaultCommand;
            FCommand = DefaultCommand;

            keyBindings[KeyCode.W] = WCommand;
            keyBindings[KeyCode.A] = ACommand;
            keyBindings[KeyCode.S] = SCommand;
            keyBindings[KeyCode.D] = DCommand;

            keyBindings[KeyCode.Q] = QCommand;
            keyBindings[KeyCode.E] = ECommand;
            keyBindings[KeyCode.R] = RCommand;
            keyBindings[KeyCode.F] = FCommand;
        }

        private void Update()
        {
            foreach (var kvPair in keyBindings)
            {
                if (Input.GetKeyDown(kvPair.Key))
                {
                    CommandInvoker.ExcuteCommand(kvPair.Value());
                }
            }
        }

        public void ChangeCommand(KeyCode keyCode1, KeyCode keyCode2)
        {
            if (keyCode1 == keyCode2) return;
            var command = keyBindings[keyCode1];
            keyBindings[keyCode1] = keyBindings[keyCode2];
            keyBindings[keyCode2] = command;
        }

        private ICommand MoveForwardCommand()
        {
            return new MoveCommand(playerController, Vector3.forward);
        }

        private ICommand MoveRightCommand()
        {
            return new MoveCommand(playerController, Vector3.right);
        }

        private ICommand MoveBackCommand()
        {
            return new MoveCommand(playerController, Vector3.back);
        }

        private ICommand MoveLeftCommand()
        {
            return new MoveCommand(playerController, Vector3.left);
        }

        private ICommand DefaultCommand()
        {
            return new Command();
        }
    }
}
