using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    // Spawn properties
    Vector3 location;
    float ballRadius;

    Timer spawnTimer;
    float minVal, maxVal;
    // Start is called before the first frame update
    void Start()
    {
        // Timer to spawn 
        spawnTimer = gameObject.AddComponent<Timer>();
        minVal = ConfigurationUtils.MinSpawnTime;
        maxVal = ConfigurationUtils.MaxSpawnTime;

        // Run timer
        spawnTimer.Duration = Random.Range(minVal, maxVal);
        spawnTimer.Run();

        location = new Vector3();

        //Get ball radius and spawn initial ball
        GameObject tempBall = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ballRadius = tempBall.GetComponent<CircleCollider2D>().radius;

        EventManager.addBallDieListener(spawnBall);
        EventManager.addBallLostListener(spawnBall);
    }

    void spawnBall()
    {
        // Spawn new ball somewhere in the middle
        location.x = 0;

        // Spawns only if there is no collision
        if (!Physics2D.OverlapCircle(location, ballRadius))
        {
            Instantiate<GameObject>(ballPrefab, location, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (spawnTimer.Finished)
        {
            spawnBall();

            // Run timer again
            spawnTimer.Duration = Random.Range(minVal, maxVal);
            spawnTimer.Run();
        }
    }
}
