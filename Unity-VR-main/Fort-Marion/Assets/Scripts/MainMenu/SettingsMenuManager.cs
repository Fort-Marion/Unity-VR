using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    [SerializeField] private Button GraphicsButton;
    [SerializeField] private Button AudioButton;
    [SerializeField] private Button GameplayButton;
    [SerializeField] private Button CancelButton;
    [SerializeField] private Button ConfirmButton;
    void Start()
    {
        var textManager = GameManager.Instance.TextManager;
        GraphicsButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_graphics", "Graphics");
        AudioButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_audio", "Audio");
        GameplayButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_gameplay", "Gameplay");
        CancelButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_cancel", "Cancel");
        ConfirmButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("settings_menu_btn_confirm", "OK");
    }
}
