using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Uduino;

public class SymbolMainHard : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------- VARIABLE DECLARATION -----------------------------------------------------------------------------------------------

    #region Variable Declaration

    /// <summary>
    ///     Variable declaration
    /// </summary>
    /// <param name="buttonCanvas">
    ///     Gameobject for the button canvas
    /// </param>
    /// <param name="switchCanvas">
    ///     Gameobject for the switch canvas
    /// </param>
    /// <param name="photoResistorCanvas">
    ///     Gameobject for the photosensor canvas
    /// </param>
    /// <param name="accelometerCanvas">
    ///     Gameobject for the accleometer canvas
    /// </param>
    /// <param name="scoreTextUI">
    ///     Gameobject for the scores UI
    /// </param>
    /// <param name="scoreText">
    ///     Gameobject for the score text
    /// </param>
    /// <param name="gameOverScoreTextUI">
    ///     Gameobject for the final scores UI
    /// </param>
    /// <param name="gameOverscoreText">
    ///     Gameobject for the final score text
    /// </param>
    /// <param name="slider">
    ///     Links UI slider to timer 
    /// </param>
    /// <param name="timerText">
    ///     Links UI text to timer
    /// </param>
    /// <param name="UIcanvas">
    ///     Gameobject for the UI canvas
    /// </param>
    /// <param name="gameOverUI">
    ///     Gameobject for the gameOverUI
    /// </param>
    /// <param name="mainThemeAudio">
    ///     Gameobject for the mainThemeAudio
    /// </param>
    /// <param name="gameOverAudio">
    ///     Gameobject for the gameOverAudio
    /// </param>
    /// <param name="audioSource">
    ///     Gameobject for audio source
    /// </param>
    /// <param name ="spawnPointTransform" >
    ///     Transform used for spawn point
    /// </param>
    /// <param name ="spawnPoint" >
    ///     GameObject used for spawn point
    /// </param>
    /// <param name="prefab">
    ///     Gameobject used to store prefab
    /// </param>
    /// <param name="spawnTime">
    ///     Amount of time the object is spawned for 
    /// </param>
    /// <param name="currentSpawnTime">
    ///     Amount of time left until spawn
    /// </param>
    /// <param name="prefabArray">
    ///     Array of prefabs
    /// </param>
    /// <param name="score">
    ///     Variable to hold score
    /// </param>
    /// <param name="score">
    ///     Bool to hold can score
    /// </param>
    /// <param name="time">
    ///     Variable for time given
    /// </param>
    /// <param name="timeRemaining">
    ///     Variable for the real time
    /// </param>
    /// <param name="buttonPressed">
    ///     Variable for arduino button press
    /// </param>
    /// <param name="switchFlipped">
    ///     Variable for if the switch is flipped or not
    /// </param>
    /// <param name="photoResistorValue">
    ///     Variable for the value of the photoresistor
    /// </param>
    /// <param name="accelometerValue">
    ///     Variable for the value of the accelometer
    /// </param>

    [Header("UI elements")]
    public GameObject buttonCanvas;
    public GameObject switchCanvas;
    public GameObject photoResistorCanvas;
    public GameObject accelometerCanvas;
    public GameObject scoretextUI;
    public TMP_Text scoreText;
    public GameObject gameOverScoretextUI;
    public TMP_Text gameOVerscoreText;
    public Slider slider;
    public TMP_Text timerText;
    public GameObject UIcanvas;
    public GameObject gameOverUI;

    [Header("Audio")]
    public GameObject mainThemeAudio;
    public GameObject gameOverAudio;
    public GameObject audioSource;

    [Header("Objects")]
    public Transform spawnPointTransform;
    public GameObject spawnPoint;
    private GameObject prefab = null; //Set to null by default

    [Header("Spawn settings")]
    public float spawnTime;
    public float currentSpawnTime;

    [Header("Array")]
    public GameObject[] prefabArray;

    [Header("Score settings")]
    public int score;
    public bool canScore = true; //Set to true by default

    [Header("Time settings")]
    public float time;
    public float timeRemaining;

    [Header("Arduino input settings")]
    private int buttonPressed;
    private int switchFlipped;

    [SerializeField]
    public int photoResistorValue = 0;
    [SerializeField]
    public int accelometerValue = 0;

    #endregion

    //----------------------------------------------------------------------------------------------- VOID START FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Start Function

    /// <summary>
    ///     Function called at the start of each frame
    /// </summary>

    void Start()
    {
        currentSpawnTime = spawnTime; //Sets currentSpawnTime to spawnTime

        scoreText.text = score.ToString(); //Sets the UIs text to be the value of score
        gameOVerscoreText.text = score.ToString(); //Sets the UIs text to be the value of score for game over

        timeRemaining = time; //Sets timeRemaining as time
        slider.maxValue = time; //Sets sliders max value to time

        audioSource.SetActive(false); //Sets audio source to false by default

        //Sets all symbols to false on start
        buttonCanvas.SetActive(false);
        switchCanvas.SetActive(false);
        photoResistorCanvas.SetActive(false);
        accelometerCanvas.SetActive(false);

        prefab = RandomPrefab(prefabArray); //Assigns prefab as part of the prefab array

        Instantiate(prefab, spawnPointTransform.position, spawnPointTransform.rotation); //Instanitates prefab from array at spawnPoint's position and rotation

        SymbolSelect(); //SymbolSelect function call

        UduinoManager.Instance.pinMode(2, PinMode.Input_pullup); //Sets buttonPressed to pin on arduino
        UduinoManager.Instance.pinMode(3, PinMode.Output); //Sets button LED to pin on arduino

        UduinoManager.Instance.pinMode(4, PinMode.Input); //Sets switch pin
        UduinoManager.Instance.pinMode(5, PinMode.Output); //Sets switch LED to pin on arduino

        UduinoManager.Instance.pinMode(AnalogPin.A0, PinMode.Input); //Sets photoresistor pin
        UduinoManager.Instance.pinMode(7, PinMode.Output); //Sets photoresistor LED to pin on arduino

        UduinoManager.Instance.pinMode(AnalogPin.A4, PinMode.Input); //Sets accelometer pin
        UduinoManager.Instance.pinMode(9, PinMode.Output); //Sets accelometer LED to pin on arduino

    }

    #endregion

    //----------------------------------------------------------------------------------------------- VOID UPDATE FUNCTION -----------------------------------------------------------------------------------------------

    #region Void Update Function

    /// <summary>
    ///     Update function that is called once per frame
    /// </summary>

    void Update()
    {
        PrefabSelect(); //Change function call

        StartCoroutine(Score()); //Score coroutine call

        GameOver(); //GameOver function call

        LED(); //LED function call

        timeRemaining -= Time.deltaTime; //Timer will decrease by one second on each function call

        slider.value = timeRemaining; //Sets slider value to timeRemaining's value
        timerText.text = timeRemaining.ToString("f2"); //Sets timer text to time remaining value with two additional decimals

        //If the timer is less than or equal to 0 the time is reset
        if (timeRemaining <= 0)
        {
            timeRemaining = time; //Resets time remaining to time
            slider.value = time; //Resets slider to time

            timerText.text = time.ToString("f3"); //Resets timer text to time
        }

        buttonPressed = UduinoManager.Instance.digitalRead(2); //Reads value from that pin

        switchFlipped = UduinoManager.Instance.digitalRead(4); //Reads value from that pin

        photoResistorValue = UduinoManager.Instance.analogRead(AnalogPin.A0); //Reads the analog value of pin

        accelometerValue = UduinoManager.Instance.analogRead(AnalogPin.A4); //Reads the analog value of pin
    }

    #endregion

    //----------------------------------------------------------------------------------------------- PREFAB SELECT FUNCTION -----------------------------------------------------------------------------------------------  

    #region PrefabSelect Function

    /// <summary>
    ///     Function to instanitate random prefab
    /// </summary>

    void PrefabSelect()
    {
        currentSpawnTime -= Time.deltaTime; //Timer will decrease by one second on each function call

        if (currentSpawnTime <= 0) //If currentSpawnTime is less than or equal to 0
        {
            prefab = RandomPrefab(prefabArray); //Assigns prefab as part of the prefab array

            Instantiate(prefab, spawnPointTransform.position, spawnPointTransform.rotation); //Instanitates prefab from array at spawnPoint's position and rotation

            currentSpawnTime = spawnTime; //Resets currentSpawnTime to spawnTime after object spawn
        }

        SymbolSelect(); //SymbolSelect function call
    }

    #endregion

    //----------------------------------------------------------------------------------------------- RANDOM PREFAB FUNCTION -----------------------------------------------------------------------------------------------  

    #region RandomPrefab Function

    /// <summary>
    ///     Function to random gameobject from list
    /// </summary>
    /// <param name="prefabs">
    ///     Variable to hold GameObject
    /// </param>
    /// <returns>
    ///     Returns element from array
    /// </returns>

    public GameObject RandomPrefab(GameObject[] prefabs)
    {
        int randomNumber = Random.Range(0, prefabs.Length - 1);

        return prefabs[randomNumber];
    }

    #endregion

    //----------------------------------------------------------------------------------------------- SYMBOL SELECT FUNCTION -----------------------------------------------------------------------------------------------  

    #region SymbolSelect Function

    /// <summary>
    ///     Function assign symbols to prefab
    /// </summary>
    /// <param name="prefab">
    ///     Variable to hold GameObject
    /// </param>
    public void SymbolSelect()
    {
        if (prefab.name == "ButtonSymbolHard") //If prefab string name equals corresponding symbol
        {
            buttonCanvas.SetActive(true); //Set desired canvas to true
            switchCanvas.SetActive(false); //Set other symbols canvas to false
            photoResistorCanvas.SetActive(false);
            accelometerCanvas.SetActive(false);
        }

        else if (prefab.name == "SwitchSymbolHard") //If prefab string name equals corresponding symbol
        {
            buttonCanvas.SetActive(false); //Set other symbols canvas to false
            switchCanvas.SetActive(true); //Set desired canvas to true
            photoResistorCanvas.SetActive(false);
            accelometerCanvas.SetActive(false);
        }

        else if (prefab.name == "PhotoResistorSymbolHard") //If prefab string name equals corresponding symbol
        {
            buttonCanvas.SetActive(false); //Set other symbols canvas to false
            switchCanvas.SetActive(false);
            photoResistorCanvas.SetActive(true); //Set desired canvas to true
            accelometerCanvas.SetActive(false);
        }

        else if (prefab.name == "AccelometerSymbolHard") //If prefab string name equals corresponding symbol
        {
            buttonCanvas.SetActive(false); //Set other symbols canvas to false
            switchCanvas.SetActive(false);
            photoResistorCanvas.SetActive(false);
            accelometerCanvas.SetActive(true); //Set desired canvas to true
        }
    }

    #endregion

    //----------------------------------------------------------------------------------------------- LED FUNCTION -----------------------------------------------------------------------------------------------  

    #region LED Function

    /// <summary>
    ///     Function to control the Arduino LEDs
    /// </summary>

    public void LED()
    {
        if (prefab.name == "ButtonSymbolHard" && canScore == true) //If prefab is ButtonSymbol and user hasnt scored
        {
            UduinoManager.Instance.digitalWrite(3, State.HIGH); //Turn LED on
        }
        else //If the user has scored
        {
            UduinoManager.Instance.digitalWrite(3, State.LOW); //Turn LED off
        }

        if (prefab.name == "SwitchSymbolHard" && canScore == true) //If prefab is SwitchSymbol and user hasnt scored
        {
            UduinoManager.Instance.digitalWrite(5, State.HIGH); //Turn LED on
        }
        else //If the user has scored
        {
            UduinoManager.Instance.digitalWrite(5, State.LOW); //Turn LED off
        }

        if (prefab.name == "PhotoResistorSymbolHard" && canScore == true) //If prefab is PhotoresistorSymbol and user hasnt scored
        {
            UduinoManager.Instance.digitalWrite(7, State.HIGH); //Turn LED on
        }
        else //If the user has scored
        {
            UduinoManager.Instance.digitalWrite(7, State.LOW); //Turn LED off
        }

        if (prefab.name == "AccelometerSymbolHard" && canScore == true) //If prefab is AccelometerSymbol and user hasnt scored
        {
            UduinoManager.Instance.digitalWrite(9, State.HIGH); //Turn LED on
        }
        else //If the user has scored
        {
            UduinoManager.Instance.digitalWrite(9, State.LOW); //Turn LED off
        }
    }

    #endregion

    //----------------------------------------------------------------------------------------------- SCORE FUNCTION -----------------------------------------------------------------------------------------------  

    #region Score Function

    /// <summary>
    ///     Function to add score
    /// </summary>

    IEnumerator Score()
    {
        scoreText.text = score.ToString(); //Sets the UIs text to be the value of score
        gameOVerscoreText.text = score.ToString(); //Sets the UIs text to be the value of score for game over

        if (prefab.name == "ButtonSymbolHard" && buttonPressed == 0 && timeRemaining > 0 && canScore == true) //If prefab name equals certain prefab and the corresponding input is pressed and there is time remaining and can score is true
        {
            score++; //Increases score

            audioSource.SetActive(true); //Plays audio

            canScore = false; //Sets can score to false
            yield return new WaitForSeconds(timeRemaining); //Waits for the remaining time
            canScore = true; //Resets can score

            audioSource.SetActive(false); //Sets object back to false
        }

        else if (prefab.name == "SwitchSymbolHard" && switchFlipped == 0 && timeRemaining > 0 && canScore == true) //If prefab name equals certain prefab and the corresponding input is pressed and there is time remaining and can score is true
        {
            score++; //Increases score

            audioSource.SetActive(true); //Plays audio

            canScore = false; //Sets can score to false
            yield return new WaitForSeconds(timeRemaining); //Waits for the remaining time
            canScore = true; //Resets can score

            audioSource.SetActive(false); //Sets object back to false
        }

        else if (prefab.name == "PhotoResistorSymbolHard" && photoResistorValue <= 500 && timeRemaining > 0 && canScore == true) //If prefab name equals certain prefab and the corresponding input is pressed and there is time remaining and can score is true
        {
            score++; //Increases score

            audioSource.SetActive(true); //Plays audio

            canScore = false; //Sets can score to false
            yield return new WaitForSeconds(timeRemaining); //Waits for the remaining time
            canScore = true; //Resets can score

            audioSource.SetActive(false); //Sets object back to false
        }

        else if (prefab.name == "AccelometerSymbolHard" && accelometerValue <= 686 && timeRemaining > 0 && canScore == true) //If prefab name equals certain prefab and the corresponding input is pressed and there is time remaining and can score is true
        {
            score++; //Increases score

            audioSource.SetActive(true); //Plays audio

            canScore = false; //Sets can score to false
            yield return new WaitForSeconds(timeRemaining); //Waits for the remaining time
            canScore = true; //Resets can score

            audioSource.SetActive(false); //Sets object back to false
        }
    }

    #endregion

    //----------------------------------------------------------------------------------------------- GAME OVER FUNCTION -----------------------------------------------------------------------------------------------  

    #region GameOver Function

    /// <summary>
    ///     Function to trigger game over
    /// </summary>

    public void GameOver()
    {
        if (timeRemaining <= 0.1 && canScore == true) //If timer is less than 0.05 and can score is true NOTE cant be 0 because unity cannot accept the input if there isnt a small amount of time available before objects are made inactive
        {
            gameOverUI.SetActive(true); //Sets game over UI to true
            gameOverAudio.SetActive(true);

            mainThemeAudio.SetActive(false); //Stops main theme audio playing
            UIcanvas.SetActive(false); //Sets UIcanvas to false
            spawnPoint.SetActive(false); //Sets spawnPoint to false
        }
    }

    #endregion

}
