using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class OnStartBlockPlacing : MonoBehaviour
{
    [SerializeField] private Transform topWall, bottomWall, ball, player1, player2, goalBlock1, goalBlock2, middleLine;
    private float screenWidth, screenHeight;

    private void Awake()
    {
        GameObject.Find("Game Manager").GetComponent<EventsController>().onRestarted.AddListener(Restart);
        //getting usefull info for later
        Camera cam = Camera.main;
        screenWidth = 1/(cam.WorldToViewportPoint(new Vector3(1,1,0)).x - .5f);
        screenHeight = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
        
        //setting up ball
        ball.transform.localScale = new Vector3(screenWidth/48, screenWidth/48);
        ball.position = new Vector2(0f, 0f);
        //setting up walls
        topWall.localScale = new Vector3(screenWidth, 1);
        topWall.position = new Vector3(0, screenHeight/2 + topWall.localScale.y/2);
        bottomWall.localScale = new Vector3(screenWidth, 1);
        bottomWall.position = new Vector3(0, -screenHeight/2 - bottomWall.localScale.y/2);
        //setting up goal blocks
        goalBlock1.localScale = new Vector3(1, screenHeight);
        goalBlock1.position = new Vector3(-screenWidth / 2 - goalBlock1.localScale.x / 2, 0);
        goalBlock2.localScale = new Vector3(1, screenHeight);
        goalBlock2.position = new Vector3(screenWidth / 2 + goalBlock2.localScale.x / 2, 0);
        //setting up players 
        player1.localScale = new Vector3(screenWidth / 72, screenHeight / 5f);
        player1.position = new Vector3(-screenWidth / 2.2f, 0);
        player2.localScale = new Vector3(screenWidth / 72, screenHeight / 5f);
        player2.position = new Vector3(screenWidth / 2.2f, 0);
        //setup middle line
        middleLine.localScale = new Vector3(0.05f, screenHeight);
        middleLine.position = Vector3.zero;
    }

    private void Restart()
    {
        player1.localScale = new Vector3(screenWidth / 72, screenHeight / 5f);
        player1.position = new Vector3(-screenWidth / 2.2f, 0);
        player2.localScale = new Vector3(screenWidth / 72, screenHeight / 5f);
        player2.position = new Vector3(screenWidth / 2.2f, 0);
    }
}
