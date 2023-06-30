using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public string detectionTag;

    [HideInInspector]
    public Spawner spawner;

    public Collider collidedWith;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(detectionTag))
        {
            collidedWith = other;

             SendMessage("Collided", this, SendMessageOptions.DontRequireReceiver);
        }
    }
}
