using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.HID;

public class SliceObjects : MonoBehaviour
{
    GameManager m_gameManager;
    IngredientManager ingredientManager;

    public Transform m_startSlicePoint;
    public Transform m_endSlicePoint;
    public VelocityEstimator m_vEstimator;

    public float m_cutForce;
    public LayerMask m_sliceableLayer;

    public bool m_isCutting;

    public AudioSource m_audioSource;
    public AudioClip[] m_cuttingAudio;

    public Material m_onion;
    public Material m_pepper;


    private void Awake()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(m_startSlicePoint.position, m_endSlicePoint.position, out RaycastHit hit, m_sliceableLayer);

        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }       

    public void Slice(GameObject targetObject)
    {
        string name = targetObject.name;
        int random = Random.Range(0, m_cuttingAudio.Length);

        Vector3 velocity = m_vEstimator.GetVelocityEstimate();
        Vector3 normal = Vector3.Cross(m_endSlicePoint.position - m_startSlicePoint.position, velocity);
        normal.Normalize();

        SlicedHull slicedHull = targetObject.Slice(m_endSlicePoint.position, normal);  

        

        if (slicedHull != null)
        {
            //GameObject upperHull = slicedHull.CreateUpperHull(targetObject, targetObject.GetComponent<Renderer>().material);
            GameObject upperHull = slicedHull.CreateUpperHull(targetObject, targetObject.GetComponent<SliceMaterial>().m_material);
            SetupSlicedComponent(upperHull, name);
            upperHull.gameObject.layer = LayerMask.NameToLayer("Sliceable");
            m_gameManager.m_slicedObjs.Add(upperHull);

            //GameObject lowerHull = slicedHull.CreateLowerHull(targetObject, targetObject.GetComponent<Renderer>().material);
            GameObject lowerHull = slicedHull.CreateLowerHull(targetObject, targetObject.GetComponent<SliceMaterial>().m_material);
            SetupSlicedComponent(lowerHull, name);
            lowerHull.gameObject.layer = LayerMask.NameToLayer("Sliceable");
            m_gameManager.m_slicedObjs.Add(lowerHull);            

            if(m_gameManager.m_slicedObjs.Contains(targetObject))
            {
                m_gameManager.m_slicedObjs.Remove(targetObject);
            }

            m_audioSource.PlayOneShot(m_cuttingAudio[random]);
            Destroy(targetObject);
        }
    }

    public void SetupSlicedComponent(GameObject slicedObject, string name)
    {
        slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;

        if(slicedObject.GetComponent<XRGrabInteractable>() == null)
        {
            slicedObject.AddComponent<XRGrabInteractable>();            
        }

        if (slicedObject.GetComponent<CookingIngredient>() == null)
        {
            slicedObject.AddComponent<CookingIngredient>();
        }

        if (slicedObject.GetComponent<SliceMaterial>() == null)
        {
            slicedObject.AddComponent<SliceMaterial>();
        }

        switch (name)
        {
            case "Onion":

                SliceMaterial onionMaterial = slicedObject.GetComponent<SliceMaterial>();
                onionMaterial.m_material = m_onion;

                slicedObject.tag = "Onion";
                slicedObject.name = "Onion";

                break;

            case "RedPepper":

                SliceMaterial pepperMaterial = slicedObject.GetComponent<SliceMaterial>();
                pepperMaterial.m_material = m_pepper;

                slicedObject.tag = "Pepper";
                slicedObject.name = "RedPepper";

                break;

            default:
                break;
        }        
    }
}
