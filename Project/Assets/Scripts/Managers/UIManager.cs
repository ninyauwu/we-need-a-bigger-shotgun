using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void openPauseMenu() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void closePauseMenu() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void openSettings() {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void closeSettings() {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void returnToMenu() {
        // Add implementation
    }

    public void changeVolume(float volumeValue) {
        // Add implementation
    }

    public void changeSFXVolume(float sfxValue) {
        // Add implementation
    }
}
