using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider soundSlider;
    public Slider musicSlider;

    private const string SoundPrefKey = "SoundVolume";
    private const string MusicPrefKey = "MusicVolume";

    void Start()
    {
        // Загружаем сохранённые значения или устанавливаем по умолчанию
        soundSlider.value = PlayerPrefs.GetFloat(SoundPrefKey, 1f);
        musicSlider.value = PlayerPrefs.GetFloat(MusicPrefKey, 1f);

        soundSlider.onValueChanged.AddListener(SetSoundVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetSoundVolume(float value)
    {
        PlayerPrefs.SetFloat(SoundPrefKey, value);
        // Тут можно добавить управление звуком эффектов
    }

    public void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(MusicPrefKey, value);
        // Тут можно управлять уровнем музыки
    }
}