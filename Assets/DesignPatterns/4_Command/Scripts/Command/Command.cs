using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class Command : ICommand
    {
        public bool Excute() { return true; }
        public void Undo() { }
    }
}
