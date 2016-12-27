using UnityEngine;
using System.Collections;

public class testFinger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnEnable()
    {
        Debug.Log("OnEnable");
        FingerGestures.OnFingerDown += OnFingerDown;
    }

    void OnDisable()
    {
        FingerGestures.OnFingerDown -= OnFingerDown;
    }
    void OnFingerDown(int fingerIndex, Vector2 fingerPos)
    {
        Debug.Log("OnFingerDown = ");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
