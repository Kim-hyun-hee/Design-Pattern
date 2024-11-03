using UnityEngine;

namespace DesignPatterns.MVC
{
    public class HealthController : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField]
        private Health model;

        [Header("View")]
        [SerializeField]
        private HealthView view;

        private void OnEnable()
        {
            model.HealthChanged += OnHealthChanged;

            view.restoreButton.onClick.AddListener(RestoreHealth);
            view.healthSlider.onValueChanged.AddListener(ChangeHealth);
        }

        private void OnDisable()
        {
            model.HealthChanged -= OnHealthChanged;

            view.restoreButton.onClick.RemoveListener(RestoreHealth);
            view.healthSlider.onValueChanged.RemoveListener(ChangeHealth);
        }

        private void OnHealthChanged(int currentHealth)
        {
            view.UpdateHealthLabel(currentHealth);
            view.UpdateHealthSlider(currentHealth);
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
            model.ChangeHealth((int)currentHealth);
        }

        public void RestoreHealth()
        {
            model.Restore();
        }
    }
}
