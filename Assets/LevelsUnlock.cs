using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsUnlock : MonoBehaviour
{


    public Button[] levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        this.Update();
    }

    private void Update()
    {
        var level = PlayerPrefs.GetInt("unlockedLevel", SceneManager.GetActiveScene().buildIndex + 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = i + 1 <= level;
        }
    }



}
