using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsController : MonoBehaviour
{
    public UnityEvent onRestarted;

    public void Restart()
    {
        onRestarted.Invoke();
    }
}
