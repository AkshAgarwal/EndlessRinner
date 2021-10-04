using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    #region Data Members

    //HUD, Pause Menu and Death menu reference reference.
    [Header("Menu references")]
    [SerializeField] private GameObject HUD = null;
    [SerializeField] public GameObject deathMenu;
    [SerializeField] public GameObject pauseMenu = null;


    [Header("Button references")] [SerializeField]
    private GameObject pauseButton;

    [SerializeField] private GameObject restartButton;

    //Singleton reference of the class
    public static MenuManager menuManager;

    #endregion

    #region Menu states

    private void Start()
    {
        if (menuManager == null)
        {
            menuManager = this;
        }

        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            deathMenu.SetActive(false);
            HUD.SetActive(false);
            pauseMenu.SetActive(false);
           
        }
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
       

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }


    }

    public void Quit()
    {
        Debug.Log("Quit Sucessfull");
        Application.Quit();
    }

    public void Pause()
    {

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        HUD.SetActive(false);
        pauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseButton);

    }

    public void Resume()
    {
        Time.timeScale = 1;
        HUD.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    #endregion

    public void DeathMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        HUD.SetActive(false);
        deathMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(restartButton);
    }
}
