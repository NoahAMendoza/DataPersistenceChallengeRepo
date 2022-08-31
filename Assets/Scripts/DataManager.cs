using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    
    public int playerScore;
    public string playerName;

    public int highScore;
    public string highScorePlayerName;


    private readonly string saveFileName = "/savefile.json";
    public List<HighScoreEntryData> highScores;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    public class HighScoreEntryData
    {
        public string playerNameToSave;
        public int playerScoreToSave;
    }

    public void SaveHighScore()
    {
        HighScoreEntryData highScoreData = new HighScoreEntryData();
        highScoreData.playerNameToSave = playerName;
        highScoreData.playerScoreToSave = playerScore;

        string jsonString = JsonUtility.ToJson(highScoreData);
        File.AppendAllText(Application.persistentDataPath + saveFileName, jsonString);

        Debug.Log("Logged high score entry to file location: " + Application.persistentDataPath + saveFileName);
    }

    public void LoadAllHighestScores()
    {
        string filepath = Application.persistentDataPath + saveFileName;
        if (File.Exists(filepath))
        {
            string jsonString = File.ReadAllText(filepath);
            highScores = JsonUtility.FromJson<List<HighScoreEntryData>>(jsonString);
        }
    }
}
