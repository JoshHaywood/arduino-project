using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuSettings : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------- VARIABLE DECLARATION -----------------------------------------------------------------------------------------------

    #region Variable Declaration

    /// <summary>
    ///     Variable declaration
    /// </summary>
    /// <param name="pauseMenu">
    ///     Links the pause menu to the UI canvas
    /// </param>
    /// <param name="pause">
    ///     keycode used for pausing
    /// </param>
    /// <param name="buttonCanvas">
    ///     Gameobject for the button canvas
    /// </param>
    /// <param name="switchCanvas">
    ///     Gameobject for the switch canvas
    /// </param>
    /// <param name="photosensorCanvas">
    ///     Gameobject for the photosensor canvas
    /// </param>
    /// <param name="accelometerCanvas">
    ///     Gameobject for the accleometer canvas
    /// </param>
    /// <param name="timerBar">
    ///     Gameobject for the timer's bar
    /// </param>
    /// <param name="timerText">
    ///     Gameobject for the timer text
    /// </param>
    /// <param name="scoreText">
    ///     Gameobject for the score text
    /// </param>
    /// <param name="buttonPrefab">
    ///     Gameobject for the button prefab
    /// </param>
    /// <param name="switchPrefab">
    ///     Gameobject for the switch prefab
    /// </param>
    /// <param name="photosensorPrefab">
    ///     Gameobject for the photosensor prefab
    /// </param>
    /// <param name="accelometerPrefab">
    ///     Gameobject for the accleometer prefab
    /// </param>
    /// <param name="spawnPoint">
    ///     Gameobject for the spawn point
    /// </param>
    /// <param name="isPaused">
    ///     Variable for if the game is in a paused state
    /// </param>

    [Header("UI elements")]
    public GameObject pauseMenu;
    public KeyCode pause;
    public GameObject buttonCanvas;
    public GameObject switchCanvas;
    public GameObject photosensorCanvas;
    public GameObject accelometerCanvas;
    public GameObject timeBar;
    public GameObject timerText;
    public GameObject scoreText;
    public GameObject buttonPrefab;
    public GameObject switchPrefab;
    public GameObject photosensorPrefab;
    public GameObject accelometerPrefab;
    public GameObject spawnPoint;

    [Header("Pause settings")]
    public bool isPaused = false; //Set to false by default

    #endregion

    //----------------------------------------------------------------------------------------------- VOID START FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Start Function

    /// <summary>
    ///     Function called at the start of each frame
    /// </summary>

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID UPDATE FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Update Function

    /// <summary>
    ///     Update function that is called once per frame
    /// </summary>

    void Update()
    {
        if (Input.GetKeyDown(pause)) //If the pause key is down
        {
            if (isPaused == true) //Paused state is true
            {
                Resume(); //Runs resume function
            }
            else
            {
                Pause(); //Else runs paused function
            }
        }
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID RESUME FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Resume Function

    /// <summary>
    ///     Function to resume the game when paused
    /// </summary>
    public void Resume()
    {
        pauseMenu.SetActive(false); //Sets the pause menu to inactive

        //Sets GameObjects to true on resume
        buttonCanvas.SetActive(true);
        switchCanvas.SetActive(true);
        photosensorCanvas.SetActive(true);
        accelometerCanvas.SetActive(true);

        timeBar.SetActive(true);
        timerText.SetActive(true);
        scoreText.SetActive(true);

        buttonPrefab.SetActive(true);
        switchPrefab.SetActive(true);
        photosensorPrefab.SetActive(true);
        accelometerPrefab.SetActive(true);

        spawnPoint.SetActive(true);

        isPaused = false; //Sets is paused to false
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID PAUSE FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Pause Function

    /// <summary>
    ///     Function to pause the game
    /// </summary>
    public void Pause()
    {
        pauseMenu.SetActive(true); //Sets the pause menu to active

        //Sets GameObjects to false on pause
        buttonCanvas.SetActive(false);
        switchCanvas.SetActive(false);
        photosensorCanvas.SetActive(false);
        accelometerCanvas.SetActive(false);

        timeBar.SetActive(false);
        timerText.SetActive(false);
        scoreText.SetActive(false);

        buttonPrefab.SetActive(false);
        switchPrefab.SetActive(false);
        photosensorPrefab.SetActive(false);
        accelometerPrefab.SetActive(false);

        spawnPoint.SetActive(false);

        isPaused = true; //Sets is paused to true
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID MENU FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Menu Function

    /// <summary>
    ///     Function to go back to the menu
    /// </summary>

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene"); // Loads the menu scene
        Time.timeScale = 1f; //Sets time to normal time scale
        isPaused = false; //Sets is paused to false
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID QUIT GAME FUNCTION -----------------------------------------------------------------------------------------------

    #region Void QuitGame Function

    /// <summary>
    ///     Function to quit the game
    /// </summary>
     
    public void QuitGame()
    {
        Application.Quit(); // Quits out of the application if the game has been built
    }

    #endregion
}