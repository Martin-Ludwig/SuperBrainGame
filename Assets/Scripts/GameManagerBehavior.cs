using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{

    public bool IsRunning = true;

    public GameObject Timer;
    public GameObject EndScreen;
    private EndScreenBehavior _endscreen;

    private GameTime gameTime;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = Timer.GetComponent<GameTime>();
        _endscreen = EndScreen.GetComponent<EndScreenBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (gameTime.GetTimeLeft() <= 0 && IsRunning)
        {
            IsRunning = false;
            ShowEndScreen();
        }
        else if (gameTime.GetTimeLeft() > 0)
        {
            IsRunning = true;
        }
    }

    void ShowEndScreen()
    {
        if (_endscreen != null)
        {
            _endscreen.ShowEndscreen();
        }
    }
}
