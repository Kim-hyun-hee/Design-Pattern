using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class MoveCommand : ICommand
    {
        private readonly IReceiver receiver;
        private readonly Vector3 moveVec;

        public MoveCommand(IReceiver receiver, Vector3 moveVec)
        {
            this.receiver = receiver;
            this.moveVec = moveVec;
        }

        public void Excute()
        {
            if (receiver.IsValidMove(moveVec))
                receiver.Move(moveVec);
        }

        public void Undo()
        {
            receiver.Move(-moveVec);
        }
    }
}
