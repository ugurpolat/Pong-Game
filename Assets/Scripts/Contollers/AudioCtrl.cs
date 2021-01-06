using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour
{
    public static AudioCtrl instance = null;
    public GameObject BGMusic;
    public AudioSource button, bounce;
    public  bool backgroundSound;
    public  bool buttonSound;
    public  bool bounceSound;

    
    private void Awake()
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
        
    }
    // Start is called before the first frame update
    void Start()
    {


        backgroundSound = PlayerPrefs.GetInt("BackgroundSound") == 1 ? true : false;
        buttonSound = PlayerPrefs.GetInt("ButtonSound") == 1 ? true : false;
        bounceSound = PlayerPrefs.GetInt("BounceSound") == 1 ? true : false;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (backgroundSound)
        {
            BGMusic.SetActive(true);
        }
        else if (!backgroundSound)
        {
            BGMusic.SetActive(false);
        }
        
    }

    public void PlayButton(Vector3 pos)
    {
        if (buttonSound)
        {
            button.Play();
        }
       
    }
    public void PlayBounce(Vector3 pos)
    {
        if (bounceSound)
        {
            bounce.Play();
        }

    }

}
