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
    public SpriteRenderer playerhalo;
    public Vector2 looking = new Vector2(0,0);
    public float rotation;
    public Coroutine catchCooldownRoutine;
    public float catchCooldown;
    public bool canCatch;
    private Color defaultHaloColor = new Color(255, 0, 0, 255);
    private Color canNotCatchHaloColor = new Color(0, 0, 255, 255);
   
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

    public void StartCatchCooldown()
    {
        if(catchCooldownRoutine == null)
        {
            canCatch = false;
            catchCooldownRoutine = StartCoroutine(CatchCooldownRoutine());
        }
    }

    private void FixedUpdate()
    {
        playerRB.AddForce(playermov*speed,ForceMode2D.Impulse);
        transform.eulerAngles = new Vector3(0,0,rotation);
    }

    public IEnumerator CatchCooldownRoutine()
    {
        var tempCatchCooldown = catchCooldown;
        playerhalo.color = canNotCatchHaloColor;
        playerhalo.enabled = true;
        while(tempCatchCooldown > 0)
        {
            tempCatchCooldown -= Time.deltaTime;
            yield return null;
        }
        canCatch = true;
        playerhalo.enabled = false;
        playerhalo.color = defaultHaloColor;
        catchCooldownRoutine = null;
    }
}
