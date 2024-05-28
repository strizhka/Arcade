using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ScoreChangedSignal
{
    public readonly int Score;

    public ScoreChangedSignal(int score)
    {
        Score = score;

        if (score > PlayerPrefs.GetInt("MaxScore", 0))
        {
            PlayerPrefs.SetInt("MaxScore", score);
        }
    }
}
