using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevelButton : MonoBehaviour
{
    public Text btnText;
    public Sprite[] sprites;
    public Image img;

    void Start()
    {
        btnText.text = this.name;
        img.sprite = sprites[PlayerPrefs.GetInt(this.name,0)];
    }

    public void OnClick()
    {
        SceneManager.LoadScene(this.name);
    }
}
