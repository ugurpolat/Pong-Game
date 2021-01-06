using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    public float startForce;
    public float speedBall;
    public GameObject paddle1;
    public GameObject paddle2;
    public Rigidbody2D rb;
    public GameCtrl gameCtrl;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(startForce * speedBall, startForce * speedBall);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.gameObject.CompareTag("GoalZone"))
        {

            if (other.gameObject.transform.position.y < 0)
            {
                transform.position = paddle2.transform.position + new Vector3(0, -0.3f, 0);
                rb.velocity = new Vector2(-startForce * speedBall, -startForce * speedBall);
                gameCtrl.UpdateScore(2);
            }
            else
            {
                transform.position = paddle1.transform.position + new Vector3(0, 0.3f, 0);
                rb.velocity = new Vector2(startForce * speedBall, startForce * speedBall);
                gameCtrl.UpdateScore(1);
            }


        }
    }
}
