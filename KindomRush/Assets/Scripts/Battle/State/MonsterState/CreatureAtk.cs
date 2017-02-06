using System;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAtk : StateBase
{
    public MonsterInfo monsterInfo;
    public string name;
    public float attackTime;
    public float curTime;
    public CreatureAtk(MonsterInfo _monsterInfo)
    {
        name = "CreatureAtk";
        monsterInfo = _monsterInfo;
        attackTime = 0;
        curTime = 0;
    }

    public void EnterExcute()
    {
        Debug.Log("CreatureAtk EnterExcute");
        monsterInfo.StartAttack();
        attackTime = monsterInfo.attackTime;
        curTime = 0;
    }

    public void Excute()
    {
        curTime += Time.deltaTime;
        if (curTime >= attackTime)
        {
            //执行普通攻击计算伤害方法
            //若目标为空或者已死亡，继续行动
            //否则，继续攻击
            //可以在这里添加攻击后被动技能
            monsterInfo.SetState("attack");
        }
    }

    public void ExitExcute()
    {

    }
}

