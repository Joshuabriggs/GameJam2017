using UnityEngine;
using System.Collections;

public class Testwave : MonoBehaviour {

    private Transform m_transform;
    public float m_speed = 3;
    public float m_moveSpeed = 0.005f;
    public int m_splashType;
    private GameObject m_floor;
  
	// Use this for initialization
	void Start () {

        m_floor = GameObject.FindGameObjectWithTag("floor");
        m_transform = transform;
        Physics.IgnoreCollision(m_floor.GetComponent<Collider>(), GetComponent<Collider>());
        if(m_splashType == 2 || m_splashType == 4)
        {
            m_transform.localScale *= 1.2f;
        }
        
	}
	
	// Update is called once per frame
	void Update () {

        switch(m_splashType)
        {
            case 1:
                m_transform.Translate(new Vector3(0, -1, 0) * m_moveSpeed);

                if (m_transform.localScale.y < 0)
                {

                    GetComponent<Collider>().enabled = false;
                }
                else
                {
                    m_transform.localScale += new Vector3(m_speed * 2, -m_speed, m_speed * 2);
                }

                if (m_transform.position.y < -10)
                {
                    Destroy(gameObject);
                }

                break;
            case 2:
                m_transform.Translate(new Vector3(0, -2, 0) * m_moveSpeed);

                if (m_transform.localScale.y < 0)
                {

                    GetComponent<Collider>().enabled = false;
                }
                else
                {
                    m_transform.localScale += new Vector3(m_speed * 2, -m_speed, m_speed * 2);
                }

                if (m_transform.position.y < -10)
                {
                    Destroy(gameObject);
                }

                break;
    
            case 3:
                m_transform.Translate(new Vector3(0, -1, 0) * m_moveSpeed);

                if (m_transform.localScale.y < 0)
                {

                    GetComponent<Collider>().enabled = false;
                }
                else
                {
                    m_transform.localScale += new Vector3(m_speed * 2, -m_speed, m_speed * 2);
                }

                if (m_transform.position.y < -10)
                {
                    Destroy(gameObject);
                }

                break;
            case 4:
                m_transform.Translate(new Vector3(0, -2, 0) * m_moveSpeed);

                if (m_transform.localScale.y < 0)
                {

                    GetComponent<Collider>().enabled = false;
                }
                else
                {
                    m_transform.localScale += new Vector3(m_speed * 2, -m_speed, m_speed * 2);
                }

                if (m_transform.position.y < -10)
                {
                    Destroy(gameObject);
                }

                break;
            case 5:
                m_transform.Translate(new Vector3(0, -1, 0) * m_moveSpeed);

                if (m_transform.localScale.y < 0)
                {

                    GetComponent<Collider>().enabled = false;
                }
                else
                {
                    m_transform.localScale += new Vector3(m_speed * 2, -m_speed, m_speed * 2);
                }

                if (m_transform.position.y < -10)
                {
                    Destroy(gameObject);
                }

                break;
        }


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "wave")
        {
            Physics.IgnoreCollision(col.collider, GetComponent<Collider>());
        }
    }
}
