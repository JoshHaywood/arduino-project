using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroScreen : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------- VARIABLE DECLARATION -----------------------------------------------------------------------------------------------

    #region Variable Declaration

    /// <summary>
    ///     Variable declaration
    /// </summary>
    /// <param name="UI">
    ///     Gameobject used for the UI menu
    /// </param>
    /// <param name="spawn">
    ///     Gameobject used for the spawn menu
    /// </param>
    /// <param name="mainThemeAudio">
    ///     Gameobject for the mainThemeAudio
    /// </param>
    /// <param name="introTextUI">
    ///     Gameobject for the intro text UI
    /// </param>
    /// <param name="introText">
    ///     Text used for the intro UI
    /// </param>

    [Header("Objects")]
    public GameObject UI;
    public GameObject spawn;
    public GameObject mainThemeAudio;

    [Header("UI elements")]
    public GameObject introTextUI;
    public TMP_Text introText;

    #endregion

    //----------------------------------------------------------------------------------------------- VOID START FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Start Function

    /// <summary>
    ///     Function called at the start of each frame
    /// </summary>

    void Start()
    {
        introTextUI.SetActive(true); //Sets the pause menu to active

        mainThemeAudio.SetActive(false); //Sets mainThemeAudio to false
        UI.SetActive(false); //Sets the pause menu to false
        spawn.SetActive(false); //Sets the spawn to false

        StartCoroutine(CountDown()); //Starts countdown coroutine
    }

    #endregion

    //----------------------------------------------------------------------------------------------- COUNTDOWN COROUTINE -----------------------------------------------------------------------------------------------

    #region CountDown Coroutine

    /// <summary>
    ///     Coroutine for the countdown
    /// </summary>

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1); //Waits for 1 second
        introText.text = "2"; //Text changes to 2
        yield return new WaitForSeconds(1); //Waits for 1 second
        introText.text = "1"; //Text changes to 1
        yield return new WaitForSeconds(1); //Waits for 1 second
        introText.text = "START"; //Text changes to START
        yield return new WaitForSeconds(1); //Waits for 1 second

        introTextUI.SetActive(false); //Sets the pause menu to active

        mainThemeAudio.SetActive(true); //Sets mainThemeAudio to active
        UI.SetActive(true); //Sets the pause menu to active
        spawn.SetActive(true); //Sets the spawn to active
    }

    #endregion
}
