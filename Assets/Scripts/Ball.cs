using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    private EventsController eventController;
    private Rigidbody2D rb;

    private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        eventController = GameObject.Find("Game Manager").GetComponent<EventsController>();
        float x = Random.Range(0, 2) == 0 ? -1 : 1; 
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x*speed, y*speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("goal"))
        {
            StartCoroutine(FreezeGame());
            eventController.Restart();
            transform.position = Vector3.zero;
            rb.velocity = Vector2.zero;
            float x = Random.Range(0, 2) == 0 ? -1 : 1; 
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector2(x*speed, y*speed);
        }
    }

    IEnumerator FreezeGame()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
    }
}
