using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class ResetStateBee : State
{
    public override void attack()
    {
        
    }

    public override void flyIn(Vector3 endPos)
    {
        
    }

    public override void wait()
    {
        
    }

    public override void reset()
    {
        transform.position = new Vector3(0, 12 + id);
    }
}
