using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == ("floor"))
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }
}
