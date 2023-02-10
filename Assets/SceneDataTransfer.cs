using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneDataTransfer : MonoBehaviour
{
    public TextMeshProUGUI difficultyDisplay;

    private void Start()
    {
        if(PlayerPrefs.GetInt("DifficultySaveKey") == 0)
        {
            difficultyDisplay.text = "Difficulty: " + "Easy";
        }
        else if (PlayerPrefs.GetInt("DifficultySaveKey") == 1)
        {
            difficultyDisplay.text = "Difficulty: " + "Medium";
        }
        else if (PlayerPrefs.GetInt("DifficultySaveKey") == 2)
        {
            difficultyDisplay.text = "Difficulty: " + "Hard";
        }
    }
}
