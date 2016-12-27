//-----------------------------------------------------
//这段代码是工具生成，不要轻易修改！！！
//-----------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class D_Monsters
{
	public int _id;
	public string _name;
	public int _attackSpeed;
	public int _attackValue;
	public int _attackRange;
	public string _description;

}
public class J_Monsters
{
    private static Dictionary<int, D_Monsters> infoDict = new Dictionary<int, D_Monsters>();
    private static string tableName = "";
    public static void LoadConfig()
    {
        if (infoDict.Count > 0)
        {
            return;
        }
        tableName = "Monsters";
        string infos = FileUtils.LoadFile(Application.dataPath, "Data/Json/Monsters.json");
		Init(infos);
    }

    private static void Init(string _info)
    {
        List<object> jsonObjects = MiniJSON.Json.Deserialize(_info) as List<object>;
        for (int i = 0; i < jsonObjects.Count; i++)
        {
            D_Monsters info = new D_Monsters();
			Dictionary<string, object> jsonObject = jsonObjects[i] as Dictionary<string, object>;
			
			info._id = int.Parse(jsonObject["id"].ToString());
			info._name = jsonObject["name"].ToString();
			info._attackSpeed = int.Parse(jsonObject["attackSpeed"].ToString());
			info._attackValue = int.Parse(jsonObject["attackValue"].ToString());
			info._attackRange = int.Parse(jsonObject["attackRange"].ToString());
			info._description = jsonObject["description"].ToString();

            infoDict.Add(info._id, info);
        }
        /*
        foreach (KeyValuePair<int, D_Monsters> info in infoDict)
        {
            Debug.Log(">>>>>"+info.Value._id+":"+info.Value._name+":"+info.Value._desc+":"+info.Value._point+":"+info.Value._label+":"+info.Value._type+":"+info.Value._number+":"+info.Value._function+":"+info.Value._para+":"+info.Value._reward+":"+"<<<<<\n");
        }
        */
    }

    /// <summary>
    /// 通过key获取数据
    /// </summary>
    /// <param name="_id">字典key</param>
    /// <returns></returns>
    public static D_Monsters GetData(int _id)
    {
        D_Monsters data = null;
        if (infoDict.ContainsKey(_id))
        {
            data = infoDict[_id];
        }
        else
        {
            Debug.Log(">>>>>table:" + tableName+" id:"+_id+" is null<<<<<\n");
        }
        return data;
    }
    /// <summary>
    /// 获取字典长度
    /// </summary>
    /// <returns></returns>
    public static int GetCount()
    {
        return infoDict.Count;
    }
    /// <summary>
    /// 把字典转换成List
    /// </summary>
    /// <returns></returns>
    public static List<D_Monsters> ToList()
    {
        List<D_Monsters> list =  new List<D_Monsters>();
        foreach (KeyValuePair<int,D_Monsters> info in infoDict)
        {
            list.Add(info.Value);
        }
        return list;
    }

}
