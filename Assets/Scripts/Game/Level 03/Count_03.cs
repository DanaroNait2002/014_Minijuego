using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.UI.Image;
using UnityEngine.LowLevel;
using Unity.VisualScripting;

public class Count_03 : MonoBehaviour
{
    #region VARIABLES

    [Header("Vectors")]
    [SerializeField] private Vector2 location01;
    [SerializeField] private Vector2 location02;

    [Header("Text & Related")]
    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private TextMeshProUGUI textEnd;
    [SerializeField] private TextMeshProUGUI textNumber01;
    [SerializeField] private TextMeshProUGUI textNumber02;
    [SerializeField] private GameObject checkerButton;
    [SerializeField] private GameObject retryButton;

    [Header("Times")]
    [SerializeField] private float timer;

    [Header("Array & Values")]
    [SerializeField] private GameObject[] objectType;
    [SerializeField] private int value01;
    [SerializeField] private int value02;
    [SerializeField] private int count01;
    [SerializeField] private int count02;
    [SerializeField] private int amount01;
    [SerializeField] private int amount02;

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

        //Postion Values
        location01 = new Vector2(-4.63f, 0.48f);
        location02 = new Vector2(4.63f, 0.48f);

        //Times Values
        timer = 15f;

        //Values
        count01 = 0;
        count02 = 0;
        amount01 = GameObject.Find("MANAGER").GetComponent<Spawner_03>().amount01;
        amount02 = GameObject.Find("MANAGER").GetComponent<Spawner_03>().amount02;

        value01 = GameObject.Find("MANAGER").GetComponent<Spawner_03>().value01;
        value02 = GameObject.Find("MANAGER").GetComponent<Spawner_03>().value02;
        ammountMedals = PlayerPrefs.GetInt("AmmountMedals03", 0);

        //Actions
        Instantiate(objectType[value01], location01, Quaternion.identity);
        Instantiate(objectType[value02], location02, Quaternion.identity);
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
                count01++;
                textNumber01.text = (count01.ToString());
            }

            //if Down Arrow is pressed
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                if (count01 == 0)
                {
                    count01 = 0;
                }
                else
                {
                    // Number--
                    count01--;
                    textNumber01.text = (count01.ToString());
                }
            }
            //if W is pressed
            if (Input.GetKeyUp(KeyCode.W))
            {
                //Number ++
                count02++;
                textNumber02.text = (count02.ToString());
            }

            //if S is pressed
            if (Input.GetKeyUp(KeyCode.S))
            {
                if (count02 == 0)
                {
                    count02 = 0;
                }
                else
                {
                    // Number--
                    count02--;
                    textNumber02.text = (count02.ToString());
                }
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

    public void Checker()
    {
        //Checker button is Disabled
        checkerButton.SetActive(false);

        //if the player insert the correct number
        if (count01 == amount01 && count02 == amount02)
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
            }
            textEnd.text = ("¡Has ganado!");

            retryButton.SetActive(true);

            //Medals value is saved
            PlayerPrefs.SetInt("AmmountMedals03", ammountMedals);

            Destroy(this);
        }

        else if (count01 == amount01 || count02 == amount02)
        {
            retryButton.SetActive(true);
            textEnd.text = ("¡Que cerca! ¡Has acertado uno de los dos! Buen intento");

            Destroy(this);
        }

        else if (count01 >= amount01 - 2 && count01 <= amount01 + 2 || count02 >= amount01 - 2 && count02 <= amount01 + 2)
        {
            //So Close Game
            textEnd.gameObject.SetActive(true);
            textEnd.text = ("¡Que cerca! Buen intento");

            //Retry Button
            retryButton.SetActive(true);

            Destroy(this);
        }

        else
        {
            //Lost Game
            textEnd.gameObject.SetActive(true);
            textEnd.text = ("¡Has perdido! Intenta contar con tus manos");

            //Retry Button
            retryButton.SetActive(true);

            Destroy(this);
        }
    }

    #endregion
}
