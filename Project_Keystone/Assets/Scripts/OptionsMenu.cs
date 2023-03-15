using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    /*
    Main menu ayarlar bölümü.
    */

    public GameObject title, btnContinue, btnNewGame, btnQuit, language, btnTurkish, btnEnglish, soundSlider, soundTitle;
    public bool isOptions;


    void Start()
    {

    }
    
    void Update()
    {
        
    }


    public void OptionsMenuBtn()
    {
        if (isOptions)
        {
            isOptions = false;
            title.SetActive(false);
            btnNewGame.SetActive(false);
            btnQuit.SetActive(false);
            btnContinue.SetActive(false);


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
            title.SetActive(true);
            btnContinue.SetActive(true);
            btnNewGame.SetActive(true);
            btnQuit.SetActive(true);


            language.SetActive(false);
            btnTurkish.SetActive(false);
            btnEnglish.SetActive(false);
            soundSlider.SetActive(false);
            soundTitle.SetActive(false);
            //Debug.Log("Options menu is closed");

        }


        

    }
}
