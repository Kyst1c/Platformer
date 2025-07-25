using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatformController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Проверяем, движется ли игрок вниз
            if (collision.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                // Позволяем игроку проходить через платформу
                Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Восстанавливаем коллизию, когда игрок покидает триггер
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), false);
        }
    }
}