using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{   
    public static EventManager Instance;

    public UnityEvent CollectibleCollected;
    public UnityEvent ObstacleTouched;
    public UnityEvent<int> ScoreUpdated;
    public UnityEvent<bool> NearGrabbableObject;
    public UnityEvent GameOver;

    private void Awake()
    {
        if (EventManager.Instance != null)
        {
            Destroy(this);
        }
        else
        {
            EventManager.Instance = this;
        }
    }
    
    public void OnCollectibleCollected()
    {
        CollectibleCollected?.Invoke();
    }

    public void OnObstacleTouched()
    {
        ObstacleTouched?.Invoke();
    }

    public void OnScoreUpdated(int score)
    {
        ScoreUpdated?.Invoke(score);
    }

    public void OnNearGrabbableObject(bool isNear)
    {
        NearGrabbableObject?.Invoke(isNear);
    }

    public void OnGameOver()
    {
        GameOver?.Invoke();
    }
}
