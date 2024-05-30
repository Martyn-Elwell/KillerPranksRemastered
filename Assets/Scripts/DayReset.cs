using UnityEngine;

public class DayReset : MonoBehaviour
{

    public bool trigger;
    public GameObject text;
    public GameObject Nightext;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<DayandNight>().IsDayTime == true)
        {
            if (GetComponentInParent<DayandNight>().NightQuest == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (trigger)
                    {
                        GetComponentInParent<DayandNight>().NewDay();

                    }
                }
            }

            if (GetComponentInParent<DayandNight>().NightQuest == true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (trigger)
                    {
                        GetComponentInParent<DayandNight>().NightTime();

                    }
                }
            }
        }

        if (GetComponentInParent<DayandNight>().IsNightTime == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (trigger)
                {
                    GetComponentInParent<DayandNight>().NewDay();

                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger = true;

            if (GetComponentInParent<DayandNight>().IsDayTime == true)
            {

                if (GetComponentInParent<DayandNight>().NightQuest == false)
                {
                    text.SetActive(true);
                }
                if (GetComponentInParent<DayandNight>().NightQuest == true)
                {
                    Nightext.SetActive(true);

                }
            }
            if (GetComponentInParent<DayandNight>().IsNightTime == true)
            {
                text.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger = false;
            text.SetActive(false);
            Nightext.SetActive(false);
           

        }

    }


}
