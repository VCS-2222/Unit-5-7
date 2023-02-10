using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public Button quitButton;

    private void Start()
    {
        quitButton.Select();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
