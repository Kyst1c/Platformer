using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  
    public int scoreValue = 10; // Очки за убийство врага

    private void OnDestroy()
    {
        GameManager.Instance.AddScore(scoreValue); // Добавляем очки в GameManager
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(); // Урон игроку
        }
    }
}