using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelPresenter : MonoBehaviour
{
    public GameObject btnLevel;

    void Start()
    {
        int maxOpenLevel = PlayerPrefs.GetInt("MaxLevel", 0) + 1;

        Instantiate(btnLevel, this.transform, true).name = "1";
        for (int i = 2; i <= maxOpenLevel; i++)
            Instantiate(btnLevel, this.transform, true).name = i.ToString();

        for (int i = maxOpenLevel + 1; i <= 50; i++)
        {
            GameObject inactive = Instantiate(btnLevel, this.transform, true);
            inactive.name = i.ToString();
            inactive.GetComponent<Button>().interactable = false;
        }
    }
}
