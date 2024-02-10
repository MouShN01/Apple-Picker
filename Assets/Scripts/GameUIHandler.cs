using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIHandler : MonoBehaviour
{ 
    public static GameUIHandler Instance;
    public Text playerNameLabel;
    public Text highScoreLabel;
    public Text topPlayerNameLabel;
    // Start is called before the first frame update
    void Start()
    {
        playerNameLabel.text = MainManager.Instance.playerName;
        highScoreLabel.text = "High Score: " + MainManager.Instance.highScore;
        topPlayerNameLabel.text= MainManager.Instance.topPlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
