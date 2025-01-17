using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string nameEssentialScene;
    [SerializeField] private string nameNewGameStartScene;
    
    public void ExitGame()
    {
        Debug.Log("You are quitting the game");
        Application.Quit();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(nameNewGameStartScene, LoadSceneMode.Single);
    }
}
