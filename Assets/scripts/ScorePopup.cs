using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

  public class ScorePopup : MonoBehaviour
{
    public static ScorePopup Instance;
    public GameObject scorePopup;  // Ссылка на попап
    public Text scoreText;          // Ссылка на текст очков
    public Button quitButton;       // Ссылка на кнопку выхода в меню
    public Button restartButton;    // Ссылка на кнопку рестарта уровня
    public Button nextLevelButton;  // Ссылка на кнопку перехода на следующий уровень

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        scorePopup.SetActive(false);
        quitButton.onClick.AddListener(QuitGame);
        restartButton.onClick.AddListener(RestartLevel);
        nextLevelButton.onClick.AddListener(LoadNextLevel);

    }  




    public void ShowScorePopup(int score)
    {
        scoreText.text = $"Score: {score}"; // Обновляем текст
        scorePopup.SetActive(true); // Показываем попап
    }

    private void QuitGame()
    {
        Time.timeScale = 1; // Возобновить игру
        // Здесь можно добавить код для возврата в главное меню
         SceneManager.LoadScene("menu");
    }

    private void RestartLevel()
    {
        Time.timeScale = 1; // Возобновить игру
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Рестарт текущей сцены
    }

    private void LoadNextLevel()
    {
        Debug.Log("слудущая сцена");
        Time.timeScale = 1; // Возобновить игру
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);

    }
}