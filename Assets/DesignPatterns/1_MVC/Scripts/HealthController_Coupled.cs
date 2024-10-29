using UnityEngine;

namespace DesignPatterns.MVC
{
    public class HealthController_Coupled : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField]
        private Health model;

        [Header("View")]
        [SerializeField]
        private HealthView_Coupled view;

        private void Start()
        {
            view.Initialize(model);
        }

        private void OnEnable()
        {
            view.restoreButton.onClick.AddListener(RestoreHealth);
            view.healthSlider.onValueChanged.AddListener(ChangeHealth);
        }

        private void OnDisable()
        {
            view.restoreButton.onClick.RemoveListener(RestoreHealth);
            view.healthSlider.onValueChanged.RemoveListener(ChangeHealth);
        }

        public void IncreaseHealth(int amount)
        {
            model.Increment(amount);
        }

        public void DecreaseHealth(int amount)
        {
            model.Decrement(amount);
        }

        public void ChangeHealth(float currentHealth)
        {
            model.CurrentHealth = (int)currentHealth;
        }

        public void RestoreHealth()
        {
            model.Restore();
        }
    }
}

