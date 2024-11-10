using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DesignPatterns.Command
{
    public class DraggableCommand : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField]
        private Image image;
        [HideInInspector]
        public Transform currentParent;
        [HideInInspector]
        public KeyCode prevKeyCode;
        [HideInInspector]
        public KeyCode currentKeyCode;

        public void OnBeginDrag(PointerEventData eventData)
        {
            prevKeyCode = currentKeyCode;

            transform.SetParent(currentParent.root);
            transform.SetAsLastSibling();
            transform.position = eventData.position;
            image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(currentParent);
            transform.SetAsFirstSibling();
            transform.position = currentParent.position;
            image.raycastTarget = true;
        }
    }
}
