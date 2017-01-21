using UnityEngine;
using System.Collections;

public class RockScript : MonoBehaviour {

    public GameObject m_splash;
    private Transform m_transform;
    private AudioManager audioManager;
    private GameObject m_splashtypeFeeder;
    private int m_type;
    private Rigidbody m_rBody;

	// Use this for initialization
	void Start () {

        m_transform = transform;
        audioManager = AudioManager.instance;
        m_rBody = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if(gameObject.tag == ("type1"))
        {
            m_type = 1;
        }
        if (gameObject.tag == ("type2"))
        {
            m_type = 2;
        }
        if (gameObject.tag == ("type3"))
        {
            m_type = 3;
        }
        if (gameObject.tag == ("type4"))
        {
            m_type = 4;
        }
        if (gameObject.tag == ("type5"))
        {
            m_type = 5;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wave")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        else
        {

         
            if (m_type == 2)
            {
                m_rBody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                m_splashtypeFeeder = Instantiate(m_splash, m_transform.position - new Vector3(0, 0.5f, 0), Quaternion.identity);
                m_splashtypeFeeder.GetComponent<Testwave>().m_splashType = m_type;
                audioManager.PlayShotSound("Object_Drop");
                Destroy(GetComponent<RockScript>());
            }
            else
            {
                m_splashtypeFeeder = Instantiate(m_splash, m_transform.position - new Vector3(0, 0.5f, 0), Quaternion.identity);
                m_splashtypeFeeder.GetComponent<Testwave>().m_splashType = m_type;
                audioManager.PlayShotSound("Object_Drop");
                Destroy(gameObject);
            }
        }
    }
}
