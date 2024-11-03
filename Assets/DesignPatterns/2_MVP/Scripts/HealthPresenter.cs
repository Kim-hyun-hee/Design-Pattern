using UnityEngine;

using Zenject;

namespace DesignPatterns.MVP
{
    public class HealthPresenter : MonoBehaviour, IHealthPresenter
    {
        /*
         * MVP ���Ͽ��� Presenter�� View�� Model�� �����ϴ� ���
         * 1. ���� ���� : �ڵ� ������ Model�� View�� ���� �����ϸ� �ʱ�ȭ
         * 2. ������ ���� : ������ �� �Ű������� Model�� View�� ���޹޾� ���
         * 3. ������ ���� : DI ������ ��ũ ��� <- ��� ��
         * 4. �ν����� Ȱ��
         */

        [Inject]
        private readonly IHealthView view;
        [Inject]
        private readonly Health model;

        public void DecreaseHealth(int amount)
        {
            model.Decrement(amount);
            view.SetHealth(model.CurrentHealth);
        }

        public void RestoreHealth()
        {
            model.Restore();
            view.SetHealth(model.CurrentHealth);
        }

        public void ChangeHealth(int currentHealth)
        {
            model.ChangeHealth(currentHealth);
            view.SetHealth(model.CurrentHealth);
        }
    }
}
