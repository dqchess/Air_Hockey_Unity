using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public Score scoreInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;
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
                StartCoroutine(ResetPuck());
            } else if(collision.tag == "PlayerGoal")
            {
                scoreInstance.Increment(Score.ScoreEnum.AiScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }
        }
    }
    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
    }
}
