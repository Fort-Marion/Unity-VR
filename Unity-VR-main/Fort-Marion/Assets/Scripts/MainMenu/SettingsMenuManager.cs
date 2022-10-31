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
    void Start()
    {
        var textManager = GameManager.Instance.TextManager;
        graphicsButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_graphics", "Graphics");
        audioButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_audio", "Audio");
        gameplayButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_gameplay", "Gameplay");
        cancelButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_cancel", "Cancel");
        confirmButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_confirm", "OK");
    }

    public void SaveSettings()
    {
        // TODO Implement this method.
    }

}
