using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _uiScore;

    private void Update()
    {
        //TextMeshPro _scoreText = _uiScore.GetComponent<TextMeshPro>();
        _uiScore.text = DateTime.Now.ToString();
    }
}
