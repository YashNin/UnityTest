using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Collided(CollisionDetector detector)
    {
        if (detector.collidedWith.CompareTag("Player"))
        {
            EventManager.Instance.OnObstacleTouched();
            SendMessage("PlaySound", SendMessageOptions.DontRequireReceiver);
        }
        else if(detector.collidedWith.CompareTag("Collectible"))
        {
            EventManager.Instance.OnGameOver();
        }

        if(detector.spawner != null)
        detector.spawner.OnSpawnedObjectDestroyed();

        EventManager.Instance.OnNearGrabbableObject(false);
        Destroy(gameObject);

    }
}
