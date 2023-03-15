using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_Languages : MonoBehaviour
{
    [HideInInspector] public List<Text> Texts;
    public List<Language> Languages;

    private string selectedLanguage;
    public string SelectedLanguage { get => selectedLanguage; set => selectedLanguage = value; }

    void Start()
    {
        foreach (Text items in Resources.FindObjectsOfTypeAll(typeof(Text)))
        {
            Texts.Add(items);
        }
        Translate(PlayerPrefs.GetString("Language"));
    }

    public void Translate(string selectedLanguage)
    {

        for (int i = 0; i < Languages.Count; i++)
        {
            for (int s = 0; s < Texts.Count; s++)
            {
                if (selectedLanguage == "Turkish")
                {
                    if (Languages[i].English == Texts[s].text)
                    {
                        Texts[s].text = Languages[i].Turkish;
                    }
                }
                else if (selectedLanguage == "English")
                {
                    if (Languages[i].Turkish == Texts[s].text)
                    {
                        Texts[s].text = Languages[i].English;
                    }
                }
            }
        }
        PlayerPrefs.SetString("Language", selectedLanguage);
    }

    public void changeLanguage(string Language)
    {
        PlayerPrefs.SetString("Language", Language);
        SelectedLanguage = Language;
        Translate(SelectedLanguage);
    }


    [System.Serializable]
    public class Language
    {
        public string Turkish;
        public string English;

        public Language(string turkish, string english)
        {
            Turkish = turkish;
            English = english;
        }
    }

}
