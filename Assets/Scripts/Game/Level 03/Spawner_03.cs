using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner_03 : MonoBehaviour
{
    #region VARIABLES

    [Header("Canvas")]
    [SerializeField] private GameObject canvasStart;
    [SerializeField] private GameObject canvasTimer;
    [SerializeField] private GameObject canvasEnd;

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
    [SerializeField] public int value02;
    [SerializeField] private int value03;
    [SerializeField] private int valueRandom;
    //Static Cats
    [SerializeField] private GameObject[] objectTypeStatic;
    [SerializeField] private GameObject instanteableStatic_01;
    [SerializeField] private GameObject instanteableStatic_02;

    [Header("Bools")] //Bools 
    [SerializeField] private bool canSummon;
    [SerializeField] private bool startGame;

    [Header("Public Variables")]
    [SerializeField] public int amount01;
    [SerializeField] public int amount02;

    #endregion

    #region METHODS

    public void Start()
    {
        //Canvas SetActive values
        canvasStart.SetActive(true);
        canvasTimer.SetActive(false);
        canvasEnd.SetActive(false);

        //Position Values
        origin = new Vector2(-10, Random.Range(-4, 4));

        //Times Values
        cooldownValue = Random.Range(minCooldown, maxCooldown);
        timerInGame = 20f;
        timerStart = 5f;

        //Array Values
        value01 = Random.Range(0, objectTypeMoving.Length - 1);
        value02 = Random.Range(0, objectTypeMoving.Length - 1);
        value03 = Random.Range(0, objectTypeMoving.Length - 1);

        //Bools Values
        startGame = false;
        canSummon = true;

        //Actions
        instanteableStatic_01 = Instantiate(objectTypeStatic[value01], new Vector2(-5f, 0f), Quaternion.identity);
        instanteableStatic_02 = Instantiate(objectTypeStatic[value02], new Vector2(5f, 0f), Quaternion.identity);
    }

    private void Update()
    {
        //Just in case
        if (value02 == value01)
        {
            //Randomizing Value again
            value02 = Random.Range(0, objectTypeMoving.Length - 1);
        }
        //Just in case
        if (value03 == value01 || value03 == value02)
        {
            value03 = Random.Range(0, objectTypeMoving.Length - 1);
        }

        //if the game is not set to start
        if (!startGame)
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
                //The game will start
                startGame = true;

                //Canvas SetActive Change
                canvasStart.SetActive(false);
                canvasTimer.SetActive(true);
                canvasEnd.SetActive(false);

                //Timer is considered as 0
                textTimeStart.text = "0";

                //The cat shown in screen is destroyed
                Destroy(instanteableStatic_01);
                Destroy(instanteableStatic_02);
            }
        }

        //If the game is set to start
        if (startGame)
        {
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
                        valueRandom = Random.Range(0, 100);

                        if (valueRandom % 2 == 0)
                        {
                            //Summon a cat
                            Instantiate(objectTypeMoving[value01], origin, Quaternion.identity);
                            //+1 cat summoned
                            amount01++;
                        }
                        else if (valueRandom >= 50)
                        {
                            //Summon a cat
                            Instantiate(objectTypeMoving[value02], origin, Quaternion.identity);
                            //+1 cat summoned
                            amount02++;
                        }
                        else
                        {
                            //Summon a cat
                            Instantiate(objectTypeMoving[value03], origin, Quaternion.identity);
                        }

                        //change the prevOrigin Value
                        prevOrigin = origin;

                        //Randomizing new origin
                        origin = new Vector2(-10, Random.Range(-4, 4));

                        //Randomizing cooldown
                        cooldownValue = Random.Range(minCooldown, maxCooldown);

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

                //The phase is considered ended
                canvasEnd.SetActive(true);
                canvasTimer.SetActive(false);
            }
        }
    }

    #endregion
}
