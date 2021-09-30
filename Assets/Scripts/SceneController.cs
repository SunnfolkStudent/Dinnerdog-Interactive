using System;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private PlayerInput _input;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
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
        if (_input.resart)
        {
            SceneManager.LoadScene("Kitchen1 Menu");
            PlayerInteract.score = 0;
        }
    }
}