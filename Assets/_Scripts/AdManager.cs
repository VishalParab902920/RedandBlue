using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour {

    public string InterstitialAdID;
    public string BannerID;

    public static float adCount = 0f;
    public static bool canShowAd = true;

    InterstitialAd interstitialAd;
    BannerView bannerAd;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        interstitialAd = new InterstitialAd(InterstitialAdID);
        ShowBanner();
        LoadInterstitialAd();
    }

    private void Update()
    {

        if ((adCount!=0)&&(adCount%2==0)&&(canShowAd))
        {
            ShowInterstitialAd();
            canShowAd = false;
        }
    }



    public void LoadInterstitialAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        Debug.Log("Showing Interstitial");
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {
            LoadInterstitialAd();
            interstitialAd.Show();
        }
    }

    

    public void ShowBanner()
    {
        bannerAd = new BannerView(BannerID, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerAd.LoadAd(request);
    }
}
