using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    float m_movementSpeed = 5.0f;
    [SerializeField]
    private float m_rotationSpeed = 45.0f;
    [SerializeField]
    private float m_jumpforce = 300f;
    private bool keyLeft, keyRight, keyUp, keyDown, keySprint, keyRLeft, keyRRight, keySpace;
    private Transform m_transform;
    private bool m_jumping, m_dashing;
    private Rigidbody m_rBody;
    private AudioManager audioManager;
    [SerializeField]
    private float m_dashTimer;

    // Use this for initialization
    void Start()
    {
        m_transform = transform;
        m_rBody = GetComponent<Rigidbody>();
        audioManager = AudioManager.instance;
        m_dashTimer = 0;
        m_dashing = true;
    }

    // Update is called once per frame
    void Update()
    {
        m_movementSpeed = 5.0f;
        GetInput();
       
        if(m_dashTimer > 5)
        {
            m_dashing = true;
            m_dashTimer = 0;
        }
        if(m_dashing == false)
        {
            m_dashTimer += Time.deltaTime;
        }

    }

    private void GetInput()
    {
        //Move Left
        if (Input.GetKey(KeyCode.A))
        {
            keyLeft = true;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            keyLeft = false;
        }
        //Move Right
        if (Input.GetKey(KeyCode.D))
        {
            keyRight = true;

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            keyRight = false;
        }

        //Move Up

        if (Input.GetKey(KeyCode.W))
        {
            keyUp = true;

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            keyUp = false;
        }
        //Move Down
        if (Input.GetKey(KeyCode.S))
        {
            keyDown = true;

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            keyDown = false;
        }
        //Sprint
        if (Input.GetKey(KeyCode.LeftShift) && m_dashing)
        {
            m_dashing = false;
            m_movementSpeed = 300f;
            audioManager.PlaySound("Character_Dash");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            keySprint = false;
        }
        //Rotate Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            keyRLeft = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            keyRLeft = false;
        }
        //Rotate Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            keyRRight = true;

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            keyRRight = false;
        }
        //Jump
        if (Input.GetKey(KeyCode.Space))
        {
            keySpace = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            keySpace = false;
        }

    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {

        //Move Left
        if (keyLeft)
        {
            m_transform.Translate(new Vector3(1,0,0) * -m_movementSpeed * Time.deltaTime, Space.Self);
        }
        //Move Right
        if (keyRight)
        {
            m_transform.Translate(new Vector3(1, 0, 0) * m_movementSpeed * Time.deltaTime, Space.Self);
        }
        //Move Up
        if (keyUp)
        {
            m_transform.Translate(new Vector3(0, 0, 1) * m_movementSpeed * Time.deltaTime, Space.Self);
        }
        //Move Down
        if (keyDown)
        {
            m_transform.Translate(new Vector3(0, 0, 1) * -m_movementSpeed * Time.deltaTime, Space.Self);
        }     
        //Rotate Left
        if (keyRLeft)
        {
            m_transform.Rotate(m_transform.up * -m_rotationSpeed * Time.deltaTime);
        }
        //Rotate Right
        if (keyRRight)
        {
            m_transform.Rotate(m_transform.up * m_rotationSpeed * Time.deltaTime);
        }
        if(keySpace && m_jumping)
        {
            m_rBody.AddForce(new Vector3(0, 1, 0) * m_jumpforce);
            audioManager.PlaySound("Character_Jump");
            m_jumping = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == ("floor"))
        {
            m_jumping = true;
        }
    }
}
