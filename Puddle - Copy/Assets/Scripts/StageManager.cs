using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {

    public float m_timer;
    public float m_otimer;
    public float m_round;
    [SerializeField]
    private float m_spawnrate;
    [SerializeField]
    private float m_waveSpawn = 10f;
    public GameObject m_O1;
    public GameObject m_wave;
    private AudioManager audioManager;

	// Use this for initialization
	void Start () {

        m_round = 1;
        m_otimer = 0;
        m_spawnrate = 5;
        InvokeRepeating("rateIncrease", 5, 5.0f);
        audioManager = AudioManager.instance;
        audioManager.PlaySound("Music_Drunken");
        audioManager.PlaySound("Enviroment_PuddleWaves");

    }
	
	// Update is called once per frame
	void Update () {

        m_timer += Time.deltaTime;
        m_otimer += Time.deltaTime;
        m_waveSpawn -= Time.deltaTime;

        if (m_timer > 30)
        {
            m_timer = 0;
            m_round++;
            m_spawnrate = 5; 
            m_otimer = 0;
        }

        if(m_otimer > m_spawnrate)
        {
            m_otimer = 0;
            Instantiate(m_O1, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
        }

        if(m_waveSpawn < 0)
        {
            Instantiate(m_wave, new Vector3(0, 0, 25), Quaternion.Euler(0,0,90));
            m_waveSpawn = 10;
        }



	
	}

    void rateIncrease()
    {
        m_spawnrate *= 0.9f-(m_round/40);
    }
}
