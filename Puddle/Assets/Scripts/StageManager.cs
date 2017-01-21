using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{

    public float m_timer;
    public float m_otimer;
    public float m_round;
    [SerializeField]
    private float m_spawnrate;
    [SerializeField]
    private float m_waveSpawn = 10f;
    public GameObject m_O1;
    public GameObject m_O2;
    public GameObject m_O3;
    public GameObject m_O4;
    public GameObject m_O5;
    public GameObject m_wave;
    [SerializeField]
    float m_waveHeight;
    public GameObject m_scorePoint;
    private AudioManager audioManager;
    private int m_spawnChoice;
    [SerializeField]
    private int m_rockCount;
    private GameObject[] m_rocks;
    
    public int m_score;
    public int m_highScore;
    UIManager UI;
    // Use this for initialization
    void Start()
    {
        m_highScore = PlayerPrefs.GetInt("HighScore");
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        m_score = 0;
        m_round = 1;
        m_otimer = 0;
        m_spawnrate = 5;
        m_rockCount = 0;
        InvokeRepeating("rateIncrease", 5, 5.0f);
        InvokeRepeating("scoreTick", 0, 1.0f);
        InvokeRepeating("scoreSpawn", 0, 10.0f);
        audioManager = AudioManager.instance;
        audioManager.PlaySound("Music_Drunken");
        audioManager.PlaySound("Enviroment_PuddleWaves");

    }

    // Update is called once per frame
    void Update()
    {

        m_timer += Time.deltaTime;
        m_otimer += Time.deltaTime;
        m_waveSpawn -= Time.deltaTime;

        if(UI.GetState() == 2){
            GameObject.Find("Number").GetComponent<Text>().text = ""+m_score;
            GameObject.Find("wavenumber").GetComponent<Text>().text = "" + m_round;
        }
        GameObject.Find("Number (2)").GetComponent<Text>().text = "" + m_highScore;
        if(m_score > m_highScore)
        {
            m_highScore = m_score;
            PlayerPrefs.SetInt("HighScore", m_highScore);
        }

        if (m_timer > 30)
        {
            m_timer = 0;
            m_round++;
            m_spawnrate = 5;
            m_otimer = 0;
            m_rocks = GameObject.FindGameObjectsWithTag("type2");
            for(int i = 0; i < m_rocks.Length; i ++)
            {
                Destroy(m_rocks[i]);
            }
           
        }

        if (m_round < 3)
        {
            if (m_otimer > m_spawnrate)
            {
                m_otimer = 0;
                Instantiate(m_O1, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
            }
        }

        if (m_round < 5 && m_round >= 3)
        {
            m_spawnChoice = Random.Range(1, 2);

            switch (m_spawnChoice)
            {
                case 1:
                    if (m_otimer > m_spawnrate)
                    {
                        m_otimer = 0;
                        Instantiate(m_O1, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                    }
                    break;
                case 2:
                    if (m_otimer > m_spawnrate)
                    {
                        if (m_rockCount < 4)
                        {
                            m_otimer = 0;
                            Instantiate(m_O2, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                            m_rockCount++;
                        }
                        else
                        {
                            Instantiate(m_O1, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                        }
                    }
                    break;
            }

        }

        if (m_round < 7 && m_round >= 5)
        {
            m_spawnChoice = Random.Range(1, 3);

            switch (m_spawnChoice)
            {
                case 1:
                    if (m_otimer > m_spawnrate)
                    {
                        m_otimer = 0;
                        Instantiate(m_O1, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                    }
                    break;
                case 2:
                    if (m_otimer > m_spawnrate)
                    {
                        if (m_rockCount < 4)
                        {
                            m_otimer = 0;
                            Instantiate(m_O2, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                            m_rockCount++;
                        }
                        else
                        {
                            Instantiate(m_O1, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                        }
                    }
                    break;
                case 3:
                    if (m_otimer > m_spawnrate)
                    {
                        m_otimer = 0;
                        Instantiate(m_O3, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                    }
                    break;
            }

        }
        if (m_round < 9 && m_round >= 7)
        {
            m_spawnChoice = Random.Range(1, 4);

            switch (m_spawnChoice)
            {
                case 1:
                    if (m_otimer > m_spawnrate)
                    {
                        m_otimer = 0;
                        Instantiate(m_O1, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                    }
                    break;
                case 2:
                    if (m_otimer > m_spawnrate)
                    {
                        if (m_rockCount < 4)
                        {
                            m_otimer = 0;
                            Instantiate(m_O2, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                            m_rockCount++;
                        }
                        else
                        {
                            Instantiate(m_O1, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                        }
                    }
                    break;
                case 3:
                    if (m_otimer > m_spawnrate)
                    {
                        m_otimer = 0;
                        Instantiate(m_O3, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                    }
                    break;
                case 4:
                    if (m_otimer > m_spawnrate)
                    {
                        m_otimer = 0;
                        Instantiate(m_O4, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                    }
                    break;
            }

        }
        if (m_round >= 9)
        {
            m_spawnChoice = Random.Range(1, 4);
            switch (m_spawnChoice)
            {
                case 1:
                    if (m_otimer > m_spawnrate)
                    {
                        m_otimer = 0;
                        Instantiate(m_O1, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                    }
                    break;
                case 2:
                    if (m_otimer > m_spawnrate)
                    {
                        if (m_rockCount < 4)
                        {
                            m_otimer = 0;
                            Instantiate(m_O2, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                            m_rockCount++;
                        }
                        else
                        {
                            Instantiate(m_O1, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                        }
                    }
                    break;
                case 3:
                    if (m_otimer > m_spawnrate)
                    {
                        m_otimer = 0;
                        Instantiate(m_O3, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                    }
                    break;
                case 4:
                    if (m_otimer > m_spawnrate)
                    {
                        m_otimer = 0;
                        Instantiate(m_O4, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                    }
                    break;
                case 5:
                    if (m_otimer > m_spawnrate)
                    {
                        m_otimer = 0;
                        Instantiate(m_O5, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                    }
                    break;
            }
        }

        if (m_waveSpawn < 0)
        {
            Instantiate(m_wave, new Vector3(0, m_waveHeight, 25), Quaternion.Euler(0, 0, 90));
            m_waveSpawn = 10;
        }
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }

    void rateIncrease()
    {
        m_spawnrate *= 0.85f - (m_round / 40);   
    }
    void scoreTick()
    {
        m_score += 1;
    }
    void scoreSpawn()
    {
        Destroy(GameObject.FindGameObjectWithTag("Score"));
        Instantiate(m_scorePoint, new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20)), Quaternion.identity);
    }
    public void addScore()
    {
        m_score += 15;
    }
}
