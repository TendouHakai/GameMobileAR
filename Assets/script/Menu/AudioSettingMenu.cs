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
        MusicSlider.value = AudioManager.instance.musicSource.volume;
        SFXSlider.value = AudioManager.instance.musicSource.volume;
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
}
