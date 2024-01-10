using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Plate : MonoBehaviour
{
    PanTrigger m_panTrigger;

    public string m_plateContents;
    GameObject m_pan;
    Quaternion m_plateRotation;

    private void Awake()
    {
        m_panTrigger = GameObject.Find("PanTrigger").GetComponent<PanTrigger>();
        m_pan = GameObject.Find("Pan");
    }

    private void Update()
    {
        if (m_panTrigger.m_overHob)
        {
            if (transform.up.y < 0f)
            {
                switch (gameObject.name)
                {
                    case "OnionPlate(Clone)":

                        m_pan.transform.GetChild(2).gameObject.SetActive(true);                        

                        break;

                    case "PepperPlate(Clone)":

                        m_pan.transform.GetChild(3).gameObject.SetActive(true);

                        break;

                    case "MincePlate":

                        m_pan.transform.GetChild(4).gameObject.SetActive(true);

                        break;

                    case "Passata":

                        m_pan.transform.GetChild(5).gameObject.SetActive(true);

                        break;

                    default:
                        break;
                }

                Destroy(this.gameObject);
            }
        }
    }
}
