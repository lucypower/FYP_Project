using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Plate : MonoBehaviour
{
    PanTrigger m_panTrigger;
    PanTrigger m_plateTrigger;

    public string m_plateContents;
    GameObject m_pan;
    GameObject m_finishPlate;

    private void Awake()
    {
        m_panTrigger = GameObject.Find("PanTrigger").GetComponent<PanTrigger>();
        m_plateTrigger = GameObject.Find("PlateTrigger").GetComponent<PanTrigger>();
        m_pan = GameObject.Find("Pan");
        m_finishPlate = GameObject.Find("SpagetPlate");
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

                    case "Pan":

                        for (int i = 0; i < m_finishPlate.transform.childCount - 2; i++)
                        {
                            m_finishPlate.transform.GetChild(i).gameObject.SetActive(true);
                        }

                        break;

                    default:
                        break;
                }

                Destroy(this.gameObject);
            }
        }
    }
}
