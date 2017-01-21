using UnityEngine;
using System.Collections;

public class Testwave : MonoBehaviour {

    private Transform m_transform;
    public float m_speed = 3;
    public float m_moveSpeed = 0.005f;
    private GameObject m_floor;
  
	// Use this for initialization
	void Start () {

        m_floor = GameObject.FindGameObjectWithTag("floor");
        m_transform = transform;
        Physics.IgnoreCollision(m_floor.GetComponent<Collider>(), GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {

        m_transform.Translate(new Vector3(0, -1, 0) * m_moveSpeed);
       
        if(m_transform.localScale.y < 0)
        {

            GetComponent<Collider>().enabled = false;
        }
        else
        {
            m_transform.localScale += new Vector3(m_speed * 2, -m_speed, m_speed * 2);
        }
        
        if(m_transform.position.y < -10)
        {
           Destroy(gameObject);
        }

    }
}
