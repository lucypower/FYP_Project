using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CookingHob : MonoBehaviour
{
    // heat : 0 - low / 1 - med / 2 - high
    // take from hob settings
    
    public float m_secs;
    //public bool m_hobOn;

    public GameObject m_panOnions;
    CookingIngredient m_onions;

    GameObject m_peppers;
    GameObject m_mince;
    

    private void Awake()
    {
        m_onions = m_panOnions.GetComponent<CookingIngredient>();

        //m_hobOn = true;        
    }

    private void Update()
    {
        if (m_panOnions.activeInHierarchy)
        {
            if (!m_onions.m_isCooking)
            {
                StartCook();
            }
            else if (m_onions.m_isCooking)
            {
                m_secs -= Time.smoothDeltaTime;

                if (m_secs <= 0)
                {
                    FinishCook();
                }
            }
        }





        //if (m_panOnions.activeInHierarchy)
        //{
        //    for (int i = 0; i < m_onions.Length; i++)
        //    {
        //        if (!m_onions[i].m_isCooking)
        //        {
        //            m_onions[i].m_isCooking = true;
        //            StartCook();
        //        }
        //    }
        //}

        //for (int i = 0; i < m_onions.Length; i++)
        //{
        //    if (m_onions[i].m_isCooking)
        //    {
        //        m_secs -= Time.smoothDeltaTime;

        //        if (m_secs <= 0)
        //        {
        //            m_onions[i].m_isCooking = false;
        //            m_onions[i].m_isCooked = true;
        //            FinishCook();
        //        }
        //    }
        //}       
    }

    public void StartCook()
    {
        Debug.Log("Start Cook");    
        m_onions.m_isCooking = true;
    }

    public void FinishCook()
    {
        Debug.Log("Stop Cook");
        m_onions.m_isCooking = false;
        m_onions.m_isCooked = true;
    }





    //private void Update()
    //{
    //    //if (m_isCooking)
    //    //{
    //    //    m_secs -= Time.smoothDeltaTime;            

    //    //    if (m_secs <= 0)
    //    //    {
    //    //        FinishCook();
    //    //    }
    //    //}
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    //if (m_hobOn)
    //    //{
    //    //    if (other.gameObject.CompareTag("Onion"))
    //    //    {
    //    //        Debug.Log("onion");
    //    //        StartCook(15);
    //    //    }
    //    //}
    //}

    //public void StartCook(float secs) 
    //{
    //    Debug.Log("Start Cook");
    //    m_secs = secs;  

    //    m_isCooking = true;        
    //}

    //public void FinishCook()
    //{
    //    Debug.Log("Finish Cook"); //play ding to tell players its done

    //    m_isCooking = false;
    //}

    //public void HobOnOff()
    //{
    //    if (!m_hobOn)
    //    {
    //        m_hobOn = true;
    //    }
    //    else
    //    {
    //        m_hobOn = false;
    //    }
    //}
}
