using UnityEngine;
using UnityEngine.UI;

using TMPro;
using Zenject;

namespace DesignPatterns.MVP
{
    public class HealthView : MonoBehaviour, IHealthView
    {
        public Slider healthSlider;
        public Button restoreButton;
        public TextMeshProUGUI healthLabel;

        [Inject]
        private readonly IHealthPresenter presenter;

        private void OnEnable()
        {
            healthSlider.onValueChanged.AddListener(OnHealthSliderValueChanged);
            restoreButton.onClick.AddListener(OnRestoreButtonClicked);
        }

        private void OnDisable()
        {
            healthSlider.onValueChanged.RemoveListener(OnHealthSliderValueChanged);
            restoreButton.onClick.RemoveListener(OnRestoreButtonClicked);
        }

        #region <<Events trigger presetner methods>>
        private void OnHealthSliderValueChanged(float value)
        {
            presenter.ChangeHealth((int)value);
        }

        private void OnRestoreButtonClicked()
        {
            presenter.RestoreHealth();
        }
        #endregion

        #region <<View methods that presenter calls them>>
        public void SetHealth(int health)
        {
            healthSlider.value = health;
            healthLabel.text = $"{health}";
        }
        #endregion
    }
}