using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject levelPanel;
    //public GameObject settingsPanel;

    private void Awake()
    {
        levelPanel.SetActive(false);
        //settingsPanel.SetActive(false);
    }

    public void PlayClick()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastLoadedLevel",1));
    }

    public void GoToMenuClick()
    {
        //settingsPanel.SetActive(false);
        levelPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void LevelsClick()
    {
        mainPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void SettingsClick()
    {
        mainPanel.SetActive(false);
        //settingsPanel.SetActive(true);
    }

    public void QuitClick()
    {
        Application.Quit();
    }
}
