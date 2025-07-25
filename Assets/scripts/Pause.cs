using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    public Button ContinueButton;
    public Button RestartButton;
    public Button MenuButton;

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
        
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        
        
        ContinueButton.onClick.AddListener(ContinueGame);
        RestartButton.onClick.AddListener(RestartLevel);
        MenuButton.onClick.AddListener(LoadMainMenu);
        
        if (!isPaused)
            Time.timeScale = 1;
    }

    public void ContinueGame()
    {
        TogglePause();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
