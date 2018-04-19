using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class DragonFly : MonoBehaviour
{
    public Vector3 endPos;

    State initialState, attackingState, resetState;

    public State currentState;

    private void Start()
    {
        initialState = gameObject.AddComponent(typeof(InitialStateDragonFly)) as InitialStateDragonFly;
        attackingState = gameObject.AddComponent(typeof(AttackingStateBee)) as AttackingStateBee;
        resetState = gameObject.AddComponent(typeof(ResetStateBee)) as ResetStateBee;

        currentState = initialState;
        currentState.flag = true;
    }

    private void Update()
    { 
        if (currentState.flag)
        {
            flyIn();
        }
        if (!currentState.flag)
        {
            endPos = currentState.endPos;
            flyIn();
        }
        if (currentState.inPos)
        {
            wait();
        }
        if (currentState.doneWaiting)
        {
            currentState.doneWaiting = false;
            currentState = attackingState;
        }
        if (GameState.dead)
        {
            currentState = resetState;
        }
        if (currentState == attackingState)
        {
            attack();
            if (currentState.resetFlag)
            {
                currentState = resetState;
            }
        }
        else if (currentState == resetState)
        {
            reset();
            currentState = initialState;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }

    public void flyIn()
    {
        currentState.flyIn(endPos);
    }

    public void wait()
    {
        currentState.wait();
    }

    public void attack()
    {
        currentState.attack();
    }

    public void reset()
    {
        currentState.reset();
    }
}

