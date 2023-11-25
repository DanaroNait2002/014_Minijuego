using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.UI.Image;
using UnityEngine.LowLevel;
using Unity.VisualScripting;

public class Count_02 : MonoBehaviour
{
    #region VARIABLES

    [Header("Vectors")]
    [SerializeField] private Vector2 location;

    [Header("Text & Related")]
    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private TextMeshProUGUI textEnd;
    [SerializeField] private TextMeshProUGUI textNumber;
    [SerializeField] private GameObject checkerButton;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject nextLevelButton;

    [Header("Times")]
    [SerializeField] private float timer;

    [Header("Array & Values")]
    [SerializeField] private GameObject[] objectType;
    [SerializeField] private int value;
    [SerializeField] private int count;
    [SerializeField] private int amount;

    [Header("PlayerPrefs Related")]
    [SerializeField] private int ammountMedals;

    #endregion

    #region METHODS

    public void Awake()
    {
        //GameObjects SetActives
        textEnd.gameObject.SetActive(false);
        checkerButton.SetActive(true);
        retryButton.SetActive(false);
        nextLevelButton.SetActive(false);

        //Postion Values
        location = new Vector2(0f, 1.75f);

        //Times Values
        timer = 15f;

        //Values
        count = 0;
        amount = GameObject.Find("MANAGER").GetComponent<Spawner_02>().amount;
        value = GameObject.Find("MANAGER").GetComponent<Spawner_02>().value01;
        ammountMedals = PlayerPrefs.GetInt("AmmountMedals02", 0);

        //Actions
        Instantiate(objectType[value], location, Quaternion.identity);
    }

    public void Update()
    {
        //Timer is shown in the screen
        textTimer.text = timer.ToString("0");

        //While the timer is above the 0 Value
        if (timer >= 0)
        {
            //Timer will be running
            timer -= Time.deltaTime;

            //if Up Arrow is pressed
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                //Number ++
                count++;
                textNumber.text = (count.ToString());
            }

            //if Down Arrow is pressed
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                if (count == 0)
                {
                    count = 0;
                }
                else
                    // Number--
                    count--;
                textNumber.text = (count.ToString());
            }
            //if Enter is pressed
            if (Input.GetKeyUp(KeyCode.Return))
            {
                Checker();
            }
        }
        //if Timer has reach 0 Value
        else
        {
            //Timer stops
            textTimer.text = "0";

            //Lost Game
            textEnd.gameObject.SetActive(true);
            textEnd.text = ("¡Has perdido! Te quedaste sin tiempo");

            //Retry button Active
            retryButton.SetActive(true);

            //Destoy Script
            Destroy(this);
        }
    }


    public void Up()
    {
        //Number ++
        count++;
        textNumber.text = (count.ToString());
    }

    public void Down()
    {
        if (count == 0)
        {
            count = 0;
        }
        else
        {
            // Number--
            count--;
            textNumber.text = (count.ToString());
        }
    }


    public void Checker()
    {
        //Checker button is Disabled
        checkerButton.SetActive(false);

        //if the player insert the correct number
        if (count == amount)
        {
            //Win Game
            textEnd.gameObject.SetActive(true);

            //Medals ++
            ammountMedals++;

            checkerButton.SetActive(false);

            //if player has 3 medals
            if (ammountMedals > 2)
            {
                //Medals value keeps being 3 (no more medals)
                ammountMedals = 3;

                //Next Level button
                nextLevelButton.SetActive(true);
                textEnd.text = ("¡Has ganado! Ya puedes jugar el siguiente nivel");
            }
            else
            {
                //Retry button
                retryButton.SetActive(true);
                textEnd.text = ("¡Has ganado! Pero aún debes conseguir más medallas en este nivel");
            }

            //Medals value is saved
            PlayerPrefs.SetInt("AmmountMedals02", ammountMedals);

            Destroy(this);
        }

        else if (count >= amount - 2 && count <= amount + 2)
        {
            //So Close Game
            textEnd.gameObject.SetActive(true);
            textEnd.text = ("¡Que cerca! El número correcto era: " + amount.ToString() + ". Buen intento");

            //Retry Button
            retryButton.SetActive(true);

            Destroy(this);
        }

        else
        {
            //Lost Game
            textEnd.gameObject.SetActive(true);
            textEnd.text = ("¡Has perdido! El número correcto era: " + amount.ToString());

            //Retry Button
            retryButton.SetActive(true);

            Destroy(this);
        }
    }

    #endregion
}
