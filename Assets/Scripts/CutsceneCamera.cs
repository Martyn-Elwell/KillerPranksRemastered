using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneCamera : MonoBehaviour
{
    [SerializeField] public GameObject cam1;
    //[SerializeField] public PlayableDirector timeline;
    [SerializeField] public GameObject cam2;

    void Start()
    {
        //cam1.SetActive(true);
        //cam2.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
