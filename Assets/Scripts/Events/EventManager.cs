﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static List<PickupBlock> freezeEffectInvoker = new List<PickupBlock>();
    static List<UnityAction<float>> freezeListener = new List<UnityAction<float>>();

    static List<PickupBlock> speedEffectInvoker = new List<PickupBlock>();
    static List<UnityAction<float, float>> speedListener = new List<UnityAction<float, float>>();

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
}