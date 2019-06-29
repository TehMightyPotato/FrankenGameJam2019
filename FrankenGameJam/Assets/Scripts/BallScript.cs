using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public BallManagerScript managerScript;
    public Coroutine looseHealthRoutine;
    public float timer;

    public void OnTriggerEnter2D (Collider2D col)
    {
        if(col.CompareTag("BallBorder"))
        {
            managerScript.BallRemove(gameObject);
            Destroy(gameObject);
        }
        if (col.CompareTag("Player"))
        {
            if(looseHealthRoutine == null)
            {
                looseHealthRoutine = StartCoroutine(LooseHealthRoutine(col.gameObject));
            }
            managerScript.BallRemove(gameObject);
            Destroy(gameObject);
        }
    }
    
    public IEnumerator LooseHealthRoutine(GameObject player)
    {
       Movement movescript = player.GetComponent<Movement>();
       while(timer > 0)
        {
            if (movescript.playertype == Playertype.PLAYER1)
            {
                if (Input.GetButtonDown("CatchP1"))
                {
                    break;
                }
            }

            if (movescript.playertype == Playertype.PLAYER2)
            {

            }
            timer = timer - Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (timer <= 0)
        {

            player.GetComponent<Health>().Loosehealth();
            yield return null;
        }
        Destroy(gameObject);

    }
}
