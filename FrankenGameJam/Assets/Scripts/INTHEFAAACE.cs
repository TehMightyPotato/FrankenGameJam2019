using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTHEFAAACE : MonoBehaviour
{
    public GameObject ballPrefab;
    public float movespeedBall;
    public Rigidbody2D body;
    public Coroutine fireroutine;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (fireroutine == null)
            {
                fireroutine = StartCoroutine(Fire());
            }
        }
    }

    public IEnumerator Fire()
    {
        Movement movescript = GetComponent<Movement>();
        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        var rbBall = ball.GetComponent<Rigidbody2D>();
        var ballscript = ball.GetComponent<PlayerThrownBall>();
        ballscript.origin = gameObject;
        rbBall.AddForce((body.velocity.magnitude + movespeedBall) * new Vector2(movescript.looking.x, movescript.looking.y * -1), ForceMode2D.Impulse);
        Debug.Log("Fire!");
        yield return new WaitForSeconds(2);
        fireroutine = null;
    }

}
