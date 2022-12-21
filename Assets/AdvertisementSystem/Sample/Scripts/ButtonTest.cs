using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AdvertisementSystem.Sample
{
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
                case AdType.Banner:
                    _advertisementSystem.ToggleBanner();
                    break;
                case AdType.Interstitial:
                    _advertisementSystem.ShowInterstitial();
                    break;
                case AdType.Rewarded:
                    _advertisementSystem.ShowRewarded();
                    break;
            }
        }
    }
}