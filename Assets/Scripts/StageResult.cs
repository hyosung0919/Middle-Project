using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class StageResult
{
    public string playername;
    public int stage;
    public int score;
}
[System.Serializable]
public class StageResultList
{
    public List<StageResult> results = new List<StageResult>();
}
public static class StageResultSaver
{
    private const string FILE = "stage_result.json";
    private const string PLAYER_NAME = "PlayerName";     // Playerprefs Ű
    private static string filepath = Path.Combine(Application.persistentDataPath, FILE);
    public static void SaveStage(int stage, int score)
    {
        StageResultList list = LoadInternal();
        string playerName = PlayerPrefs.GetString(PLAYER_NAME,"");
        StageResult entry = new StageResult
        {
            playername = playerName,
            stage = stage,
            score = score
        };
        list.results.Add(entry);
        string json = JsonUtility.ToJson(list, true);
        File.WriteAllText(filepath, json);
    }

    public static StageResultList LoadRank()
    {
        return LoadInternal();
    }
    private static StageResultList LoadInternal()
    {
        if(!File.Exists(filepath))
            return new StageResultList();
        string json = File.ReadAllText(filepath);
        StageResultList list = JsonUtility.FromJson<StageResultList>(json);
        if(list == null)
            return new StageResultList();
        else
            return list;
    }
}
