using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour {

    bool menuMusic = false;

    private AudioManager audiomanager;
	// Use this for initialization
	void Start () {
        audiomanager = AudioManager.instance;
        if(audiomanager == null)
        {
            Debug.LogError("Menu Manager: No AudioManager Detected.");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!menuMusic)
        {
            audiomanager.PlaySound("Music_Menu");
            audiomanager.PlaySound("Enviroment_HeavyRain");
            menuMusic = true;
        }
	}
    public void StartClicked()
    {
        audiomanager.PlayShotSound("Character_Jump");
        audiomanager.StopSound("Music_Menu");
        SceneManager.LoadScene("Test scene");
    }
    public void SettingsClicked()
    {
        audiomanager.PlayShotSound("Character_Jump");
    }
    public void QuiteClicked()
    {
        audiomanager.PlayShotSound("Character_Jump");
        Application.Quit();
    }

    public void SetMaster(float masterVolume)
    {
        audiomanager.masterMixer.SetFloat("MasterVol", masterVolume);
    }
    public void SetMusic(float musicVolume)
    {
        audiomanager.masterMixer.SetFloat("MusicVol", musicVolume);
    }
    public void SetEffect(float EffectVolume)
    {
        audiomanager.masterMixer.SetFloat("EffectVol", EffectVolume);
    }
}
