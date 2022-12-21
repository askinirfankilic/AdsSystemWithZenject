using System;
using Zenject;

namespace AdvertisementSystem
{
    public class ApplovinSystem : IInitializable, IAdvertisementSystem
    {
        public Action OnInterstitialNotReady { get; set; }
        public Action<int> OnRewardReceived { get; set; }

        private bool _bannerVisible = true;

        private readonly ApplovinSettingsData _applovinSDKData;
        private readonly ApplovinInterstitial _applovinInterstitial;
        private readonly ApplovinBanner _applovinBanner;
        private readonly ApplovinRewarded _applovinRewarded;

        public ApplovinSystem(
            ApplovinSettingsData applovinSDKData,
            ApplovinInterstitial applovinInterstitial,
            ApplovinBanner applovinBanner,
            ApplovinRewarded applovinRewarded)
        {
            _applovinSDKData = applovinSDKData;
            _applovinInterstitial = applovinInterstitial;
            _applovinBanner = applovinBanner;
            _applovinRewarded = applovinRewarded;
        }

        public void Initialize()
        {
            MaxSdkCallbacks.OnSdkInitializedEvent += _applovinInterstitial.OnSDKInitializeEvent;
            MaxSdkCallbacks.OnSdkInitializedEvent += _applovinBanner.OnSDKInitializeEvent;
            MaxSdkCallbacks.OnSdkInitializedEvent += _applovinRewarded.OnSDKInitializeEvent;
#if !UNITY_EDITOR
            MaxSdkCallbacks.OnSdkInitializedEvent += configuration => { MaxSdk.ShowMediationDebugger(); };
#endif

            _applovinRewarded.OnRewardReceived += OnRewardReceived;

            MaxSdk.SetMuted(_applovinSDKData.Muted);
            MaxSdk.SetSdkKey(_applovinSDKData.SDKKey);
            MaxSdk.SetUserId(_applovinSDKData.UserId);
            MaxSdk.InitializeSdk();
        }


        public void ShowBanner()
        {
            _bannerVisible = true;
            MaxSdk.ShowBanner(_applovinSDKData.BannerAdUnitId);
        }

        public void ToggleBanner()
        {
            if (!_bannerVisible)
            {
                MaxSdk.ShowBanner(_applovinSDKData.BannerAdUnitId);
            }
            else
            {
                MaxSdk.HideBanner(_applovinSDKData.BannerAdUnitId);
            }

            _bannerVisible = !_bannerVisible;
        }

        public void ShowInterstitial()
        {
            if (!_applovinInterstitial.InterstitalReady)
            {
                OnInterstitialNotReady?.Invoke();
                return;
            }
            
            if (MaxSdk.IsInterstitialReady(_applovinSDKData.InterstitialAdUnitId))
            {
                MaxSdk.ShowInterstitial(_applovinSDKData.InterstitialAdUnitId);
            }
        }

        public void ShowRewarded()
        {
            if (MaxSdk.IsRewardedAdReady(_applovinSDKData.RewarddedAdUnitId))
            {
                MaxSdk.ShowRewardedAd(_applovinSDKData.RewarddedAdUnitId);
            }
        }
    }
}