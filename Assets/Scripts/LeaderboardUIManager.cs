using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardUIManager : MonoBehaviour
{
    private int MaxScores = 5;
    public Text[] Entries; 

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadAllHighestScores();
        Debug.Log("Grabbed the following high scores: " + DataManager.Instance.highScores.highScoresList[0].playerNameToSave);
        Debug.Log("Number of high scores: " + DataManager.Instance.highScores.highScoresList.Count);

        showScores();
        
        //TODO Use data from the above log to populate UI
    }

    private void showScores()
    {
        for(int i = 0; (i < MaxScores) && (i < DataManager.Instance.highScores.highScoresList.Count) ; i++)
        {
            Entries[i].text = DataManager.Instance.highScores.highScoresList[i].playerNameToSave + " : " + DataManager.Instance.highScores.highScoresList[i].playerScoreToSave;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
