using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingsMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown textureQualityDropdown;
    void Start()
    {
        var textManager = GameManager.Instance.TextManager;
        textureQualityDropdown.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("graphics_menu_dropdown_texture_quality", "Texture Quality");
        textureQualityDropdown.AddOptions(new List<TMP_Dropdown.OptionData>()
        {
            new TMP_Dropdown.OptionData(textManager.GetTextOrDefault("graphics_menu_texture_quality_high", "High")),
            new TMP_Dropdown.OptionData(textManager.GetTextOrDefault("graphics_menu_texture_quality_medium", "Medium")),
            new TMP_Dropdown.OptionData(textManager.GetTextOrDefault("graphics_menu_texture_quality_low", "Low")),
        });
        textureQualityDropdown.value = 0; // TODO Update this to keep track of option state
    }
}
