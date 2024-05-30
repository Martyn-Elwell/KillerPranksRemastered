using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    [Header("Night")]
    public bool NightQuest;
    public bool IsNightTime;
    public Material NightSkyBox; 

    [Header("DayTime")]
    public  List<GameObject> RoofLights;  
    public bool IsDayTime;
    public Light sun;
    public Material DaySkyBox;

    [Header("UI")]
    public TMP_Text hours;
    public TMP_Text minutes;

    private void Awake()
    {
        _timeOfDay = 8;
        IsDayTime = true;
        RoofLights.AddRange(GameObject.FindGameObjectsWithTag("RoofLight")); 

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

        if (hour == 23)
        {
            Endofday = true;
            _orbitSpeed = 0;
            _timeOfDay = 23;
            minute = 0;
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
        IsNightTime = false;
        IsDayTime = true;

        foreach (GameObject gc in RoofLights)
        {
            gc.SetActive(true);
        }

        sun.intensity = 1;
        RenderSettings.ambientIntensity = 1;
        RenderSettings.skybox = DaySkyBox; 
    }

    public void NightTime()
    {
        _timeOfDay = 19;
        _orbitSpeed = 0.25f;
        IsNightTime = true;
        IsDayTime = false;

        foreach (GameObject gc in RoofLights)
        {
            gc.SetActive(false); 
        }

        sun.intensity = 0.1f;
        RenderSettings.ambientIntensity = 0.1f;
        RenderSettings.skybox = NightSkyBox;



    }
}
