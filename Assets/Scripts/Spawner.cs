using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    public Vector3 levelBounds;

    public int minimumDistanceBetweenObjects;

    int activeObjects;

    Vector3 randomPosition;


    public void Start()
    {
        StartCoroutine(SpawnObjects());
    }


    IEnumerator SpawnObjects()
    {
        foreach (var item in objectsToSpawn)
        {
            do
            {
                randomPosition = GetRandomPositionInLevel();
                yield return null;

            } while (Physics.CheckBox(randomPosition, new Vector3(2f, 0.1f, 2f)));    

            GameObject spawndObject = Instantiate(item, randomPosition, Quaternion.identity);

            spawndObject.GetComponent<CollisionDetector>().spawner = this;
        }

        activeObjects = objectsToSpawn.Length;
    }


    Vector3 GetRandomPositionInLevel()
    {
        return new Vector3(Random.Range(-levelBounds.x, levelBounds.x), levelBounds.y, Random.Range(-levelBounds.z, levelBounds.z));
    }


    public void OnSpawnedObjectDestroyed()
    {
        activeObjects -= 1;

        if (activeObjects < 1)
        {
            StartCoroutine(SpawnObjects());
        }
    }
}
