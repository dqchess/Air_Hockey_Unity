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

    public UiManager uiManager;

    public int maxScore;

    #region Scores
    private int aiScore, playerScore;

    private int AiScore
    {
        get{ return aiScore; }
        set {
            aiScore = value;
            if(value == maxScore)
            {
                uiManager.ShowRestartCanvas(true);
            }
        }
    }

    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            playerScore = value;
            if (value == maxScore)
            {
                uiManager.ShowRestartCanvas(false);
            }
        }
    }
    #endregion

    public void Increment(ScoreEnum whichScore)
    {
        if(whichScore == ScoreEnum.AiScore)
        {
            AiScoreTxt.text = (++AiScore).ToString();
        } else
        {
            PlayerScoreTxt.text = (++PlayerScore).ToString();
        }
    }
    public void ResetScores()
    {
        AiScore = PlayerScore = 0;
        AiScoreTxt.text = PlayerScoreTxt.text = "0";
    }
}
