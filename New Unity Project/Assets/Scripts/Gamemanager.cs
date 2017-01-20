using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Gamemanager : MonoBehaviour {

    [HideInInspector]
    public StageManager stManager;

	// Use this for initialization
	void Start () {
	
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static Gamemanager instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Gamemanager instance already exists");
        }
        instance = this;
    }
}
