using System;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public PlayerInput _input;
    

    private void Update()
    {
        QuitGame();
        RestartGame();
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public static void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        if (_input.quit)
        {
            Application.Quit();
        }
    }

    public void RestartGame()
    {
        if (_input.restart)
        {
            SceneManager.LoadScene("Kitchen1 Menu");
            print("restart selected");
            PlayerInteract.score = 0;
        }
    }
    
}