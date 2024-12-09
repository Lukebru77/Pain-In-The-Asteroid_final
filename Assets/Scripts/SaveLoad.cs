using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    public static string fileHS = Application.dataPath + "/saveHS.json";

    public static void SaveHighScore(HighScoreData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(fileHS, json);
    }

    public static HighScoreData LoadHighScore()
    {
        if (File.Exists(fileHS))
        {
            string json = File.ReadAllText(fileHS);
            return JsonUtility.FromJson<HighScoreData>(json);
        }

        return null;
    }
}
