using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DesignPatterns.Command
{
    public class Slot : UIBehaviour, IDropHandler
    {
        [SerializeField]
        private string keyName;
        [SerializeField]
        private GameObject pressedEffect;
        [HideInInspector]
        public KeyCode keyCode;

        protected override void Awake()
        {
            keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), keyName);
            var currentCommand = GetComponentInChildren<DraggableCommand>();
            if (currentCommand != null)
            {
                currentCommand.currentKeyCode = keyCode;
                currentCommand.currentParent = transform;
            }
        }

        public void Pressed()
        {
            pressedEffect.SetActive(true);
        }

        public void Released()
        {
            pressedEffect.SetActive(false);
        }

        public void OnDrop(PointerEventData eventData) // OnEndDrag 보다 먼저 실행됨
        {
            var dropped = eventData.pointerDrag;
            var droppedCommand = dropped.GetComponent<DraggableCommand>();
            if (droppedCommand == null) return;

            var droppedCommandKeyCode = droppedCommand.currentKeyCode;
            var droppedCommandParent = droppedCommand.currentParent;

            droppedCommand.currentKeyCode = keyCode;
            droppedCommand.currentParent = transform;

            var currentSlotCommand = transform.GetComponentInChildren<DraggableCommand>();
            if (currentSlotCommand != null)
            {
                currentSlotCommand.currentKeyCode = droppedCommandKeyCode;
                currentSlotCommand.currentParent = droppedCommandParent;

                currentSlotCommand.transform.SetParent(droppedCommandParent);
                currentSlotCommand.transform.SetAsFirstSibling();
                currentSlotCommand.transform.position = droppedCommandParent.position;
            }
        }
    }
}
