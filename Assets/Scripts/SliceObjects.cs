using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;

public class SliceObjects : MonoBehaviour
{
    public Transform m_startSlicePoint;
    public Transform m_endSlicePoint;
    public VelocityEstimator m_vEstimator;

    public float m_cutForce;
    public LayerMask m_sliceableLayer;

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
        Vector3 velocity = m_vEstimator.GetVelocityEstimate();
        Vector3 normal = Vector3.Cross(m_endSlicePoint.position - m_startSlicePoint.position, velocity);
        normal.Normalize();

        SlicedHull slicedHull = targetObject.Slice(m_endSlicePoint.position, normal);

        if (slicedHull != null)
        {
            GameObject upperHull = slicedHull.CreateUpperHull(targetObject, targetObject.GetComponent<Renderer>().material);
            SetupSlicedComponent(upperHull);
            upperHull.gameObject.layer = LayerMask.NameToLayer("Sliceable");
            

            GameObject lowerHull = slicedHull.CreateLowerHull(targetObject, targetObject.GetComponent<Renderer>().material);
            SetupSlicedComponent(lowerHull);
            lowerHull.gameObject.layer = LayerMask.NameToLayer("Sliceable");

            Destroy(targetObject);
        }
    }

    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(m_cutForce, slicedObject.transform.position, 1);
    }
}
