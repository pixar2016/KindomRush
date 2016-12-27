using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

public class PathTools : EditorWindow
{
    /// <summary>
    /// 编辑器窗口实例
    /// </summary>
    private static PathTools instance;

    private static Vector2 scrollPos;

    private static List<GameObject> objs;

    [MenuItem("Plugins/PathGenerate")]
    static void ShowPathTools()
    {
        Init();
    }
    private static void Init()
    {
        instance = EditorWindow.GetWindow<PathTools>();
        objs = new List<GameObject>();
        //GameObject[] temp = GameObject.FindGameObjectsWithTag("path");
        //foreach (GameObject obj in temp)
        //{
        //    objs.Add(obj);
        //}
    }
    void OnGUI()
    {
        DrawOptions();
        DrawExport();
    }

    private void DrawOptions()
    {
        if (objs == null) return;
        EditorGUILayout.LabelField("现有的路径为：");
        if (objs.Count < 1)
        {
            EditorGUILayout.LabelField("目前没有路径被选中哦!");
        }
        GUILayout.BeginVertical();
        scrollPos = GUILayout.BeginScrollView(scrollPos, false, true, GUILayout.Height(150));
        foreach (GameObject obj in objs)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(true, obj.name);
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView();
        GUILayout.EndVertical();
    }
    private void DrawExport()
    {
        if (GUILayout.Button("转换路径为json"))
        {
            Convert();
        }
    }

    private void Convert()
    {
        if (objs == null)
            return;
        //List<object> table = new List<object>();
        List<List<Dictionary<string, float>>> table = new List<List<Dictionary<string, float>>>();
        foreach (GameObject obj in objs)
        {
            if (obj.GetComponent<SavePath>() == null)
            {
                continue;
            }
            SavePath path = obj.GetComponent<SavePath>();
            //List<object> singlePath = new List<object>();
            List<Dictionary<string, float>> singlePath = new List<Dictionary<string, float>>();
            foreach (GameObject point in path.objs)
            {
                Dictionary<string, float> pathPoint = new Dictionary<string, float>();
                Vector3 pos = point.transform.position;
                pathPoint.Add("x", pos.x);
                pathPoint.Add("y", pos.y);
                Debug.Log("x = " + pos.x + ", y = " + pos.y);
                singlePath.Add(pathPoint);
            }
            Debug.Log(singlePath.Count);
            table.Add(singlePath);
            Debug.Log(table.Count);
        }

        //生成Json字符串
        string json = JsonConvert.SerializeObject(table, Newtonsoft.Json.Formatting.Indented);
        Debug.Log(json);
        //string JsonPath = "D:/KindomRush/KindomRush/Assets/Data/Json/test.json";
        FileUtils.SaveFile(Application.dataPath, "Data/Json/test.json", json);
        //using (FileStream fileStream = new FileStream(JsonPath, FileMode.Create, FileAccess.Write))
        //{
        //    using (TextWriter textWriter = new StreamWriter(fileStream, Encoding.GetEncoding("utf-8")))
        //    {
        //        textWriter.Write(json);
        //    }
        //}
    }

    void OnSelectionChange()
    {
        Show();
        LoadPath();
        Repaint();
    }
    void LoadPath()
    {
        if (objs == null)
            objs = new List<GameObject>();
        objs.Clear();
        object[] selection = (object[])Selection.objects;
        if (selection.Length == 0)
        {
            return;
        }
        foreach (object obj in selection)
        {
            if (obj.GetType() == typeof(UnityEngine.GameObject))
            {
                objs.Add((GameObject)obj);
            }
        }
    }
}
