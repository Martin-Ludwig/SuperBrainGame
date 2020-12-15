using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public float DurationInSeconds = 60;
    public Text TimerTextField;

    private float timeEnds;
    private float timeLeft = float.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        timeEnds = Time.time + DurationInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = timeEnds - Time.time;
    }

    void FixedUpdate()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        string _text = "Time over";
        if (timeLeft > 0)
        {
            _text = "Time: " + ((int)timeLeft).ToString();
        }

        TimerTextField.text = _text;

    }

    public float GetTimeLeft()
    {
        return this.timeLeft;
    }
}
