using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] m_spagetIngrePages;
    int m_spagetPageCount;

    private void Awake()
    {
        m_spagetPageCount = 0;
    }

    public void ButtonPress()
    {
        Debug.Log("Button");
    }

    public void BackPage()
    {
        m_spagetIngrePages[m_spagetPageCount].SetActive(false);
        m_spagetPageCount--;

        if (m_spagetPageCount < 0)
        {
            m_spagetPageCount = 0;
            m_spagetIngrePages[m_spagetPageCount].SetActive(true);
        }
        else
        {
            m_spagetIngrePages[m_spagetPageCount].SetActive(true);
        }
    }

    public void ForwardPage()
    {
        m_spagetIngrePages[m_spagetPageCount].SetActive(false);
        m_spagetPageCount++;

        if (m_spagetPageCount > m_spagetIngrePages.Length - 1)
        {
            m_spagetPageCount = m_spagetIngrePages.Length - 1;
            m_spagetIngrePages[m_spagetPageCount].SetActive(true);
        }
        else
        {
            m_spagetIngrePages[m_spagetPageCount].SetActive(true);
        }
    }
}
