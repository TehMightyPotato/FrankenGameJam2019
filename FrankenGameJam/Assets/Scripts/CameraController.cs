using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Screen Movement Settings")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float moveDistance;
    [SerializeField]
    private Vector3 startPosition;
    [SerializeField]
    private Vector3 currentWayPoint;
    [SerializeField]
    private Vector3 nextWayPoint;
    private Coroutine ownCoroutine;

    void Start()
    {
        currentWayPoint = startPosition = transform.position;
        ownCoroutine = StartCoroutine(FloatingCamCoroutine());
    }

    public void ScreenShake(float time, float intensity)
    {
        if (ownCoroutine != null)
        {
            StopCoroutine(ownCoroutine);
            ownCoroutine = StartCoroutine(ScreenShakeRoutine(time, intensity));
        }
        else
        {
            ownCoroutine = StartCoroutine(ScreenShakeRoutine(time, intensity));
        }
    }


    private Vector3 CalcNewWaypoint()
    {
        var waypoint = (Vector3)Random.insideUnitCircle * moveDistance + startPosition;
        return waypoint;
    }

    public IEnumerator FloatingCamCoroutine()
    {
        nextWayPoint = CalcNewWaypoint();
        while (true)
        {
            if (Vector3.Distance(transform.position, nextWayPoint) >= 0.1)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextWayPoint, moveSpeed * Time.deltaTime);
            }
            else
            {
                currentWayPoint = nextWayPoint;
                nextWayPoint = CalcNewWaypoint();
            }
            yield return null;
        }
    }

    public IEnumerator ScreenShakeRoutine(float time, float intensity)
    {
        while (time > 0)
        {
            if (Vector3.Distance(transform.position, nextWayPoint) >= 0.1)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextWayPoint, moveSpeed * Time.deltaTime * intensity);
            }
            else
            {
                currentWayPoint = nextWayPoint;
                nextWayPoint = CalcNewWaypoint();
            }
            time -= Time.deltaTime;
            yield return null;
        }
        transform.position = currentWayPoint = startPosition;
        ownCoroutine = StartCoroutine(FloatingCamCoroutine());
    }
}
