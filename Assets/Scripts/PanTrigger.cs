using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanTrigger : MonoBehaviour
{
    public bool m_overHob;
    public bool m_onHob;

    private void Awake()
    {
        m_overHob = false;
        m_onHob = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plate"))
        {
            m_overHob = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Plate"))
        {
            m_overHob = false;
        }
    }

    public void PanOnHob()
    {
        m_onHob = true;
    }

    public void PanOffHob()
    {
        m_onHob = false;
    }
}
