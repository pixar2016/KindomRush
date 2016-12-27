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

    public Dictionary<int, CharacterView> creatures;


    private EntityViewManager()
    {
        creatures = new Dictionary<int, CharacterView>();
    }

    public void AddCreature(CharacterInfo charInfo)
    {
        CharacterView charView = new CharacterView(charInfo);
        charView.LoadModel();
        if (creatures.ContainsKey(charInfo.Id))
        {
            creatures[charInfo.Id] = charView;
        }
        else
        {
            creatures.Add(charInfo.Id, charView);
        }
    }
}
