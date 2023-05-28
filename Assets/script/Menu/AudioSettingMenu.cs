using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingMenu : MonoBehaviour
{
    [SerializeField] Slider MusicSlider, SFXSlider;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            MusicSlider.value = AudioManager.instance.musicSource.volume;
            SFXSlider.value = AudioManager.instance.sfxSource.volume;
            Debug.Log("Load audio settings sucessfully");
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume()
    {
        AudioManager.instance.SetMusicVolume(MusicSlider.value);
    }

    public void SetSFXVolume()
    {
        AudioManager.instance.SetSFXVolume(SFXSlider.value);
    }

    public void SaveAudioSetttingData()
    {
        SaveLoadSystem.instance.SaveData();
    }
}
