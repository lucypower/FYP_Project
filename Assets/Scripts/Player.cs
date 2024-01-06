using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    GameManager m_gameManager;

    private InputDevice m_inputDevice;

    private void Awake()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        var devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            m_inputDevice = devices[0];
        }
    }

    private void Update()
    {
        bool triggerValue;

        if (m_inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            Debug.Log("Trigger pressed");
        }
        //if (m_gameManager.m_objectHeld && (m_inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) && triggerValue > 0.1f)
        //{
        //    Debug.Log("Pressed");
        //}
    }
}
