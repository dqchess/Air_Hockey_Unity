using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiScript : MonoBehaviour,IReset
{
    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    private Vector2 startingPosition;

    public Rigidbody2D puck;

    public Transform PlayerBoundaryHolder;
    private Boundary playerBoundary;

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

    private Vector2 targetPosition;

    private bool isFirstTimeInOppenentsHalf = true;
    private float offsetXFromTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y
          , PlayerBoundaryHolder.GetChild(1).position.y
          , PlayerBoundaryHolder.GetChild(2).position.x
          , PlayerBoundaryHolder.GetChild(3).position.x
          );

        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y
        , PuckBoundaryHolder.GetChild(1).position.y
        , PuckBoundaryHolder.GetChild(2).position.x
        , PuckBoundaryHolder.GetChild(3).position.x
        );
        UiManager.Instance.resetGameObjects.Add(this);

        switch(GameValues.Difficulty)
        {
            case GameValues.Difficulties.Easy:
                MaxMovementSpeed = 10;
                break;
            case GameValues.Difficulties.Medium:
                MaxMovementSpeed = 15;
                break;
            case GameValues.Difficulties.Hard:
                MaxMovementSpeed = 20;
                break;
        }
    }
    private void FixedUpdate()
    {
        if (!Puck.WasGoal)
        {
            float movementSpeed;
            if (puck.position.y < puckBoundary.Down)
            {
                if (isFirstTimeInOppenentsHalf)
                {
                    isFirstTimeInOppenentsHalf = false;
                    offsetXFromTarget = Random.Range(-1f, 1f);
                }

                movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
                targetPosition = new Vector2(Mathf.Clamp(puck.position.x + offsetXFromTarget,
                    playerBoundary.Left,
                    playerBoundary.Right),
                    startingPosition.y);
            }
            else
            {
                isFirstTimeInOppenentsHalf = true;

                movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
                targetPosition = new Vector2(Mathf.Clamp(puck.position.x,
                                             playerBoundary.Left,
                                             playerBoundary.Right),
                                             Mathf.Clamp(puck.position.y,
                                             playerBoundary.Down,
                                             playerBoundary.Up));
            }
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                movementSpeed * Time.fixedDeltaTime));
        }
    }
    public void ResetPosition()
    {
        if (rb != null)
        {
            rb.position = startingPosition;
        }
    }
}
