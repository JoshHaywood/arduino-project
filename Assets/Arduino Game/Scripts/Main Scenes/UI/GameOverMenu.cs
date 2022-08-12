using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------- VOID MENU FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Menu Function

    /// <summary>
    ///     Function to go back to the menu
    /// </summary>

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene"); //Loads the menu scene
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
