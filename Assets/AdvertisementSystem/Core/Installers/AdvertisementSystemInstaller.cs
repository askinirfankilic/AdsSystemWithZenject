using AdvertisementSystem.Core;
using UnityEngine;
using Zenject;

public class AdvertisementSystemInstaller : MonoInstaller<AdvertisementSystemInstaller>
{
    public override void InstallBindings()
    {
        // Bind different Meditation SDK's in here.
        BindApplovin();
    }

    private void BindApplovin()
    {
        Container.BindInterfacesAndSelfTo<ApplovinSystem>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<Interstitial>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<Banner>().AsSingle().NonLazy();
    }
}