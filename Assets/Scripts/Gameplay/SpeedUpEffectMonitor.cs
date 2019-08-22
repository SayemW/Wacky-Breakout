using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpEffectMonitor : MonoBehaviour
{
    bool speedUpInEffect = false;
    float speedUpFactor;
    Timer effectTimer;

    public float SpeedUpFactor
    {
        get { return speedUpFactor; }
    }

    public bool isSpeedUpInEffect
    {
        get { return speedUpInEffect; }
    }

    public float timeRemaining
    {
        get { return effectTimer.timeRemaining; }
    }

    // Start is called before the first frame update
    void Start()
    {
        effectTimer = gameObject.AddComponent<Timer>();
        EventManager.addSpeedListener(speedUpActivated);
    }

    // Update is called once per frame
    void Update()
    {
        if (effectTimer.Finished)
        {
            speedUpInEffect = false;
        }
    }

    // SpeedUp effect activated method
    void speedUpActivated(float duration, float speedupFactor)
    {
        speedUpFactor = speedupFactor;
        if (speedUpInEffect)
        {
            effectTimer.addTime(duration);
        }
        else
        {
            effectTimer.Duration = duration;
            effectTimer.Run();
            speedUpInEffect = true;
        }
    }
}
