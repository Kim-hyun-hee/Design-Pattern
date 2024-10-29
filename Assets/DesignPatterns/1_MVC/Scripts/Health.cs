using System;
using UnityEngine;

namespace DesignPatterns.MVC
{
    public class Health : MonoBehaviour
    {
        public Action<int> HealthChanged;

        private int currentHealth;
        private const int minHealth = 0;
        private const int maxHealth = 100;

        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = Mathf.Clamp(value, minHealth, maxHealth);
                HealthChanged?.Invoke(currentHealth);
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

        public void Restore()
        {
            CurrentHealth = maxHealth;
        }
    }
}
