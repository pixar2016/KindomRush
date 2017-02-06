using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using LitJson;
using Hero;
using CoreLib.Timer;
public class Test1 : MonoBehaviour {

    Animate animate;

    MonsterInfo charInfo;
    SoliderInfo soliderInfo;
    List<SoliderInfo> soliderList;

    CTimerSystem m_TimerSystem = null;
	// Use this for initialization
    void Awake()
    {
        GameLoader loader = GameObject.Find("GameLoader").GetComponent<GameLoader>();
        loader.Initialize();
    }
	void Start () {
        EntityManager.getInstance();
        EntityViewManager.getInstance();
        
        DataPreLoader.getInstance().LoadData("Monsters");

		SpriteFrameCache.getInstance().addSpriteFrameFromFile("Resources/Config/monster1.txt");
        AnimationCache animCache = AnimationCache.getInstance();
        //第一个参数 createAnimation（参数1-图片名字 参数2-图片开始序号 参数3-图片结束序号 参数4-动画间隔 参数5-是否循环）
        //第二个参数 动画名称
        //第三个参数 动作名称
        animCache.addAnimation(animCache.createAnimation("wulf_", 19, 19, 0.1f, true), "wulf", "idle");
        animCache.addAnimation(animCache.createAnimation("wulf_", 1, 8, 0.1f, true), "wulf", "run1");
        animCache.addAnimation(animCache.createAnimation("wulf_", 9, 18, 0.1f, true), "wulf", "run2");
        animCache.addAnimation(animCache.createAnimation("wulf_", 19, 28, 0.1f, false), "wulf", "attack");
        animCache.addAnimation(animCache.createAnimation("wulf_", 29, 35, 0.1f, false), "wulf", "stuck_start");
        animCache.addAnimation(animCache.createAnimation("wulf_", 35, 40, 0.1f, false), "wulf", "stuck_end");
        animCache.addAnimation(animCache.createAnimation("wulf_", 41, 49, 0.1f, false), "wulf", "die");

        animCache.addAnimation(animCache.createAnimation("knight_", 1, 1, 0.1f, true), "knight", "idle");
        animCache.addAnimation(animCache.createAnimation("knight_", 2, 6, 0.1f, true), "knight", "run1");
        animCache.addAnimation(animCache.createAnimation("knight_", 7, 10, 0.1f, true), "knight", "attack");
        animCache.addAnimation(animCache.createAnimation("knight_", 11, 15, 0.1f, true), "knight", "attack1");
        animCache.addAnimation(animCache.createAnimation("knight_", 16, 33, 0.1f, true), "knight", "skill1");
        animCache.addAnimation(animCache.createAnimation("knight_", 34, 62, 0.1f, true), "knight", "skill2");
        animCache.addAnimation(animCache.createAnimation("knight_", 63, 69, 0.1f, true), "knight", "die");

        J_Monsters.LoadConfig();
        J_SkillEvent.LoadConfig();
        J_Skill.LoadConfig();

        charInfo = EntityManager.getInstance().AddMonster(1);
        charInfo.ChangeState("move");
        //charInfo.SetPosition(-5, 3, 0);

        //soliderInfo = EntityManager.getInstance().AddSolider(1);
        //soliderInfo.DoAction("run1");
        //soliderList = EntityManager.getInstance().GetSoliderInfo();
        //StartAI();
        
    }

    public void StartAI()
    {
        Debug.Log("StartAI");
        if (null == m_TimerSystem)
        {
            m_TimerSystem = new CTimerSystem();
            m_TimerSystem.Create();

        }
        m_TimerSystem.CreateTimer(1, 1000, UpdateMonsterAI);
    }

    public void UpdateMonsterAI(uint nTimeID)
    {
        Debug.Log("UpdateMonsterAI");
        foreach (SoliderInfo solider in soliderList)
        {
            if (!solider.IsDead())
            {
                solider.RunAI();
            }
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            charInfo.DoAction("stuck_start");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            charInfo.DoAction("stuck_end");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            charInfo.ChangeState("attack");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            charInfo.ChangeState("move");
        }
        EntityManager.getInstance().Update();
        EntityViewManager.getInstance().Update();
        TriggerManager.getInstance().Update(Time.deltaTime);
        if (null != m_TimerSystem)
        {
            m_TimerSystem.UpdateTimer();
        }
//        animate.OnUpdate(Time.deltaTime);
	}
}
