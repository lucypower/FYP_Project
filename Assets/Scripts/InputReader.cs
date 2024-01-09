using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InputReader : MonoBehaviour
{
    List<InputDevice> m_inputDevices = new List<InputDevice>();
    public bool m_leftTriggerPressed;
    public string m_itemHovered;

    private void Start()
    {
        InitialiseInputReader();
        m_leftTriggerPressed = false;
    }

    void InitialiseInputReader()
    {
        //InputDevices.GetDevices(m_inputDevices);

        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, m_inputDevices);

        foreach (var inputDevice in m_inputDevices)
        {
            inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
            //Debug.Log(inputDevice.name + " " + triggerValue);

            if (triggerValue > 0.1f)
            {
                m_leftTriggerPressed = true;
            }
            else
            {
                m_leftTriggerPressed = false;
            }

            inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool yButton);
            //Debug.Log(inputDevice.name + " " + yButton);
                

            //Debug.Log(inputDevice.name + " " + inputDevice.characteristics);
        }
    }

    private void Update()
    {
        if(m_inputDevices.Count < 2)
        {
            InitialiseInputReader();
        }
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log($"{args.interactorObject} hovered over {args.interactableObject}", this);

        m_itemHovered = args.interactableObject.ToString();
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        Debug.Log($"{args.interactorObject} stopped hovering over {args.interactableObject}", this);

        m_itemHovered = "";
    }
}
