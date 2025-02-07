using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("soundVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            LoadMusicVolume();
        }


        if(PlayerPrefs.HasKey("soundVolume"))
        {
            LoadSoundVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            LoadSoundVolume();
        }
    }

    // Update is called once per frame
    public void SetMusicVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveMusicVolume();
    }
    public void SaveMusicVolume()
    {
        PlayerPrefs.SetFloat("soundVolume", volumeSlider.value);
    }
    public void LoadMusicVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }


    public void SetSoundVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveSoundVolume();
    }
    public void SaveSoundVolume()
    {
        PlayerPrefs.SetFloat("soundVolume", volumeSlider.value);
    }
    public void LoadSoundVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }
}
