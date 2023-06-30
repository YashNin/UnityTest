using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void Collided(CollisionDetector detector)
    {
        if (detector.collidedWith.CompareTag("Player"))
        {
            EventManager.Instance.OnCollectibleCollected();
            SendMessage("PlaySound", SendMessageOptions.DontRequireReceiver);
        }

        detector.spawner.OnSpawnedObjectDestroyed();
        Destroy(gameObject);
    }
}
