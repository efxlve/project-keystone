﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    public string startScene, continueScene;

    public Button continueButton;
    public Text textContinue;
    public float MainSound;
    public string language;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        control();
    }

    void Update()
    {
        
    }

    public void NewGame()
    {
        MainSound = PlayerPrefs.GetFloat("SoundVolume"); //Ses seviyesi silinmeden önce değerini alıyoruz
        //Debug.Log("Ana ses silinmeden önce: " + MainSound);
        language = PlayerPrefs.GetString("Language"); //Dil seviyesi silinmeden önce değerini alıyoruz

        SceneManager.LoadScene(startScene);
        PlayerPrefs.DeleteAll(); 

        
        PlayerPrefs.SetFloat("SoundVolume", MainSound); //Ses seviyesini geri yüklüyoruz
        //Debug.Log("Ana ses silinmeden sonra: " + MainSound);
        PlayerPrefs.SetString("Language", language); //Dil seviyesini geri yüklüyoruz

    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(continueScene);
    }

    public void QuitGame()
    {
        
        Application.Quit();
        Debug.Log("Quitting Game");
    }


    void control()
    {
        if (PlayerPrefs.HasKey(startScene + "_unlocked"))
        {
            continueButton.interactable = true;
            continueButton.GetComponent<Image>().color = Color.white;
            textContinue.GetComponent<Text>().color = Color.white;
        }
        else
        {
            continueButton.interactable = false;
            continueButton.GetComponent<Image>().color = Color.grey;
            textContinue.GetComponent<Text>().color = Color.gray;
        }
    }
}
