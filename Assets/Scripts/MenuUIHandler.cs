using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text highScore;

    private void Start()
    {
        MainManager.Instance.LoadData();
        highScore.text = "Top player: " + MainManager.Instance.topPlayerName + "\nHigh Score: " + MainManager.Instance.highScore.ToString();
    }
    public void NewStart()
    {
        MainManager.Instance.playerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
