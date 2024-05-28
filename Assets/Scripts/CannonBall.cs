using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class CannonBall : MonoBehaviour
{
    private int _score;
    private EventBus _eventBus;

    public void Initialize(int initialScore, EventBus eventBus)
    {
        _score = initialScore;
        _eventBus = eventBus;
        if (_eventBus != null)
        {
            _eventBus.Subscribe<ScoreChangedSignal>(GetScore);
        }
        else
        {
            Debug.LogError("EventBus component is missing!");
        }
    }

    private void GetScore(ScoreChangedSignal signal)
    {
        _score = signal.Score;
        Debug.Log("From store: " + signal.Score);
    }

    private void AddScore(int score)
    {
        Debug.Log("Prev: " + _score);
        _score = Mathf.Clamp(_score + score, 0, 10000);
        _eventBus.Invoke(new ScoreChangedSignal(_score));
        Debug.Log("Added: " + _score + "+" + score);
    }

    private void RemoveScore(int score)
    {
        _score = Mathf.Clamp(_score - score, 0, 10000);
        _eventBus.Invoke(new ScoreChangedSignal(_score));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("targetGood"))
            {
                AddScore(100);
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.CompareTag("targetBad"))
            {
                RemoveScore(30);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        if (_eventBus != null)
        {
            _eventBus.Unsubscribe<ScoreChangedSignal>(GetScore);
        }
    }
}


//public class CannonBall : MonoBehaviour
//{
//    private int _score;
//    private EventBus _eventBus;


//    private void Start()
//    {
//        _eventBus = FindObjectOfType<EventBus>();
//        if (_eventBus != null)
//        {
//            _eventBus.Subscribe<ScoreChangedSignal>(GetScore);
//        }
//        else
//        {
//            Debug.LogError("EventBus component is missing!");
//        }
//    }

//    private void GetScore(ScoreChangedSignal signal)
//    {
//        _score = signal.Score;
//        Debug.Log("From store: " + signal.Score);
//    }

//    private void AddScore(int score)
//    {
//        Debug.Log("Prev: " + _score);
//        _score = Mathf.Clamp(_score + score, 0, 10000);
//        _eventBus.Invoke(new ScoreChangedSignal(_score));
//        Debug.Log("Added: " + _score + "+" + score);
//    }

//    private void RemoveScore(int score)
//    {
//        _score = Mathf.Clamp(_score - score, 0, 10000);
//        _eventBus.Invoke(new ScoreChangedSignal(_score));
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision != null)
//        {
//            if (collision.gameObject.CompareTag("targetGood"))
//            {
//                AddScore(100);
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
//        if (_eventBus != null)
//        {
//            _eventBus.Unsubscribe<ScoreChangedSignal>(GetScore);
//        }
//    }
//}

