using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class AttackingStateBee : State
{
    int n;
    private void Awake()
    {
        n = Random.Range(-10, 10);
    }

    public override void attack()
    {
        resetFlag = false;
        attackDest = new Vector3(n, -10);

        float step = 9 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, attackDest, step);
        if (transform.position.y == -10)
        {
            resetFlag = true;
        }
    }

    public override void flyIn(Vector3 endPos)
    {
        
    }

    public override void wait()
    {
        
    }

    public override void reset()
    {
        print("Nothing");
    }
}
