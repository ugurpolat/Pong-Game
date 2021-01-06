using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCtrl : MonoBehaviour
{
    public Button btn_BGSoundOn;
    public Button btn_BGSoundOff;
    public Button btn_ButtonSoundOn;
    public Button btn_ButtonSoundOff;
    public Button btn_BounceSoundOn;
    public Button btn_BounceSoundOff;

    void Start()
    {
        PlayerPrefs.SetInt("BackgroundSound", 1);
        PlayerPrefs.SetInt("ButtonSound", 1);
        PlayerPrefs.SetInt("BounceSound", 1);

        if (AudioCtrl.instance.backgroundSound)
        {
            btn_BGSoundOn.GetComponent<Image>().color = Color.green;
        }
        else
        {
            btn_BGSoundOff.GetComponent<Image>().color = Color.green;
        }
        
        if (AudioCtrl.instance.buttonSound)
        {
            btn_ButtonSoundOn.GetComponent<Image>().color = Color.green;
        }
        else
        {
            btn_ButtonSoundOff.GetComponent<Image>().color = Color.green;
        }

        if (AudioCtrl.instance.bounceSound)
        {
            btn_BounceSoundOn.GetComponent<Image>().color = Color.green;
        }
        else
        {
            btn_BounceSoundOff.GetComponent<Image>().color = Color.green;
        }
    }

    void Update()
    {
    
    }

    public void BGSoundOn()
    {
        AudioCtrl.instance.backgroundSound = true;
        PlayerPrefs.SetInt("BackgroundSound", 1);

        btn_BGSoundOn.GetComponent<Image>().color = Color.green;
        btn_BGSoundOff.GetComponent<Image>().color = Color.white;
        
    }
    public void BGSoundOff()
    {
        
        AudioCtrl.instance.backgroundSound = false;
        PlayerPrefs.SetInt("BackgroundSound", 0);

        btn_BGSoundOn.GetComponent<Image>().color = Color.white;
        btn_BGSoundOff.GetComponent<Image>().color = Color.green;

    }
    public void ButtonSoundOn()
    {
        AudioCtrl.instance.buttonSound = true;
        PlayerPrefs.SetInt("ButtonSound", 1);

        btn_ButtonSoundOn.GetComponent<Image>().color = Color.green;
        btn_ButtonSoundOff.GetComponent<Image>().color = Color.white;

    }
    public void ButtonSoundOff()
    {
        
        AudioCtrl.instance.buttonSound = false;
        PlayerPrefs.SetInt("ButtonSound", 0);

        btn_ButtonSoundOn.GetComponent<Image>().color = Color.white;
        btn_ButtonSoundOff.GetComponent<Image>().color = Color.green;
    }

    public void BounceSoundOn()
    {
        

        AudioCtrl.instance.bounceSound = true;
        PlayerPrefs.SetInt("BounceSound", 1);

        btn_BounceSoundOn.GetComponent<Image>().color = Color.green;
        btn_BounceSoundOff.GetComponent<Image>().color = Color.white;
    }
    public void BounceSoundOff()
    {
        
        
        AudioCtrl.instance.bounceSound = false;
        PlayerPrefs.SetInt("BounceSound", 0);

        btn_BounceSoundOn.GetComponent<Image>().color = Color.white;
        btn_BounceSoundOff.GetComponent<Image>().color = Color.green;
    }
}
