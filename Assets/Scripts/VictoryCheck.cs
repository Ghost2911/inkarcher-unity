using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class VictoryCheck : MonoBehaviour
{
    public GameObject winPanel;
    public string[] victoryText = {  "RETRY PLEASE", "Okeeeeey", "GOOD JOB", "AWESOME"};


    private bool isWin = false;
    private Animation winAnim;
    private GameObject btnNext;
    private Text winText;

    private void Start()
    {
        LevelInfo.readJSON();
        winAnim = winPanel.transform.GetChild(0).GetComponent<Animation>();
        btnNext = winPanel.transform.GetChild(2).gameObject;
        winText = winPanel.transform.GetChild(1).GetComponent<Text>();
        btnNext.SetActive(false);
    }

    void Update()
    {
        if (!isWin)
        {
            if (transform.childCount == 0)
            {
                int levelNow = SceneManager.GetActiveScene().buildIndex;
                int[] arr = LevelInfo.GetStarsCondition(levelNow);
                int shootArrow = GameObject.FindGameObjectWithTag("Player").GetComponent<FireScript2D>().ShootCount();

                for (int i = 0; i < arr.Length; i++)
                    if (shootArrow <= arr[i])
                    {
                        winAnim.clip = winAnim.GetClip("star" + (3 - i));
                        PlayerPrefs.SetInt(levelNow.ToString(), 3 - i);
                        winText.text = victoryText[3-i];
                        btnNext.SetActive(true);
                        break;
                    }
                PlayerPrefs.SetInt("MaxLevel", levelNow);
                isWin = true;
                winPanel.SetActive(true);
            }
        }
    }
}
