using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelContentSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int cellSize = Screen.currentResolution.height / 3;
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellSize/2, cellSize);
    }

}
