using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class DragonFly : Subscriber
{
    public Vector3 endPos;

    State initialState, attackingState, resetState;
    State currentState;
    int phase=1, id;

    private void Start()
    {
        initialState = gameObject.AddComponent(typeof(InitialStateDragonFly)) as InitialStateDragonFly;
        attackingState = gameObject.AddComponent(typeof(AttackingStateBee)) as AttackingStateBee;
        resetState = gameObject.AddComponent(typeof(ResetStateBee)) as ResetStateBee;

        currentState = initialState;
        currentState.flag = true;

        Phase.subscribe(this);
        if (name.Substring(12) == ")")
        {
            int.TryParse(name.Substring(11, 1), out id);
        }
        else
        {
            int.TryParse(name.Substring(11, 2), out id);
        }
    }

    private void Update()
    {
        switch (phase)
        {
            case 1:
                if(id <=50)
                {
                    return;
                }
                break;
            case 2:
                if(id <= 40)
                {
                    return;
                }
                break;
            case 3:
                if (id <= 30)
                {
                    return;
                }
                break;
            case 4:
                if (id <= 20)
                {
                    return;
                }
                break;
            case 5:
                if (id <= 10)
                {
                    return;
                }
                break;
        }
        if(GameState.dead)
        {
            currentState = resetState;
        }
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

    public override void notify()
    {
        phase = Phase.getPhase();
    }
}

