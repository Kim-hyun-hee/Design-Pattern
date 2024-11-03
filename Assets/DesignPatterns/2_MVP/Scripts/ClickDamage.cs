using UnityEngine;

using Zenject;

namespace DesignPatterns.MVP
{
    public class ClickDamage : MonoBehaviour
    {
        [Inject]
        private readonly IHealthPresenter healthPresenter;
        [SerializeField]
        private int damage = 10;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, Mathf.Infinity))
                {
                    healthPresenter.DecreaseHealth(damage);
                }
            }
        }
    }
}
