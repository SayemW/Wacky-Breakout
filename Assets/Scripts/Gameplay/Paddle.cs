using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behaviour of the paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    // Paddle movement
    Rigidbody2D paddleRigidBody2D;
    Vector2 direction;
    float moveUnitsPerSecond;

    // Paddle dimensions
    BoxCollider2D paddleBoxCollider;
    float paddleWidth;

    // ScreenUtils
    float edgeLeft;
    float edgeRight;

    // Convex bounce
    const float BounceAngleHalfRange = Mathf.PI / 3;

    // Check if paddle is frozen
    bool isFrozen = false;
    bool isSpedUp = false;
    
    // Effect Timer
    Timer freezeEffectTimer;
    Timer speedEffectTimer;

    // Sprite Color
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        paddleRigidBody2D = GetComponent<Rigidbody2D>();
        moveUnitsPerSecond = ConfigurationUtils.PaddleMoveUnitsPerSecond;

        // Get sprite renderer
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        // get paddle width
        paddleBoxCollider = GetComponent<BoxCollider2D>();
        paddleWidth = paddleBoxCollider.size.x / 2;

        // Set edge locations
        edgeLeft = ScreenUtils.ScreenLeft;
        edgeRight = ScreenUtils.ScreenRight;

        // Direction to move the paddle
        direction = transform.position;

        // Initialize timer and add event listener
        freezeEffectTimer = gameObject.AddComponent<Timer>();
        speedEffectTimer = gameObject.AddComponent<Timer>();

        EventManager.addFreezeListener(setFreeze);
        EventManager.addSpeedListener(setSpeedColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (freezeEffectTimer.Finished && isFrozen)
        {
            isFrozen = false;
            if (!isSpedUp)
                spriteRenderer.material = Resources.Load<Material>("PaddleMaterialOrange");
        }
        if (speedEffectTimer.Finished && isSpedUp)
        {
            isSpedUp = false;
            if (!isFrozen)
                spriteRenderer.material = Resources.Load<Material>("PaddleMaterialOrange");
        }
    }

    private void FixedUpdate()
    {
        // Set direction to move the paddle
        float directionInput = Input.GetAxis("Horizontal");

        // Move the paddle
        if (directionInput != 0 && !isFrozen)
        {              
            // Move paddle to left or right edge
            direction.x = direction.x + moveUnitsPerSecond * directionInput * Time.fixedDeltaTime;

            // Clamp the paddle
            direction.x = calculateClampedX(direction.x);

            // Control speed of paddle
            paddleRigidBody2D.MovePosition(direction);
        }
    }

    float calculateClampedX(float x)
    {
        if (direction.x + paddleWidth > edgeRight)
            return edgeRight - paddleWidth;
        else if (direction.x - paddleWidth < edgeLeft)
            return edgeLeft + paddleWidth;
        else
            return direction.x;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && isValid(coll))
        {
            AudioManager.Play(AudioClipName.PadHit);
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                paddleWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.setDirection(direction);
        }
    }

    bool isValid(Collision2D coll)
    {
        float diff = coll.gameObject.transform.position.y - transform.position.y;
        float diff2 = coll.gameObject.GetComponent<CircleCollider2D>().radius + (paddleBoxCollider.size.y / 2);
        return Mathf.Abs(diff - diff2) <= 0.5f;
    }

    // Check if freeze event occures 
    void setFreeze(float duration)
    {
        if (isFrozen)
        {
            freezeEffectTimer.addTime(duration);
        }
        else
        {
            spriteRenderer.material = Resources.Load<Material>("PaddleMaterialBlue");
            freezeEffectTimer.Duration = duration;
            freezeEffectTimer.Run();
            isFrozen = true;
        }
    }

    void setSpeedColor(float duration, float multiplier)
    {
        if (isSpedUp)
        {
            speedEffectTimer.addTime(duration);
        }
        else
        {
            speedEffectTimer.Duration = duration;
            speedEffectTimer.Run();
            isSpedUp = true;
            spriteRenderer.material = Resources.Load<Material>("PaddleMaterialRed");
        }
    }
}
