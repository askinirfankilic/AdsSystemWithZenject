using System;
using AdvertisementSystem.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonTest : MonoBehaviour
{
    [SerializeField]
    private AdType _adType;
    
    private Button _button;

    private IAdvertisementSystem _advertisementSystem;

    [Inject]
    private void Construct(IAdvertisementSystem advertisementSystem)
    {
        _advertisementSystem = advertisementSystem;
    }
    
    private void Awake()
    {
        if (TryGetComponent(out _button))
        {
            _button.onClick.AddListener(OnButtonClicked);
        }
    }

    private void OnButtonClicked()
    {
        switch (_adType)
        {
            case AdType.StartBanner:
                _advertisementSystem.ShowBanner();
                break;
            case AdType.ToggleBanner:
                _advertisementSystem.ToggleBanner();
                break;
            case AdType.Fullscreen:
                _advertisementSystem.ShowInterstitial();
                break;
            case AdType.Rewarded:
                _advertisementSystem.ShowRewarded();
                break;
        }
    }
}