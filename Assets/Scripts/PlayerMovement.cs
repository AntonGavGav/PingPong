using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    private enum MoveDirection
    {
        Upwards,
        Downwards
    }

    private float speed;

    private MoveDirection currentDirection;
    private bool canChangeDirection = true;
    
    private void Start()
    {
        float screenHeight = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
        GameObject.Find("Game Manager").GetComponent<EventsController>().onRestarted.AddListener(RandomDir);
        currentDirection = (MoveDirection)Random.Range(0, 2);
        speed = screenHeight / 3;
    }

    private void Update()
    {
        if(currentDirection == MoveDirection.Upwards){
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        if (canChangeDirection)
        {
            canChangeDirection = false;
            Vector3 startingPoint;
            if (currentDirection == MoveDirection.Upwards)
            {
                currentDirection = MoveDirection.Downwards;
            }
            else
            {
                currentDirection = MoveDirection.Upwards;
            }

            canChangeDirection = true;
        }
    }

    private void RandomDir()
    {
        currentDirection = (MoveDirection)Random.Range(0, 2);
    }
}
