using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public enum ScoreEnum
    {
        AiScore,PlayerScore
    }

    public Text AiScoreTxt, PlayerScoreTxt;

    private int aiScore, playerScore;

    public void Increment(ScoreEnum whichScore)
    {
        if(whichScore == ScoreEnum.AiScore)
        {
            AiScoreTxt.text = (++aiScore).ToString();
        } else
        {
            PlayerScoreTxt.text = (++playerScore).ToString();
        }
    }
}
