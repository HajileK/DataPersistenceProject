using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
public class StartManager : MonoBehaviour
{
    public TMP_InputField enterName;
    public TextMeshProUGUI bestScoreText;
    private void Start()
    {
        bestScoreText.text = $"{BestScore.Instance.bestPlayer} : {BestScore.Instance.highScore}";
    }
    public void StartGame()
    {
        BestScore.Instance.PlayerName = enterName.GetComponent<TMP_InputField>().text;
        if(BestScore.Instance.PlayerName != string.Empty)
        {
SceneManager.LoadScene(1);
        }
        else
        {
Debug.Log("Please enter a Name");
        }
        
        
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
