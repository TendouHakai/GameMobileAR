using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject AudioSettingMenu;
    [SerializeField] GameObject HighScoreRank;
    [SerializeField] GameObject EnterNameMenu;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        AudioSettingMenu.SetActive(false);
        HighScoreRank.SetActive(false);
        EnterNameMenu.SetActive(false);

        SaveLoadSystem.instance.LoadPath();
        if (!SaveLoadSystem.instance.LoadData())
        {
            ComeEnterNameMenu();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void backMainMenu()
    {
        MainMenu.SetActive(true);
        AudioSettingMenu.SetActive(false);
        HighScoreRank.SetActive(false);
        EnterNameMenu.SetActive(false);
    }

    public void ComeAudioSettingMenu()
    {
        AudioSettingMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void ComeHighScoreRank()
    {
        HighScoreRank.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void ComeEnterNameMenu()
    {
        EnterNameMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void EnterTheName()
    {
        try
        {
            EnterNameMenu.transform.Find("ERROR").GetComponent<TextMeshProUGUI>().text = EnterNameMenu.GetComponentInChildren<TMP_InputField>().text;
            if (EnterNameMenu.GetComponentInChildren<TMP_InputField>().text.Length <= 10)
            {
                HubManager.instance.GameName = EnterNameMenu.GetComponentInChildren<TMP_InputField>().text;
                SaveLoadSystem.instance.SaveData();
                backMainMenu();
            }
            else
            {
                EnterNameMenu.transform.Find("ERROR").gameObject.SetActive(true);
            }
        }
        catch(System.Exception e)
        {
            EnterNameMenu.transform.Find("ERROR").GetComponent<TextMeshProUGUI>().text += e.Message;
            EnterNameMenu.transform.Find("ERROR").gameObject.SetActive(true);
        }
    }
}
