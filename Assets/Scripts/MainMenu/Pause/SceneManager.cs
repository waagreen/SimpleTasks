using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject optinons;
    [HideInInspector] public bool isPaused = false;
    

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
        isPaused = true;
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Core.Binds.mLook.XYAxis = Core.Binds.mFollow;
        isPaused = false;
    }
}
