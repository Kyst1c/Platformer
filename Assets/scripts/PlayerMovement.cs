using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public int maxHealth = 10;
    public int currentHealth;
    public int ammoCount = 10;

    public GameObject bulletPrefab;   // Префаб пули
    public Transform firePoint;       // Точка, из которой будет производиться стрельба
    public float bulletSpeed = 10f;   // Скорость пули 

    public AudioClip jumpSound;       
    private AudioSource audioSource;  

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool isJumping = false;

	private bool facingRight = true; // Переменная для отслеживания стороны

	private float reloadTime = 2f;
	private bool isReloading = false;

	public Vector3 offsetRight = new Vector3(1f, 0f, 0f); // Смещение для стрельбы вправо
	public Vector3 offsetLeft = new Vector3(-1f, 0f, 0f); // Смещение для стрельбы влево

	public Vector3 firePointRotationRight = Vector3.zero;
	public Vector3 firePointRotationLeft = Vector3.zero;
	
	


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth; // Инициализация здоровья

        audioSource = GetComponent<AudioSource>();
    }

	void Update()
	{
		if (animator.GetBool("isDead")) return; // Если персонаж мертв, ничего не делаем

		float moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

		// Флип персонажа в зависимости от направления движения
		if (moveInput > 0 && !facingRight)
		{
			Flip();
		}
		else if (moveInput < 0 && facingRight)
		{
			Flip();
		}

		// Установка анимаций
		animator.SetBool("isRunning", moveInput != 0);

		if (Input.GetButtonDown("Jump") && !isJumping)
		{
			Jump();
		}

		if (Input.GetMouseButtonDown(0) && ammoCount > 0)
		{
			Shoot();
		}

        if (ammoCount <= 0 && !isReloading)
        {
            StartCoroutine(Reload());
        }
	}

	private void Jump()
	{
	    isJumping = true;
	    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
	    animator.SetTrigger("Jump");
	    
	    // Воспроизведение звука прыжка
	    if (audioSource != null && jumpSound != null)
	    {
	        audioSource.PlayOneShot(jumpSound);
	    }
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
	    if (collision.gameObject.CompareTag("Ground"))
	    {
	        isJumping = false; // Позволяем прыгнуть снова
	    }
	    else if (collision.gameObject.CompareTag("Enemy"))
	    {
	        TakeDamage(); // Урон от врага
	    }
	}

	public void TakeDamage()
	{
	    currentHealth--;
	    animator.SetTrigger("Hit"); // Запускает анимацию получения урона

	    if (currentHealth <= 0)
	    {
	        Die(); // Вызываем метод смерти
	    }
	}


	private void Die()
	{
	    	animator.SetBool("isDead", true); // Запускает анимацию смерти
	    	GetComponent<Collider2D>().enabled = false; // Отключает коллизию
	    	rb.gravityScale = 1; // Позволяет персонажу падать
	    	rb.velocity = new Vector2(0, -5); // Начальная скорость падения
	}

	private void Shoot()
	{
	    if (ammoCount > 0 && !isReloading)
	    {
	        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
	        bulletRb.velocity = firePoint.up * bulletSpeed; // Направление и скорость пули
	        ammoCount--;
		    if (ammoCount <= 0)
			{
                StartCoroutine(Reload());
            }	
	    }
	}

	System.Collections.IEnumerator Reload()
	{
	    isReloading=true;
	    yield return new WaitForSeconds(reloadTime);
	    ammoCount=10;
	    isReloading=false;
	}

	public void Heal(int amount)
	{
	    currentHealth+=amount;
	    if(currentHealth>maxHealth)
	        currentHealth=maxHealth;
	}

	private void Flip()
	{
	    facingRight = !facingRight;
	    spriteRenderer.flipX = !spriteRenderer.flipX;
	 	// Обновляем позицию firePoint при смене стороны
            UpdateFirePointPosition();
	}


	private void UpdateFirePointPosition()
	{
    	if (facingRight)
    	{
        	firePoint.localPosition = offsetRight;
        	firePoint.localRotation = Quaternion.Euler(firePointRotationRight);
    	}
    	else
    	{
        	firePoint.localPosition = offsetLeft;
        	firePoint.localRotation = Quaternion.Euler(firePointRotationLeft);
    	}
}
}