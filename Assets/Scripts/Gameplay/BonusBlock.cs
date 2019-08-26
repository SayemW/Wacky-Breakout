using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Blocks
{
    // Start is called before the first frame update
    protected override void Start()
    {
        blockValue = ConfigurationUtils.BonusBlockPoints;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(222/255f, 183/255f, 55/255f, 1);
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
