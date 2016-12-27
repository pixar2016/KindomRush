using UnityEngine;
using System.Collections;
using Hero;

public class CharacterView {

    public CharacterInfo charInfo;
    public GameObject charObj;
    public Animate charAnim;

    public CharacterView(CharacterInfo charInfo)
    {
        this.charInfo = charInfo;
    }

    public void LoadModel()
    {
        charObj = GameLoader.Instance.LoadAssetSync("Resources/Prefabs/fly.prefab").GameObjectAsset;
        if (charObj.GetComponent<Animate>() != null)
        {
            charAnim = charObj.GetComponent<Animate>();
        }
        else
        {
            charAnim = charObj.AddComponent<Animate>();
        }
        charAnim.OnInit(AnimationCache.getInstance().getAnimation(charInfo.charName));
        charAnim.startAnimation();
    }

    public void DoAction(string actionName)
    {

    }


}
