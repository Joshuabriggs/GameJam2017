using UnityEngine;
using System.Collections;

public class RockScript : MonoBehaviour {

    public GameObject m_splash;
    private Transform m_transform;

	// Use this for initialization
	void Start () {

        m_transform = transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(m_splash, m_transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
