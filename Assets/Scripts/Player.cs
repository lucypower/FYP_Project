using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    GameManager m_gameManager;
    InputReader m_inputReader;
    IngredientManager m_ingredientManager;
    TableTrigger m_tableTrigger;

    public GameObject m_table;
    public GameObject m_onionPlate;
    public bool m_pickedUp;

    private void Awake()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_inputReader = GameObject.Find("InputReader").GetComponent<InputReader>();
        m_ingredientManager = GameObject.Find("IngredientManager").GetComponent<IngredientManager>();
        m_tableTrigger = GameObject.Find("TriggerRadius").GetComponent<TableTrigger>();
    }

    private void Start()
    {
        m_pickedUp = false;
    }

    private void Update()
    {
        if (m_tableTrigger.m_inRadius)
        {
            if (m_gameManager.m_objectHeld && m_inputReader.m_leftTriggerPressed)
            {
                if (m_inputReader.m_itemHovered == "Onion (UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable)")
                {
                    Debug.Log("Action");
                    Action("Onion");
                }
                else if (m_inputReader.m_itemHovered == "RedPepper (UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable)")
                {
                    Debug.Log("Action");
                    Action("RedPepper");
                }
            }            
        }
    }

    public void Action(string ingredient)
    {
        GameObject plate = GameObject.Find("Plate");
        int objects = m_gameManager.m_slicedObjs.Count;      
        
        for (int i = 0; i < objects; i++)
        {
            m_gameManager.m_slicedObjs.RemoveAll(i => i == null);
        }

        objects = m_gameManager.m_slicedObjs.Count;

        switch (ingredient)
        {
            case "Onion":

                Instantiate(m_ingredientManager.m_onionPlate, m_tableTrigger.m_onionPlate.transform.position, Quaternion.identity);

                for (int i = 0; i < objects; i++)
                {          
                    if (m_gameManager.m_slicedObjs[i].name == "Onion")
                    {
                        Destroy(m_gameManager.m_slicedObjs[i].gameObject);
                        //m_gameManager.m_slicedObjs.RemoveAt(i);
                    }
                }

                break;

            case "RedPepper":

                Instantiate(m_ingredientManager.m_pepperPlate, m_tableTrigger.m_pepperPlate.transform.position, Quaternion.identity);

                for (int i = 0; i < objects; i++)
                {
                    if (m_gameManager.m_slicedObjs[i].name == "RedPepper")
                    {                      
                        Destroy(m_gameManager.m_slicedObjs[i].gameObject);
                        
                        //m_gameManager.m_slicedObjs.RemoveAt(i);
                    }
                }

                break;

            default:
                break;
        }

        

        //for (int i = 0; i < objects; i++)
        //{
        //    if (m_gameManager.m_slicedObjs[i].gameObject == null)
        //    {
        //        m_gameManager.m_slicedObjs.RemoveAt(i);
        //    }
        //}

        plate.transform.position = m_tableTrigger.m_plateSpawn.transform.position;
    }



    //public void Action()
    //{
    //    GameObject plate = GameObject.FindGameObjectWithTag("Plate");
    //    int objects = m_gameManager.m_slicedObjs.Count;
    //    int ingredientPercent = Mathf.RoundToInt((float)(objects * 0.75));

    //    // spawns prefab onto plate        

    //    for (int i = 0; i < ingredientPercent; i++)
    //    {
    //        var position = new Vector3(Random.Range(-0.1f, 0.1f), 0.01f, Random.Range(-0.1f, 0.1f));
    //        var rotation = new Quaternion(0, Random.Range(-90, 90), 0, 0);

    //        GameObject ingredient = Instantiate(m_ingredientManager.m_onion, plate.transform.position + position, rotation);
    //        ingredient.transform.parent = plate.transform;

    //        m_gameManager.m_plateIngre.Add(ingredient);
    //    }   

    //    for (int i = 0; i < objects; i++)
    //    {
    //        Destroy(m_gameManager.m_slicedObjs[i].gameObject);
    //    }

    //    m_gameManager.m_slicedObjs.Clear();

    //    m_pickedUp = true;
    //}

    void RandomStuffs()
    {
        //spawns some of the objects onto the plate

        //int ingredientPercent = Mathf.RoundToInt((float)(objects * 0.2));

        //for (int i = 0; i < ingredientPercent; i++)
        //{
        //    m_gameManager.m_slicedObjs[i].transform.position = plate.transform.position;
        //    m_gameManager.m_slicedObjs[i].transform.parent = plate.transform;

        //    Rigidbody rb = m_gameManager.m_slicedObjs[i].GetComponent<Rigidbody>();
        //    rb.useGravity = false;

        //    m_gameManager.m_plateIngre.Add(m_gameManager.m_slicedObjs[i]);
        //}

        //for (int i = ingredientPercent; i < objects; i++)
        //{
        //    Destroy(m_gameManager.m_slicedObjs[i].gameObject);
        //}
    }
}
