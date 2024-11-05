using UnityEngine;
using Zenject;

namespace DesignPatterns.MVP
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HealthView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthPresenter>().FromComponentInHierarchy().AsSingle();
        }
    }
}