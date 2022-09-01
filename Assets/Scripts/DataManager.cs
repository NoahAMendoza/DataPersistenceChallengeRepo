using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    
    public int playerScore;
    public string playerName;

    public int highScore;
    public string highScorePlayerName;


    private readonly string saveFileName = "/savefile.json";

    public HighScoreList highScores;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadAllHighestScores();
    }

    [Serializable]
    public class HighScoreEntryData
    {
        public string playerNameToSave;
        public int playerScoreToSave;
    }

    [Serializable]
    public class HighScoreList
    {
        public List<HighScoreEntryData> highScoresList;
    }

    public void SaveHighScore()
    {
        HighScoreEntryData highScoreData = new HighScoreEntryData();
        highScoreData.playerNameToSave = playerName;
        highScoreData.playerScoreToSave = playerScore;

        HighScoreList highScoresList = new HighScoreList();
        if(highScores == null)
        {
            highScores = new HighScoreList();
            highScores.highScoresList = new List<HighScoreEntryData>();
        }
        highScoresList.highScoresList = highScores.highScoresList;
        highScoresList.highScoresList.Add(highScoreData);
        
        string jsonString = JsonUtility.ToJson(highScoresList);
        File.WriteAllText(Application.persistentDataPath + saveFileName, jsonString);

        Debug.Log("Logged high score entry to file location: " + Application.persistentDataPath + saveFileName);
    }

    public void LoadAllHighestScores()
    {
        string filepath = Application.persistentDataPath + saveFileName;
        if (File.Exists(filepath))
        {
            string jsonString = File.ReadAllText(filepath);
            highScores = JsonUtility.FromJson<HighScoreList>(jsonString);
        }
    }

    public HighScoreEntryData GetHighestScore()
    {
        if(highScores == null)
        {
            return new HighScoreEntryData { playerNameToSave = playerName, playerScoreToSave = 0};
        }

        return highScores.highScoresList.OrderBy(entry => entry.playerScoreToSave).Last();
    }
}
