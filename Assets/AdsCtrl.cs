using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdsCtrl : MonoBehaviour
{
    public static AdsCtrl instance = null;
    public string Android_Admob_Banner_ID;          //ca-app-pub-3940256099942544/6300978111
    public string Android_Admob_Banner_ID_Real;
    Scene scene;

    public bool testMode;
    BannerView bannerView;
    // Start is called before the first frame update
    void Start()
    {
        

        RequestBanner();

    }
   

    void RequestBanner()
    {
        AdSize adSize = new AdSize(300,75);
        if (testMode)
        {
            bannerView = new BannerView(Android_Admob_Banner_ID, adSize, AdPosition.Top);
        }
        else
        {
            bannerView = new BannerView(Android_Admob_Banner_ID_Real, adSize,AdPosition.Top);
        }
        

        AdRequest adRequest = new AdRequest.Builder().Build();

        bannerView.LoadAd(adRequest);
        
    }
    
    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }
     void OnDestroy()
    {
        bannerView.Destroy();    
    }
}
