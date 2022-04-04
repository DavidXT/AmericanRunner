using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void MainGame()
    {
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1;
    }
    public void LeaveGame()
    {
        Application.Quit();
    }
}
