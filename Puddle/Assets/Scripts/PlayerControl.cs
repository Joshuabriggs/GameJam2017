﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    [SerializeField]
    private float m_floatPower = 5f;
    private GameObject m_rthrust, m_lthrust, m_fthrust, m_bthrust;
    [SerializeField]
    private ParticleSystem m_dashEffect;
    [SerializeField]
    private Sprite m_stand;
    [SerializeField]
    private Sprite m_leanLeft;
    [SerializeField]
    private Sprite m_leanRight;
    private SpriteRenderer m_fairy;
    [SerializeField]
    private Animator m_flutter;

    UIManager UI;

    // Use this for initialization
    void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        m_transform = transform;
        m_rBody = GetComponent<Rigidbody>();
        audioManager = AudioManager.instance;
        m_dashTimer = 5;
        m_dashing = true;
        m_rthrust = GameObject.Find("RightThrust");
        m_lthrust = GameObject.Find("LeftThrust");
        m_fthrust = GameObject.Find("ForwardThrust");
        m_bthrust = GameObject.Find("BackThrust");
        m_dashEffect = GetComponent<ParticleSystem>();
        m_fairy = GetComponentInChildren<SpriteRenderer>();
        m_flutter = GetComponentInChildren<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        m_movementSpeed = 5.0f;
        m_flutter.SetInteger("State", 0);
        GetInput();
        if (UI.GetState() == 2)
        {
            GameObject.Find("Dash Slider").GetComponent<Slider>().value = m_dashTimer;
        }
        
        if (m_dashTimer > 5)
        {
            m_dashing = true;
            
        }
        if (m_dashing == false)
        {
            m_dashTimer += Time.deltaTime;
            if (m_dashTimer < 1)
            {
                m_transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 15, Space.Self);
                m_flutter.SetInteger("State", 3);
            }
            
        }

        if(m_jumping == false)
        {
            m_floatPower = 1.5f;
        }
        else
        {
            m_floatPower = 4.5f;
        }
        m_rBody.AddForce(new Vector3(0, 1, 0));

    }

    private void GetInput()
    {
        //Move Left
        if (Input.GetKey(KeyCode.A))
        {
            keyLeft = true;
            m_flutter.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            keyLeft = false;
            m_flutter.SetInteger("State", 0);
        }
        //Move Right
        if (Input.GetKey(KeyCode.D))
        {
            keyRight = true;
            m_flutter.SetInteger("State", 1);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            keyRight = false;
            m_flutter.SetInteger("State", 0);

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
            m_dashTimer = 0;
            m_dashing = false;
            audioManager.PlaySound("Character_Dash");
            m_dashEffect.Play();
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
        if (keyRight)
        {
            m_transform.Translate(new Vector3(1,0,0) * -m_movementSpeed * Time.deltaTime, Space.Self);
            m_rBody.AddForceAtPosition(m_transform.up * m_floatPower, m_lthrust.transform.position);
        }
        //Move Right
        if (keyLeft)
        {
            m_transform.Translate(new Vector3(1, 0, 0) * m_movementSpeed * Time.deltaTime, Space.Self);
            m_rBody.AddForceAtPosition(m_transform.up * m_floatPower, m_rthrust.transform.position);
        }
        //Move Up
        if (keyUp)
        {
            m_transform.Translate(new Vector3(0, 0, 1) * m_movementSpeed * Time.deltaTime, Space.Self);
            m_rBody.AddForceAtPosition(m_transform.up * m_floatPower, m_fthrust.transform.position);
        }
        //Move Down
        if (keyDown)
        {
            m_transform.Translate(new Vector3(0, 0, 1) * -m_movementSpeed * Time.deltaTime, Space.Self);
            m_rBody.AddForceAtPosition(m_transform.up * m_floatPower, m_bthrust.transform.position);
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
        if(col.gameObject.tag == ("Score"))
        {
            Gamemanager.instance.stManager.addScore();
            Destroy(col.gameObject);
        }
    }
}
