using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class CommandInvoker
    {
        public void ExcuteCommand(ICommand command)
        {
            command.Excute();
        }
    }
}
