using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class InitialStateBee : State
{
    public override void attack()
    {
        throw new NotImplementedException();
    }

    public override void flyIn(Vector3 endPos)
    {
        float step = 7 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos, step);
    }

    public override void wait()
    {
        throw new NotImplementedException();
    }
}
