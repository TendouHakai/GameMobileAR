using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour
{
    public static HubManager instance;
    public string GameName;
    public int currentlevel;
    public int Completedlevel;
    public int Maxlevel;
    public int highestScore;
    public int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool NextLevel()
    {
        if (currentlevel < Maxlevel)
        {
            currentlevel++;
            return true;
        }
        return false;
    }

    public void updateCompletedLevel()
    {
        if(Completedlevel < currentlevel+1) 
        {
            Completedlevel = currentlevel+1;
        }
    }

    public void updateHighestScore()
    {
        if(highestScore < score)
        {
            highestScore = score;
            SaveLoadSystem.instance.SendScore();
        }
    }
}
