using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPanel;

    public float Timer;
    public TextMeshProUGUI TimerText;
    public bool canContinue;
    public bool gameContinue = false;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canContinue = true;
    }

    // Update is called once per frame
    void Update()
    {
        UITimer();
    }

    public void Continuer()
    {
        if (canContinue)
        {
            gameOverPanel.SetActive(false);
            Time.timeScale = 1;
            canContinue = false;
            gameContinue = true;
        }

    }

    public void UITimer()
    {
        Timer += Time.deltaTime;
        int score = (int)Timer;
        TimerText.text = score.ToString();
        //int minutes = Mathf.FloorToInt(Timer / 60F);
        //int seconds = Mathf.FloorToInt(Timer % 60F);
        //int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
        //TimerText.text = minutes.ToString() + seconds.ToString("0");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void LeaveGame()
    {
        Application.Quit();
    }
}
