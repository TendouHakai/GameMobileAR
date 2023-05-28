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
        if(HubManager.instance.currentlevel != HubManager.instance.Maxlevel)
        {
            StartGame();
        }
        else
        {
            ScreenManager.instance.GameWin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarttingGame)
        {
            if (timeStart > 4.0f)
            {
                if (goObject.active == true)
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
                if (goObject.active == false)
                    goObject.SetActive(true);
            }
            else if(timeStart > 2.5f)
            {
                if(readyObject.active == true)
                    readyObject.SetActive(false);
            }
            else if(timeStart>0.5f)
            {
                if(readyObject.active == false)
                    readyObject.SetActive(true);
            }

            timeStart += Time.deltaTime;
        }
        
    }

    public void StartGame()
    {
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
