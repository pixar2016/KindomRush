using UnityEngine;
using System.Collections.Generic;


public class SoliderInfo : CharacterInfo
{
    public StateMachine soliderStateMachine;
    public SoliderAtk soliderAtk;
    public SoliderDead soliderDead;
    public SoliderIdle soliderIdle;
    public SoliderMove soliderMove;

    public SkillInfo attackSkill;
    public SoliderInfo(int soliderIndexId, int soliderId)
    {
        Id = soliderIndexId;
        charId = soliderId;
        charName = "knight";

        soliderStateMachine = new StateMachine();
        soliderAtk = new SoliderAtk(this);
        soliderDead = new SoliderDead(this);
        soliderIdle = new SoliderIdle(this);
        soliderMove = new SoliderMove(this);

        attackSkill = SkillManager.getInstance().AddSkill(1, this);

        attackTime = AnimationCache.getInstance().getAnimation(charName).getMeshAnimation("attack").getAnimTime();
    }

    //执行AI
    public void RunAI()
    {
        Debug.Log("RunAI");
        MonsterInfo monster = FindMonster();
        if (monster != null)
        {
            AttackMonster(monster);
        }
    }
    //寻找怪物
    MonsterInfo FindMonster()
    {
        List<MonsterInfo> monsterList = EntityManager.getInstance().GetMonsterInfo();
        foreach (MonsterInfo monster in monsterList)
        {
            if (monster.actionName != "attack" && Vector3.Distance(this.GetPosition(), monster.GetPosition()) <= 5)
            {
                return monster;
            }
        }
        return null;
    }
    //攻击怪物
    void AttackMonster(MonsterInfo monster)
    {
        Debug.Log("AttackMonster");
        monster.StopAllAction();
        attackCharInfo = monster;
        this.ChangeState("move");
    }

    public bool IsDead()
    {
        return false;
    }

    public void StopAllAction()
    {
        soliderStateMachine.ChangeState(soliderIdle);
    }

    public override void ChangeState(string _state)
    {
        if (_state == "attack")
        {
            soliderStateMachine.ChangeState(soliderAtk);
        }
        else if (_state == "die")
        {
            soliderStateMachine.ChangeState(soliderDead);
        }
        else if (_state == "idle")
        {
            soliderStateMachine.ChangeState(soliderIdle);
        }
        else if (_state == "move")
        {
            soliderStateMachine.ChangeState(soliderMove);
        }
    }

    public override void SetState(string _state)
    {
        if (_state == "attack")
        {
            soliderStateMachine.SetCurrentState(soliderAtk);
        }
        else if (_state == "die")
        {
            soliderStateMachine.SetCurrentState(soliderDead);
        }
        else if (_state == "idle")
        {
            soliderStateMachine.SetCurrentState(soliderIdle);
        }
        else if (_state == "move")
        {
            soliderStateMachine.SetCurrentState(soliderMove);
        }
    }

    public override void StartAttack()
    {
        SkillManager.getInstance().StartSkill(attackSkill);
    }

    public override void StartSkill(int skillId)
    {

    }
    public override void Hurt()
    {
        if (attackCharInfo != null)
        {

        }
    }

    public void Update()
    {
        soliderStateMachine.Excute();
    }

}
