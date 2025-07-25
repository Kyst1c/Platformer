using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform firePoint; // Точка, откуда стреляем
    public float fireInterval = 2f; // Интервал между выстрелами
    public float projectileSpeed = 5f; // Скорость снаряда

    private float fireTimer = 0f;
    private Transform playerTransform;



    private void Start()
    {
        // Находим игрока по тегу
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireInterval)
            {
                FireAtPlayer();
                fireTimer = 0f;
            }
        }
    }

    private void FireAtPlayer()
    {
        // Создаём снаряд в точке firePoint
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        // Направляем снаряд к игроку
        Vector2 direction = (playerTransform.position - firePoint.position).normalized;
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(); // Урон игроку
        }
    }
}