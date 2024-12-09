using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScoreData
{
    public int highScore;

    public HighScoreData()
    {
        highScore = 0;
    }

    public HighScoreData(int score)
    {
        highScore = score;
    }
}
