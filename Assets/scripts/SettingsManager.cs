using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider soundSlider;
    public Slider musicSlider;

    public AudioSource effectsAudioSource; // источник для эффектов
    public AudioSource musicAudioSource;   // источник для музыки

    private const string SoundPrefKey = "SoundVolume";
    private const string MusicPrefKey = "MusicVolume";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Загружаем сохранённые значения или устанавливаем по умолчанию
        float savedSoundVolume = PlayerPrefs.GetFloat(SoundPrefKey, 1f);
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicPrefKey, 1f);

        // Если есть слайдеры (например, в главном меню), подключаем их
        if (soundSlider != null)
        {
            soundSlider.value = savedSoundVolume;
            soundSlider.onValueChanged.AddListener(SetSoundVolume);
        }

        if (musicSlider != null)
        {
            musicSlider.value = savedMusicVolume;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        // Устанавливаем уровни громкости для аудиоисточников
        if (effectsAudioSource != null)
            effectsAudioSource.volume = savedSoundVolume;
        if (musicAudioSource != null)
            musicAudioSource.volume = savedMusicVolume;
    }

    public void SetSoundVolume(float value)
    {
        PlayerPrefs.SetFloat(SoundPrefKey, value);
        if (effectsAudioSource != null)
            effectsAudioSource.volume = value;
    }

    public void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(MusicPrefKey, value);
        if (musicAudioSource != null)
            musicAudioSource.volume = value;
    }
}
