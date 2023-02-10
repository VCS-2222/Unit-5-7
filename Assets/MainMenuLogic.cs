using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuLogic : MonoBehaviour
{
    [Header("Important Components")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private TMP_Dropdown difficultyDropdown;

    [SerializeField] private Button startButton;

    [Header("Sound Assets")]
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer soundMixer;

    private void Start()
    {
        startButton.Select();

        //music
        musicMixer.SetFloat("Volume", PlayerPrefs.GetFloat("MusicSaveKey"));
        musicSlider.value = PlayerPrefs.GetFloat("MusicSaveKey");

        //sound
        soundMixer.SetFloat("Volume", PlayerPrefs.GetFloat("SFXSaveKey"));
        SFXSlider.value = PlayerPrefs.GetFloat("SFXSaveKey");

        //dif
        difficultyDropdown.value = PlayerPrefs.GetInt("DifficultySaveKey");

        //musicToggle toggle
        int i = PlayerPrefs.GetInt("musicToggleSaveKey");

        if (i == 1)
        {
            musicToggle.isOn = true;
            musicSlider.interactable = true;
            SetMusicVolume(PlayerPrefs.GetFloat("SFXSaveKey"));
        }
        else if (i == 0)
        {
            musicToggle.isOn = false;
            musicSlider.interactable = false;
            musicMixer.SetFloat("Volume", -80);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetDifficulty(int value)
    {
        difficultyDropdown.value = value;
        PlayerPrefs.SetInt("DifficultySaveKey", value);
    }

    public void ToggleMusic(int logic)
    {
        if(musicToggle.isOn == true)
        {
            logic = 1;
            musicSlider.interactable = true;
            SetMusicVolume(PlayerPrefs.GetFloat("SFXSaveKey"));
        }
        else if(musicToggle.isOn == false)
        {
            logic = 0;
            musicSlider.interactable = false;
            musicMixer.SetFloat("Volume", -80);
        }

        PlayerPrefs.SetInt("musicToggleSaveKey", logic);
    }

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("Volume", PlayerPrefs.GetFloat("MusicSaveKey"));
        musicSlider.value = volume;
        PlayerPrefs.SetFloat("MusicSaveKey", volume);
    }

    public void SetSFXVolume(float volume)
    {
        soundMixer.SetFloat("Volume", PlayerPrefs.GetFloat("SFXSaveKey"));
        SFXSlider.value = volume;
        PlayerPrefs.SetFloat("SFXSaveKey", volume);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quitting");
    }
}
