using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace DesignPatterns.MVC
{
    public class HealthView : MonoBehaviour
    {
        public Slider healthSlider;
        public Button restoreButton;
        public TextMeshProUGUI healthLabel;

        public void UpdateHealth(int health)
        {
            healthLabel.text = $"{health}";
            healthSlider.value = health;
        }
    }
}
