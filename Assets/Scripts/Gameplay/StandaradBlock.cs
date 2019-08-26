using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandaradBlock : Blocks
{
    SpriteRenderer spriteRenderer;
    Color[] color = new Color[3];
    // Start is called before the first frame update
    protected override void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        color[0] = new Color(201 / 255f, 99 / 255f, 131 / 255f, 1);
        color[1] = new Color(99/255f, 201/255f, 119/255f, 1);
        color[2] = new Color(107/255f, 99/255f, 201/255f, 1);
        spriteRenderer.color = color[Random.Range(0, 3)];
        blockValue = ConfigurationUtils.StandardBlockPoints;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        addPointsEvent.Invoke(blockValue);
        base.OnCollisionEnter2D(collision);
    }
}
