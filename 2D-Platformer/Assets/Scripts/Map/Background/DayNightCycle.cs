using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // In minutes
    [Tooltip("Unit is in Minutes")]
    public float dayDuration;
    [SerializeField] [ReadOnly]  
    private float dayDurationInSeconds;

    private float totalTime;

    [Tooltip("0 = 00:00, 1 = 24:00")]
    [field: SerializeField]
    public float timeOfDay { get; private set; }

    [field: SerializeField] public int day { get; private set; }
    [field: SerializeField] public int hour { get; private set; }
    [field: SerializeField] public int minute { get; private set; }
    [field: SerializeField] public int seconds { get; private set; }

    //public TimeSpan gameTime_TimeSpan { get { return new TimeSpan((long)gameTime); } }


    private void Update()
    {
        totalTime = Time.timeSinceLevelLoad;

        timeOfDay = totalTime % dayDurationInSeconds / dayDurationInSeconds * 0.5f;
        
    }

    private void OnValidate()
    {
        dayDuration = Mathf.Max(0.1f, dayDuration);
        dayDurationInSeconds = dayDuration * 60;
    }
}
