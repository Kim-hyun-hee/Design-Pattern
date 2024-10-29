using UnityEngine;

namespace DesignPatterns.MVC
{
    public class ClickDamage : MonoBehaviour
    {
        [SerializeField]
        private HealthController healthController;
        [SerializeField]
        private int damage = 10;

        private void Awake()
        {
            TryGetComponent(out healthController);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, Mathf.Infinity))
                {
                    healthController.DecreaseHealth(damage);
                }
            }
        }
    }
}
