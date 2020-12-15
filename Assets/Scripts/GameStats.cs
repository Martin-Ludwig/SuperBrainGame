using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    private int Score = 0;
    public Text ScoreTextField;
    public Text EndScreenScore;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        Score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (ScoreTextField != null)
        {
            ScoreTextField.text = Score.ToString();
            EndScreenScore.text = $"Score: {Score}";
        }
    }
}
