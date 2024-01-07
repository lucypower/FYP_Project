using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    public GameObject m_onion;

    public string m_tag;

    private void Awake()
    {
        gameObject.tag = m_tag;
    }
}
