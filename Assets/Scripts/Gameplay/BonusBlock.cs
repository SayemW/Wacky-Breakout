using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Blocks
{
    // Start is called before the first frame update
    protected override void Start()
    {
        blockValue = ConfigurationUtils.BonusBlockPoints;
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
