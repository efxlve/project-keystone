using System.Collections;
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
    public float mmsound;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        control();
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        mmsound = PlayerPrefs.GetFloat("VolumeValue");
        Debug.Log("ses sıfırlanmadan önce= " + mmsound);
        SceneManager.LoadScene(startScene);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("VolumeValue", mmsound);

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

 
}
