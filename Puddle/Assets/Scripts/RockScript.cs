using UnityEngine;
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
        Instantiate(m_splash, m_transform.position, Quaternion.identity);
        audioManager.PlayShotSound("Character_Dash");
        Destroy(gameObject);
    }
}
