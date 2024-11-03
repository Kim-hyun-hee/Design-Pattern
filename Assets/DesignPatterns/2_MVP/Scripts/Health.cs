using UnityEngine;

using Zenject;

namespace DesignPatterns.MVP
{
    public class Health : MonoBehaviour
    {
        [Inject]
        private readonly IHealthPresenter presenter;

        private int currentHealth;
        private const int minHealth = 0;
        private const int maxHealth = 100;

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
