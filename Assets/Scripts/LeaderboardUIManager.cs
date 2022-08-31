using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardUIManager : MonoBehaviour
{

    public List<(string, int)> leaderboardData;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadAllHighestScores();
        Debug.Log(DataManager.Instance.highScores.ToString());
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
