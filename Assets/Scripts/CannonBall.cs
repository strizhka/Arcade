using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
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
    }

    private void AddScore(int score)
    {
        if (Score.IsDoubled)
        {
            _score = Mathf.Clamp(_score + score * 2, 0, 10000);
        }
        else
        {
            _score = Mathf.Clamp(_score + score, 0, 10000);   
        }
        _eventBus.Invoke(new ScoreChangedSignal(_score));
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
            Target target = collision.gameObject.GetComponent<Target>();

            if (collision.gameObject.CompareTag("targetGood"))
            {
                AddScore(target.Score);
            }

            if (collision.gameObject.CompareTag("timerBonus"))
            {
                AddScore(target.Score);
                Timer._remainingTime += 10;
            }

            if (collision.gameObject.CompareTag("bombBonus"))
            {
                AddScore(target.Score);
                gameObject.GetComponent<SphereCollider>().radius = 10;
            }

            if (collision.gameObject.CompareTag("scoreBonus"))
            {
                AddScore(target.Score);
                StartCoroutine(Score.DoubleCoroutine());
            }

            if (collision.gameObject.CompareTag("targetBad"))
            {
                RemoveScore(target.Score);
            }

            if (collision.gameObject.CompareTag("antiBonus"))
            {
                RemoveScore(target.Score);
                Timer._remainingTime -= 10;
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

