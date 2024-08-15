using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public AdsInitializer initilizer;
    public InterstitialAd interstitial;
    public RewardedAd rewarded;

    public static AdsManager Instance;

    public static int levelCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            initilizer = GetComponent<AdsInitializer>();
            interstitial = GetComponent<InterstitialAd>();
            rewarded = GetComponent<RewardedAd>();

            interstitial.LoadAd();
            rewarded.LoadAd();
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    
}
