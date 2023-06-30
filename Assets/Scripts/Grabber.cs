using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public string grabbableTag;

    public KeyCode grabKey;

    public GameObject grabbableObject;

    public GameObject grabbedObject;

    public Transform player;

    private void Start()
    {
        player = transform.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(grabbableTag))
        {
            if (grabbedObject == null)
            {
                EventManager.Instance.OnNearGrabbableObject(true);

                grabbableObject = other.gameObject;
                _other = other;
            }
        }
    }

    public void Update()
    {
        #region Grabbing

        if (grabbableObject != null && grabbedObject == null)
        {
            EventManager.Instance.OnNearGrabbableObject(true);

            if (Input.GetKeyDown(grabKey))
            {
                Grab();
            }
        }
        else if (grabbableObject == null && grabbedObject != null)
        {
            EventManager.Instance.OnNearGrabbableObject(false);

            if (Input.GetKeyDown(grabKey))
            {
                Release();
            }
        }

        #endregion

        #region While Grabbed

        if (grabbedObject != null)
        {
            grabbedObject.transform.parent = player;
        }

        #endregion

    }


    Vector3 grabOffset;
    void Grab()
    {
        grabbedObject = grabbableObject;
        grabbableObject = null;

        Rigidbody rb = grabbedObject.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

    }

    void Release()
    {
        grabbedObject.transform.parent = null;
        grabbableObject = grabbedObject;

        if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            Destroy(grabbedObject.GetComponent<Rigidbody>());
        }

        grabbedObject = null;
    }

    Collider _other;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(grabbableTag))
        {
            _other = other;
            grabbableObject = null;
            EventManager.Instance.OnNearGrabbableObject(false);
        }
    }
}
