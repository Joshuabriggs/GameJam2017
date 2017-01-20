using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {

    public float m_timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        m_timer += Time.deltaTime;
	
	}
}
