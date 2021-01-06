using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour
{
    public Text scorePlayers;
    public Text winScreen;
    public Text txtTimer;
    public GameObject panelWin;
    public GameObject panelScore;
    public GameObject panelSelectMode;
    public GameObject panelTimer;
    public GameObject ball;
    public GameObject middleLine;
    public int scoreTarget;
    int score1, score2;
    public float maxTime;
    bool timeMode;
    float timeLeft;
    BallCtrl ballCtrl;
    public bool singleplayMode;
    void Start()
    {
        timeLeft = maxTime;
        txtTimer.text = "" +(int)timeLeft;
        ballCtrl = ball.GetComponent<BallCtrl>();
        singleplayMode = PlayerPrefs.GetInt("Singleplay") == 1 ? true : false;

        
    }
    void Update()
    {
        
        if (timeMode)
        {
            UpdateTimer();
        }
       
    }

    public void UpdateScore(int player)
    {
        if (player == 1)
        {
            score1 += 1;
            if (score1 >= scoreTarget)
            {
                PanelWinOpen();
                winScreen.text = "Player 1 won";

                score1 = 0;

            }

        }
        if (player == 2)
        {
            score2 += 1;
            if (score2 >= scoreTarget)
            {
                PanelWinOpen();
                if (!singleplayMode)
                    panelWin.transform.Rotate(0, 0, 180);
                else
                    panelWin.transform.Rotate(0, 0, 0);
                winScreen.text = "Player 2 won.";

                score2 = 0;

            }
        }

        scorePlayers.text = score2.ToString() + " " + score1.ToString();
    }
    void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        txtTimer.text = "" + (int)timeLeft;
        
        if (timeLeft <= 0)
        {
            txtTimer.text = "0";
            if (score1 > score2)
            {
                PanelWinOpen();
                winScreen.text = "Player 1 wins";
            }
            else
            {
                PanelWinOpen();
                if (!singleplayMode)
                    panelWin.transform.Rotate(0, 0, 180);
                else
                    panelWin.transform.Rotate(0, 0, 0);

                winScreen.text = "Player 2 wins";

            }
            
        }

    }
    void PanelWinOpen()
    {
        panelWin.SetActive(true);
        ball.SetActive(false);
    }
    public void FiveGoal()
    {
        AudioCtrl.instance.PlayButton(gameObject.transform.position);
        scoreTarget = 5;
        
        ballCtrl.rb.velocity = new Vector2(ballCtrl.startForce * ballCtrl.speedBall, ballCtrl.startForce * ballCtrl.speedBall);
        panelSelectMode.SetActive(false);
        panelScore.SetActive(true);
    }
    public void ElevenGoal()
    {
        AudioCtrl.instance.PlayButton(gameObject.transform.position);
        scoreTarget = 11;
        
        ballCtrl.rb.velocity = new Vector2(ballCtrl.startForce * ballCtrl.speedBall, ballCtrl.startForce * ballCtrl.speedBall);
        panelSelectMode.SetActive(false);
        panelScore.SetActive(true);

    }
    public void OneMinute()
    {
        AudioCtrl.instance.PlayButton(gameObject.transform.position);
        maxTime = 60;
        timeMode = true;
        panelSelectMode.SetActive(false);
        panelScore.SetActive(true);
        scoreTarget = 150;
        
        ballCtrl.rb.velocity = new Vector2(ballCtrl.startForce * ballCtrl.speedBall, ballCtrl.startForce * ballCtrl.speedBall);
        panelTimer.SetActive(true);
        middleLine.SetActive(false);

    }
   
}
