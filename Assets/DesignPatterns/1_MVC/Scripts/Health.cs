using System;
using UnityEngine;

namespace DesignPatterns.MVC
{
    public class Health : MonoBehaviour
    {
        public Action<int> HealthChanged; // 변경 통지에 대한 처리방법

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
