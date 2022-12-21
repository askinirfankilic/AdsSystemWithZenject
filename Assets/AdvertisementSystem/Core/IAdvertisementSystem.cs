using System;

namespace AdvertisementSystem
{
    /// <summary>
    /// Inject this interface for displaying ads.
    /// </summary>
    public interface IAdvertisementSystem
    {
        public Action<int> OnRewardReceived { get; set; }
        public void ShowBanner();
        public void ToggleBanner();
        public void ShowInterstitial();
        public void ShowRewarded();
    }
}