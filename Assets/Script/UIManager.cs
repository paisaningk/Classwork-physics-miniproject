using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player Player;
    public GameObject GameObjectPlayer;
    public GameObject Pause;
    public GameObject Lose;
    public GameObject Hp;
    public Image HpImage;
    private float MaxHP;
    private bool isPause = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Hp.SetActive(true);
        Lose.SetActive(false);
        Pause.SetActive(false);
        Player = GameObjectPlayer.GetComponent<Player>();
        Time.timeScale = 1;
        MaxHP = Player.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        float hp = Player.Hp / MaxHP;
        Debug.Log(hp);
        HpImage.fillAmount = hp;
        if (Player.Hp <= 0)
        {
            Lose.SetActive(true);
            Hp.SetActive(false);
            Destroy(GameObjectPlayer);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                PauseGame();
            }
            else
            {
                Hp.SetActive(false);
                Pause.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
            }
        }
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PauseGame()
    {
        Hp.SetActive(true);
        isPause = false;
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
}
