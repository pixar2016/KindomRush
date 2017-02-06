using System;
using System.Collections.Generic;
using UnityEngine;

public class CreatureDead : StateBase
{
    public MonsterInfo monsterInfo;
    public string name;

    public CreatureDead(MonsterInfo _monsterInfo)
    {
        name = "CreatureAtk";
        monsterInfo = _monsterInfo;
    }

    public void EnterExcute()
    {
        Debug.Log("CreatureDead EnterExcute");
        monsterInfo.DoAction("die");
    }

    public void Excute()
    {

    }

    public void ExitExcute()
    {

    }
}

