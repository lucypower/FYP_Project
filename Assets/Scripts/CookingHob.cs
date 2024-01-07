using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingHob : MonoBehaviour
{
    // heat : 0 - low / 1 - med / 2 - high
    // take from hob settings

    public bool m_isCooking;
    public float m_secs;
    public bool m_hobOn;

    private void Awake()
    {
        m_isCooking = false;
        m_hobOn = true;
    }

    private void Update()
    {
        if (m_isCooking)
        {
            m_secs -= Time.smoothDeltaTime;            

            if (m_secs <= 0)
            {
                FinishCook();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_hobOn)
        {
            if (other.gameObject.CompareTag("Onion"))
            {
                Debug.Log("onion");
                StartCook(15);
            }
        }
    }

    public void StartCook(float secs) 
    {
        Debug.Log("Start Cook");
        m_secs = secs;  

        m_isCooking = true;        
    }

    public void FinishCook()
    {
        Debug.Log("Finish Cook"); //play ding to tell players its done

        m_isCooking = false;
    }

    public void HobOnOff()
    {
        if (!m_hobOn)
        {
            m_hobOn = true;
        }
        else
        {
            m_hobOn = false;
        }
    }
}
