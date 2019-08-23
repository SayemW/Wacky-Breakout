using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static List<PickupBlock> freezeEffectInvoker = new List<PickupBlock>();
    static List<UnityAction<float>> freezeListener = new List<UnityAction<float>>();

    static List<PickupBlock> speedEffectInvoker = new List<PickupBlock>();
    static List<UnityAction<float, float>> speedListener = new List<UnityAction<float, float>>();

    static List<Blocks> addPointsInvoker = new List<Blocks>();
    static List<UnityAction<float>> addPointsListener = new List<UnityAction<float>>();

    static List<Ball> ballLostInvoker = new List<Ball>();
    static List<UnityAction> ballLostListener = new List<UnityAction>();

    static List<Ball> ballDieInvoker = new List<Ball>();
    static List<UnityAction> ballDieListener = new List<UnityAction>();

    static HUD lastBallLostInvoker;
    static UnityAction lastBallLostListener;

    public static void addFreezeListener(UnityAction<float> listener2)
    {
        freezeListener.Add(listener2);
        foreach (PickupBlock invoker in freezeEffectInvoker)
        {
            invoker.AddFreezeEffectListener(listener2);
        }
    }

    public static void addFreezeInvoker(PickupBlock invoker)
    {
        freezeEffectInvoker.Add(invoker);
        foreach (UnityAction<float> lsnr in freezeListener)
        {
            invoker.AddFreezeEffectListener(lsnr);
        }
    }

    // For speed
    public static void addSpeedListener(UnityAction<float, float> listener2)
    {
        speedListener.Add(listener2);
        foreach (PickupBlock invoker in speedEffectInvoker)
        {
            invoker.AddSpeedEffectListener(listener2);
        }
    }

    public static void addSpeedInvoker(PickupBlock invoker)
    {
        speedEffectInvoker.Add(invoker);
        foreach (UnityAction<float, float> lsnr in speedListener)
        {
            invoker.AddSpeedEffectListener(lsnr);
        }
    }

    public static void addAddPointsListener(UnityAction<float> listener2)
    {
        addPointsListener.Add(listener2);
        foreach (Blocks invoker in addPointsInvoker)
        {
            invoker.addAddPointsListener(listener2);
        }
    }

    public static void addAddPointsInvoker(Blocks invoker)
    {
        addPointsInvoker.Add(invoker);
        foreach (UnityAction<float> lsnr in addPointsListener)
        {
            invoker.addAddPointsListener(lsnr);
        }
    }

    public static void addBallLostListener(UnityAction listener)
    {
        ballLostListener.Add(listener);
        foreach(Ball invoker in ballLostInvoker)
        {
            invoker.addBallLostListener(listener);
        }
    }

    public static void addBallLostInvoker(Ball invoker)
    {
        ballLostInvoker.Add(invoker);
        foreach (UnityAction lsnr in ballLostListener)
        {
            invoker.addBallLostListener(lsnr);
        }
    }

    public static void addBallDieListener(UnityAction listener)
    {
        ballDieListener.Add(listener);
        foreach (Ball invoker in ballDieInvoker)
        {
            invoker.addBallDieListener(listener);
        }
    }

    public static void addBallDieInvoker(Ball invoker)
    {
        ballDieInvoker.Add(invoker);
        foreach (UnityAction lsnr in ballDieListener)
        {
            invoker.addBallDieListener(lsnr);
        }
    }

    public static void addLastBallLostListener(UnityAction listener2)
    {
        lastBallLostListener = listener2;
        if (lastBallLostInvoker != null)
        {
            lastBallLostInvoker.addLastBallLostListener(lastBallLostListener);
        }
    }

    public static void addLastBallLostInvoker(HUD invoker)
    {
        lastBallLostInvoker = invoker;
        if (lastBallLostListener != null)
        {
            lastBallLostInvoker.addLastBallLostListener(lastBallLostListener);
        }
    }

}
