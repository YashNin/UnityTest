using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;

    public void OnEnable()
    {
        EventManager.Instance.CollectibleCollected.AddListener(OnCollectibleCollected);
        EventManager.Instance.ObstacleTouched.AddListener(OnObstacleTouched);
    }


    public void OnCollectibleCollected()
    {
        score += 1;
        EventManager.Instance.OnScoreUpdated(score);
    }

    public void OnObstacleTouched()
    {
        if(score - 1 >= 0)
        {
            score -= 1;
            EventManager.Instance.OnScoreUpdated(score);
        }
    }

    public void OnDisable()
    {
        EventManager.Instance.CollectibleCollected.RemoveListener(OnCollectibleCollected);
        EventManager.Instance.ObstacleTouched.RemoveListener(OnObstacleTouched);
    }
}
