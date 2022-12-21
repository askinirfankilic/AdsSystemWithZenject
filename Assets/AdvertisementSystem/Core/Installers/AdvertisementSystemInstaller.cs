using AdvertisementSystem.Core;
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
        Container.BindInterfacesAndSelfTo<ApplovinInterstitial>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ApplovinBanner>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ApplovinRewarded>().AsSingle().NonLazy();
    }
}