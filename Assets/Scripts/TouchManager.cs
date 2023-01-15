using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private float screenWidth;
    [SerializeField] private PlayerMovement player1, player2;
    private void Start()
    {
        Camera cam = Camera.main;
        screenWidth = Screen.width;
    }
    
    void Update()
    {
        
        for (int i = 0; i <  Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                if (t.position.x < screenWidth / 2)
                {
                    player1.ChangeDirection();
                }
                else
                {
                    player2.ChangeDirection();
                }
            }
        }
    }
}
