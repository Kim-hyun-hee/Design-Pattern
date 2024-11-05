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
            CurrentHealth = maxHealth;
        }

        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (currentHealth == value)
                    return;
                currentHealth = Mathf.Clamp(value, minHealth, maxHealth);
                presenter.ShowHealth(CurrentHealth);
            }
        }

        public void Increment(int amount)
        {
            CurrentHealth += amount;
        }

        public void Decrement(int amount)
        {
            CurrentHealth -= amount;
        }

        public void ChangeHealth(int currentHealth)
        {
            CurrentHealth = currentHealth;
        }

        public void Restore()
        {
            CurrentHealth = maxHealth;
        }
    }
}
