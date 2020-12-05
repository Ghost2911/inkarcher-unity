using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;


public class Ads : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3762911", false);
            StartCoroutine(ShowBanner());
        }
    }

    public void SkipLevelClick()
    {
        if (Advertisement.IsReady())
            Advertisement.Show("video");
        PlayerPrefs.SetInt("MaxLevel", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ShowBanner()
    {
        while (!Advertisement.IsReady("banner"))
        {
            yield return new WaitForSeconds(1f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("banner");
    }
}
