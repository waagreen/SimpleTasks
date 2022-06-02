using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{   
    public Animator transition;
    public float transitionDuration;
    [SerializeField] private bool isOnMenu;

    [Header("Menu Buttons")]
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject optionsScreen;
    [SerializeField] AudioSource volume;
    [HideInInspector] public bool isPaused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isOnMenu){
            if(!isPaused)  PauseGame();

        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        
        if(!isOnMenu)
        {
            Time.timeScale = 0f; //stop animations, updates 
            Core.Binds.mLook.XYAxis = Core.Binds.mZero;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        
        if(!isOnMenu)
        {
            Time.timeScale = 1f;
            Core.Binds.mLook.XYAxis = Core.Binds.mFollow;
            Cursor.visible = false;
        }

        isPaused = false;
    }

    public void SettingsGame(){
        buttons.SetActive(false);
        optionsScreen.SetActive(true);
    }

    IEnumerator BackLevel() 
    {
        Time.timeScale = 1f;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionDuration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator LoadLevel() 
    {
        Time.timeScale = 1f;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionDuration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadCredits()
    {
        Time.timeScale = 1f;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionDuration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Forward() => StartCoroutine(LoadLevel());
    public void Backwards() => StartCoroutine(BackLevel());
    public void Credits() => StartCoroutine(LoadCredits());
    
    public void QuitGame()
    {   
        Time.timeScale = 1f;
        Application.Quit();
    }
}
