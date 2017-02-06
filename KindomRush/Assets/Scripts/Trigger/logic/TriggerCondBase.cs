using System;
using System.Collections.Generic;

public class TriggerCondBase
{
    public TriggerCondBase()
    {

    }

    public virtual bool IsLifeOver(TriggerInfo triggerInfo, TriggerCondInfo condInfo)
    {
        return triggerInfo.EffectCount > 0;
    }

    public virtual bool CheckCondition(TriggerInfo triggerInfo, TriggerCondInfo condInfo)
    {
        return true;
    }

    public virtual void ResetCondition(TriggerInfo triggerInfo, TriggerCondInfo condInfo)
    {
        condInfo.isConditionMatch = false;
    }
}

