using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /*
    Oyun içi ayarlar bölümü
    */
    public static PauseMenu instance;
    public string levelSelect, mainMenu;

    public GameObject pauseScreen, btnResume, btnLevelSelect, btnMainMenu, pauseTitle, language, btnTurkish, btnEnglish, soundSlider, soundTitle;
    public bool isPaused, isOptions, isEnd;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isEnd = false;
    }

    void Update()
    {
        if (!isEnd == true) //Sona geldiyse pause menüsü açılmaz.
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                PauseUnpause(); //pause menüsü açılır
            }
        }
        
    }

    public void PauseUnpause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f; //oyunu duraklatır.
            isOptions = false;
            OptionsMenu();  //ayarlar menusunde kalmaması için.
        }
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1.0f;
    }

    public void OptionsMenu()
    {
        if (isOptions)
        {
            isOptions = false;
            pauseTitle.SetActive(false);
            btnLevelSelect.SetActive(false);
            btnMainMenu.SetActive(false);
            btnResume.SetActive(false);


            language.SetActive(true);
            btnTurkish.SetActive(true);
            btnEnglish.SetActive(true);
            soundSlider.SetActive(true);
            soundTitle.SetActive(true);
            //Debug.Log("Options menu is opened");

        }
        else
        {
            isOptions = true;
            pauseTitle.SetActive(true);
            btnLevelSelect.SetActive(true);
            btnMainMenu.SetActive(true);
            btnResume.SetActive(true);


            language.SetActive(false);
            btnTurkish.SetActive(false);
            btnEnglish.SetActive(false);
            soundSlider.SetActive(false);
            soundTitle.SetActive(false);
            //Debug.Log("Options menu is closed");
        }
    }

}
