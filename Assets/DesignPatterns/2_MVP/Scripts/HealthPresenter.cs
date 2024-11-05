using UnityEngine;

using Zenject;

namespace DesignPatterns.MVP
{
    public class HealthPresenter : MonoBehaviour, IHealthPresenter
    {
        /*
         * MVP 패턴에서 Presenter가 View와 Model을 참조하는 방식
         * 1. 직접 참조 : 코드 내에서 Model과 View를 직접 참조하며 초기화
         * 2. 생성자 주입 : 생성할 때 매개변수로 Model과 View를 전달받아 사용
         * 3. 의존성 주입 : DI 프레임 워크 사용 <- 사용 중
         * 4. 인스펙터 활용
         */

        [Inject]
        private readonly IHealthView view;
        private Health model;

        private void Awake()
        {
            model = new Health(this);
        }

        public void DecreaseHealth(int amount)
        {
            model.Decrement(amount);
        }

        public void RestoreHealth()
        {
            model.Restore();
        }

        public void ChangeHealth(int currentHealth)
        {
            // Presenter는 Model에게 데이터를 요청
            model.ChangeHealth(currentHealth);
        }

        public void ShowHealth(int currentHealth)
        {
            // Presenter는 View에게 데이터를 응답
            view.SetHealth(currentHealth);
        }
    }
}
