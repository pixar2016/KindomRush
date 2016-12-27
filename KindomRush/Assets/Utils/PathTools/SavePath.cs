using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hero;

public class SavePath : MonoBehaviour {

    public List<GameObject> objs;
	// Use this for initialization
	void Start () {
        //foreach (Transform child in transform)
        //{
        //    Debug.Log(child.name);
        //}
        objs = new List<GameObject>();
        foreach (Transform child in transform)
        {
            objs.Add(child.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            objs.Add(CreateSheep(GetWorldPos(Input.mousePosition)));
        }
	}

    GameObject CreateSheep(Vector3 pos)
    {
        GameObject sheep = GameLoader.Instance.LoadAssetSync("Resources/Prefabs/littlesheep.prefab").GameObjectAsset;
        sheep.transform.position = pos;
        sheep.transform.parent = transform;
        return sheep;
    }

    //把Unity屏幕坐标换算成3D坐标
    Vector3 GetWorldPos(Vector2 screenPos)
    {
        Camera mainCamera = Camera.main;
        return mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Mathf.Abs(transform.position.z - mainCamera.transform.position.z)));
    }
}
