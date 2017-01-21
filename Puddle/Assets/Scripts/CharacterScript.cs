using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    AudioManager audiomanager;
    UIManager UI;
    // Use this for initialization
    void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        audiomanager = AudioManager.instance;
        if(audiomanager == null)
        {
            Debug.LogError("CharacterScript: AudioManager = null");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == ("floor"))
        {
            audiomanager.StopSound("Enviroment_PuddleWaves");
            audiomanager.StopSound("Music_Drunken");
            UI.ChangeState(0);
            Gamemanager.instance.stManager.BacktoMenu();
            Destroy(gameObject);
        }
    }
}
