﻿using UnityEngine;

namespace AdvertisementSystem.Core
{
    public class Banner : IAdFormat
    {
        private readonly ApplovinSDKData _applovinSDKData;
        
        public Banner(ApplovinSDKData applovinSDKData)
        {
            _applovinSDKData = applovinSDKData;
        }
        
        public void OnSDKInitializeEvent(MaxSdkBase.SdkConfiguration sdkConfiguration)
        {
            // Banners are automatically sized to 320×50 on phones and 728×90 on tablets
            // You may call the utility method MaxSdkUtils.isTablet() to help with view sizing adjustments
            MaxSdk.CreateBanner(_applovinSDKData.BannerAdUnitId, MaxSdkBase.BannerPosition.BottomCenter);

            // Set background or background color for banners to be fully functional
            MaxSdk.SetBannerBackgroundColor(_applovinSDKData.BannerAdUnitId, Color.black);

            MaxSdkCallbacks.Banner.OnAdLoadedEvent      += OnBannerAdLoadedEvent;
            MaxSdkCallbacks.Banner.OnAdLoadFailedEvent  += OnBannerAdLoadFailedEvent;
            MaxSdkCallbacks.Banner.OnAdClickedEvent     += OnBannerAdClickedEvent;
            MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += OnBannerAdRevenuePaidEvent;
            MaxSdkCallbacks.Banner.OnAdExpandedEvent    += OnBannerAdExpandedEvent;
            MaxSdkCallbacks.Banner.OnAdCollapsedEvent   += OnBannerAdCollapsedEvent;
        }

        private void OnBannerAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) {}

        private void OnBannerAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo) {}

        private void OnBannerAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            Debug.Log("Clicked");
        }

        private void OnBannerAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) {}

        private void OnBannerAdExpandedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)  {}

        private void OnBannerAdCollapsedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) {} 
    }
}