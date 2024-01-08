using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingIngredient : MonoBehaviour
{
    CookingHob m_cookingHob;
    Renderer m_renderer;

    Color m_cookedOnion;
    Color m_cookedPepper;

    public bool m_inPan;

    private void Awake()
    {
        m_cookingHob = GameObject.Find("PanTrigger").GetComponent<CookingHob>();

        m_renderer = GetComponent<Renderer>();

        m_cookedOnion = new Color(0.29f, 0.1134f, 0.241f, 1f);
        m_cookedPepper = new Color(0.8584f, 0.1498f, 0.1498f, 1f);

        m_inPan = false;
    }

    void Update()
    {
        if (m_cookingHob.m_isCooking && m_inPan)
        {

            switch (gameObject.tag)
            {
                case ("Onion"): // currently doesn't change colour for couple sides of object

                    m_renderer.material.color = Color.Lerp(m_renderer.material.color, m_cookedOnion, Time.deltaTime / m_cookingHob.m_secs);

                    break;

                case ("Pepper"):

                    m_renderer.material.color = Color.Lerp(m_renderer.material.color, m_cookedPepper, Time.deltaTime / m_cookingHob.m_secs);

                    break;

                default:
                    break;
            }            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Pan")
        {
            m_inPan = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Pan")
        {
            m_inPan = false;
        }
    }
}
