using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene : MonoBehaviour
{
    bool isStarttingGame = false;
    float timeStart = 0f;
    public GameObject readyObject;
    public GameObject goObject;
    public GameObject gunLeft;
    public GameObject gunRight;
    public GameObject shootCenter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarttingGame)
        {
            if (timeStart > 4.0f)
            {
                if (goObject.activeInHierarchy == true)
                {
                    goObject.SetActive(false);
                    gunLeft.SetActive(true);
                    gunRight.SetActive(true);
                    shootCenter.SetActive(true);
                    SpawnManager.instance.isInFight = true;
                    SpawnManager.instance.createEnemies(HubManager.instance.currentlevel);
                }
            }
            else if(timeStart > 3.0f)
            {
                if (goObject.activeInHierarchy == false)
                    goObject.SetActive(true);
            }
            else if(timeStart > 2.5f)
            {
                if(readyObject.activeInHierarchy == true)
                    readyObject.SetActive(false);
            }
            else if(timeStart>0.5f)
            {
                if(readyObject.activeInHierarchy == false)
                    readyObject.SetActive(true);
            }

            timeStart += Time.deltaTime;
        }
        
    }

    public void StartGame()
    {
        Debug.Log("Start game");
        AudioManager.instance.PlayMusic("CombatMusic");
        isStarttingGame = true;
        timeStart = 0f;
    }

    public void ResumeGame(int level)
    {
        HubManager.instance.currentlevel = level;
        isStarttingGame = true;
        timeStart = 0f;
    }

    public void StartGameNextLevel()
    {
        Debug.Log("Start next level " + HubManager.instance.currentlevel);
        if (HubManager.instance.NextLevel())
        {
            isStarttingGame = true;
            timeStart = 0f;
        }
        else
        {
            ScreenManager.instance.GameWin();
        }
    }
}
