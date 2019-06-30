using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : GenericBall
{
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
        managerScript.BallRemove(gameObject);
    }
}
