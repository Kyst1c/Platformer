using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2;   // Максимальное здоровье врага
    private int currentHealth;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;  // Инициализация здоровья
        animator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        currentHealth--;
        animator.SetTrigger("Hit");  // Запускает анимацию получения урона

        if (currentHealth <= 0)
        {
            Die();  // Вызов метода смерти
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true);  // Запуск анимации смерти
        GetComponent<Collider2D>().enabled = false; // Отключение коллизии
        Destroy(gameObject, 2f);  // Уничтожить объект через 2 секунды
    }
}
