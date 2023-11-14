using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Count_03 : MonoBehaviour
{
    [SerializeField]
    private int count;
    [SerializeField]
    private int amount;
    [SerializeField]
    private int value;
    [SerializeField]
    private GameObject[] objectType;
    [SerializeField]
    private Vector2 location;

    [SerializeField]
    private float timer;
    [SerializeField]
    private TextMeshProUGUI textTimer;

    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject win;
    [SerializeField]
    private TextMeshProUGUI winText;
    [SerializeField]
    private GameObject close;
    [SerializeField]
    private TextMeshProUGUI closeText;
    [SerializeField]
    private GameObject lost;
    [SerializeField]
    private TextMeshProUGUI lostText;

    [SerializeField]
    private GameObject checkerButton;
    [SerializeField]
    private GameObject retryButton;
    [SerializeField]
    private GameObject nextLevelButton;

    [SerializeField]
    private int ammountMedals;

    public void Awake()
    {
        location = new Vector2(0f, 1.75f);

        count = 0;
        text.text = (count.ToString());

        win.SetActive(false);
        close.SetActive(false);
        lost.SetActive(false);

        checkerButton.SetActive(true);
        retryButton.SetActive(false);

        amount = GameObject.Find("Spawner").GetComponent<Spawner_03>().amount;

        value = GameObject.Find("Spawner").GetComponent<Spawner_03>().value;

        Instantiate(objectType[value], location, Quaternion.identity);

        timer = 15f;

        ammountMedals = PlayerPrefs.GetInt("AmmountMedals03", 0);
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        textTimer.text = timer.ToString("0");

        if (timer >= 0)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                count++;

                text.text = (count.ToString());
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                count--;

                text.text = (count.ToString());
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                Checker();
            }
        }
        else
        {
            textTimer.text = "0";

            lost.SetActive(true);
            lostText.text = ("You loose! You ran out of time");

            retryButton.SetActive(true);

            Destroy(this);
        }
    }

    public void Checker()
    {
        checkerButton.SetActive(false);
        retryButton.SetActive(true);

        if (count == amount)
        {
            win.SetActive(true);
            winText.text = ("You won");

            ammountMedals++;

            checkerButton.SetActive(false);

            if (ammountMedals > 2)
            {
                ammountMedals = 3;
                PlayerPrefs.SetInt("AmmountMedals03", ammountMedals);

                nextLevelButton.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetInt("AmmountMedals03", ammountMedals);
                retryButton.SetActive(true);
            }

            Destroy(this);
        }

        else if (count == amount - 2 || count == amount + 2)
        {
            close.SetActive(true);
            closeText.text = ("So close! The correct number was: " + amount.ToString() + ". Nice Try");

            checkerButton.SetActive(false);
            retryButton.SetActive(true);

            Destroy(this);
        }

        else
        {
            lost.SetActive(true);
            lostText.text = ("You loose! The correct number was: " + amount.ToString());

            checkerButton.SetActive(false);
            retryButton.SetActive(true);

            Destroy(this);
        }
    }
}
