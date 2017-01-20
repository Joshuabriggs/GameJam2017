using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    bool playingMenu = false;
    private AudioManager audioManager;
	// Use this for initialization
	void Start () {
        audioManager = AudioManager.instance;
        if(audioManager == null)
        {
            Debug.LogError("No AudiomManager found");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!playingMenu)
        {
            audioManager.PlaySound("Music_Menu");
            audioManager.PlaySound("Enviroment_HeavyRain");
            playingMenu = true;
        }
    }
}
