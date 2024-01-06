using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public List<GameObject> m_slicedObjs = new List<GameObject>();
    public bool m_objectHeld;

    public void ObjectHeld()
    {
        m_objectHeld = true;
    }

    public void ObjectNotHeld()
    {
        m_objectHeld= false;
    }
}
