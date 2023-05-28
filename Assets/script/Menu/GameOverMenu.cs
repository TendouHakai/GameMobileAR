using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        ScreenManager.instance.ResumeGame();
    }

    public void CombackMainMenu()
    {
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene(0);
    }
}
