using System;
using System.Collections.Generic;
using UnityEngine;
public class TriggerGroup
{
    public int Id;
    public int triggerIndexId;
    public bool isActive;

    public SkillInfo skillInfo;
    public CharacterInfo charInfo;

    public List<TriggerInfo> triggerInfos;

    public TriggerGroup(int id)
    {
        Id = id;
        triggerIndexId = 0;
        triggerInfos = new List<TriggerInfo>();
    }

    public TriggerInfo AddTriggerInfo(TriggerConfigData data)
    {
        triggerIndexId++;
        TriggerInfo triggerInfo = new TriggerInfo(triggerIndexId);
        triggerInfo.triggerGroup = this;
        triggerInfo.skillInfo = this.skillInfo;
        triggerInfo.charInfo = this.skillInfo.charInfo;
        triggerInfo.LoadDataWithConfig(data);
        triggerInfos.Add(triggerInfo);
        return triggerInfo;
    }

    public void LoadDataWithSkill(SkillInfo skillInfo)
    {
        Debug.Log("LoadDataWithSkill");
        Debug.Log(skillInfo.charInfo);
        this.skillInfo = skillInfo;
        this.charInfo = skillInfo.charInfo;
        List<D_SkillEvent> datas = GetSkillAllEvents(skillInfo.triggerId);
        foreach (D_SkillEvent data in datas)
        {
            Debug.Log(data._id);
            TriggerConfigData configData = new TriggerConfigData();
            configData.SetInfo(data);
            TriggerInfo trigger = AddTriggerInfo(configData);
        }
    }

    public List<D_SkillEvent> GetSkillAllEvents(int _triggerId)
    {
        List<D_SkillEvent> list = J_SkillEvent.ToList();
        List<D_SkillEvent> temp = new List<D_SkillEvent>();
        foreach (D_SkillEvent info in list)
        {
            if (info._triggerId == _triggerId)
            {
                temp.Add(info);
            }
        }
        return temp;
    }

    public void Reset()
    {
        this.isActive = false;
        foreach (TriggerInfo trigger in triggerInfos)
        {
            trigger.Reset();
        }
    }

    public void Set(bool isActive)
    {
        this.isActive = isActive;
    }

    public bool GetActive()
    {
        if (this.isActive)
        {
            if (this.skillInfo != null && this.skillInfo.GetActive())
            {
                return true;
            }
        }
        return false;
    }

    public void Update()
    {

    }
}

