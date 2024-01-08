using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    CookingHob m_cookingHob;

    public string m_plateContents;
    GameObject m_pan;
    Quaternion m_plateRotation;

    private void Awake()
    {
        m_cookingHob = GameObject.Find("PanTrigger").GetComponent<CookingHob>();
        m_pan = GameObject.Find("Pan");
    }

    private void Update()
    {
        if (m_cookingHob.m_overHob)
        {
            if (transform.up.y < 0f)
            {
                m_pan.transform.GetChild(1).gameObject.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }
}
