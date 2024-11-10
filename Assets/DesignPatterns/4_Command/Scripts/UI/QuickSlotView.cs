using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

using UniRx;
using UniRx.Triggers;

namespace DesignPatterns.Command
{
    public class QuickSlotView : MonoBehaviour
    {
        [SerializeField]
        private Dictionary<KeyCode, Slot> slots;

        public IObservable<DraggableCommand> OnEndDragObservable { get; private set; }

        private void Start()
        {
            slots = GetComponentsInChildren<Slot>().ToDictionary(slot => slot.keyCode, slot => slot);
            OnEndDragObservable = slots.ToObservable()
                .SelectMany(slot => slot.Value.OnDropAsObservable().Select(eventData => eventData.pointerDrag.GetComponent<DraggableCommand>()));
        }

        public void Pressed(KeyCode keyCode)
        {
            slots[keyCode].Pressed();
        }

        public void Released(KeyCode keyCode)
        {
            slots[keyCode].Released();
        }
    }
}
