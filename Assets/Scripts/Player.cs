using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    GameManager m_gameManager;
    InputReader m_inputReader;

    public bool m_pickedUp;

    private void Awake()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_inputReader = GameObject.Find("InputReader").GetComponent<InputReader>();
    }

    private void Start()
    {
        m_pickedUp = false;
    }

    private void Update()
    {
        if (!m_pickedUp)
        {
            if (m_gameManager.m_objectHeld && m_inputReader.m_leftTriggerPressed)
            {
                Debug.Log("Action");
                Action(); //need to condition it to be near the chopping board
            }
        }
    }

    public void Action()
    {
        GameObject plate = GameObject.FindGameObjectWithTag("Plate");
        int objects = m_gameManager.m_slicedObjs.Count;
        int ingredientPercent = Mathf.RoundToInt((float)(objects * 0.75));

        // spawns prefab onto plate        

        for (int i = 0; i < ingredientPercent; i++)
        {
            var position = new Vector3(Random.Range(-0.1f, 0.1f), 0.01f, Random.Range(-0.1f, 0.1f));
            var rotation = new Quaternion(0, Random.Range(-90, 90), 0, 0);

            GameObject ingredient = Instantiate(m_gameManager.m_onion, plate.transform.position + position, rotation);
            ingredient.transform.parent = plate.transform;

            m_gameManager.m_plateIngre.Add(ingredient);
        }   
         
        for (int i = 0; i < objects; i++)
        {
            Destroy(m_gameManager.m_slicedObjs[i].gameObject);
        }

        m_gameManager.m_slicedObjs.Clear();

        m_pickedUp = true;
    }

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
