using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSettings : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------- VARIABLE DECLARATION -----------------------------------------------------------------------------------------------

    #region Variable Declaration

    /// <summary>
    ///     Variable declaration
    /// </summary>
    /// <param name="lifeDuration">
    ///     How long the prefabs live for before being destroyed
    /// </param>
    /// <param name="lifeTimer">
    ///     Timer to support the life duration function
    /// </param>
    /// <param name="rend">
    ///     renderer used for the object
    /// </param>
    /// <param name="currentColour">
    ///     Varible to store the current material colour
    /// </param>

    [Header("Lifetime settings")]
    public float lifeDuration;
    private float lifeTimer;

    private Renderer rend;

    [Header("Material settings")]
    public Color currentColour;
    public Color lerpedRed, lerpedBlue, lerpedGreen, lerpedYellow;

    [Header("Lerp Settings")]
    public float lerpDuration;
    private float lerpTime;

    #endregion

    //----------------------------------------------------------------------------------------------- VOID START FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Start Function

    /// <summary>
    ///     Function called at the start of each frame
    /// </summary>

    void Start()
    {
        lifeTimer = lifeDuration; //Sets timer to be duration

        rend = GetComponent<Renderer>(); //sets component to be objects renderer  

        currentColour = GetComponent<Renderer>().material.color; //Sets the current colour as the material colour
    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID UPDATE FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Update Function

    /// <summary>
    ///     Update function that is called once per frame
    /// </summary>

    void Update()
    {
        LifeTime(); //Lifetime function call

        Lerp();  //Lerp function call
    }

    #endregion

    //----------------------------------------------------------------------------------------------- LIFETIME FUNCTION-----------------------------------------------------------------------------------------------

    #region LifeTime Function

    /// <summary>
    ///     Function for the lifetime of the object
    /// </summary>

    void LifeTime()
    {
        lifeTimer -= Time.deltaTime; //Timer will decrease by one second on each function call

        //If the timer is less than or equal to 0 the object is destroyed
        if (lifeTimer <= 0)
        {
            lifeTimer = lifeDuration;
            Destroy(gameObject);
        }
    }

    #endregion

    //----------------------------------------------------------------------------------------------- LERP FUNCTION-----------------------------------------------------------------------------------------------

    #region Lerp Function

    /// <summary>
    ///     Function to lerp from one colour to another
    /// </summary>
    
    void Lerp()
    {
        if(currentColour == Color.red)
        {
            if (lerpTime < lerpDuration) //If lerptime is less than the duration
            {
                rend.material.color = Color.Lerp(currentColour, lerpedRed, lerpTime / lerpDuration); //Lerp material colour from current colour to lerped colour by the duration

                lerpTime += Time.deltaTime; //Increases lerp time by one a second
            }
        }

        else if (currentColour == Color.green)
        {
            if (lerpTime < lerpDuration) //If lerptime is less than the duration
            {
                rend.material.color = Color.Lerp(currentColour, lerpedGreen, lerpTime / lerpDuration); //Lerp material colour from current colour to lerped colour by the duration

                lerpTime += Time.deltaTime; //Increases lerp time by one a second
            }
        }

        else if (currentColour == Color.blue)
        {
            if (lerpTime < lerpDuration) //If lerptime is less than the duration
            {
                rend.material.color = Color.Lerp(currentColour, lerpedBlue, lerpTime / lerpDuration); //Lerp material colour from current colour to lerped colour by the duration

                lerpTime += Time.deltaTime; //Increases lerp time by one a second
            }   
        }

        else if (currentColour == Color.yellow)
        {
            if (lerpTime < lerpDuration) //If lerptime is less than the duration
            {
                rend.material.color = Color.Lerp(currentColour, lerpedYellow, lerpTime / lerpDuration); //Lerp material colour from current colour to lerped colour by the duration

                lerpTime += Time.deltaTime; //Increases lerp time by one a second
            }
        }
    }

    #endregion
}
