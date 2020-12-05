using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ContinueClick()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    public void NextLevelClick()
    {
        PlayerPrefs.SetInt("MaxLevel", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitClick()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
