using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class RewardAds : MonoBehaviour
{
    public static RewardAds instance;
    public GameObject RewardPanel;
    private RewardBasedVideoAd rewardedAd;
    //test private string rewardedAdID = "ca-app-pub-3940256099942544/5224354917";
    private string rewardedAdID = "ca-app-pub-4585950872793310/5622357617";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        rewardedAd = RewardBasedVideoAd.Instance;
        RequestRewardedAd();

        rewardedAd.OnAdLoaded += HandleRewardBasedVideoLoaded;
        rewardedAd.OnAdFailedToLoad += HandleRewardBasedVideoOnAdFailedToLoad;
        rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;
    }

    public void OnDestroy()
    {
        rewardedAd.OnAdLoaded -= HandleRewardBasedVideoLoaded;
        rewardedAd.OnAdFailedToLoad -= HandleRewardBasedVideoOnAdFailedToLoad;
        rewardedAd.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        rewardedAd.OnAdClosed -= HandleRewardBasedVideoClosed;
    }

    public void RequestRewardedAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request, rewardedAdID);
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        Debug.Log("loaded");
    }

    public void HandleRewardBasedVideoOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("failed");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        RewardPanel.SetActive(true);
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        RequestRewardedAd();
    }

    public void ReceiveReward()
    {
        MainMenuController.coins = MainMenuController.coins + 10;
        AudioScript.PlaySound("Purchase");
        RewardPanel.SetActive(false);
    }
}
