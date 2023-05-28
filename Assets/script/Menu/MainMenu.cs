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
        Debug.Log("Play new game");
        HubManager.instance.currentlevel = 1;
        SceneManager.LoadScene(1);
    }

    public void ResumeGame()
    {
        Debug.Log("Resume game in level"+ HubManager.instance.Completedlevel);
        HubManager.instance.currentlevel = HubManager.instance.Completedlevel;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
