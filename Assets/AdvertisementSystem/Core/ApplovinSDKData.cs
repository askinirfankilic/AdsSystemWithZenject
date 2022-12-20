using UnityEngine;
using UnityEngine.Serialization;

namespace AdvertisementSystem.Core
{
    [CreateAssetMenu(fileName = "ApplovinSDKData", menuName = "Advertisement/Applovin SDK Data", order = 0)]
    public class ApplovinSDKData : ScriptableObject
    {
        public string UserId;
        public string BannerAdUnitId; 
        public string InterstitialAdUnitId; 
        public string SDKKey; 
    }
}