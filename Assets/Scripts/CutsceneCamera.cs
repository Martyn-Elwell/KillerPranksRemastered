using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneCamera : MonoBehaviour
{
    [SerializeField] public GameObject play_cam;
    [SerializeField] public PlayableDirector timeline;
    [SerializeField] public GameObject CutsceneTimeline;

    void Start()
    {
        //play_cam.SetActive(false);
        CutsceneTimeline.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            play_cam.SetActive(false);
            CutsceneTimeline.SetActive(true);
        }
    }
}
