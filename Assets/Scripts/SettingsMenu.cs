using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropDown;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        // clear out all the options in our resolution dropdown
        resolutionDropDown.ClearOptions();

        // create a list of strings
        List<string> options = new List<string>();

        // create variable for correct default resolution
        int currentResolutionIndex = 0;

        // loop through each element in our resolutions array
        for (int i = 0; i < resolutions.Length; i++)
        {
            // for each element we create a formatted string that displays the resolution
            string option = resolutions[i].width + " x " + resolutions[i].height;
            // add the resolution to the list
            options.Add(option);

            // compares the current resolution in the list to the screen's current resolution (by looking at the width and height becuase you can't compare resolutions)
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // adds the options list to resolutions dropdown
        resolutionDropDown.AddOptions(options);

        // sets the default screen resolution to the proper resolution
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
