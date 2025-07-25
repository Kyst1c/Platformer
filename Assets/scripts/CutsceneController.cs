using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;


public class CutsceneController : MonoBehaviour
{
    public GameObject player; // Игрок
    public GameObject targetObject; // Объект для показа во время кат-сцены
    public CinemachineVirtualCamera cinemachineCam; // Виртуальная камера Cinemachine
    public Canvas uiCanvas; // Канвас для текста и полос
    public Text phraseText; // Текст для фраз
    public GameObject topBlackBar; // Верхняя черная полоса
    public GameObject bottomBlackBar; // Нижняя черная полоса
    public GameObject Panel;
    private RigidbodyConstraints2D originalConstraints;
    private Rigidbody2D playerRigidbody;

    public string[] phrases; // Массив фраз для отображения
    public float phraseDisplayTime = 2f; // Время отображения каждой фразы

    private bool isCutsceneActive = false;

    void Start()
    {
        // Изначально скрываем полосы и текст
        topBlackBar.SetActive(false);
        bottomBlackBar.SetActive(false);
        phraseText.gameObject.SetActive(false);
        StartCutscene();
    }

    public void StartCutscene()
    {
        StartCoroutine(CutsceneSequence());
    }

    private IEnumerator CutsceneSequence()
{
    isCutsceneActive = true;

    // Получаем Rigidbody2D
    playerRigidbody = player.GetComponent<Rigidbody2D>();
    if (playerRigidbody != null)
    {
        // Сохраняем текущие ограничения
        originalConstraints = playerRigidbody.constraints;
        // Замораживаем позицию по X и Y
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    // Переключить камеру на Cinemachine
    cinemachineCam.Priority = 10;

    // Показать полосы и начать анимацию
    yield return StartCoroutine(ShowBlackBars());

    // Показать фразы по очереди
    foreach (var phrase in phrases)
    {
        phraseText.text = phrase;
        phraseText.gameObject.SetActive(true);
        yield return new WaitForSeconds(phraseDisplayTime);
        phraseText.gameObject.SetActive(false);
    }

    // Скрыть полосы
    yield return StartCoroutine(HideBlackBars());

    // Восстановить ограничения Rigidbody2D
    if (playerRigidbody != null)
    {
        playerRigidbody.constraints = originalConstraints;
    }

    // Вернуть приоритет камеры обратно
    cinemachineCam.Priority = 0;

    isCutsceneActive = false;
}

    private IEnumerator ShowBlackBars()
    {
        topBlackBar.SetActive(true);
        bottomBlackBar.SetActive(true);

        float duration = 1f;
        float elapsed = 0f;

        RectTransform topRect = topBlackBar.GetComponent<RectTransform>();
        RectTransform bottomRect = bottomBlackBar.GetComponent<RectTransform>();

        Vector2 topStartPos = new Vector2(0, 200);
        Vector2 topEndPos = new Vector2(0, 0);

        Vector2 bottomStartPos = new Vector2(0, -200);
        Vector2 bottomEndPos = new Vector2(0, 0);

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            topRect.anchoredPosition = Vector2.Lerp(topStartPos, topEndPos, t);
            bottomRect.anchoredPosition = Vector2.Lerp(bottomStartPos, bottomEndPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        topRect.anchoredPosition = topEndPos;
        bottomRect.anchoredPosition = bottomEndPos;
    }

    private IEnumerator HideBlackBars()
    {
        float duration = 1f;
        float elapsed = 0f;

        RectTransform topRect = topBlackBar.GetComponent<RectTransform>();
        RectTransform bottomRect = bottomBlackBar.GetComponent<RectTransform>();

        Vector2 topStartPos = topRect.anchoredPosition;
        Vector2 topEndPos = new Vector2(0, 200);

        Vector2 bottomStartPos = bottomRect.anchoredPosition;
        Vector2 bottomEndPos = new Vector2(0, -200);

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            topRect.anchoredPosition = Vector2.Lerp(topStartPos, topEndPos, t);
            bottomRect.anchoredPosition = Vector2.Lerp(bottomStartPos, bottomEndPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        topRect.anchoredPosition = topEndPos;
        bottomRect.anchoredPosition = bottomEndPos;

        topBlackBar.SetActive(false);
        bottomBlackBar.SetActive(false);
        Panel.SetActive(false);
    }
}
