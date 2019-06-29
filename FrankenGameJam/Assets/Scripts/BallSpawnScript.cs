using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootingDirection
{
    TOP,
    BOTTOM,
    LEFT,
    RIGHT
}

public class BallSpawnScript : MonoBehaviour
{
    public GameObject ballPrefab;
    public float movespeedBall;
    public ShootingDirection shootingDirection;

    public GameObject SpawnBall(BallManagerScript manager)
    {
        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        var rbBall = ball.GetComponent<Rigidbody2D>();
        var ballscript = ball.GetComponent<BallScript>();
        Vector2 direction = new Vector2(0, 0);

        ball.GetComponent<GenericBall>().managerScript = manager;

        if (shootingDirection == ShootingDirection.TOP)
        {
            direction.x = 0;
            direction.y = 1;
        }
        if (shootingDirection == ShootingDirection.BOTTOM)
        {
            direction.x = 0;
            direction.y = -1;
        }
        if (shootingDirection == ShootingDirection.LEFT)
        {
            direction.x = -1;
            direction.y = 0;
        }

        if (shootingDirection == ShootingDirection.RIGHT)
        {
            direction.x = 1;
            direction.y = 0;
        }
        rbBall.AddForce(direction * movespeedBall);
        return ball;
    }
}
