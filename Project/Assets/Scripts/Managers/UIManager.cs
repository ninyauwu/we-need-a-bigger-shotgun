using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject SettingsMenu;


    /// <summary>
    /// Called whenever the on-screen pause button is pressed
    /// </summary>
    public void openPauseMenu() {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Called whenever the "Resume Game" button is pressed within the pause menu
    /// </summary>
    public void closePauseMenu() {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Called whenever the "Settings" button is pressed within the pause menu
    /// </summary>
    public void openSettings() {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    /// <summary>
    /// Called whenever the "Return" button is pressed within the settings menu
    /// </summary>
    public void closeSettings() {
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    /// <summary>
    /// Called whenever the "Return to menu" button is pressed within the pause menu
    /// </summary>
    public void returnToMenu() {
        // Add implementation
    }

    /// <summary>
    /// Called whenever the "Volume" slider is adjusted within the pause menu
    /// </summary>
    /// <param name="volumeValue">New desired volume level on a scale of 0-100</param>
    public void changeVolume(float volumeValue) {
        // Add implementation
    }

    /// <summary>
    /// Called whenever the "SFX" slider is adjusted within the pause menu
    /// </summary>
    /// <param name="sfxValue">New desired Sound effects volume level on a scale of 0-100</param>
    public void changeSFXVolume(float sfxValue) {
        // Add implementation
    }
}
