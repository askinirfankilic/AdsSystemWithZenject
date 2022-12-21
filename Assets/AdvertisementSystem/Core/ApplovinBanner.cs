using UnityEngine;

namespace AdvertisementSystem
{
    public class ApplovinBanner : IAdFormat
    {
        private readonly ApplovinSettingsData _applovinSettingsData;

        public ApplovinBanner(ApplovinSettingsData applovinSettingsData)
        {
            _applovinSettingsData = applovinSettingsData;
        }

        public void OnSDKInitializeEvent(MaxSdkBase.SdkConfiguration sdkConfiguration)
        {
            MaxSdk.CreateBanner(_applovinSettingsData.BannerAdUnitId, MaxSdkBase.BannerPosition.BottomCenter);

            MaxSdk.SetBannerBackgroundColor(_applovinSettingsData.BannerAdUnitId, Color.black);

            MaxSdkCallbacks.Banner.OnAdLoadedEvent += OnBannerAdLoadedEvent;
            MaxSdkCallbacks.Banner.OnAdLoadFailedEvent += OnBannerAdLoadFailedEvent;
            MaxSdkCallbacks.Banner.OnAdClickedEvent += OnBannerAdClickedEvent;
            MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += OnBannerAdRevenuePaidEvent;
            MaxSdkCallbacks.Banner.OnAdExpandedEvent += OnBannerAdExpandedEvent;
            MaxSdkCallbacks.Banner.OnAdCollapsedEvent += OnBannerAdCollapsedEvent;
            
            MaxSdk.ShowBanner(_applovinSettingsData.BannerAdUnitId);
        }

        private void OnBannerAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
        }

        private void OnBannerAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
        {
        }

        private void OnBannerAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
        }

        private void OnBannerAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
        }

        private void OnBannerAdExpandedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
        }

        private void OnBannerAdCollapsedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
        }
    }
}