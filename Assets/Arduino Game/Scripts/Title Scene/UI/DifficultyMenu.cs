using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{

    //----------------------------------------------------------------------------------------------- VOID PLAY EASY FUNCTION -----------------------------------------------------------------------------------------------

    #region Void PlayGame Function

    /// <summary>
    ///     Function to play easy difficult
    /// </summary>

    public void PlayEasy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads the next scene as shown in the build settings
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID PLAY MEDIUM FUNCTION -----------------------------------------------------------------------------------------------

    #region Void PlayGame Function

    /// <summary>
    ///     Function to play medium difficult
    /// </summary>

    public void PlayMedium()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //Loads the next scene as shown in the build settings
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID PLAY HARD FUNCTION -----------------------------------------------------------------------------------------------

    #region Void PlayGame Function

    /// <summary>
    ///     Function to play hard difficult
    /// </summary>

    public void PlayHard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3); //Loads the next scene as shown in the build settings
    }

    #endregion
}
