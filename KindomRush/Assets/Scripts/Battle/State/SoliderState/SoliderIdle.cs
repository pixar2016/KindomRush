using System;
using System.Collections.Generic;
using UnityEngine;

public class SoliderIdle : StateBase
{
    public SoliderInfo soliderInfo;

    public SoliderIdle(SoliderInfo _soliderInfo)
    {
        soliderInfo = _soliderInfo;
    }

    public void EnterExcute()
    {
        soliderInfo.DoAction("idle");
    }

    public void Excute()
    {

    }

    public void ExitExcute()
    {

    }
}
