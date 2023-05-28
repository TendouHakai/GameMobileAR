using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        HubManager.instance.currentlevel = 1;
        SceneManager.LoadScene(1);
    }

    public void ResumeGame()
    {
        HubManager.instance.currentlevel = HubManager.instance.Completedlevel;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
