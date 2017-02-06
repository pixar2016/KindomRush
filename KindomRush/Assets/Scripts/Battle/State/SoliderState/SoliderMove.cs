using System;
using System.Collections.Generic;
using UnityEngine;

public class SoliderMove : StateBase
{
    public SoliderInfo soliderInfo;
    public Vector3 curPos;
    public Vector3 targetPos;
    public float speed;
    public SoliderMove(SoliderInfo _soliderInfo)
    {
        soliderInfo = _soliderInfo;
    }

    public void EnterExcute()
    {
        curPos = soliderInfo.GetPosition();
        targetPos = soliderInfo.attackCharInfo.GetPosition();
        speed = soliderInfo.GetSpeed();
        soliderInfo.DoAction("run1");
    }

    public void Excute()
    {
        Vector3 pos = soliderInfo.GetPosition();
        float dis = Vector3.Distance(pos, targetPos);
        if (dis < speed * Time.deltaTime)
        {
            soliderInfo.SetPosition(targetPos.x, targetPos.y, targetPos.z);
            soliderInfo.ChangeState("attack");
            soliderInfo.attackCharInfo.ChangeState("attack");
        }
        else
        {
            pos = Vector3.MoveTowards(pos, targetPos, Time.deltaTime * speed);
            soliderInfo.SetPosition(pos.x, pos.y, pos.z);
        }
    }

    public void ExitExcute()
    {

    }
}
