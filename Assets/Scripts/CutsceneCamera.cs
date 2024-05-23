using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneCamera : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] public GameObject controlPanel;
    //[SerializeField] public GameObject cam1;
    //[SerializeField] public PlayableDirector timeline;
    //[SerializeField] public GameObject cam2;

    private void Awake()
    {
        //cam1.SetActive(false);
        director.played += Director_Played;
        director.stopped += Director_Stopped;
    }

    public void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }*/
    }

    private void Director_Played(PlayableDirector obj)
    {
        controlPanel.SetActive(false);
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        controlPanel.SetActive(true);
    }

    public void startTimeline()
    {
        director.Play();
        //cam1.SetActive(true);
    }
}
