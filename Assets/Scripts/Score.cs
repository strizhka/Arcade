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

//public class Score : MonoBehaviour
//{
//    private int _score = 0;
//    /*[SerializeField] */private TextMeshProUGUI _uiScore;

//    private EventBus _eventBus;

//    private void Awake()
//    {
//        _uiScore = GetComponent<TextMeshProUGUI>();
//        if (_uiScore.text == null)
//        {
//            _score = 0;
//        }
//        else
//        {
//            Debug.Log(_uiScore.text);
//            _score = int.Parse(_uiScore.text);
//        }
//    }

//    private void Start()
//    {
//        //_uiScore = GetComponent<TextMeshProUGUI>();
//        _eventBus = FindObjectOfType<EventBus>();
//        if (_eventBus != null)
//        {
//            _eventBus.Subscribe<ScoreChangedSignal>(DisplayScore);
//            _eventBus.Subscribe<ScoreChangedSignal>(Die);
//            _eventBus.Subscribe<ScoreChangedSignal>(Win);
//        }
//        else
//        {
//            Debug.LogError("EventBus component is missing!");
//        }
//    }

//    //private void AddScore(int score)
//    //{
//    //    _score = Math.Clamp(_score + score, 0, 10000);
//    //    _eventBus.Invoke(new ScoreChangedSignal(_score));
//    //}

//    //private void RemoveScore(int score)
//    //{
//    //    _score = Mathf.Clamp(_score - score, 0, 10000);
//    //    _eventBus.Invoke(new ScoreChangedSignal(_score));
//    //}

//    private void DisplayScore(ScoreChangedSignal signal)
//    {
//        _score = signal.Score;
//        Debug.Log("DisplayScore: " + signal.Score);

//        if (_uiScore != null)
//        {
//            _uiScore.text = _score.ToString() + "p";
//        }
//        else
//        {
//            Debug.LogError("UI Score reference is missing when trying to display score!");
//        }
//    }

//    private void Die(ScoreChangedSignal signal)
//    {
//        if (signal.Score < 0)
//        {
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        }
//    }

//    private void Win(ScoreChangedSignal signal)
//    {
//        if (signal.Score >= 10000)
//        {
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        }
//    }

//    //private void OnCollisionEnter(Collision collision)
//    //{
//    //    if (collision != null)
//    //    {
//    //        if (collision.gameObject.CompareTag("targetGood"))
//    //        {
//    //            AddScore(100);
//    //            //Destroy(collision.gameObject);
//    //        }

//    //        if (collision.gameObject.CompareTag("targetBad"))
//    //        {
//    //            RemoveScore(30);
//    //            //Destroy(collision.gameObject);
//    //        }
//    //    }
//    //}

//    private void OnDestroy()
//    {
//        if (_eventBus != null)
//        {
//            _eventBus.Unsubscribe<ScoreChangedSignal>(Die);
//            _eventBus.Unsubscribe<ScoreChangedSignal>(DisplayScore);
//            _eventBus.Unsubscribe<ScoreChangedSignal>(Win);
//        }
//    }
//}

public class Score : MonoBehaviour
{
    private static int _score = 0;
    [SerializeField] private TextMeshProUGUI _uiScore;

    private EventBus _eventBus;

    public static int CurrentScore => _score;

    private void Awake()
    {
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
            _uiScore.text = _score.ToString();
        }
        else
        {
            Debug.LogError("UI Score reference is missing when trying to display score!");
        }
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

