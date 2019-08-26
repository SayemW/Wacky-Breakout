using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Blocks
{
    // Effect properties
    int blockType;
    float effectDuration;
    float speedupFactor;
    FreezerEffectActivated freezerEffectActivated;
    SpeedupEffectActivated speedupEffectActivated;

    // Change the Visuals
    SpriteRenderer spriteRenderer;

    // Set Color
    Material[] mat = new Material[2];
    public int setBlockType
    {
        set
        {
            blockType = value;

            // Set colors
            mat[0] = Resources.Load<Material>("PaddleMaterialBlue");
            mat[1] = Resources.Load<Material>("PaddleMaterialRed");

            // Get spriterenderer
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.material = mat[value]; 

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
    protected override void Start()
    {
        blockValue = ConfigurationUtils.PickupBlockPoints;
        base.Start();
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
            addPointsEvent.Invoke(blockValue);
        }
        else
        {
            speedupEffectActivated.Invoke(effectDuration, speedupFactor);
        }
        base.OnCollisionEnter2D(collision);
    }
}
