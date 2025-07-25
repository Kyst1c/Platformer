using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public int coinValue = 1; // Значение монеты

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddCoins(coinValue); // Добавляем монеты в GameManager
            Destroy(gameObject); // Уничтожаем монету
        }
    }
}