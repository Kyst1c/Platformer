using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Если пуля столкнулась с врагом
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(); // Наносим урон врагу
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(); // Урон игроку
        }
        Destroy(gameObject); // Уничтожаем пулю
    
    }

}