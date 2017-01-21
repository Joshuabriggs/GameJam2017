using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowingWave : MonoBehaviour {

    [SerializeField]
    private float m_speed = 5.0f;
    private Transform m_transform;

	// Use this for initialization
	void Start () {

        m_transform = transform;

	}
	
	// Update is called once per frame
	void Update () {

        m_transform.Translate(new Vector3(0, 0, -1) * m_speed * Time.deltaTime);

        if(m_transform.position.z < -25)
        {
            Destroy(gameObject);
        }
	}
}
