using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Plate : MonoBehaviour
{
    PanTrigger m_panTrigger;
    PanTrigger m_plateTrigger;
    CookingHob m_cookingHob;

    public string m_plateContents;
    GameObject m_pan;
    GameObject m_finishPlate;    

    private void Awake()
    {
        m_panTrigger = GameObject.Find("PanTrigger").GetComponent<PanTrigger>();
        m_plateTrigger = GameObject.Find("PlateTrigger").GetComponent<PanTrigger>();
        m_pan = GameObject.Find("Pan");
        m_cookingHob = GameObject.Find("HobTrigger").GetComponent<CookingHob>();
        m_finishPlate = GameObject.Find("SpagetPlate");
    }

    private void Update()
    {
        if (m_panTrigger.m_overHob && m_panTrigger.m_onHob)
        {
            if (transform.up.y < 0f)
            {
                switch (gameObject.name)
                {
                    case "OnionPlate(Clone)":

                        m_pan.transform.GetChild(2).gameObject.SetActive(true);
                        m_cookingHob.Veggies();
                        m_panTrigger.m_overHob = false;
                        Destroy(this.gameObject);

                        break;

                    case "PepperPlate(Clone)":

                        m_pan.transform.GetChild(3).gameObject.SetActive(true);
                        m_cookingHob.Veggies();
                        m_panTrigger.m_overHob = false;
                        Destroy(this.gameObject);

                        break;

                    case "MincePlate":

                        m_pan.transform.GetChild(4).gameObject.SetActive(true);
                        m_cookingHob.Meat();
                        m_panTrigger.m_overHob = false;
                        Destroy(this.gameObject);

                        break;

                    case "Passata":

                        m_pan.transform.GetChild(5).gameObject.SetActive(true);
                        m_panTrigger.m_overHob = false;
                        Destroy(this.gameObject);

                        break;                    

                    


                    case "WorcestershireSauce":

                        m_cookingHob.Liquid();
                        m_panTrigger.m_overHob = false;
                        Destroy(this.gameObject);

                        break;

                    

                    default:
                        break;
                }
            }
            else
            {
                switch (gameObject.name)
                {
                    case "Oregano":

                        m_cookingHob.Spices();
                        m_panTrigger.m_overHob = false;
                        Destroy(this.gameObject);

                        break;

                    case "Salt":
                                               
                        m_cookingHob.Spices();
                        m_panTrigger.m_overHob = false;
                        Destroy(this.gameObject);

                        break;

                    case "Pepper":

                        m_cookingHob.Spices();
                        m_panTrigger.m_overHob = false;
                        Destroy(this.gameObject);

                        break;

                    default:
                        break;
                }
            }
        }

        if (m_plateTrigger.m_overHob && m_cookingHob.m_finishedCooking)
        {
            if (transform.up.y < 0f)
            {
                if (gameObject.name == "Pan")
                {
                    Debug.Log("Pan");
                    m_finishPlate.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
