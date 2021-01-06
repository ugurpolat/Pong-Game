using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchCtrl : MonoBehaviour
{
    
    private float speed;
    float srcHeight;
    public GameObject paddle1, paddle2;
    public bool singleplayerMode;
    Touch touch, touch2;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
        srcHeight = Screen.height;
        singleplayerMode = PlayerPrefs.GetInt("Singleplayer") == 1 ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {

                if (singleplayerMode)
                {
                    
                }
                else if (touch.position.y < srcHeight/2 )
                {
                    paddle1.gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x + touch.deltaPosition.x * speed, -2.5f, 2.5f), transform.position.y, transform.position.z);
                }
                else if (touch.position.y > srcHeight / 2)
                {
                    paddle2.gameObject.transform.position = new Vector3(Mathf.Clamp(paddle2.gameObject.transform.position.x + touch.deltaPosition.x * speed, -2.5f, 2.5f), paddle2.gameObject.transform.position.y, paddle2.gameObject.transform.position.z);

                }


            }
            
            if (Input.touchCount == 2)
            {
               touch2 = Input.GetTouch(1);
                if (touch2.phase == TouchPhase.Moved)
                {
                    if (touch2.position.y > srcHeight / 2)
                    {
                        paddle2.gameObject.transform.position = new Vector3(Mathf.Clamp(paddle2.gameObject.transform.position.x + touch2.deltaPosition.x * speed, -2.5f, 2.5f), paddle2.gameObject.transform.position.y, paddle2.gameObject.transform.position.z);
                    }
                    else if (touch.position.y < srcHeight / 2)
                    {
                        paddle1.gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x + touch2.deltaPosition.x * speed, -2.5f, 2.5f), transform.position.y, transform.position.z);

                    }

                }
            }

        }
    }

}

