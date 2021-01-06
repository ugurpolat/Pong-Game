using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{

    public float speedBoost;
    public float direction;
    public float adjustSpeed;

    public RectTransform upperLimit;
    public RectTransform lowerLimit;
    bool singleplayMode;

    public BallCtrl ballCtrl;

    



    // Start is called before the first frame update
    void Start()
    {
        ballCtrl = FindObjectOfType<BallCtrl>();
        singleplayMode = PlayerPrefs.GetInt("Singleplay") == 1 ? true : false;

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (singleplayMode)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(ballCtrl.transform.position.x,transform.position.y,transform.position.z), speedBoost * Time.deltaTime);
        }
        
        SetBorders();
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        
        if (singleplayMode)
        {
            Debug.Log("sa");
            other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x * 1.1f, other.rigidbody.velocity.y + (direction * adjustSpeed));
            Debug.Log(other.rigidbody.velocity);
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
