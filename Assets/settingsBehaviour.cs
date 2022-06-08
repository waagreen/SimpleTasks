using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsBehaviour : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Awake()
    {
        LoadValues();
    }

    public void SaveVolumeButton(){
        float volumeValue = volumeSlider.value;

        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    void LoadValues(){
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
