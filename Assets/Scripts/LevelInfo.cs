using UnityEngine;
using SimpleJSON;
using System;

public static class LevelInfo
{
    static JSONArray js;

    public static void readJSON()
    {
        if (js==null)
            js = JSON.Parse(Resources.Load<TextAsset>("level_data").text).AsArray;
    }

    public static int[] GetStarsCondition(int levelNumber)
    {
        JSONNode jn =  js[levelNumber-1];
        int[] arrowOnStar = new int[3];

        if (js != null)
            for (int i = 0; i < 3;)
                arrowOnStar[i] = Convert.ToInt32(jn[++i].Value);

        return arrowOnStar;
    }

}
