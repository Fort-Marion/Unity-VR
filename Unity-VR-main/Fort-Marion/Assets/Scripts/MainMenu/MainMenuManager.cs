using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button exploreButton;
    [SerializeField] private Button tourButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;
    void Start()
    {
        var textManager = GameManager.Instance.TextManager;
        exploreButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("main_menu_btn_start", "Explore Fort");
        tourButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("main_menu_btn_tour", "Tour Fort");
        settingsButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("main_menu_btn_settings", "Settings");
        exitButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("main_menu_btn_exit", "Quit");
    }

    public void OnExploreButton_Clicked()
    {
        SceneManager.LoadScene("Fort");
    }
    public void OnExitButton_Clicked()
    {
        Application.Quit();
    }
}
