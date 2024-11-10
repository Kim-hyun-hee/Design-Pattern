using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UniRx;
using UniRx.Triggers;

namespace DesignPatterns.Command
{
    public class QuickSlotView : MonoBehaviour
    {
        [SerializeField]
        private Slot[] slots;

        public IObservable<DraggableCommand> OnEndDragObservable { get; private set; }

        private void Awake()
        {
            slots = GetComponentsInChildren<Slot>();
            OnEndDragObservable = slots.ToObservable()
                .SelectMany(slot => slot.OnDropAsObservable().Select(eventData => eventData.pointerDrag.GetComponent<DraggableCommand>()));
        }
    }
}
