using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//public class CannonBall : MonoBehaviour
//{
//    [SerializeField] private TextMeshProUGUI _uiScore;
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

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision != null)
//        {
//            if (collision.gameObject.CompareTag("targetGood"))
//            {
//                AddScore(100);
//                Console.WriteLine();
//                Destroy(collision.gameObject);
//            }

//            if (collision.gameObject.CompareTag("targetBad"))
//            {
//                RemoveScore(30);
//                Destroy(collision.gameObject);
//            }
//        }
//    }
//}
