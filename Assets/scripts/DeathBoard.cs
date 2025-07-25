using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoard : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
             // Урон игроку
        }
    }
}