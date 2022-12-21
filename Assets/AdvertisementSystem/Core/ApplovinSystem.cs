using AdvertisementSystem.Core;
using Zenject;

public class ApplovinSystem : IInitializable, IAdvertisementSystem
{
    private bool _bannerVisible = false;

    private readonly ApplovinSDKData _applovinSDKData;
    private readonly Interstitial _interstitial;
    private readonly Banner _banner;

    public ApplovinSystem(ApplovinSDKData applovinSDKData, Interstitial interstitial, Banner banner)
    {
        _applovinSDKData = applovinSDKData;
        _interstitial = interstitial;
        _banner = banner;
    }

    public void Initialize()
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += _interstitial.OnSDKInitializeEvent;
        MaxSdkCallbacks.OnSdkInitializedEvent += _banner.OnSDKInitializeEvent;

        MaxSdkCallbacks.OnSdkInitializedEvent += configuration =>
        {
            MaxSdk.ShowMediationDebugger();
        };

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
        if (MaxSdk.IsInterstitialReady(_applovinSDKData.InterstitialAdUnitId))
        {
            MaxSdk.ShowInterstitial(_applovinSDKData.InterstitialAdUnitId);
        }
    }

    public void ShowRewarded()
    {
    }
}