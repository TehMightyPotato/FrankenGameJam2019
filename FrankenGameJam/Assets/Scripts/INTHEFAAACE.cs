using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTHEFAAACE : MonoBehaviour
{
    public GameObject ballPrefab;
    public float movespeedBall;
    public Rigidbody2D body;
    public Coroutine fireroutine;
    public Movement movementScript;
    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementScript.playertype == Playertype.PLAYER1)
        {
            if (Input.GetButtonDown("Fire1") && movementScript.looking.magnitude != 0)
            {
                if (fireroutine == null)
                {
                    fireroutine = StartCoroutine(Fire());
                }
            }
        }
        if (movementScript.playertype == Playertype.PLAYER2 && movementScript.looking.magnitude != 0)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (fireroutine == null)
                {
                    fireroutine = StartCoroutine(Fire());
                }
            }
        }
    }

    public IEnumerator Fire()
    {
        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        var rbBall = ball.GetComponent<Rigidbody2D>();
        var ballscript = ball.GetComponent<PlayerThrownBall>();
        ballscript.origin = gameObject;
        rbBall.AddForce((body.velocity.magnitude + movespeedBall) * new Vector2(movementScript.looking.x, movementScript.looking.y * -1), ForceMode2D.Impulse);
        Debug.Log("Fire!");
        yield return new WaitForSeconds(2);
        fireroutine = null;
    }

}
