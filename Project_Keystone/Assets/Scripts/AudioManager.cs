using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundEffects;

    public AudioSource bgm, levelEndMusic, bossMusic;


    public float MainSound;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Text volumeTextUI = null;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        if (PlayerPrefs.HasKey("SoundVolume")) 
        {
            AudioListener.volume = PlayerPrefs.GetFloat("SoundVolume");
            volumeSlider.value = PlayerPrefs.GetFloat("SoundVolume"); 
        }
        else
        {
            PlayerPrefs.SetFloat("SoundVolume", 1f);
            AudioListener.volume = PlayerPrefs.GetFloat("SoundVolume");
        }

        //Debug.Log("Ana ses " + AudioListener.volume);
    }

    
    void Update()
    {
        //Debug.Log("Güncel Oyun ses seviyesi : " + AudioListener.volume);
       // Debug.Log("Güncel SoundVolume ses seviyesi : " + PlayerPrefs.GetFloat("SoundVolume"));


    }

    public void VolumeSlider()
    {
        volumeTextUI.text = volumeSlider.value.ToString("0.0"); // slider textini değiştiriyor
        PlayerPrefs.SetFloat("SoundVolume", volumeSlider.value); // sliderda değişiklik olduğunda PlayerPrefs'a kaydediyor
        AudioListener.volume = PlayerPrefs.GetFloat("SoundVolume"); // PlayerPrefs'dan alıp ses seviyesini değiştiriyor
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
