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

    public GameObject Player;
    private BciController _bciInput;


    public bool IsReady = false;

    private const float _delay = 1;
    private float _inputDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        _bciInput = Player.GetComponent<BciController>();

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
        try
        {
            if (gameObject.activeSelf && Time.time >= _inputDelay)
            {
                // Debug.Log("1");

                IsReady = true;

                if (_bciInput != null && _bciInput.State == BciController.BciControllerState.Connected)
                {
                    // Debug.Log("2");
                    if (_bciInput.Input.IsLeft)
                    {
                        StartNewGame();
                    }

                    if (_bciInput.Input.IsRight)
                    {
                        ReturnToMainMenu();
                    }
                }
            }
        }
        catch (System.Exception)
        {
            Debug.Log("Secret error found!");
        }
    }

    private void ReturnToMainMenu()
    {
        ReturnToMainMenuButton.image.sprite = OnPressImage;
        HideEndscreen();
        SceneManager.LoadScene(0);
    }

    private void StartNewGame()
    {
        StartNewGameButton.image.sprite = OnPressImage;
        HideEndscreen();
        SceneManager.LoadScene(1);
    }

    public void ShowEndscreen()
    {
        gameObject.SetActive(true);
        _inputDelay = Time.time + _delay;
    }

    public void HideEndscreen()
    {
        gameObject.SetActive(false);
        IsReady = false;
    }



}
