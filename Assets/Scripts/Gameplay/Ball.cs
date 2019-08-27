using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField]
    GameObject[] effect;

    Material[] mat;
    // Timer to control when the ball destroys itself
    Timer timer, waitTimer, effectTimer;
    const float WaitDuration = 1;
    float speedFac;

    Rigidbody2D ballRigidBody2D;

    bool isSpedUp;

    BallLostEvent ballLostEvent;
    BallDieEvent ballDieEvent;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mat = new Material[2];
        mat[0] = Resources.Load<Material>("BallStandard");
        mat[1] = Resources.Load<Material>("PaddleMaterialRed");
        // Sprite renderer
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

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

        // Event
        ballLostEvent = new BallLostEvent();
        EventManager.addBallLostInvoker(this);

        ballDieEvent = new BallDieEvent();
        EventManager.addBallDieInvoker(this);

        // Set initial color
        if (EffectUtils.isSpeedupInEffect && EffectUtils.timeRemaining > 1)
        {
            effect[1].GetComponent<Renderer>().material = mat[1];
            spriteRenderer.material =mat[1];
        }
        else
        {
            effect[1].GetComponent<Renderer>().material = mat[0];
        }
        Instantiate(effect[1], transform.position , Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTimer.Finished)
        {
            spriteRenderer.enabled = true;
            giveForce();
            waitTimer.Stop();
        }
        // When the timer runs out
        if (timer.Finished)
        {
            if (isSpedUp)
            {
                effect[0].GetComponent<Renderer>().material = mat[1];
            }
            Instantiate(effect[0], transform.position, Quaternion.identity);
            effect[0].GetComponent<Renderer>().material = mat[0];
            ballDieEvent.Invoke();
            Destroy(gameObject);
        }
        if(effectTimer.Finished && isSpedUp)
        {
            spriteRenderer.material = mat[0];
            ballRigidBody2D.velocity /= speedFac;
            isSpedUp = false;
        }
    }

    private void OnBecameInvisible()
    {
        if (Camera.main != null && gameObject != null && !timer.Finished && gameObject.transform.position.y <= ScreenUtils.ScreenBottom)
        {
            ballLostEvent.Invoke();
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
            spriteRenderer.material = mat[1];
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
                spriteRenderer.material = mat[1];
                ballRigidBody2D.velocity *= speedupFactor;
                effectTimer.Duration = duration;
                effectTimer.Run();
                isSpedUp = true;
            }
        }
    }

    public void addBallLostListener(UnityAction listener)
    {
        ballLostEvent.AddListener(listener);
    }

    public void addBallDieListener(UnityAction listener)
    {
        ballDieEvent.AddListener(listener);
    }
}
