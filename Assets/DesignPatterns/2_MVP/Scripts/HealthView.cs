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
            // 사용자의 Action들이 View를 통해 들어옴
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
            // View는 데이터를 Presenter에게 요청
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
            // View는 Presenter가 응답한 데이터를 이용하여 화면을 나타냄
            healthSlider.value = health;
            healthLabel.text = $"{health}";
        }
        #endregion
    }
}