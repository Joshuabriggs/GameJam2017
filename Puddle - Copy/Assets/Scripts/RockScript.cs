﻿using UnityEngine;
using System.Collections;

public class RockScript : MonoBehaviour {

    public GameObject m_splash;
    private Transform m_transform;
    private AudioManager audioManager;

	// Use this for initialization
	void Start () {

        m_transform = transform;
        audioManager = AudioManager.instance;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(m_splash, m_transform.position - new Vector3(0, 0.5f, 0), Quaternion.identity);
        audioManager.PlayShotSound("Object_Drop");
        Destroy(gameObject);
    }
}
