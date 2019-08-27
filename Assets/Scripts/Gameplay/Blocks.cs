using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Blocks : MonoBehaviour
{
    protected float blockValue;
    protected AddPointsEvent addPointsEvent;
    protected LastBlockDestroyed lastBlockDestroyed;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        addPointsEvent = new AddPointsEvent();
        lastBlockDestroyed = new LastBlockDestroyed();
        EventManager.addLastBlockLostInvoker(this);
        EventManager.addAddPointsInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Play(AudioClipName.BlockHit);
        if (GameObject.FindGameObjectsWithTag("Block").Length == 1)
        {
            lastBlockDestroyed.Invoke();
        }
        Destroy(gameObject);
    }

    public void addAddPointsListener(UnityAction<float> listener)
    {
        addPointsEvent.AddListener(listener);
    }

    public void addLastBlockLostListener(UnityAction listener)
    {
        lastBlockDestroyed.AddListener(listener);
    }
}
