using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Blocks : MonoBehaviour
{
    protected float blockValue;
    protected AddPointsEvent addPointsEvent;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        addPointsEvent = new AddPointsEvent();
        EventManager.addAddPointsInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    public void addAddPointsListener(UnityAction<float> listener)
    {
        addPointsEvent.AddListener(listener);
    }
}
