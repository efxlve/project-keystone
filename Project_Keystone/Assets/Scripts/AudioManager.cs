using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundEffects;

    public AudioSource bgm, levelEndMusic, bossMusic;


    public float MainValue;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Text volumeTextUI = null;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        MainValue = MainMenu.instance.mmsound;
        LoadValues();
        volumeSlider.value = MainValue;
        PlayerPrefs.GetFloat("VolumeValue");
    }

    // Update is called once per frame
    void Update()
    {
        VolumeSlider();
        LoadValues();
        SaveVolumeButton();
    }
    
    public void VolumeSlider()
    {
        volumeTextUI.text = volumeSlider.value.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        MainValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", MainValue);
        LoadValues();
    }

    void LoadValues()
    {
        MainValue = PlayerPrefs.GetFloat("VolumeValue");
        AudioListener.volume = MainValue;
        Debug.Log("LoadValues değeri =" + MainValue);  
        
    }



    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(0.9f, 1.1f);

        soundEffects[soundToPlay].Play();
    }


    public void PlayerLevelVictory()
    {
        bgm.Stop();
        levelEndMusic.Play();
    }

    public void PlayBossMusic()
    {
        bgm.Stop();
        bossMusic.Play();
    }

    public void StopBossMusic()
    {
        bossMusic.Stop();
        bgm.Play();
    }
}
