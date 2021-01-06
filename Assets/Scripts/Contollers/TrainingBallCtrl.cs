using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBallCtrl : MonoBehaviour
{
    public float startForce;
    public float speedBall;
    public Transform rebornPoint;
    
    Rigidbody2D rb;
    public TrainingCtrl trainCtrl;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(startForce * speedBall, startForce * speedBall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("GoalZone"))
        {
                
                transform.position = rebornPoint.position;
                rb.velocity = new Vector2(-startForce * speedBall, -startForce * speedBall);
                trainCtrl.DeleteScore();
            
                
        }
    }
}
