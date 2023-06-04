using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    public static SaveLoadSystem instance;
    string path;

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
        path = Path.Combine(Application.persistentDataPath , "data.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        Debug.Log("Save data");
        GameData gameData = new GameData();
        gameData.name = HubManager.instance.GameName;
        gameData.CompletedLevel = HubManager.instance.Completedlevel;
        gameData.highestScore = HubManager.instance.highestScore;
        gameData.MusicVolume = AudioManager.instance.musicSource.volume;
        gameData.SFXVolume = AudioManager.instance.sfxSource.volume;

        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(path, json);
    }

    public bool LoadData()
    {
        Debug.Log(path);
        if (File.Exists(path))
        {
            Debug.Log("Load file data successfully" + path);
            string json = File.ReadAllText(path);
            GameData gameData = JsonUtility.FromJson<GameData>(json);

            HubManager.instance.GameName = gameData.name;   
            HubManager.instance.Completedlevel = gameData.CompletedLevel;
            HubManager.instance.highestScore = gameData.highestScore;
            AudioManager.instance.musicSource.volume = gameData.MusicVolume;
            AudioManager.instance.sfxSource.volume = gameData.SFXVolume;
            return true;
        } 
        else
        {
            Debug.Log("Not found file data "+ path);
            return false;
        }
    }

    public void SendScore()
    {
        HighScores.UploadScore(HubManager.instance.GameName, HubManager.instance.highestScore);
    }

    public void LoadPath()
    {
        path = Path.Combine(Application.persistentDataPath, "data.json");
    }
}
