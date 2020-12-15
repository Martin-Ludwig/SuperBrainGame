using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenBehavior : MonoBehaviour
{
    public Button StartNewGameButton;
    public Button ReturnToMainMenuButton;

    public Sprite OnPressImage;

    // Start is called before the first frame update
    void Start()
    {
        if (StartNewGameButton != null)
        {
            StartNewGameButton.onClick.AddListener(StartNewGame);
        }
        if (ReturnToMainMenuButton != null)
        {
            ReturnToMainMenuButton.onClick.AddListener(ReturnToMainMenu);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReturnToMainMenu()
    {
        ReturnToMainMenuButton.image.sprite = OnPressImage;
        SceneManager.LoadScene(0);
    }

    private void StartNewGame()
    {
        StartNewGameButton.image.sprite = OnPressImage;
        SceneManager.LoadScene(1);
    }
}
