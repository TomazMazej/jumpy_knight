using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class InterstitialAds : MonoBehaviour{

    private InterstitialAd interstitial;

    void Awake(){
        RequestInterstitial();
    }

    void FixedUpdate(){
        if (this.interstitial.IsLoaded()){
            this.interstitial.Show();
        }
    }

    private void RequestInterstitial(){
        //test string adID = "ca-app-pub-3940256099942544/1033173712";
        string adID = "ca-app-pub-4585950872793310/2066255982";

        #if UNITY_ANDROID
                string adUnitId = adID;
        #elif UNITY_IOS
                string adUnitId = adID;
        #else
                string adUnitId = adID;
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
}