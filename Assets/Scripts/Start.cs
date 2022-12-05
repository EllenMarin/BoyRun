using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{

    public void StartGame()
    {
        // agora quando for iniciar o jogo se player já tiver passado os niveis já começar onde parou
        var level = PlayerPrefs.GetInt("unlockedLevel", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(level);

    }


}
