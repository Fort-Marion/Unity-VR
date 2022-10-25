using System.Collections;
using System.Collections.Generic;
using FortMarion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider;
    void Start()
    {
        var textManager = GameManager.Instance.TextManager;
        masterVolumeSlider.GetComponentInChildren<TextMeshProUGUI>().text = textManager.GetTextOrDefault("audio_menu_slider_mastervolume", "Master Volume");
    }
    
    public void MasterVolumeSlider_Updated(float val)
    {
        AudioListener.volume = val;
    }
}
