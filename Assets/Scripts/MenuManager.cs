using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saindo do jogo");
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    
    public void NextLevel()
    {
        // Exactamente igual o start
        var level = PlayerPrefs.GetInt("unlockedLevel", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(level);
    }

    public void RestartLevel()
    {
        // Exactamente igual o start
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
