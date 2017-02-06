using System;
using System.Collections.Generic;

public class EntityViewManager
{
    private static EntityViewManager instance = null;

    public static EntityViewManager getInstance()
    {
        if (instance == null)
        {
            instance = new EntityViewManager();
        }
        return instance;
    }

    public Dictionary<int, CharacterView> monsters;
    public Dictionary<int, CharacterView> soliders;

    private EntityViewManager()
    {
        monsters = new Dictionary<int, CharacterView>();
        soliders = new Dictionary<int, CharacterView>();
        EntityManager.getInstance().eventDispatcher.Register("AddMonster", AddMonster);
        EntityManager.getInstance().eventDispatcher.Register("AddSolider", AddSolider);
    }

    public void AddMonster(object[] data)
    {
        CharacterInfo charInfo = (CharacterInfo)data[0];
        CharacterView charView = new CharacterView(charInfo);
        charView.LoadModel();
        if (monsters.ContainsKey(charInfo.Id))
        {
            monsters[charInfo.Id] = charView;
        }
        else
        {
            monsters.Add(charInfo.Id, charView);
        }
    }

    public void AddSolider(object[] data)
    {
        CharacterInfo charInfo = (CharacterInfo)data[0];
        CharacterView charView = new CharacterView(charInfo);
        charView.LoadModel();
        if (soliders.ContainsKey(charInfo.Id))
        {
            soliders[charInfo.Id] = charView;
        }
        else
        {
            soliders.Add(charInfo.Id, charView);
        }
    }

    public void Update()
    {
        foreach (int key in soliders.Keys)
        {
            soliders[key].Update();
        }
        foreach (int key in monsters.Keys)
        {
            monsters[key].Update();
        }
    }
}
