using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    

    public static SceneChanger instance;

    public bool training,multiplayer,singleplay;
    
    //public bool backgroundSound, buttonSound, bounceSound;
    public GameObject panelSettings;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;        
        }

        
    }
    void Start()
    {

        PlayerPrefs.SetInt("BackgroundSound", 1);
        PlayerPrefs.SetInt("ButtonSound", 1);
        PlayerPrefs.SetInt("BounceSound", 1);

    }
    void Update()
    {
        
        
    }

    public void LoadScene(string sceneName)
    {
        AudioCtrl.instance.PlayButton(gameObject.transform.position);
        SceneManager.LoadScene(sceneName);
        if (sceneName == "Training")
        {
            training = true;
            PlayerPrefs.SetInt("Training", training ? 1 : 0);

            
            
        }
        else if (sceneName == "Multiplayer")
        {
            multiplayer = true;
            PlayerPrefs.SetInt("Multiplayer", multiplayer ? 1 : 0);
            
        }
        else if (sceneName == "Singleplay")
        {
            singleplay = true;
            PlayerPrefs.SetInt("Singleplay", singleplay ? 1 : 0);
            
        }
        
        else if (sceneName == "Menu")
        {

            PlayerPrefs.SetInt("Training", 0);
            PlayerPrefs.SetInt("Multiplayer", 0);
            PlayerPrefs.SetInt("Singleplay", 0);

            AdsCtrl2.instance.ShowInterstitial();
           
        }
    }
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void OpenSettingsPanel()
    {
        panelSettings.SetActive(true);
        AudioCtrl.instance.PlayButton(gameObject.transform.position);
    }
    public void CloseSettingsPanel()
    {
        panelSettings.SetActive(false);
        AudioCtrl.instance.PlayButton(gameObject.transform.position);
    }
}
