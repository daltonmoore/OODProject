using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class InitialStateBee : State
{
    public override void attack()
    {
        
    }
    int count = 1;
    public override void flyIn(Vector3 endPos)
    {
        float step = 7 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos, step);
        if (transform.position == endPos)
        {
            
            switch (count)
            {
                case 1:
                    endPos = new Vector3(3, 3);
                    break;
            }
            count++;
        }
    }

    public override void wait()
    {
        
    }
}
