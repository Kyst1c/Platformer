using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPlatformController : MonoBehaviour
{
    public float speed = 2f; // Скорость движения платформы
    private SliderJoint2D sliderJoint;
    private bool movingRight = true;

    void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Получаем текущее положение платформы
        float currentPosition = sliderJoint.anchor.x;

        // Двигаем платформу
        if (movingRight)
        {
            sliderJoint.anchor = new Vector2(currentPosition + speed * Time.deltaTime, sliderJoint.anchor.y);
            if (currentPosition >= sliderJoint.limits.max)
            {
                movingRight = false; // Меняем направление
            }
        }
        else
        {
            sliderJoint.anchor = new Vector2(currentPosition - speed * Time.deltaTime, sliderJoint.anchor.y);
            if (currentPosition <= sliderJoint.limits.min)
            {
                movingRight = true; // Меняем направление
            }
        }
    }
}