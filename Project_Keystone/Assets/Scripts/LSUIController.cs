using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSUIController : MonoBehaviour
{
    public static LSUIController instance;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject levelInfoPanel;
    
    public Text levelName, gemsFound, gemsTarget, bestTime, timeTarget;

    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    public void ShowInfo(MapPoint levelInfo)
    {
        //string Language = MainMenu_Languages.Instance.GetLanguage();
        string Language = PlayerPrefs.GetString("Language");
        if (Language == "Turkish")
        {
            ShowInfoTR(levelInfo);
        }
        
        else
        {
            ShowInfoEN(levelInfo);
        }

        
    }

    public void ShowInfoEN(MapPoint levelInfo)
    {
        levelName.text = levelInfo.levelName;

        gemsFound.text = "FOUND: " + levelInfo.gemsCollected;
        gemsTarget.text = "IN LEVEL: " + levelInfo.totalGems;

        timeTarget.text = "TARGET: " + levelInfo.targetTime + "s";

        if (levelInfo.bestTime == 0)
        {
            bestTime.text = "BEST: ----";
        }
        else
        {
            bestTime.text = "BEST: " + levelInfo.bestTime.ToString("F2") + "s";
        }

        levelInfoPanel.SetActive(true);
    }

    public void ShowInfoTR(MapPoint levelInfo)
    {
        string found = "BULUNDU: ",
        inLevel = "SEVIYE ICINDE: ",
        target = "HEDEF: ",
        best0 = "EN IYI: ----",
        best1 = "EN IYI: ",
        sn = "sn";

        string levelText = levelInfo.levelName;

        if (levelText == "1 - The Beginning")
        {
            levelName.text = "1 - Baslangic";
        }
        else if (levelText == "2 - High Jump")
        {
            levelName.text = "2 - Yuksek Atlayis";
        }
        else if (levelText == "3 - More Jumping")
        {
            levelName.text = "3 - Daha Fazla Zipla";
        }
        else if (levelText == "4 - Zero Point")
        {
            levelName.text = "4 - Sifir Noktasi";
        }
        else if (levelText == "5 - You Better Watch Out")
        {
            levelName.text = "5 - Dikkat Etsen Iyi Olur";
        }
        else if (levelText == "6 - Top Secret")
        {
            levelName.text = "6 - Cok Gizli";
        }
        else if (levelText == "7 - Splashdown")
        {
            levelName.text = "7 - Sicrama";
        }
        else if (levelText == "8 - Darkness Rises")
        {
            levelName.text = "8 - Karanlik Yukseliyor";
        }
        else if (levelText == "9 - Out of Time")
        {
            levelName.text = "9 - Zaman Doldu";
        }
        else if (levelText == "10 - THE END")
        {
            levelName.text = "10 - SON";
        }

        gemsFound.text = found + levelInfo.gemsCollected;
        gemsTarget.text = inLevel + levelInfo.totalGems;

        timeTarget.text = target + levelInfo.targetTime + "s";

        if (levelInfo.bestTime == 0)
        {
            bestTime.text = best0;
        }
        else
        {
            bestTime.text = best1 + levelInfo.bestTime.ToString("F2") + sn;
        }

        levelInfoPanel.SetActive(true);
    }

    public void HideInfo()
    {
        levelInfoPanel.SetActive(false);
    }



}
