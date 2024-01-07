using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTrigger : MonoBehaviour
{
    public bool m_inRadius;

    private void Awake()
    {
        m_inRadius = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        m_inRadius = true;
    }

    private void OnTriggerExit(Collider other)
    {
        m_inRadius = false;
    }
}
