using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using LitJson;
using Hero;
public class Test1 : MonoBehaviour {

    Animate animate;
	// Use this for initialization
    void Awake()
    {
        GameLoader loader = GameObject.Find("GameLoader").GetComponent<GameLoader>();
        loader.Initialize();
    }
	void Start () {

        
        DataPreLoader.getInstance().LoadData("Monsters");

		SpriteFrameCache.getInstance().addSpriteFrameFromFile("Resources/Config/SavageBird.txt");
        AnimationCache animCache = AnimationCache.getInstance();
        animCache.addAnimation(animCache.createAnimation("SavageBird ", 1, 11, 0.1f), "drop", "normal");

        //EntityManager.getInstance().AddCreature(1);
        J_Monsters.LoadConfig();
    }
	
	// Update is called once per frame
	void Update () {
//        animate.OnUpdate(Time.deltaTime);
	}
}
