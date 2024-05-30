using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameOverScore;

    public void Start()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {

        if (_gameOverScore != null)
        {
            _gameOverScore.text = $"Max score\n{PlayerPrefs.GetInt("MaxScore", 0)}";
        }
        else
        {
            Debug.LogError("UI Score reference is missing when trying to display score!");
        }
    }
}
