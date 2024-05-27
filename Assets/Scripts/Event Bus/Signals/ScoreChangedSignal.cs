using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ScoreChangedSignal
{
    public readonly int Score;

    public ScoreChangedSignal(int score)
    {
        Score = score;
    }
}
