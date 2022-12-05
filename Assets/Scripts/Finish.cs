using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        // Se jogardor ganhou a partido desloqueia o proximo level
        if (other.gameObject.name == "Jogador" && other.GetComponent<MovJogador>().GetWin())
        {
            var unlockedLevel = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("unlockedLevel", unlockedLevel);
            Debug.Log("Finish - WIN");
        }
    }

}
