using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EntityManager {

	private static EntityManager instance = null;

	public static EntityManager getInstance()
	{
		if (instance == null)
		{
			instance = new EntityManager();
		}
		return instance;
	}

    public Dictionary<int, CharacterInfo> creatures;
    //兵种序列ID
    public int creatureIndexId;
	private EntityManager()
	{
		creatures = new Dictionary<int, CharacterInfo> ();
        creatureIndexId = 0;
	}

    public void AddCreature(int creatureId)
    {
        creatureIndexId += 1;
        CharacterInfo charInfo = new CharacterInfo(creatureIndexId, creatureId);
        creatures.Add(creatureIndexId, charInfo);
        //Debug.Log(DataPreLoader.getInstance().GetData("Monsters")[creatureId]["AttackValue"]);
        EntityViewManager.getInstance().AddCreature(charInfo);
    }
}
