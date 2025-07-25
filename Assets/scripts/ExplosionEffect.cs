using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f); // Удаляем эффект через 1 секунду
    }
}