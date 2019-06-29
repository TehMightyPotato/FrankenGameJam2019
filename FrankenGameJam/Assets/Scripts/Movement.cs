using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public InputMaster inputs;
    public SpriteRenderer playerhalo;
    public Vector2 looking = new Vector2(0,0);
    public float rotation;
   
    // Update is called once per frame
    void Update()
    {
        if (playertype == Playertype.PLAYER1)
        {
            playermov.x = Input.GetAxis("HorizontalP1");
            playermov.y = Input.GetAxis("VerticalP1");
            looking.x = Input.GetAxis("LookX");
            looking.y = Input.GetAxis("LookY");
        }
        if (playertype == Playertype.PLAYER2)
        {
            playermov.x = Input.GetAxis("HorizontalP2");
            playermov.y = Input.GetAxis("VerticalP2");
            looking.x = Input.GetAxis("LookX2");
            looking.y = Input.GetAxis("LookY2");
        }
        rotation = Mathf.Atan2(looking.x, looking.y) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        playerRB.AddForce(playermov*speed,ForceMode2D.Impulse);
        transform.eulerAngles = new Vector3(0,0,rotation);
    }
}
