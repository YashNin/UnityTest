using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public string scorePrefix;

    public TMP_Text scoreText, scoreTextOnGameEnd;

    public GameObject grabText;
    public GameObject gameOverPanel;


    public void OnEnable()
    {
        EventManager.Instance.ScoreUpdated.AddListener(OnScoreUpdated);
        EventManager.Instance.NearGrabbableObject.AddListener(OnNearGrabbableObject);
        EventManager.Instance.GameOver.AddListener(OnGameOver);
    }

    public void OnScoreUpdated(int score)
    {
        scoreText.text = scorePrefix + score;
        scoreTextOnGameEnd.text = scorePrefix + score;
    }

    public void OnDisable()
    {
        EventManager.Instance.ScoreUpdated.RemoveListener(OnScoreUpdated);
        EventManager.Instance.NearGrabbableObject.RemoveListener(OnNearGrabbableObject);
        EventManager.Instance.GameOver.RemoveListener(OnGameOver);
    }

    public void OnNearGrabbableObject(bool isNear)
    {
        grabText.SetActive(isNear);
    }

    public void OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
