using UnityEngine;
using System.Collections.Generic;


public class MonsterInfo : CharacterInfo
{
    public StateMachine creatureStateMachine;
    public CreatureAtk creatureAtk;
    public CreatureDead creatureDead;
    public CreatureIdle creatureIdle;
    public CreatureMove creatureMove;

    public Vector3 startPos;

    public SkillInfo attackSkill;
    public MonsterInfo(int creatureIndexId, int creatureId)
    {
        Id = creatureIndexId;
        charId = creatureId;
        charName = "wulf";

        creatureStateMachine = new StateMachine();
        creatureAtk = new CreatureAtk(this);
        creatureDead = new CreatureDead(this);
        creatureIdle = new CreatureIdle(this);
        creatureMove = new CreatureMove(this);

        startPos = new Vector3(0, 0, 0);

        attackSkill = SkillManager.getInstance().AddSkill(1, this);

        attackTime = AnimationCache.getInstance().getAnimation(charName).getMeshAnimation("attack").getAnimTime();
    }

    public Vector3 GetNextPoint()
    {
        startPos = startPos + new Vector3(1, 0, 0);
        return startPos;
    }

    public void StopAllAction()
    {
        creatureStateMachine.ChangeState(creatureIdle);
    }

    public override void ChangeState(string _state)
    {
        if (_state == "attack")
        {
            creatureStateMachine.ChangeState(creatureAtk);
        }
        else if (_state == "die")
        {
            creatureStateMachine.ChangeState(creatureDead);
        }
        else if (_state == "idle")
        {
            creatureStateMachine.ChangeState(creatureIdle);
        }
        else if (_state == "move")
        {
            creatureStateMachine.ChangeState(creatureMove);
        }
    }

    public override void SetState(string _state)
    {
        if (_state == "attack")
        {
            creatureStateMachine.SetCurrentState(creatureAtk);
        }
        else if (_state == "die")
        {
            creatureStateMachine.SetCurrentState(creatureDead);
        }
        else if (_state == "idle")
        {
            creatureStateMachine.SetCurrentState(creatureIdle);
        }
        else if (_state == "move")
        {
            creatureStateMachine.SetCurrentState(creatureMove);
        }
    }

    public override void StartAttack()
    {
        SkillManager.getInstance().StartSkill(attackSkill);
    }

    public override void StartSkill(int skillId)
    {
        
    }
    //向上走
    public override void RunUp()
    {
        SetRotation(0, 0, 0);
        DoAction("run2");
    }
    //向下走
    public override void RunDown()
    {
        SetRotation(0, 0, 180);
        DoAction("run2");
    }
    //向右走
    public override void RunRight()
    {
        SetRotation(0, 0, 0);
        DoAction("run1");
    }
    //向左走
    public override void RunLeft()
    {
        SetRotation(0, 180, 0);
        DoAction("run1");
    }
    public void Update()
    {
        creatureStateMachine.Excute();
    }
}
