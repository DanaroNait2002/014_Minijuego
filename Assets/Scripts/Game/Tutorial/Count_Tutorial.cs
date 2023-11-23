using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.UI.Image;
using UnityEngine.LowLevel;
using Unity.VisualScripting;

public class Count_Tutorial : MonoBehaviour
{
    #region VARIABLES

    [Header("Vectors")]
    [SerializeField] private Vector2 location;

    [Header("Text & Related")]
    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private TextMeshProUGUI textEnd;
    [SerializeField] private TextMeshProUGUI textNumber;
    [SerializeField] private GameObject checkerButton;
    [SerializeField] private GameObject completeButton;
    [SerializeField] private GameObject retryButton;

    [Header("Times")]
    [SerializeField] private float timer;

    [Header("Array & Values")]
    [SerializeField] private GameObject[] objectType;
    [SerializeField] private int value;
    [SerializeField] private int count;
    [SerializeField] private int amount;

    #endregion

    #region METHODS

    public void Awake()
    {
        //GameObjects SetActives
        textEnd.gameObject.SetActive(false);
        checkerButton.SetActive(true);
        completeButton.SetActive(false);
        retryButton.SetActive(false);

        //Postion Values
        location = new Vector2(0f, 1.75f);

        //Times Values
        timer = 15f;

        //Values
        count = 0;
        amount = GameObject.Find("MANAGER").GetComponent<Tutorial>().amount;
        value = GameObject.Find("MANAGER").GetComponent<Tutorial>().value01;

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

            //Destoy Script
            Destroy(this);
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
            completeButton.SetActive(true);
            textEnd.text = ("¡Has ganado! Ya puedes jugar el siguiente nivel");


            Destroy(this);
        }

        else if (count >= amount - 2 && count <= amount + 2)
        {
            //So Close Game
            textEnd.gameObject.SetActive(true);
            retryButton.SetActive(true);
            textEnd.text = ("¡Que cerca! El número correcto era: " + amount.ToString() + ". Buen intento");

            Destroy(this);
        }

        else
        {
            //Lost Game
            textEnd.gameObject.SetActive(true);
            retryButton.SetActive(true);
            textEnd.text = ("¡Has perdido! El número correcto era: " + amount.ToString());

            Destroy(this);
        }
    }

    #endregion
}
