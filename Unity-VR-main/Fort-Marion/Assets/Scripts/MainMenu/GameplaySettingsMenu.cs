using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySettingsMenu : MonoBehaviour
{
    [SerializeField] private Toggle leftHandedToggle;
    
    private Dictionary<string, object> settings;
    
    void Start()
    {
        settings = GetComponentInParent<SettingsMenuManager>().Settings;
        var textManager = GameManager.Instance.TextManager;
        leftHandedToggle.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("gameplay_menu_toggle_lefthanded", "Left-Hand Dominate");
    }
    
    public void LeftHandedToggle_Updated(bool val)
    {
        // TODO implement this
    }
}
