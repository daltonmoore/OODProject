using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

abstract class State : MonoBehaviour
{
    public bool flag = false, inPos = false, doneWaiting = false, resetFlag = false;
    public Vector3 endPos, attackDest;
    public int id, randomWaitTime;
    public float timer;

    public abstract void flyIn(Vector3 endPos);
    public abstract void wait();
    public abstract void attack();
    public abstract void reset();
}
