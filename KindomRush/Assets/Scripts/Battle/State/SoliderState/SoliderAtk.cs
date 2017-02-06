using System;
using System.Collections.Generic;
using UnityEngine;

public class SoliderAtk : StateBase
{
    public SoliderInfo soliderInfo;
    public float attackTime;
    public float curTime;
    //普通攻击放到状态机里做，技能用SkillManager做，普通攻击不作为技能处理
    public SoliderAtk(SoliderInfo _soliderInfo)
    {
        soliderInfo = _soliderInfo;
        attackTime = 0;
        curTime = 0;
    }

    public void EnterExcute()
    {
        soliderInfo.StartAttack();
        attackTime = soliderInfo.attackTime;
        curTime = 0;
    }

    public void Excute()
    {
        curTime += Time.deltaTime;
        //若完成一次攻击
        if (curTime >= attackTime)
        {
            //执行普通攻击计算伤害方法
            //若目标为空或者已死亡，返回停留位置
            //否则，继续攻击
            //可以在这里添加攻击后被动技能
            soliderInfo.SetState("attack");
        }
    }

    public void ExitExcute()
    {

    }
}

