using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button CreditButton;
    [SerializeField] private Button QuitButton;

    private void Awake()
    {
        StartButton.onClick.AddListener(StartGame);
        QuitButton.onClick.AddListener(QuitGame);
        CreditButton.onClick.AddListener(Credit);
        Time.timeScale = 1;
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void Credit()
    {
        SceneManager.LoadScene("CreditScene");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
    
    public void MenuGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
