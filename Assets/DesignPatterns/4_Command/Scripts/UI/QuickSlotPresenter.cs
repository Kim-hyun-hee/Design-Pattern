using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

namespace DesignPatterns.Command
{
    public class QuickSlotPresenter : MonoBehaviour
    {
        [SerializeField]
        private QuickSlotView quickSlotView;
        [SerializeField]
        private InputHandler inputHandler;

        private void Start()
        {
            quickSlotView.Init();
            quickSlotView.OnEndDragObservable.Subscribe(draggableCommand =>
            {
                ChangeSlot(draggableCommand.prevKeyCode, draggableCommand.currentKeyCode);
            }).AddTo(quickSlotView);
        }

        public void ChangeSlot(KeyCode keyCode1, KeyCode keyCode2)
        {
            inputHandler.ChangeCommand(keyCode1, keyCode2);
        }

        public void Pressed(KeyCode keyCode)
        {
            quickSlotView.Pressed(keyCode);
        }

        public void Released(KeyCode keyCode)
        {
            quickSlotView.Released(keyCode);
        }
    }
}
