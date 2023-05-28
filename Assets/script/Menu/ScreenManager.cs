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
        playScreen.SetActive(true);
        warningScreen.SetActive(true);
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
        gameOverScreen.SetActive(true);
        warningScreen.SetActive(false);
        AudioManager.instance.PlaySFX("Win");
    }

    public void GameWin()
    {
        gameWinScreen.SetActive(true);
        AudioManager.instance.PlaySFX("GameOver");  
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
        playScreen.GetComponent<PlayScene>().StartGame();
    }

    public void LevelGameComplete()
    {
        levelCompleteScreen.SetActive(true);
        isComplettingLevel = true;
        timeStart = 0f;
    }

    public IEnumerator BossAppear()
    {
        yield return new WaitForSeconds(1.5f);
        warningBossAppearScreen.SetActive(true);
        IsBossAppearing = true;
        timeStart = 0f;
    }
}
