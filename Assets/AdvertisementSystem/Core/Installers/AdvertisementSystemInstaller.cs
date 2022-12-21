using Zenject;


namespace AdvertisementSystem 
{
    /// <summary>
    /// Bind different Meditation Platforms in here.
    /// </summary>
    public class AdvertisementSystemInstaller : MonoInstaller<AdvertisementSystemInstaller>
    {
        public override void InstallBindings()
        {
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
}