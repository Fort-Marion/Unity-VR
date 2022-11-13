using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySettingsMenu : MonoBehaviour
{
    [SerializeField] private Toggle subtitlesToggle;
    
    private Dictionary<string, object> settings;
    
    void Start()
    {
        settings = GetComponentInParent<SettingsMenuManager>().Settings;
        var textManager = GameManager.Instance.TextManager;
        subtitlesToggle.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("gameplay_menu_toggle_subtitles", "Subtitles");

        subtitlesToggle.isOn = (int) settings["Subtitles"] == 1;
    }
    
    public void SubtitlesToggle_Updated(bool val)
    {
        settings["Subtitles"] = val ? 1 : 0;
    }
}
