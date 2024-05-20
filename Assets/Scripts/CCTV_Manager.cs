using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV_Manager : MonoBehaviour
{
    public GameObject[] UI;
    public GameObject[] cameras;
    public int CurrentCam;
    // Start is called before the first frame update
    void Start()
    {
        CurrentCam = 0; 
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.E))
        {
            CurrentCamera(); 
            CurrentCam++;
            NextCam();

        }

       if (CurrentCam > cameras.Length)
        {
            CurrentCam = 0; 
        }
    }

    public void CurrentCamera()
    
    {
        UI[CurrentCam].SetActive(false);
        Animator anim = cameras[CurrentCam].GetComponent<Animator>();
        anim.enabled = false; 
        Camera cam =  cameras[CurrentCam].GetComponent<Camera>();
        cam.enabled = false;
    }
    public void NextCam()
    {
        UI[CurrentCam].SetActive(true);
        Animator anim = cameras[CurrentCam].GetComponent<Animator>();
        anim.enabled = true;
        Camera cam = cameras[CurrentCam].GetComponent<Camera>();
        cam.enabled = true;

    }

}
