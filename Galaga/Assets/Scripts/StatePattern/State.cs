using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

abstract class State : MonoBehaviour
{
    public abstract void flyIn(Vector3 endPos);
    public abstract void wait();
    public abstract void attack();
}
