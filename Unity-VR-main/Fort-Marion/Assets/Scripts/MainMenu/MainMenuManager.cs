using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button ExploreButton;
    [SerializeField] private Button TourButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button ExitButton;
    void Start()
    {
        var textManager = GameManager.Instance.TextManager;
        ExploreButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("main_menu_btn_start", "Explore Fort");
        TourButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("main_menu_btn_tour", "Tour Fort");
        SettingsButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("main_menu_btn_settings", "Settings");
        ExitButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("main_menu_btn_exit", "Quit");
    }
}
