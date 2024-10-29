using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace DesignPatterns.MVC
{
    public class HealthView_Coupled : MonoBehaviour
    {
        public Slider healthSlider;
        public Button restoreButton;
        public TextMeshProUGUI healthLabel;

        private Health model;

        public void Initialize(Health model)
        {
            this.model = model;
            this.model.HealthChanged += UpdateHealth;
        }

        public void UpdateHealth(int health)
        {
            healthLabel.text = $"{health}";
            healthSlider.value = health;
        }
    }
}
