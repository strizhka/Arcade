using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Palmmedia.ReportGenerator.Core.Common;
using UnityEditor.SceneManagement;
using System.Collections;

public class Score : MonoBehaviour
{

    [SerializeField] private GameObject _screen;

    private TextMeshProUGUI _uiScore;

    private static int _score = 0;
    private static bool _isDoubled = false;
    public static GameObject _doubledScreen;
    private EventBus _eventBus;

    public static int CurrentScore => _score;
    public static bool IsDoubled => _isDoubled;

    private void Awake()
    {
        _doubledScreen = _screen;
        _isDoubled = false;
        if (_uiScore == null)
        {
            _uiScore = GetComponent<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        if (_uiScore == null)
        {
            Debug.LogError("UI Score reference is missing!");
        }

        _eventBus = FindObjectOfType<EventBus>();
        if (_eventBus != null)
        {
            _eventBus.Subscribe<ScoreChangedSignal>(DisplayScore);
            _eventBus.Subscribe<ScoreChangedSignal>(Die);
            _eventBus.Subscribe<ScoreChangedSignal>(Win);
            _eventBus.Invoke(new ScoreChangedSignal(0));
        }
        else
        {
            Debug.LogError("EventBus component is missing!");
        }
    }

    private void DisplayScore(ScoreChangedSignal signal)
    {
        _score = signal.Score;
        Debug.Log("DisplayScore: " + signal.Score);

        if (_uiScore != null)
        {
            _uiScore.text = $"Current score: {_score}\nMax score: {PlayerPrefs.GetInt("MaxScore", 0)}";
        }
        else
        {
            Debug.LogError("UI Score reference is missing when trying to display score!");
        }
    }

    public static IEnumerator DoubleCoroutine()
    {
        _isDoubled = true;
        _doubledScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        _doubledScreen.SetActive(false);
        _isDoubled = false;
    }

    private void Die(ScoreChangedSignal signal)
    {
        if (signal.Score < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Win(ScoreChangedSignal signal)
    {
        if (signal.Score >= 10000)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnDestroy()
    {
        if (_eventBus != null)
        {
            _eventBus.Unsubscribe<ScoreChangedSignal>(Die);
            _eventBus.Unsubscribe<ScoreChangedSignal>(DisplayScore);
            _eventBus.Unsubscribe<ScoreChangedSignal>(Win);
        }
    }
}

