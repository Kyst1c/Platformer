using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int totalScore; // Общее количество очков
    private int totalCoins; // Общее количество монет

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект при загрузке новых сцен
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public void AddCoins(int amount)
   {
        totalCoins += amount; // Добавляем монеты
   }

    public void AddScore(int amount)
    {
        totalScore += amount; // Добавляем очки
    }

    public int GetTotalScore()
    {
        return totalScore;
    }


    public void EndLevel()
    {
        int score = GetTotalScore(); // Получаем общее количество очков
        ScorePopup.Instance.ShowScorePopup(score); // Вызываем метод показа попапа с очками
        Time.timeScale = 0; // Останавливаем время
    }
}