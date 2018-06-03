using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer MasterMixer;
    public AudioMixer MusicMixer;
    public AudioMixer EffectMixer;


    public string nameMasterVolume;
    public string nameMusicVolume;
    public string nameEffectVolume;


    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    
    void Start()
    {
        resolutions = Screen.resolutions;
        
        if (resolutionDropdown.options != null)
            resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        if (options != null)
            resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void SetMasterVolume(float volume)
    {
        MasterMixer.SetFloat(nameMasterVolume, volume);
    }
    
    public void SetMusicVolume(float volume)
    {
        MusicMixer.SetFloat(nameMusicVolume, volume);
    }    
    
    public void SetEffectVolume(float volume)
    {
        EffectMixer.SetFloat(nameEffectVolume, volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
