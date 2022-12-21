using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AdvertisementSystem.Sample
{
    public class InformationTest : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textInfo;

        private CanvasGroup _canvasGroup;

        private Sequence _fadeOutSequence;

        private IAdvertisementSystem _advertisementSystem;

        [Inject]
        private void Construct(IAdvertisementSystem advertisementSystem)
        {
            _advertisementSystem = advertisementSystem;

            _advertisementSystem.OnInterstitialNotReady += ShowInformation;
        }

        private void OnDestroy()
        {
            _advertisementSystem.OnInterstitialNotReady -= ShowInformation;
        }

        private void Awake()
        {
            TryGetComponent(out _canvasGroup);
        }

        private void ShowInformation()
        {
            _textInfo.text = $"Can't show Interstitial before {(30f - Time.time).ToString()} seconds...";

            AnimateInfobox();
        }

        private void AnimateInfobox()
        {
            _fadeOutSequence?.Kill();
            gameObject.SetActive(true);

            _canvasGroup.alpha = 1;
            _fadeOutSequence = DOTween.Sequence();
            _fadeOutSequence.Append(_canvasGroup.DOFade(0, 1.5f));
            _fadeOutSequence.AppendCallback(() => gameObject.SetActive(false));
        }
    }
}