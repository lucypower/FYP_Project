using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTrigger : MonoBehaviour
{
    public bool m_inRadius;

    public GameObject m_onionPlate;
    public GameObject m_pepperPlate;
    public GameObject m_plateSpawn;
    private GameObject m_plate;

    private void Awake()
    {
        m_inRadius = false;

        m_plate = GameObject.Find("Plate");

        m_plate.transform.position = m_plateSpawn.transform.position;
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
