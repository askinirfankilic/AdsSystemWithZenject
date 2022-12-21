using UnityEngine;
using UnityEngine.Serialization;

namespace AdvertisementSystem.Core
{
    [CreateAssetMenu(fileName = "ApplovinSettingsData", menuName = "Advertisement/Applovin Settings Data", order = 0)]
    public class ApplovinSettingsData : ScriptableObject
    {
        [FormerlySerializedAs("MuteAudio")]
        public bool Muted;
        public string UserId;
        public string SDKKey;
        
        [Header("Ad Formats")]
        public string BannerAdUnitId; 
        public string InterstitialAdUnitId; 
        public string RewarddedAdUnitId;
    }
}