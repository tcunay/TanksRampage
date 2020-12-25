using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Exit()
    {
        Application.Quit();
    }
}
