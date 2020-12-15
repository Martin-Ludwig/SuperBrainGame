using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{

    public bool IsRunning = true;

    public GameObject Timer;
    public GameObject EndScreen;

    private GameTime gameTime;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = Timer.GetComponent<GameTime>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (gameTime.GetTimeLeft() <= 0)
        {
            IsRunning = false;
            ShowEndScreen();
        }
        else
        {
            IsRunning = true;
        }
    }

    void ShowEndScreen()
    {
        EndScreen.SetActive(true);
    }
}
