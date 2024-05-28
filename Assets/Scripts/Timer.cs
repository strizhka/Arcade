using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _remainingTime;
    [SerializeField] private GameObject  _gameOverScreen;

    private void Update()
    {
        if (_remainingTime > 5)
        {
            _remainingTime -= Time.deltaTime;
        }
        else if (_remainingTime > 0)
        {
            _timerText.color = Color.red;
            _remainingTime -= Time.deltaTime;
        }
        else
        {
            _remainingTime = 0;
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);

        }

        int minutes = Mathf.FloorToInt(_remainingTime / 60);
        int seconds = Mathf.FloorToInt(_remainingTime % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
