using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    float m_movementSpeed = 5.0f;
    [SerializeField]
    private float m_rotationSpeed = 5.0f;
    private bool keyLeft, keyRight, keyUp, keyDown, keySprint, keyRLeft, keyRRight;
    private Transform m_transform;

    // Use this for initialization
    void Start()
    {
        m_transform = transform;
    }

    // Update is called once per frame
    void Update()
    {

        GetInput();

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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            keySprint = true;
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
            m_transform.Translate(m_transform.right * -m_movementSpeed * Time.deltaTime);
        }
        //Move Right
        if (keyRight)
        {
            m_transform.Translate(m_transform.right * m_movementSpeed * Time.deltaTime);
        }
        //Move Up
        if (keyUp)
        {
            m_transform.Translate(m_transform.forward * m_movementSpeed * Time.deltaTime);
        }
        //Move Down
        if (keyDown)
        {
            m_transform.Translate(m_transform.forward * -m_movementSpeed * Time.deltaTime);
        }
        //Sprint
        if (keySprint)
        {
            m_movementSpeed = 10f;
        }
        if (!keySprint)
        {
            m_movementSpeed = 5f;
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
    }
}
