using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup audioMixerGroup;

    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 0.5f)]
    public float VolumeVarience;

    [Range(0.5f, 1.5f)]
    public float pitch;
    [Range(0f, 0.5f)]
    public float PitchVarience;

    public bool loop = false;

    private AudioSource source = null;
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
        source.outputAudioMixerGroup = audioMixerGroup;
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-VolumeVarience / 2f, VolumeVarience /2f));
        source.pitch = pitch * (1 + Random.Range(-PitchVarience / 2f, PitchVarience / 2f));
        source.Play();
    }
    public void PlayOneShotSound()
    {
        source.volume = volume * (1 + Random.Range(-VolumeVarience / 2f, VolumeVarience / 2f));
        source.pitch = pitch * (1 + Random.Range(-PitchVarience / 2f, PitchVarience / 2f));
        source.PlayOneShot(source.clip, source.volume);
    }
    public void Stop()
    {
        source.Stop();
    }
}

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    public AudioMixer masterMixer;

    void Awake()
    {
        if(instance != null)
        {
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        for(int i = 0; i <sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + " " + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }
    public void PlaySound (string _name)
    {
        for(int i = 0; i <sounds.Length; i++)
        {
            if(sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        Debug.LogWarning("AudioManager: Sound not found in list = " + _name);
    }
    public void PlayShotSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].PlayOneShotSound();
                return;
            }
        }
        Debug.LogWarning("AudioManager: Sound not found in list = " + _name);
    }
    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                return;
            }
        }
        Debug.LogWarning("AudioManager: Sound not found in list = " + _name);
    }
    public void SetVolume(float _volume, string _mixerGroup)
    {
        masterMixer.SetFloat(_mixerGroup, _volume);
    }
}
