using System;
using AdvertisementSystem.Core;
using Zenject;

public class ApplovinSystem : IInitializable, IAdvertisementSystem, IDisposable
{
    public Action<int> OnCurrencyChanged;

    private bool _bannerVisible = false;

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

        _applovinRewarded.OnRewardReceived += OnCurrencyChanged;
    }

    public void Initialize()
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += _applovinInterstitial.OnSDKInitializeEvent;
        MaxSdkCallbacks.OnSdkInitializedEvent += _applovinBanner.OnSDKInitializeEvent;
        MaxSdkCallbacks.OnSdkInitializedEvent += _applovinRewarded.OnSDKInitializeEvent;
        MaxSdkCallbacks.OnSdkInitializedEvent += configuration => { MaxSdk.ShowMediationDebugger(); };

        OnCurrencyChanged += ChangeCurrency;

        MaxSdk.SetMuted(_applovinSDKData.Muted);
        MaxSdk.SetSdkKey(_applovinSDKData.SDKKey);
        MaxSdk.SetUserId(_applovinSDKData.UserId);
        MaxSdk.InitializeSdk();
    }

    public void Dispose()
    {
        OnCurrencyChanged -= ChangeCurrency;
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

    public void ChangeCurrency(int amount)
    {
    }
}