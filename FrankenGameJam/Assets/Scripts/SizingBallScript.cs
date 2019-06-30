using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizingBallScript : GenericBall
{

    public int timeCounter;
    public Vector2 transformScale;
    public float transformScaleX;
    public float transformScaleY;

    void FixedUpdate()
    {
        timeCounter++;
        transformScale = transform.localScale;
        if (timeCounter < 30)
        {
            transformScale.x += transformScaleX;
            transformScale.y += transformScaleY;

            transform.localScale = transformScale;
        }

        if (timeCounter >= 30 && timeCounter < 60)
        {
            transformScale.x -= transformScaleX;
            transformScale.y -= transformScaleY;

            transform.localScale = transformScale;
        }
        if (timeCounter == 60)
        {
            timeCounter = timeCounter - 60;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("BallBorder"))
        {
            Destroy(gameObject);
        }
        if (col.CompareTag("Player"))
        {
            if (looseHealthRoutine == null)
            {
                looseHealthRoutine = StartCoroutine(LooseHealthRoutine(col.gameObject));
            }
        }
        if(managerScript != null)
        {
            managerScript.BallRemove(gameObject);
        }
    }
}
