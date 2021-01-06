using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TrainingCtrl : MonoBehaviour
{
    public static TrainingCtrl instance;
    int score1;
    public Text scoreText;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score2", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score1 > PlayerPrefs.GetInt("Score2"))
        {
            PlayerPrefs.SetInt("Score2", score1);
        }
    }

    public void UpdateScore()
    {
        score1++;
        scoreText.text = score1.ToString();
    }
    public void DeleteScore()
    {
        score1 = 0;
        scoreText.text = score1.ToString();
    }
}
