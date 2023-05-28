using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject AudioSettingMenu;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        AudioSettingMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backMainMenu()
    {
        MainMenu.SetActive(true);
        AudioSettingMenu.SetActive(false);
    }

    public void ComeAudioSettingMenu()
    {
        AudioSettingMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
