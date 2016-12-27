using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate: MonoBehaviour 
{
    private GameObject animObj;
	private MyAnimation anim;
	private Mesh mesh;
	private int FrameNum;
	private float delay;
	private MeshAnimation curAnimation;
	private string curActionName;
	private bool active;
	private float curTime;
	public void Start()
	{
	}

	public void OnInit(MyAnimation myanim)
	{
		anim = myanim;
		animObj = this.gameObject;
		curActionName = "normal";
		mesh = new Mesh();
		FrameNum = 0;
		curAnimation = anim.getMeshAnimation(curActionName);
		delay = curAnimation.delay;
		active = false;
		curTime = 0;
		animObj.GetComponent<MeshRenderer>().sharedMaterial = SpriteFrameCache.getInstance().getSpriteTexture(anim.pictName);
	}
	
	public void Update()
	{
		if (!active)
		{
			return;
		}
		if (curAnimation != null)
		{
			curTime += Time.deltaTime;
			if (curTime < delay)
			{
				return;
			}
			curTime = 0;
			if (FrameNum >= curAnimation.frameList.Count)
			{
				FrameNum = 0;
			}
			Mesh temp = GetMesh(curAnimation.frameList[FrameNum]);
			animObj.GetComponent<MeshFilter>().sharedMesh = temp;
			FrameNum++;
		}
	}

    public void startAnimation()
    {
        active = true;
    }
    public void stopAnimation()
    {
        active = false;
    }

    public void setTrigger(string actionName)
    {
        curActionName = actionName;
        curAnimation = anim.getMeshAnimation(curActionName);
        delay = curAnimation.delay;
    }
    public Mesh GetMesh(SpriteFrame frame)
    {
        mesh.vertices = frame.vertices;
        mesh.triangles = frame.triangles;
        mesh.uv = frame.uv;
        return mesh;
    }
}

