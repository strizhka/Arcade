using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private string _score;
    [SerializeField] private TextMeshProUGUI _uiScore;
    [SerializeField] private TextMeshProUGUI _gameOverScore;

    public void Start()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        _score = _uiScore.text;

        if (_gameOverScore != null)
        {
            _gameOverScore.text = $"Final Score\n{Score.CurrentScore}\nMax score: {PlayerPrefs.GetInt("MaxScore", 0)} ";
        }
        else
        {
            Debug.LogError("UI Score reference is missing when trying to display score!");
        }
    }
}
