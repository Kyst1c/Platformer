using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public PlayerMovement player;      // Ссылка на скрипт игрока
    public Text hpText;                  // Ссылка на текст HP
    public GameObject gameOverText;      // Ссылка на текст "Game Over"
    public Button restartButton;          // Ссылка на кнопку перезапуска
    public Text AmmoText;

    private void Start()
    {
        Time.timeScale = 1;
        if (player == null)
        {
            player = FindObjectOfType<PlayerMovement>(); // Найти игрока в сцене
        }
        gameOverText.SetActive(false); // Скрыть текст Game Over при старте
        restartButton.gameObject.SetActive(false); // Скрыть кнопку при старте

        // Привязать метод к событию нажатия на кнопку
        restartButton.onClick.AddListener(RestartGame);
    }

    private void Update()
    {
        // Обновляем отображение здоровья
        hpText.text = "HP: " + player.currentHealth;
        AmmoText.text = "Ammo: " + player.ammoCount.ToString();

        // Проверяем, мертв ли игрок
        if (player.currentHealth <= 0)
        {
            ShowGameOver(); // Показать сообщение Game Over
            Time.timeScale = 0;
        }
    }

    private void ShowGameOver()
    {
        gameOverText.SetActive(true); // Показываем сообщение Game Over
        restartButton.gameObject.SetActive(true); // Показываем кнопку перезапуска

    }

    // Метод для перезапуска игры
    private void RestartGame()
    {
        Time.timeScale = 1; // Возобновляем игру
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

