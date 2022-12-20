namespace AdvertisementSystem.Core
{
    public interface IAdvertisementSystem
    {
        public void ShowBanner();
        public void ToggleBanner();
        public void ShowInterstitial();
        public void ShowRewarded();
    }
}