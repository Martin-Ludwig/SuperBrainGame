using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public Sprite DefaultImage;
    public Sprite OnHoverImage;
    public Sprite OnPressImage;

    public Button StartButton;
    public Button SettingsButton;
    public Button ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        
        if (StartButton != null)
        {
            StartButton.onClick.AddListener(StartGame);
        }

        if (SettingsButton != null)
        {
            SettingsButton.onClick.AddListener(OpenSettings);
        }
        
        if (ExitButton != null)
        {
            ExitButton.onClick.AddListener(ExitGame);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
    }


    public void StartGame()
    {
        Debug.Log("StartGame");
        StartButton.image.sprite = OnPressImage;

        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        Debug.Log("OpenSettings");
        SettingsButton.image.sprite = OnPressImage;

        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        ExitButton.image.sprite = OnPressImage;

        Application.Quit();
    }
}
