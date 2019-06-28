using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Playertype
{
    PLAYER1,
    PLAYER2
}
public class Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D playerRB;
    public Playertype playertype;
    public Vector2 playermov = new Vector2(0, 0);    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playertype == Playertype.PLAYER1)
        {
            playermov.x = Input.GetAxis("HorizontalP1");
            playermov.y = Input.GetAxis("VerticalP1");
        }
        if (playertype == Playertype.PLAYER2)
        {
            playermov.x = Input.GetAxis("HorizontalP2");
            playermov.y = Input.GetAxis("VerticalP2");
        }
    }
    private void FixedUpdate()
    {
        playerRB.AddForce(playermov*speed,ForceMode2D.Impulse);
    }
}
