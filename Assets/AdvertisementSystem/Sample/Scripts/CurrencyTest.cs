using AdvertisementSystem.Core;
using TMPro;
using UnityEngine;
using Zenject;

public class CurrencyTest : MonoBehaviour
{
    private int _curency;

    private TextMeshProUGUI _textCurrency;
    private IAdvertisementSystem _advertisementSystem;

    [Inject]
    private void Construct(IAdvertisementSystem advertisementSystem)
    {
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