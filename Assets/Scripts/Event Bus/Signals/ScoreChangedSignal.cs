using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ScoreChangedSignal
{
    public readonly int Score;
    public readonly int MaxScore;

    public ScoreChangedSignal(int score)
    {
        Score = score;

        if (Score > MaxScore)
        {
            MaxScore = Score;
        }
    }
}
