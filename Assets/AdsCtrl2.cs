using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsCtrl2 : MonoBehaviour
{
    public static AdsCtrl2 instance = null;
    public string Android_Admob_Interstitial_ID; //ca-app-pub-3940256099942544/1033173712
    public string Android_Admob_Interstitial_ID_Real; 
    public bool testMode;
    InterstitialAd interstitial;
    AdRequest request;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        RequestInterstitial();
    }

    void RequestInterstitial()
    {
        if (testMode)
        {
            interstitial = new InterstitialAd(Android_Admob_Interstitial_ID);
        }
        else
        {
            interstitial = new InterstitialAd(Android_Admob_Interstitial_ID_Real);
        }
        

        request = new AdRequest.Builder().Build();

        interstitial.LoadAd(request);

        interstitial.OnAdClosed += HandleOnAdClosed;
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        interstitial.Destroy();
        RequestInterstitial();
    }
    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }
    
}
