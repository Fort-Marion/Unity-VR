using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapViewMenuManager : MonoBehaviour
{
    [SerializeField] private Button backButton;

    void Start()
    {
        var textManager = GameManager.Instance.TextManager;
        backButton.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("mapview_menu_btn_back", "Back");
    }
}
