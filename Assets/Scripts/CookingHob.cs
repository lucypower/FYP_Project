using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CookingHob : MonoBehaviour
{    
    public float m_secs;
    public float m_secsToCook;

    public GameObject m_panOnions;
    CookingIngredient m_onions;
    
    public GameObject m_panPeppers;
    CookingIngredient m_peppers;

    public GameObject m_panMince;
    CookingIngredient m_mince;

    public AudioClip m_clip;
    public AudioSource m_audioSource;
    public AudioClip m_spices;
    public AudioClip m_liquidPour;
    public AudioClip m_simmering;
    public AudioClip m_plop;
    public AudioClip m_veggies;
    public AudioClip m_meat;

    bool m_finalCook;
    public bool m_finishedCooking;
    bool m_lidOn;

    private void Awake()
    {
        m_onions = m_panOnions.GetComponent<CookingIngredient>();
        m_peppers = m_panPeppers.GetComponent<CookingIngredient>();
        m_mince = m_panMince.GetComponent<CookingIngredient>();
        m_finalCook = false;
        m_finishedCooking = false;
        m_lidOn = false;
    }

    private void Update()
    {
        if (m_panOnions.activeInHierarchy)
        {
            if (!m_onions.m_isCooking && !m_onions.m_isCooked)
            {
                StartCook(15);
            }
            else if (m_onions.m_isCooking && !m_onions.m_isCooked)
            {
                m_secs -= Time.smoothDeltaTime;

                if (m_secs <= 0)
                {
                    m_onions.m_isCooked = true;
                    FinishCook();
                }
            }
        }

        if (m_panPeppers.activeInHierarchy)
        {
            if (!m_peppers.m_isCooking && !m_peppers.m_isCooked)
            {
                StartCook(15);
            }
            else if (m_peppers.m_isCooking && !m_peppers.m_isCooked)
            {
                m_secs -= Time.smoothDeltaTime;

                if (m_secs <= 0)
                {
                    m_peppers.m_isCooked = true;
                    FinishCook();
                }
            }
        }

        if (m_panMince.activeInHierarchy)
        {
            if (!m_mince.m_isCooking && !m_mince.m_isCooked)
            {
                StartCook(30);
            }
            else if (m_mince.m_isCooking && !m_mince.m_isCooked)
            {
                m_secs -= Time.smoothDeltaTime;

                if (m_secs <= 0)
                {
                    m_mince.m_isCooked = true;
                    FinishCook();
                }
            }
        }   

        if (m_lidOn && !m_finishedCooking)
        {
            if (!m_finalCook)
            {
                StartCook(45);
            }
            else
            {
                m_secs -= Time.smoothDeltaTime;

                if (m_secs <= 0)
                {
                    FinishCook();
                    m_finishedCooking = true;
                }
            }

            
        }
    }

    public void StartCook(int secs)
    {
        m_secs = secs;

        Debug.Log("Start Cook");

        if (m_panOnions.activeInHierarchy)
        {
            if (!m_onions.m_isCooked)
            {
                m_onions.m_isCooking = true;
            }
        }

        if (m_panPeppers.activeInHierarchy)
        {
            if (!m_peppers.m_isCooked)
            {
                m_peppers.m_isCooking = true;
            }
        }

        if (m_panMince.activeInHierarchy)
        {
            if (!m_mince.m_isCooked)
            {
                m_mince.m_isCooking = true;
            }
        }        
        
        if (m_lidOn)
        {
            m_audioSource.PlayOneShot(m_simmering);
            m_finalCook = true;
        }
    }

    public void FinishCook()
    {       
        Debug.Log("Stop Cook");

        if (m_panOnions.activeInHierarchy)
        {
            if (m_onions.m_isCooked)
            {
                m_onions.m_isCooking = false;
            }
        }

        if (m_panPeppers.activeInHierarchy)
        {
            if (m_peppers.m_isCooked)
            {
                m_peppers.m_isCooking = false;
            }
        }

        if (m_panMince.activeInHierarchy)
        {
            if (m_mince.m_isCooked)
            {
                m_mince.m_isCooking = false;
            }
        }


        m_finalCook = false;

        m_audioSource.Stop();
        m_audioSource.PlayOneShot(m_clip);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lid"))
        {
            if (!m_lidOn)
            {
                Debug.Log("lid on");                
                m_lidOn = true;
            }
        }

        if (other.gameObject.name == "StockPot")
        {
            m_audioSource.PlayOneShot(m_plop);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Lid"))
        {
            if (m_lidOn)
            {
                m_lidOn = false;
            }
        }
    }

    public void Spices()
    {
        m_audioSource.PlayOneShot(m_spices);
    }

    public void Liquid()
    {
        m_audioSource.PlayOneShot(m_liquidPour);
    }

    public void Veggies()
    {
        m_audioSource.PlayOneShot(m_veggies);
    }

    public void Meat()
    {
        m_audioSource.PlayOneShot(m_meat);
    }
}
