﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public Score scoreInstance;
    public static bool WasGoal { get; private set; }
    public float maxSpeed;
    private Rigidbody2D rb;
    public AudioManager audioManager; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!WasGoal)
        {
            if(collision.tag == "AiGoal")
            {
                scoreInstance.Increment(Score.ScoreEnum.PlayerScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(false));
            } else if(collision.tag == "PlayerGoal")
            {
                scoreInstance.Increment(Score.ScoreEnum.AiScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(true));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlayPuckCollision();        
    }
    private IEnumerator ResetPuck(bool didAiScore)
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);

        if(didAiScore)
        {
            rb.position = new Vector2(0,-1);
        } else
        {
            rb.position = new Vector2(0, 1);

        }
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity,maxSpeed);
    }
}
