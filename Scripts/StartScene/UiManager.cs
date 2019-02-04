using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;
    [Header("Text")]
    public GameObject WinText;
    public GameObject LoseText;

    [Header("Other")]
    public AudioManager audioManager;
    public Score score;
    public Puck puck;
    public PlayerMovement playerMovement;
    public AiScript aiScript;

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
        puck.CenterPuck();
        playerMovement.ResetPosition();
        aiScript.ResetPosition();
    }
    public void ShowMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
