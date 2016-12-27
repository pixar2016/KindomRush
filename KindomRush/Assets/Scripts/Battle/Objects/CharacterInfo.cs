using UnityEngine;
using System.Collections;

public class CharacterInfo {

    //序列ID
    public int Id;
    public int charId;
    
    public string charName;

    public CharacterInfo(int creatureIndexId, int creatureId)
    {
        Id = creatureIndexId;
        charId = creatureId;
        charName = "drop";
    }
}
