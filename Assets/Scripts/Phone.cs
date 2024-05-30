using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Phone : MonoBehaviour
{

    public GameObject PhoneObject;
    public bool PhoneInUse;
    public bool CoolDown; 
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && CoolDown == false)
        {
            if (PhoneInUse)
            {
               Debug.Log("Hello");
               CoolDown = true; 
               PhoneInUse = false; 
               PhoneObject.SetActive(false);
               Cooldown(); 
            }

            else 
            {
                Debug.Log("Bye Phone");
                CoolDown = true;
                PhoneInUse = true; 
                PhoneObject.SetActive(true);
                Cooldown();
            }
        }


    }

    void Cooldown()
    {

        StartCoroutine(CoolDownTimer());  
        IEnumerator CoolDownTimer()
        {
            yield return new WaitForSeconds(3);
            CoolDown = false;

        }


    }
}
