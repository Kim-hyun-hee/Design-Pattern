namespace DesignPatterns.MVP
{
    public interface IHealthPresenter
    {
        void DecreaseHealth(int amount);
        void RestoreHealth();
        void ChangeHealth(int currentHealth);
        void ShowHealth(int currentHealth);
    }
}
