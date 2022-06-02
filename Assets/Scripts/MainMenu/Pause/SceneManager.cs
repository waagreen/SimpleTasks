using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject optinons;
    [SerializeField] GameObject pauseText;
    [SerializeField] GameObject optionsScreen;
    [SerializeField] Slider volumeSlider = null;
    [SerializeField] TextMeshProUGUI volumeText = null;
    [HideInInspector] public bool isPaused = false;

    void Awake(){
        LoadValues();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(!isPaused)  PauseGame();
            
        }
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; //stop animations, updates 
        Core.Binds.mLook.XYAxis = Core.Binds.mZero;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPaused = true;
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Core.Binds.mLook.XYAxis = Core.Binds.mFollow;
        Cursor.visible = false;
        isPaused = false;
    }

    public void SettingsGame(){
        pauseText.SetActive(false);
        buttons.SetActive(false);
        optionsScreen.SetActive(true);
        
    }

    public void BackToMenu(){
        optionsScreen.SetActive(false);
        pauseText.SetActive(true);
        buttons.SetActive(true);
    }

    public void VolumeSlider(float volume){
        volumeText.text = volume.ToString("0.0");
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
