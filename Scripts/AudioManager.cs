using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip puckCollision;
    public AudioClip goal;
    public AudioClip wonGame;
    public AudioClip lostGame;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuckCollision()
    {
        audioSource.PlayOneShot(puckCollision);
    }
    public void PlayGoal()
    {
        audioSource.PlayOneShot(goal);
    }
    public void PlayLostGame()
    {
        audioSource.PlayOneShot(lostGame);
    }
    public void PlayWonGame()
    {
        audioSource.PlayOneShot(wonGame);
    }
}
