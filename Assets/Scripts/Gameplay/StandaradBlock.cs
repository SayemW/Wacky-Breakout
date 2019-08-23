using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandaradBlock : Blocks
{
    [SerializeField]
    Sprite[] blockSprites;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    protected override void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = blockSprites[Random.Range(0, blockSprites.Length)];
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
