using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;


[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
    public InputField playerNameInputField;
    //private string playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void StartGame()
    {
        if (playerNameInputField.text != null)
        {
            Debug.Log(playerNameInputField.text);
            MainManager.Instance.playerName = playerNameInputField.text;
            SceneManager.LoadScene(1);
        }

        if( playerNameInputField == null)
        {

        }
    }


    public void LoadLeaderboardScene()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void ExitGame()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        
    }
}
