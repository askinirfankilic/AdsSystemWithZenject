namespace AdvertisementSystem.Core
{
    /// <summary>
    /// Inject this interface for displaying ads.
    /// </summary>
    public interface IAdvertisementSystem
    {
        public void ShowBanner();
        public void ToggleBanner();
        public void ShowInterstitial();
        public void ShowRewarded();
    }
}