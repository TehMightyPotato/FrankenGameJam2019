using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrownBall : GenericBall
{

    public GameObject origin;
    public Coroutine looseHealthRoutine;
    public float timer;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("BallBorder"))
        {
            managerScript.BallRemove(gameObject);
            Destroy(gameObject);
        }
        if (col.CompareTag("Player") && col.gameObject != origin)
        {
            if (looseHealthRoutine == null)
            {
                looseHealthRoutine = StartCoroutine(LooseHealthRoutine(col.gameObject));
            }
            managerScript.BallRemove(gameObject);
        }
    }


    public IEnumerator LooseHealthRoutine(GameObject player)
    {
        Movement movescript = player.GetComponent<Movement>();
        player.GetComponent<Health>().Loosehealth();
        yield return null;
        Destroy(gameObject);
    }
}
