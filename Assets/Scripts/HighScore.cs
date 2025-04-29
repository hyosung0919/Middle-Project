using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScore
{
    private const string Key = "HighScore";

    public static int Load(int stage)
    {
        return PlayerPrefs.GetInt(Key + "_" + stage, 0);
    }

    public static void TrySet(int stage, int newScore)
    {
        if (newScore <= Load(stage))
            return;

        PlayerPrefs.SetInt(Key + "_" + stage, newScore);
        PlayerPrefs.Save();
    }
}
