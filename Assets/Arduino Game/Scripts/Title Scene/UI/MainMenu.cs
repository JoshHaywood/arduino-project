using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
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
