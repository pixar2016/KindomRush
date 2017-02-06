using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
//using EventDispatcherSpace;

public class EntityManager {

	private static EntityManager instance = null;
    //用于广播事件
    public MiniEventDispatcher eventDispatcher;
	public static EntityManager getInstance()
	{
		if (instance == null)
		{
			instance = new EntityManager();
		}
		return instance;
	}

    public Dictionary<int, MonsterInfo> monsters;
    public Dictionary<int, SoliderInfo> soliders;
    //兵种序列ID
    public int monsterIndexId;
    public int soliderIndexId;
	private EntityManager()
	{
        monsters = new Dictionary<int, MonsterInfo>();
        soliders = new Dictionary<int, SoliderInfo>();
        eventDispatcher = new MiniEventDispatcher();
        monsterIndexId = 0;
        soliderIndexId = 0;
	}

    public MonsterInfo AddMonster(int monsterId)
    {
        monsterIndexId += 1;
        MonsterInfo charInfo = new MonsterInfo(monsterIndexId, monsterId);
        monsters.Add(monsterIndexId, charInfo);
        //Debug.Log(DataPreLoader.getInstance().GetData("Monsters")[creatureId]["AttackValue"]);
        this.eventDispatcher.Broadcast("AddMonster", charInfo);
        //EntityViewManager.getInstance().AddCreature(charInfo);
        return charInfo;
    }

    public SoliderInfo AddSolider(int soliderId)
    {
        soliderIndexId += 1;
        SoliderInfo charInfo = new SoliderInfo(soliderIndexId, soliderId);
        soliders.Add(soliderIndexId, charInfo);
        this.eventDispatcher.Broadcast("AddSolider", charInfo);
        return charInfo;
    }

    public void Update()
    {
        foreach (int key in monsters.Keys)
        {
            monsters[key].Update();
        }
        foreach (int key in soliders.Keys)
        {
            soliders[key].Update();
        }
    }

    public List<SoliderInfo> GetSoliderInfo()
    {
        List<SoliderInfo> list = new List<SoliderInfo>();
        foreach (int key in soliders.Keys)
        {
            list.Add(soliders[key]);
        }
        return list;
    }

    public List<MonsterInfo> GetMonsterInfo()
    {
        List<MonsterInfo> list = new List<MonsterInfo>();
        foreach (int key in monsters.Keys)
        {
            list.Add(monsters[key]);
        }
        return list;
    }
}
