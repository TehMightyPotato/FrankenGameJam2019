using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericBall : MonoBehaviour
{
    public BallManagerScript managerScript;
    public Coroutine looseHealthRoutine;
    public float timer;
    public SpriteRenderer ownRenderer;

    public IEnumerator LooseHealthRoutine(GameObject player)
    {
        Movement movescript = player.GetComponent<Movement>();
        movescript.playerhalo.enabled = true;
        ownRenderer.enabled = false;
        if (movescript.playertype == Playertype.PLAYER1)
        {
            while (timer > 0)
            {

                if (Input.GetButtonDown("CatchP1") && movescript.canCatch)
                {
                    movescript.StartCatchCooldown();
                    break;
                }
                timer -= Time.deltaTime;
                yield return null;
            }
        }

        if (movescript.playertype == Playertype.PLAYER2)
        {
            while (timer > 0)
            {
                if (Input.GetButtonDown("CatchP2") && movescript.canCatch)
                {
                    movescript.StartCatchCooldown();
                    break;
                }
                timer -= Time.deltaTime;
                yield return null;
            }
        }

        if (timer <= 0)
        {
            movescript.playerhalo.enabled = false;
            player.GetComponent<Health>().Loosehealth();
            yield return null;
        }
        Destroy(gameObject);
    }
}
