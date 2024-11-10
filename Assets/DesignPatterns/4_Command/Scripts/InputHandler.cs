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

        private void Start()
        {
            keyBindings[KeyCode.Q] = DefaultCommand;
            keyBindings[KeyCode.W] = () => MoveCommand(Vector3.forward);
            keyBindings[KeyCode.E] = DefaultCommand;
            keyBindings[KeyCode.R] = DefaultCommand;
            keyBindings[KeyCode.A] = () => MoveCommand(Vector3.left);
            keyBindings[KeyCode.S] = () => MoveCommand(Vector3.back);
            keyBindings[KeyCode.D] = () => MoveCommand(Vector3.right);
            keyBindings[KeyCode.F] = DefaultCommand;
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

        private ICommand MoveCommand(Vector3 direction)
        {
            return new MoveCommand(playerController, direction);
        }

        private ICommand DefaultCommand()
        {
            return new Command();
        }
    }
}
