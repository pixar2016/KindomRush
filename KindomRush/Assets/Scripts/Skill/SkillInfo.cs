using System;
using System.Collections.Generic;
using UnityEngine;
public class SkillInfo
{
    public int Id;
    public int skillId;
    public CharacterInfo charInfo;
    public int triggerId;
    public TriggerGroup triggerGroup;
    public bool isActive;
    //用于广播事件
    public MiniEventDispatcher eventDispatcher;
    public SkillInfo(int indexId, int skillId)
    {
        this.Id = indexId;
        this.skillId = skillId;
        this.triggerId = J_Skill.GetData(skillId)._triggerId;
        this.eventDispatcher = new MiniEventDispatcher();
    }

    public void Start()
    {
        Debug.Log("SkillEvent_Start");
        Reset();
        this.isActive = true;
        this.triggerGroup.Set(true);
        eventDispatcher.Broadcast("SkillEvent_start");
    }

    public void End()
    {
        this.isActive = false;
        Reset();
    }

    public void LoadData()
    {
        triggerGroup = TriggerManager.getInstance().AddSkillTrigger(this);
    }

    public void Reset()
    {
        triggerGroup.Reset();
    }

    public bool GetActive()
    {
        if (this.isActive)
        {
            return true;
        }
        return false;

    }

    public void Update()
    {

    }
}

