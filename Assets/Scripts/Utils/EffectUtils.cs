using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    public static SpeedUpEffectMonitor speedUpEffectMonitor = Camera.main.GetComponent<SpeedUpEffectMonitor>();

    public static bool isSpeedupInEffect
    {
        get { return speedUpEffectMonitor.isSpeedUpInEffect; }
    }

    public static float speedUpFactor
    {
        get { return speedUpEffectMonitor.SpeedUpFactor; }
    }

    public static float timeRemaining
    {
        get { return speedUpEffectMonitor.timeRemaining; }
    }
}
