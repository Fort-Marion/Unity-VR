using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider;

    private Dictionary<string, object> settings;
    
    void Start()
    {
        settings = GetComponentInParent<SettingsMenuManager>().Settings;
        var textManager = GameManager.Instance.TextManager;
        masterVolumeSlider.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("audio_menu_slider_mastervolume", "Master Volume");

        masterVolumeSlider.value = (float) settings["MasterVolume"];
    }
    
    public void MasterVolumeSlider_Updated(float val)
    {
        settings["MasterVolume"] = val;
    }
}
