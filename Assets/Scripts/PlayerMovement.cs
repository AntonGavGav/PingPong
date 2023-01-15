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

    [SerializeField] private float speed = 1f;

    private MoveDirection currentDirection;
    
    private void Start()
    {
        GameObject.Find("Game Manager").GetComponent<EventsController>().onRestarted.AddListener(RandomDir);
        currentDirection = (MoveDirection)Random.Range(0, 2);
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
        if (currentDirection == MoveDirection.Upwards)
        {
            currentDirection = MoveDirection.Downwards;
        }
        else
        {
            currentDirection = MoveDirection.Upwards;
        }
    }

    private void RandomDir()
    {
        currentDirection = (MoveDirection)Random.Range(0, 2);
    }
    
}
