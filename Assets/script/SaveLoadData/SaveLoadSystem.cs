using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    public static SaveLoadSystem instance;

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
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        Debug.Log("Save data");
        GameData gameData = new GameData();
        gameData.CompletedLevel = HubManager.instance.Completedlevel;
        gameData.highestScore = HubManager.instance.highestScore;
        gameData.MusicVolume = AudioManager.instance.musicSource.volume;
        gameData.SFXVolume = AudioManager.instance.sfxSource.volume;

        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(Application.dataPath + "/GameARdata.json", json);
    }

    public void LoadData()
    {
        if(File.Exists(Application.dataPath + "/GameARdata.json"))
        {
            Debug.Log("Load file data successfully" + Application.dataPath + "/GameARdata.json");
            string json = File.ReadAllText(Application.dataPath + "/GameARdata.json");
            GameData gameData = JsonUtility.FromJson<GameData>(json);

            HubManager.instance.Completedlevel = gameData.CompletedLevel;
            HubManager.instance.highestScore = gameData.highestScore;
            AudioManager.instance.musicSource.volume = gameData.MusicVolume;
            AudioManager.instance.sfxSource.volume = gameData.SFXVolume;
        } 
        else
        {
            Debug.Log("Not found file data "+ Application.dataPath + "/GameARdata.json");
        }
    }
}
