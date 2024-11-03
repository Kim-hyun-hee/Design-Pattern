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
            model.HealthChanged += OnHealthChanged; // Model의 상태가 변경될 때 View에 전달함

            // View에서 발생한 사용자 입력을 처리해 Model을 업데이트 함 (View <-> Model)
            // Controll와 View의 강한 결합
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
            // Model 데이터의 변경사항을 수신하기 위한 View별 코드가 필요
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
