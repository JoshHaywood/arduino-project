using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------- VARIABLE DECLARATION -----------------------------------------------------------------------------------------------

    #region Variable Declaration

    /// <summary>
    ///     Variable declaration
    /// </summary>
    /// <param name="audioMixer">
    ///     Variable for the AudioMixer
    /// </param>
    /// <param name="graphicsDropdown">
    ///     Dropdown for graphics
    /// </param>
    /// <param name="resolutionDropdown">
    ///     Dropdown for resoultion
    /// </param>
    /// <param name="resolutions">
    ///     Variable to store resoultions
    /// </param>

    [Header("Audio Settings")]
    public AudioMixer audioMixer;

    [Header("UI elements")]
    public TMP_Dropdown graphicsDropdown;
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    #endregion

    //----------------------------------------------------------------------------------------------- VOID START FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Start Function

    /// <summary>
    ///     Function called at the start of each frame
    /// </summary>
    /// <param name="options">
    ///     List to hold all availble drop down options
    /// </param>
    /// <param name="currentResolutionIndex">
    ///     Variable to store the current resolution on start
    /// </param>
    /// <param name="option">
    ///     Variable to store dropdown options
    /// </param>

    void Start()
    {
        resolutions = Screen.resolutions; //Sets resoultion to current screen resoultion

        resolutionDropdown.ClearOptions(); //Clears options from dropdown

        List<string> options = new List<string>(); //Creates new list to hold resolutions dimesions

        int currentResolutionIndex = 0; //Sets indec to 0 on start

        for (int i = 0; i < resolutions.Length; i++) //Itterations through resolution lengths
        {
            string option = resolutions[i].width + "x" + resolutions[i].height; //Creates an option from the resoultion length and height
            options.Add(option); //Adds this options list

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) //If current resoultion is equal to screen resoultion 
            {
                currentResolutionIndex = i; //Sets resoultion to current index value
            }
        }

        resolutionDropdown.AddOptions(options); //Adds all option in the list to the dropdown
        resolutionDropdown.value = currentResolutionIndex; //Sets dropdown to current resoultion
        resolutionDropdown.RefreshShownValue(); //Refreshes dropdown values
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID SET VOLUME FUNCTION -----------------------------------------------------------------------------------------------

    #region Void SetVolume Function

    /// <summary>
    ///     Function to set the volume of the audio mixer
    /// </summary>
    /// <param name="volume">
    ///     Variable to store the volume
    /// </param

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20); //Sets the audio mixer value as the sliders value
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID SET QUALITY FUNCTION -----------------------------------------------------------------------------------------------

    #region Void SetQuality Function

    /// <summary>
    ///     Function to set the quality of game
    /// </summary>
    /// <param name="qualityIndex">
    ///     Variable for acessing the projects quality settings
    /// </param
    
    public void SetQuality(int qualityIndex)
    {
        qualityIndex = graphicsDropdown.value;
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID SET FULL SCREEN FUNCTION -----------------------------------------------------------------------------------------------

    #region Void SetFullScreen Function

    /// <summary>
    ///     Function to set fullscreen
    /// </summary>
    /// <param name="isFullScreen">
    ///     Bool to state if the screen is currently fullscreen
    /// </param
    
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID SET Resolution FUNCTION -----------------------------------------------------------------------------------------------

    #region Void SetResolution Function

    /// <summary>
    ///     Function to set resoultion
    /// </summary>
    /// <param name="resolutionIndex">
    ///     Variable to hold resolution index
    /// </param

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex]; //Sets resolution value to resolution index value
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //Sets resolution
    }

    #endregion
}

