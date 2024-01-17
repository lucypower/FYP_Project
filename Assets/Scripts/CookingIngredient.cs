using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class CookingIngredient : MonoBehaviour
{
    CookingHob m_cookingHob;
    Renderer[] m_renderer;

    Color m_cookedOnion;
    Color m_black;
    Color m_cookedPepper;
    Color m_cookedMince;

    //public bool m_inPan;
    public bool m_isCooked;
    public bool m_isCooking;

    private void Awake()
    {
        m_cookingHob = GameObject.Find("HobTrigger").GetComponent<CookingHob>();

        m_renderer = GetComponentsInChildren<Renderer>();

        m_cookedOnion = new Color(0.29f, 0.1134f, 0.241f, 1f);
        m_black = new Color(0,0,0, 1f);
        m_cookedPepper = new Color(0.8584f, 0.1498f, 0.1498f, 1f);
        m_cookedMince = new Color(0.2169f, 0.2130f, 0.2118f, 1f);

        //m_inPan = false;
        m_isCooked = false;
        m_isCooking = false;

    }

    void Update()
    {
        if (m_isCooking && !m_isCooked)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                switch (gameObject.transform.GetChild(i).gameObject.tag)
                {
                    case ("PanOnion"):

                        Debug.Log("Cooking");

                        for (int j = 0; j < gameObject.transform.childCount; j++)
                        {
                            m_renderer[j].material.color = Color.Lerp(m_renderer[j].material.color, m_cookedOnion, Time.deltaTime / m_cookingHob.m_secs);
                        }

                        Debug.Log("Cooked");

                        break;

                    case ("PanPepper"):

                        Debug.Log("PepperCook");

                        for (int j = 0; j < gameObject.transform.childCount; j++)
                        {
                            m_renderer[j].material.color = Color.Lerp(m_renderer[j].material.color, m_cookedPepper, Time.deltaTime / m_cookingHob.m_secs);
                        }

                        break;

                    case ("PanMince"):

                        for (int j = 0; j < gameObject.transform.childCount; j++)
                        {
                            m_renderer[j].material.color = Color.Lerp(m_renderer[j].material.color, m_cookedMince, Time.deltaTime / m_cookingHob.m_secs);
                        }

                        break;

                    default:
                        break;
                }
            }
        }
    }
}
