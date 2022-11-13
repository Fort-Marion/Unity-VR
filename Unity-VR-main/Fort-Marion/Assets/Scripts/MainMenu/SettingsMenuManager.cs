using System;
using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    [SerializeField] private Button graphicsButton;
    [SerializeField] private Button audioButton;
    [SerializeField] private Button gameplayButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button confirmButton;
    
    public Dictionary<string, object> Settings;

    private void Awake()
    {
        InitializeSettings();
    }

    void Start()
    {
        var textManager = GameManager.Instance.TextManager;
        graphicsButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_graphics", "Graphics");
        audioButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_audio", "Audio");
        gameplayButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_gameplay", "Gameplay");
        cancelButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_cancel", "Cancel");
        confirmButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_confirm", "OK");
        
    }

    /**
     * Initializes Settings by loading in the values stored in PlayerPrefs.
     */
    private void InitializeSettings()
    {
        Settings = new Dictionary<string, object>
        {
            { "MasterVolume", PlayerPrefs.HasKey("MasterVolume") ? PlayerPrefs.GetFloat("MasterVolume") : 100f },
            { "GraphicsQuality", PlayerPrefs.HasKey("GraphicsQuality") ? PlayerPrefs.GetInt("GraphicsQuality") : 0 },
            { "Subtitles", PlayerPrefs.HasKey("Subtitles") ? PlayerPrefs.GetInt("SubTitles") : 0 }
        };
    }

    public void Cancel()
    {
        // Reset settings back to what is in PlayerPrefs
        InitializeSettings();
    }

    public void SaveSettings()
    {
        UpdatePlayerPrefs();
        PlayerPrefs.Save();
        ApplySettings();
    }

    /**
     * Updates PlayerPrefs to the values stored in the Settings Dictionary.
     */
    private void UpdatePlayerPrefs()
    {
        foreach (var kvp in Settings)
        {
            switch (kvp.Value)
            {
                case int intVal:
                    PlayerPrefs.SetInt(kvp.Key, intVal);
                    break;
                case float floatVal:
                    PlayerPrefs.SetFloat(kvp.Key, floatVal);
                    break;
                case string stringVal:
                    PlayerPrefs.SetString(kvp.Key, stringVal);
                    break;
            }
        }
    }

    /**
     * Applies settings stored in PlayerPrefs.
     */
    private void ApplySettings()
    {
        AudioListener.volume = PlayerPrefs.HasKey("MasterVolume") ? PlayerPrefs.GetFloat("MasterVolume") : 100f;
        QualitySettings.SetQualityLevel(PlayerPrefs.HasKey("GraphicsQuality") ? PlayerPrefs.GetInt("GraphicsQuality") : 0);
    }

}
