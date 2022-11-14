using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingsMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown graphicsQualityDropdown;
    
    private Dictionary<string, object> settings;
    
    void Start()
    {
        settings = GetComponentInParent<SettingsMenuManager>().Settings;
        var textManager = GameManager.Instance.TextManager;
        graphicsQualityDropdown.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("graphics_menu_dropdown_graphics_quality", "Graphics Quality");
        graphicsQualityDropdown.AddOptions(new List<TMP_Dropdown.OptionData>()
        {
            new TMP_Dropdown.OptionData(textManager.GetTextOrDefault("graphics_menu_graphics_quality_low", "Low")),
            new TMP_Dropdown.OptionData(textManager.GetTextOrDefault("graphics_menu_graphics_quality_medium", "Medium")),
            new TMP_Dropdown.OptionData(textManager.GetTextOrDefault("graphics_menu_graphics_quality_high", "High")),
            new TMP_Dropdown.OptionData(textManager.GetTextOrDefault("graphics_menu_graphics_quality_ultra", "Ultra"))
        });
        graphicsQualityDropdown.value = (int) settings["GraphicsQuality"];
    }

    public void GraphicsQualityDropdown_Updated(int val)
    {
        settings["GraphicsQuality"] = val + 2;
    }
}
