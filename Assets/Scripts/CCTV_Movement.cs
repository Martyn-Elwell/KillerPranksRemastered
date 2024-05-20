using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CCTV_Movement : MonoBehaviour
{
    public bool Rightmove = false;
    public bool Leftmove = false;
    public float speed;
    public GameObject camera; 
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f; 
    }

    // Update is called once per frame
    void Update()
    {

        // Move Right
     
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Rightmove = true; 
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Rightmove = false;
        }

        if (Rightmove)
        {
            camera.transform.Rotate(0,1 * speed,0);
            
        }

        

        // Move Left

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Leftmove = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Leftmove = false;
        }

        if (Leftmove)
        {
            camera.transform.Rotate(0, -1 * speed, 0 );
        }
    }

    
}
