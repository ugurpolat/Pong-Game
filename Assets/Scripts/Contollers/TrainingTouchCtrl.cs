﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTouchCtrl : MonoBehaviour
{
    private float speed;
    
    //public GameObject trainingPaddle;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x + touch.deltaPosition.x * speed, -2.5f, 2.5f), transform.position.y, transform.position.z);
            }

        }
    }
}
