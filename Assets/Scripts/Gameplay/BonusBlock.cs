using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Blocks
{
    // Start is called before the first frame update
    void Start()
    {
        blockValue = ConfigurationUtils.BonusBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
