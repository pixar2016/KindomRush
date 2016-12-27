using System;
using System.Collections.Generic;
using UnityEngine;

//主要是组成单独的动画，将spriteFrameCache中缓存的相关的帧放到一起
public class MeshAnimation
{
    public List<SpriteFrame> frameList;
    //动作名，若没有，则为空
    public string actionName;
    public float delay;
    public bool active;
    //动画帧所属图片
    public string texture;
    public MeshAnimation()
    {
        frameList = new List<SpriteFrame>();
    }
    //创建MeshAnimation
    public void createWithSpriteFrames(List<SpriteFrame> animFrames, float delays)
    {
        delay = delays;
        if (animFrames.Count > 0)
        {
            texture = animFrames[0].textureName;
        }
        foreach (SpriteFrame frame in animFrames)
        {
            frameList.Add(frame);
        }
    }
}

