using TMPro;
using UnityEngine;
using Zenject;

namespace AdvertisementSystem.Sample 
{
    public class CurrencyTest : MonoBehaviour
    {
        private int _curency;

        private TextMeshProUGUI _textCurrency;
        private IAdvertisementSystem _advertisementSystem;

        [Inject]
        private void Construct(IAdvertisementSystem advertisementSystem)
        {
            _advertisementSystem = advertisementSystem;

            _advertisementSystem.OnRewardReceived += SetCurrency;
        }

        private void OnDestroy()
        {
            _advertisementSystem.OnRewardReceived -= SetCurrency;
        }

        private void Awake()
        {
            TryGetComponent(out _textCurrency);
        }

        public void SetCurrency(int currencyChange)
        {
            _curency += currencyChange;
            _textCurrency.SetText(_curency.ToString());
        }
    }
}