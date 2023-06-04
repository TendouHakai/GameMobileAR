using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    public GameObject playScreen;
    public GameObject warningScreen;
    public GameObject warningBossAppearScreen;
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;
    public GameObject levelCompleteScreen;

    private bool isComplettingLevel = false;
    private bool IsBossAppearing = false;
    private float timeStart = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playScreen.SetActive(true);
        warningScreen.SetActive(true);
        playScreen.transform.Find("TapToPlacePortal").gameObject.SetActive(true);
        warningBossAppearScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameWinScreen.SetActive(false);
        levelCompleteScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart > 2.0f && isComplettingLevel)
        {
            levelCompleteScreen.SetActive(false);
            isComplettingLevel = false;

            playScreen.GetComponent<PlayScene>().StartGameNextLevel();
        }
        else timeStart += Time.deltaTime;

        if(timeStart > 4.0f && IsBossAppearing)
        {
            warningBossAppearScreen.SetActive(false);
            IsBossAppearing = false;

            SpawnManager.instance.isInFight = true;
            SpawnManager.instance.createBoss(HubManager.instance.currentlevel);
        }
        else timeStart += Time.deltaTime;
    }

    public void gameOver()
    {
        Debug.Log("Game over");
        SpawnManager.instance.isInFight = false;

        gameOverScreen.SetActive(true);
        warningScreen.SetActive(false);

        HubManager.instance.updateHighestScore();
        AudioManager.instance.PlaySFX("GameOver");
        SaveLoadSystem.instance.SaveData();
    }

    public void GameWin()
    {
        Debug.Log("Game win");
        SpawnManager.instance.isInFight = false;

        gameWinScreen.SetActive(true);

        AudioManager.instance.PlaySFX("Win");
        HubManager.instance.updateHighestScore();
        SaveLoadSystem.instance.SaveData();
    }

    public void ResumeGame()
    {
        playScreen.SetActive(true);
        playScreen.transform.Find("TapToPlacePortal").gameObject.SetActive(false); 
        warningScreen.SetActive(true);
        warningBossAppearScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameWinScreen.SetActive(false);
        levelCompleteScreen.SetActive(false);

        if (HubManager.instance.currentlevel > HubManager.instance.Maxlevel)
        {
            GameWin();
        }
        else
        {
            SpawnManager.instance.Clear();
            PlayerHealth.instance.Resume();
            HubManager.instance.score = 0;
            playScreen.GetComponent<PlayScene>().StartGame();
        }
    }

    public void LevelGameComplete()
    {
        Debug.Log("Complete level " + HubManager.instance.currentlevel.ToString());
        levelCompleteScreen.SetActive(true);
        playScreen.transform.Find("heathbarBoss").gameObject.SetActive(false);
        isComplettingLevel = true;
        timeStart = 0f;

        HubManager.instance.updateCompletedLevel();
        HubManager.instance.updateHighestScore();
        SaveLoadSystem.instance.SaveData();
    }

    public IEnumerator BossAppear()
    {
        Debug.Log("Boss Appear in level "+ HubManager.instance.currentlevel.ToString());
        yield return new WaitForSeconds(1.5f);
        warningBossAppearScreen.SetActive(true);
        IsBossAppearing = true;
        timeStart = 0f;
    }
}
