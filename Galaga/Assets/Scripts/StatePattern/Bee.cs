using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Bee : MonoBehaviour
{
    public Vector3 endPos;

    State initialState, attackingState;

    State currentState;
    bool flag;

    private void Start()
    {
        initialState = gameObject.AddComponent(typeof(InitialStateBee)) as InitialStateBee;
        attackingState = gameObject.AddComponent(typeof(AttackingStateBee)) as AttackingStateBee;
        
        currentState = initialState;
    }

    private void Update()
    {
        if (flag)
        {
            flyIn();
        }
        wait();
        attack();
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
}

