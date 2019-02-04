using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    #region Singleton  
    public static UiManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    #endregion


    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;
    [Header("Text")]
    public GameObject WinText;
    public GameObject LoseText;

    [Header("Other")]
    public AudioManager audioManager;
    public Score score;

    public List<IReset> resetGameObjects = new List<IReset>();

    public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0;
        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);
        if (didAiWin)
        {
            audioManager.PlayLostGame();
            WinText.SetActive(false);
            LoseText.SetActive(true);
        } else
        {
            audioManager.PlayWonGame();
            WinText.SetActive(true);
            LoseText.SetActive(false);
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);
        score.ResetScores();

        foreach (var obj in resetGameObjects)
        {
            obj.ResetPosition();
        }
    }
    public void ShowMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
