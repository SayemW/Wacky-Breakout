using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandaradBlock : Blocks
{
    [SerializeField]
    Sprite[] blockSprites;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = blockSprites[Random.Range(0, blockSprites.Length)];
        blockValue = ConfigurationUtils.StandardBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
