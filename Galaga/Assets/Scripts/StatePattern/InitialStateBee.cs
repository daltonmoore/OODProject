using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class InitialStateBee : State
{
    private void Start()
    {
        randomWaitTime = Random.Range(0, 5);
        if (name.Substring(6) == ")")
        {
            int.TryParse(name.Substring(5, 1), out id);
        }
        else
        {
            int.TryParse(name.Substring(5, 2), out id);
        }
    }

    int count = 1;
    public override void flyIn(Vector3 endPos)
    {
        float step = 9 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos, step);
        if (transform.position == endPos)
        {
            flag = false;
            switch (count)
            {
                case 1:
                    this.endPos = new Vector3(2, 0);
                    break;
                case 2:
                    this.endPos = new Vector3(2.5f, 2);
                    break;
                case 3:
                    this.endPos = new Vector3(3, 3);
                    break;
                case 4:
                    this.endPos = new Vector3(3.5f, 3.5f);
                    break;
                case 5:
                    this.endPos = new Vector3(6, 4);
                    break;
                case 6:
                    this.endPos = new Vector3(8, 3);
                    break;
                case 7:
                    this.endPos = new Vector3(8.5f, 2);
                    break;
                case 8:
                    this.endPos = new Vector3(8, 1);
                    break;
                case 9:
                    this.endPos = new Vector3(7.5f, -1);
                    break;
                case 10:
                    this.endPos = new Vector3(7, -2);
                    break;
                case 11:
                    this.endPos = new Vector3(5, -3);
                    break;
                case 12:
                    this.endPos = new Vector3(3, -3.5f);
                    break;
                case 13:
                    this.endPos = new Vector3(2, -2);
                    break;
                case 14:
                    this.endPos = new Vector3(-3, 4);
                    break;
                case 15:
                    this.endPos = new Vector3(id % 5 - 2, id / 5);
                    break;
            }
            if(count>15 && !doneWaiting)
            {
                inPos = true;
            }
            count++;
        }
    }

    public override void wait()
    {
        StartCoroutine("waitForXSeconds");
        if(doneWaiting)
            inPos = false;
    }

    IEnumerator waitForXSeconds()
    {
        yield return new WaitForSeconds(2 + randomWaitTime);
        doneWaiting = true;
    }

    public override void attack()
    {
        print("Nothing");
    }

    public override void reset()
    {
        print("Nothing");
    }
}
