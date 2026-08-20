using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI highScoreDisplay;
    private int highScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("maxScore",0);
        highScoreDisplay.text = "Highscore " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
