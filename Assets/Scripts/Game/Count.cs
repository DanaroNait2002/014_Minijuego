using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    [SerializeField]
    private int count;
    [SerializeField]
    private int amount;

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

    public void Start()
    {
        count = 0;
        text.text = (count.ToString());

        win.SetActive(false);
        close.SetActive(false);
        lost.SetActive(false);

        amount = GameObject.Find("Spawner").GetComponent<Spawner>().amount;
    }

    public void Update()
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
    }

    public void Checker()
    {
        if (count == amount)
        {
            win.SetActive(true);
            winText.text = ("You won");

            checkerButton.SetActive(false);
            retryButton.SetActive(true);

            Destroy(this);
        }

        else if (count == amount - 2 || count == amount + 2)
        {
            close.SetActive(true);
            closeText.text = ("So close! The correct number was: " + amount.ToString());

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
