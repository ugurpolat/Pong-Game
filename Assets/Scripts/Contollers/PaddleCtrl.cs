using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PaddleCtrl : MonoBehaviour
{

    public float speedBoost;
    public float direction;
    public float adjustSpeed;
    
    public RectTransform upperLimit;
    public RectTransform lowerLimit;
    public bool trainingMode, multiplayerMode,singleplayMode;
    
   
    
    //public TrainingCtrl trainingCtrl;



    // Start is called before the first frame update
    void Start()
    {
      
      trainingMode = PlayerPrefs.GetInt("Training") == 1 ? true : false;
      multiplayerMode = PlayerPrefs.GetInt("Multiplayer") == 1 ? true : false;
      singleplayMode = PlayerPrefs.GetInt("Singleplay") == 1 ? true : false;
        
    }

    // Update is called once per frame
    void Update()
    {
   
            float direction = Input.GetAxisRaw("Horizontal");
            if (direction > 0)
            {
                MoveRight(direction);
                direction = 1;
            }
            else if (direction < 0)
            {
                MoveLeft(direction);
                direction = -1;
            }
            else
            {
                direction = 0;
            }     
        
        SetBorders();
    }

    void MoveRight(float direction)
    {
        transform.position = transform.position + new Vector3(direction*speedBoost* Time.deltaTime,0,0);
    }

    void MoveLeft(float direction)
    {
        transform.position = transform.position + new Vector3(direction * speedBoost * Time.deltaTime, 0, 0);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        
        //Debug.Log(SceneChanger.instance.trainingMode);
        if (trainingMode)
        {
            
            other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x * 1.1f, other.rigidbody.velocity.y + (direction * adjustSpeed));

            TrainingCtrl.instance.UpdateScore();

            AudioCtrl.instance.PlayBounce(gameObject.transform.position);
            
        }
        else if(multiplayerMode)
        {
            
            other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x * 1.1f, other.rigidbody.velocity.y + (direction * adjustSpeed));
            
            AudioCtrl.instance.PlayBounce(gameObject.transform.position);
        }
        else if (singleplayMode)
        {
            other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x * 1.1f, other.rigidbody.velocity.y + (direction * adjustSpeed));

            AudioCtrl.instance.PlayBounce(gameObject.transform.position);
        }
        

    }

    void SetBorders()
    {
        if (transform.position.x > upperLimit.position.x)
        {
            transform.position = new Vector3(upperLimit.position.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < lowerLimit.position.x)
        {
            transform.position = new Vector3(lowerLimit.position.x, transform.position.y, transform.position.z);
        }
    }
    
}
