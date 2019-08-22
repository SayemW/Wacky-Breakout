using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Timer to control when the ball destroys itself
    Timer timer, waitTimer, effectTimer;
    const float WaitDuration = 1;
    float speedFac;

    Rigidbody2D ballRigidBody2D;

    bool isSpedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        // Timer to make the ball wait before dropping
        waitTimer = gameObject.AddComponent<Timer>();
        waitTimer.Duration = WaitDuration;
        waitTimer.Run();

        // Timer to make the ball dissappear
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = ConfigurationUtils.BallLifeTime + WaitDuration;
        timer.Run();

        // Effect timer
        effectTimer = gameObject.AddComponent<Timer>();
        EventManager.addSpeedListener(speedEffect);
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTimer.Finished)
        {
            giveForce();
            waitTimer.Stop();
        }
        // When the timer runs out
        if (timer.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().spawnBall();
            Destroy(gameObject);
        }
        if(effectTimer.Finished && isSpedUp)
        {
            ballRigidBody2D.velocity /= speedFac;
            isSpedUp = false;
        }
    }

    private void OnBecameInvisible()
    {
        HUD.removeBall();

        if (gameObject != null && !timer.Finished && gameObject.transform.position.y <= ScreenUtils.ScreenBottom)
        {
            if (Camera.main != null)
            {
                Camera.main.GetComponent<BallSpawner>().spawnBall();
            }
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Makes the ball move
    /// </summary>
    void giveForce()
    {
        ballRigidBody2D = GetComponent<Rigidbody2D>();
        float angle = -Mathf.PI / 2;
        if (EffectUtils.isSpeedupInEffect)
        {
            effectTimer.Duration = EffectUtils.timeRemaining;
            isSpedUp = true;
            effectTimer.Run();
            speedFac = EffectUtils.speedUpFactor;
            ballRigidBody2D.AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * ConfigurationUtils.BallImpulseForce * EffectUtils.speedUpFactor, ForceMode2D.Force);
        }
        else
        {
            ballRigidBody2D.AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * ConfigurationUtils.BallImpulseForce, ForceMode2D.Force);
        }
    }

    public void setDirection(Vector2 direction)
    {
        ballRigidBody2D.velocity = ballRigidBody2D.velocity.magnitude * direction;
    }

    void speedEffect(float duration, float speedupFactor)
    {
        speedFac = speedupFactor;
        if (ballRigidBody2D != null)
        {
            if (isSpedUp)
            {
                effectTimer.addTime(duration);
            }
            else
            {
                ballRigidBody2D.velocity *= speedupFactor;
                effectTimer.Duration = duration;
                effectTimer.Run();
                isSpedUp = true;
            }
        }
    }
}
