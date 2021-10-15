using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public Image gamePauseImage;
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void GamePause()
    {
        gamePauseImage.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        gamePauseImage.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
