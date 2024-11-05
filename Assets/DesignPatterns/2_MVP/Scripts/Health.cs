using UnityEngine;

using Zenject;

namespace DesignPatterns.MVP
{
    public class Health
    {
        private readonly IHealthPresenter presenter;

        private int currentHealth;
        private const int minHealth = 0;
        private const int maxHealth = 100;

        public Health(IHealthPresenter presenter)
        {
            this.presenter = presenter;
            currentHealth = maxHealth;
        }

        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (currentHealth == value)
                    return;
                currentHealth = Mathf.Clamp(value, minHealth, maxHealth);
            }
        }

        private void Awake()
        {
            CurrentHealth = maxHealth;
            presenter.ShowHealth(CurrentHealth);
        }

        public void Increment(int amount)
        {
            CurrentHealth += amount;
            presenter.ShowHealth(CurrentHealth);
        }

        public void Decrement(int amount)
        {
            CurrentHealth -= amount;
            presenter.ShowHealth(CurrentHealth);
        }

        public void ChangeHealth(int currentHealth)
        {
            CurrentHealth = currentHealth;
            // Model은 Presenter에게 요청받은 데이터를 응답
            presenter.ShowHealth(CurrentHealth);
        }

        public void Restore()
        {
            CurrentHealth = maxHealth;
            presenter.ShowHealth(CurrentHealth);
        }
    }
}
