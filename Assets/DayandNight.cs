using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayandNight : MonoBehaviour
{
    [Header("Time Params")]
    [SerializeField, Range(0, 24)] private float _timeOfDay;
    [SerializeField] private float _orbitSpeed;
    
    
    [Header("Time")]
    public int hour;
    public int minute;

    [Header("Settings")]
    public bool Newday;
    public bool Endofday;

    [Header("UI")]
    public TMP_Text hours;
    public TMP_Text minutes;

    private void Awake()
    {
        _timeOfDay = 8; 
        
    }
    private void OnValidate()
    {
        ProgressTime();
    }

    private void Update()
    {
        _timeOfDay += Time.deltaTime * _orbitSpeed;
        ProgressTime();

        if (hour == 17)
        {
            Endofday = true;
            _orbitSpeed = 0;
            _timeOfDay = 17;
            minute = 0; 
            
        }

        if (Newday)
        {
            _timeOfDay = 8;
            _orbitSpeed = 0.25f;
            Newday = false;
            Endofday = false;
        }

      

        hours.SetText(hour.ToString("D2"));
        minutes.SetText(minute.ToString("D2")); 

    }

    private void ProgressTime()
    {

        float currentTime = _timeOfDay / 24;
             

        hour = Mathf.FloorToInt(_timeOfDay);
        minute = Mathf.FloorToInt((_timeOfDay / (24f / 1440f) % 60));

      

        _timeOfDay %= 24;
    }

    public void NewDay()
    {
        _timeOfDay = 8;
        _orbitSpeed = 0.25f;
        Newday = false;
    }
}
