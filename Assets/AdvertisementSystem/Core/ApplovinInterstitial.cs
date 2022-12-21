using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdvertisementSystem.Core;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ApplovinInterstitial : IAdFormat
{
    private int _retryAttempt = 0;
    
    private readonly ApplovinSettingsData _applovinSDKData;
    
    public ApplovinInterstitial(ApplovinSettingsData applovinSDKData)
    {
        _applovinSDKData = applovinSDKData;
    }
    
    public void OnSDKInitializeEvent(MaxSdkBase.SdkConfiguration sdkConfiguration)
    {
        // Attach callback
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;
        
        LoadInterstitial();
    }

    private void LoadInterstitial()
    {
        MaxSdk.LoadInterstitial(_applovinSDKData.InterstitialAdUnitId);
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'
        // Reset retry attempt
        _retryAttempt = 0;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)
        Debug.Log("InterstitialLoadFailed");

        _retryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, _retryAttempt));

        //TODO: Unitask is probably appropriate solution for this.
        DelayedLoadInterstatialAsync(retryDelay).Forget();
    }

    private async UniTaskVoid DelayedLoadInterstatialAsync(double retryDelay)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(retryDelay));
        LoadInterstitial();
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo,
        MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        LoadInterstitial();
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
    }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
        LoadInterstitial();
    }

}