using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public interface IReceiver
    {
        void Move(Vector3 moveVec);
        bool IsValidMove(Vector3 moveVec);
    }
}
