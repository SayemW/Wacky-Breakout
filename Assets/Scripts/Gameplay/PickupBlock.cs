﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Blocks
{
    [SerializeField]
    Sprite[] blockSprites;

    // Effect properties
    int blockType;
    float effectDuration;
    float speedupFactor;
    FreezerEffectActivated freezerEffectActivated;
    SpeedupEffectActivated speedupEffectActivated;

    // Change the Visuals
    SpriteRenderer spriteRenderer;

    public int setBlockType
    {
        set
        {
            blockType = value;

            // Get spriterenderer
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = blockSprites[value];

            // Create freeze effect object
            if (value == 0)
            {
                freezerEffectActivated = new FreezerEffectActivated();
                EventManager.addFreezeInvoker(this);
            }
            else
            {
                speedupEffectActivated = new SpeedupEffectActivated();
                EventManager.addSpeedInvoker(this);
            }
        }
    }

    public float setEffectDuration
    {
        set
        {
            effectDuration = value;
        }
    }

    public float setSpeedFactor
    {
        set
        {
            speedupFactor = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        blockValue = ConfigurationUtils.PickupBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFreezeEffectListener(UnityAction<float> listener) 
    {
        freezerEffectActivated.AddListener(listener);
    }

    public void AddSpeedEffectListener(UnityAction<float, float> listener)
    {
        speedupEffectActivated.AddListener(listener);
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (blockType == 0)
        {
            freezerEffectActivated.Invoke(effectDuration);
        }
        else
        {
            speedupEffectActivated.Invoke(effectDuration, speedupFactor);
        }
        base.OnCollisionEnter2D(collision);
    }
}