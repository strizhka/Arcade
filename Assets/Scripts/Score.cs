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

public class Score : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI _uiScore;

    private EventBus _eventBus;

    private void Awake()
    {
        if (_uiScore != null)
        {
            if(_uiScore.text == null)
            {
                _score = 9;
                Debug.Log("_uiScore.text == null");
            }
            else
            {
                Debug.Log(_uiScore.text);
                _score = int.Parse( _uiScore.text );
            }
                
        }
        else
        {
            Debug.LogError("UI Score reference is missing!");
        }
        Debug.Log("Awake: Initial score is " + _score);
    }

    private void Start()
    {
        _eventBus = GetComponent<EventBus>();
        if (_eventBus != null)
        {
            _eventBus.Subscribe<ScoreChangedSignal>(DisplayScore);
            _eventBus.Subscribe<ScoreChangedSignal>(Die);
        }
        else
        {
            Debug.LogError("EventBus component is missing!");
        }
    }

    private void Update()
    {
        // Debugging to ensure Update is called
        //Debug.Log("Update called");
    }

    private void AddScore(int score)
    {
        _score = Math.Clamp(_score + score, 0, 10000);
        _eventBus.Invoke(new ScoreChangedSignal(_score));
        Debug.Log("Score added: " + score + ", new score: " + _score);
    }

    private void RemoveScore(int score)
    {
        _score = Mathf.Clamp(_score - score, 0, 10000);
        _eventBus.Invoke(new ScoreChangedSignal(_score));
        Debug.Log("Score removed: " + score + ", new score: " + _score);
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
            Debug.Log("You died!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Win(ScoreChangedSignal signal)
    {
        if (signal.Score >= 10000)
        {
            Debug.Log("You won!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("targetGood"))
            {
                AddScore(100);
                Debug.Log("Hit targetGood");
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.CompareTag("targetBad"))
            {
                RemoveScore(30);
                Debug.Log("Hit targetBad");
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        if (_eventBus != null)
        {
            _eventBus.Unsubscribe<ScoreChangedSignal>(Die);
            _eventBus.Unsubscribe<ScoreChangedSignal>(DisplayScore);
        }
    }
}


//public class Score : MonoBehaviour
//{
//    private int _score;
//    [SerializeField] private TextMeshProUGUI _uiScore;

//    private EventBus _eventBus;

//    private void Awake()
//    {
//        _score = int.Parse(_uiScore.text);
//        Debug.Log("dddddd");
//    }

//    private void Start()
//    {
//        _eventBus = GetComponent<EventBus>();
//        _eventBus.Subscribe<ScoreChangedSignal>(DisplayScore);
//        _eventBus.Subscribe<ScoreChangedSignal>(Die);
//    }

//    private void Update()
//    {
//        if (_uiScore != null)
//        {
//        }
//    }

//    private void AddScore(int score)
//    {
//        _score = Math.Clamp(_score + score, 0, 10000);
//        _eventBus.Invoke(new ScoreChangedSignal(_score));
//    }

//    private void RemoveScore(int score)
//    {
//        _score = Math.Clamp(_score - score, 0, 10000);
//        _eventBus.Invoke(new ScoreChangedSignal(_score));
//    }

//    private void DisplayScore(ScoreChangedSignal signal)
//    {
//        _score = signal.Score;
//        Debug.Log(signal.Score);


//        _uiScore.text = _score.ToString();
//    }

//    private void Die(ScoreChangedSignal signal)
//    {
//        if (signal.Score < 0)
//        {
//            Debug.Log("Вы умерли!");
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        }
//    }

//    private void Win(ScoreChangedSignal signal)
//    {
//        if (signal.Score >= 10000)
//        {
//            Debug.Log("Вы победили!");
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision != null)
//        {
//            if (collision.gameObject.CompareTag("targetGood"))
//            {
//                AddScore(100);
//                Debug.Log("sdd");
//                Destroy(collision.gameObject);
//            }

//            if (collision.gameObject.CompareTag("targetBad"))
//            {
//                RemoveScore(30);
//                Destroy(collision.gameObject);
//            }
//        }
//    }

//    private void OnDestroy()
//    {
//        _eventBus.Unsubscribe<ScoreChangedSignal>(Die);
//        _eventBus.Unsubscribe<ScoreChangedSignal>(DisplayScore);
//    }
//}
