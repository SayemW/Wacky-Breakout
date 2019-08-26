using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject paddlePrefab;

    [SerializeField]
    GameObject standardBlockPrefab;

    [SerializeField]
    GameObject bonusBlockPrefab;

    [SerializeField]
    GameObject pickupBlockPrefab;

    Vector2 blockSize;
    int[,] template;

    System.Array enumValues;

    // Start is called before the first frame update
    void Start()
    {
        // Fill enum values
        enumValues = System.Enum.GetValues(typeof(PickupEffect));

        // Add the paddle
        Instantiate(paddlePrefab, new Vector3(0, ScreenUtils.ScreenBottom * 6 / 7, 0), Quaternion.identity);

        GameObject tempBlock = Instantiate(bonusBlockPrefab);
        blockSize = tempBlock.GetComponent<BoxCollider2D>().size;
        Destroy(tempBlock);

        // Create a template
        template = new int[5, 8];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                template[i, j] = Random.Range(0, 3) > 0.2 ? 1 : 0;
            }
        }

        // Add the blocks
        Vector3 location = new Vector3();
        location.y = (ScreenUtils.ScreenTop * 4 / 5) - (blockSize.y / 2);
        for (int i = 0; i < 5; i++)
        {
            location.x = ScreenUtils.ScreenLeft + (blockSize.x / 2 + 0.15f);
            int col = 0, add = 1;
            while (location.x + (blockSize.x / 2) <= ScreenUtils.ScreenRight)
            {
                if (template[i, col] == 1)
                    setBlock(location);
                location.x += blockSize.x + (blockSize.x / 2);
                if (col == 7)
                {
                    add = -1;
                }
                col += add;
            }
            location.y -= (blockSize.y + blockSize.y / 2) ;
        }

        // Last ball lost event
        EventManager.addLastBallLostListener(lastBallIsLost);

        // Last block broken
        EventManager.addLastBlockLostListener(lastBlockIsLost);
    }

    void setBlock(Vector3 location)
    {
        float val = Random.Range(0f, 1f);
        GameObject newObj;
        if (val <= ConfigurationUtils.StandardBlockProb)
        {
            newObj = standardBlockPrefab;
        }
        else if (val <= ConfigurationUtils.StandardBlockProb + ConfigurationUtils.BonusBlockProb)
        {
            newObj = bonusBlockPrefab;
        }
        else
        {
            newObj = pickupBlockPrefab;
        }
        GameObject pickupBlock = Instantiate<GameObject>(newObj, location, Quaternion.identity);
        if (newObj.Equals(pickupBlockPrefab))
        {
            int blockType = Random.Range(0, enumValues.Length);
            pickupBlock.GetComponent<PickupBlock>().setBlockType = blockType;
            if (blockType == 0)
            {
                pickupBlock.GetComponent<PickupBlock>().setEffectDuration = ConfigurationUtils.FreezeDuration;
            }
            else
            {
                pickupBlock.GetComponent<PickupBlock>().setEffectDuration = ConfigurationUtils.SpeedupDuration;
                pickupBlock.GetComponent<PickupBlock>().setSpeedFactor = ConfigurationUtils.SpeedupFactor;

            }
            pickupBlock.GetComponent<PickupBlock>().setEffectDuration = blockType == 0 ? 
                ConfigurationUtils.FreezeDuration : ConfigurationUtils.FreezeDuration;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            MenuManager.goToMenu(MenuList.Pause);
        }
    }

    void lastBallIsLost()
    {
        MenuManager.goToMenu(MenuList.GameOver);
    }

    void lastBlockIsLost()
    {
        MenuManager.goToMenu(MenuList.GameOver);
    }
}
