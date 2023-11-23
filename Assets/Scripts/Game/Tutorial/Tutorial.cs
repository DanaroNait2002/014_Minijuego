using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    #region VARIABLES

    #region TUTORIAL

    [Header("Canvas")]
    [SerializeField] private GameObject canvasTutorial;
    [SerializeField] private GameObject[] canvas;

    [Header("Array & Values")]
    [SerializeField] private GameObject[] steps;
    [SerializeField] private int valueTutorial;

    [Header("Bools")]
    [SerializeField] private bool canNext;

    #endregion

    #region GAME

    [Header("Vectors")]
    [SerializeField] private Vector2 origin;
    [SerializeField] private Vector2 prevOrigin;
    [SerializeField] private Vector2 spawnPos;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI textTimeStart;
    [SerializeField] private TextMeshProUGUI textTimeInGame;

    [Header("Times")]
    [SerializeField] private float timerCooldown;
    [SerializeField] private float maxCooldown;
    [SerializeField] private float minCooldown;
    [SerializeField] private float cooldownValue;
    [SerializeField] private float timerStart;
    [SerializeField] private float timerInGame;

    [Header("Arrays & Values")]
    //Cats in Movement
    [SerializeField] private GameObject[] objectTypeMoving;
    [SerializeField] public int value01;
    //Static Cats
    [SerializeField] private GameObject[] objectTypeStatic;
    [SerializeField] private GameObject instanteableStatic_01;

    [Header("Bools")] //Bools 
    [SerializeField] private bool canSummon;

    [Header("Public Variables")]
    [SerializeField] public int amount;

    #endregion

    #endregion

    #region METHODS

    private void Start()
    {
        #region TUTORIAL

        canvasTutorial.SetActive(true);

        canNext = true;
        valueTutorial = 0;

        #endregion

        #region GAME

        //Position Values
        origin = new Vector2(-10, Random.Range(-4, 4));

        //Times Values
        cooldownValue = 7.5f;
        timerInGame = 20f;
        timerStart = 10f;

        //Array Values
        value01 = Random.Range(0, objectTypeMoving.Length - 1);

        //Bools Values
        canSummon = true;

        //Actions
        instanteableStatic_01 = Instantiate(objectTypeStatic[value01], Vector2.zero, Quaternion.identity);

        #endregion
    }

    private void Update()
    {
        #region TUTORIAL

        if (canNext)
        {
            steps[valueTutorial].SetActive(true);
            LeanTween.alphaCanvas(steps[valueTutorial].GetComponent<CanvasGroup>(), 1, 0.5f);

            canvas[valueTutorial].SetActive(true);
            canNext = false;
        }

        #endregion

        #region GAME

        {
            //if the game is not set to start
            if (valueTutorial == 0)
            {
                //Timer is shown in the screen
                textTimeStart.text = timerStart.ToString("0");

                //While the timer is above the 0 value
                if (timerStart >= 0)
                {
                    //The timer will be running
                    timerStart -= Time.deltaTime;
                }
                //Once the timer is under the 0 value
                else
                {
                    //Timer is considered as 0
                    textTimeStart.text = "0";

                    NextStep();
                }
            }

            //If the game is set to start
            if (valueTutorial == 1)
            {
                canvas[valueTutorial].SetActive(true);

                //The cat shown in screen is destroyed
                Destroy(instanteableStatic_01);

                //Timer will start running
                timerInGame -= Time.deltaTime;

                //Timer is shown in the screen
                textTimeInGame.text = timerInGame.ToString("0");

                //While timer is above the 2.5 Value
                if (timerInGame >= 2.5f)
                {
                    //Checking is the prevOrigin is the same as the current origin
                    if (origin == prevOrigin)
                    {
                        //can't summon
                        canSummon = false;

                        //randomizing again
                        origin = new Vector2(-10, Random.Range(-4, 4));
                    }
                    //if not
                    else
                    {
                        //can summon
                        canSummon = true;
                    }

                    //if the game can summon
                    if (canSummon)
                    {
                        //Cooldown timer start running
                        timerCooldown += Time.deltaTime;

                        //When the timer reach the cooldown Value
                        if (timerCooldown >= cooldownValue)
                        {
                            //Summon a cat
                            Instantiate(objectTypeMoving[value01], origin, Quaternion.identity);

                            LeanTween.alphaCanvas(steps[valueTutorial].GetComponent<CanvasGroup>(), 0, 0.5f);
                            canvas[valueTutorial].SetActive(false);


                            //change the prevOrigin Value
                            prevOrigin = origin;

                            //Randomizing new origin
                            origin = new Vector2(-10, Random.Range(-4, 4));

                            //Randomizing cooldown
                            cooldownValue = Random.Range(minCooldown, maxCooldown);

                            //+1 cat summoned
                            amount++;

                            //Reseting Timer
                            timerCooldown = 0;
                        }
                    }
                }
                //Once the Timer reach the 0 Value
                else if (timerInGame <= 0f)
                {
                    //Time stop showing
                    textTimeInGame.text = "0";

                    NextStep();
                }
            }
        }

        #endregion
    }

    public void NextStep()
    {
        LeanTween.alphaCanvas(steps[valueTutorial].GetComponent<CanvasGroup>(), 0, 0.5f);
        canvas[valueTutorial].SetActive(false);

        if (valueTutorial < steps.Length - 1)
        {
            valueTutorial++;
            canNext = true;
        }
        else
        {
            canNext = false;
        }
    }

    public void TutorialComplete()
    {
        PlayerPrefs.SetString("TutorialDone", "True");
    }

    #endregion
}
