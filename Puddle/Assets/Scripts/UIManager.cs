using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField]
    GameObject[] UIElements;
    int currentState;
    bool first = false;

    void Start()
    {
        currentState = 0;
        Debug.Log("It begins");
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(currentState == 0)
        {
            UIElements[0].SetActive(true);
            UIElements[1].SetActive(true);
            UIElements[2].SetActive(true);
            UIElements[3].SetActive(false);
            UIElements[4].SetActive(false);
            UIElements[5].SetActive(false);
            UIElements[6].SetActive(false);
            UIElements[7].SetActive(false);
            UIElements[8].SetActive(false);
            UIElements[9].SetActive(false);
            UIElements[10].SetActive(false);
            UIElements[11].SetActive(false);
            UIElements[12].SetActive(false);
            if (!first)
            {
                GameObject.Find("Number (2)").GetComponent<Text>().text = "" + PlayerPrefs.GetInt("HighScore");
                Debug.Log(PlayerPrefs.GetInt("HighScore"));
                first = true;
            }

        }
        if (currentState == 1)
        {
            UIElements[0].SetActive(false);
            UIElements[1].SetActive(false);
            UIElements[2].SetActive(false);
            UIElements[3].SetActive(true);
            UIElements[4].SetActive(true);
            UIElements[5].SetActive(true);
            UIElements[6].SetActive(true);
            UIElements[7].SetActive(true);
            UIElements[8].SetActive(true);
            UIElements[9].SetActive(true);
            UIElements[10].SetActive(false);
            UIElements[11].SetActive(false);
            UIElements[12].SetActive(false);
           
        }
        if (currentState == 2)
        {
            UIElements[0].SetActive(false);
            UIElements[1].SetActive(false);
            UIElements[2].SetActive(false);
            UIElements[3].SetActive(false);
            UIElements[4].SetActive(false);
            UIElements[5].SetActive(false);
            UIElements[6].SetActive(false);
            UIElements[7].SetActive(false);
            UIElements[8].SetActive(false);
            UIElements[9].SetActive(false);
            UIElements[10].SetActive(true);
            UIElements[11].SetActive(true);
            UIElements[12].SetActive(true);
        }
    }
    public void ChangeState(int state)
    {
        currentState = state;
        Debug.Log(currentState);
    }
    public int GetState()
    {
        return currentState;
    }

}
