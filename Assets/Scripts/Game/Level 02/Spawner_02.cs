using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner_02 : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private Vector2 origin;
    [SerializeField]
    private Vector2 prevOrigin;
    [SerializeField]
    private Vector2 spawnPos;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float maxCooldown;
    [SerializeField]
    private float minCooldown;
    [SerializeField]
    private float cooldown;

    [SerializeField]
    private float gameTime;
    [SerializeField]
    private TextMeshProUGUI textTime;

    [SerializeField]
    public int amount;

    [SerializeField]
    private bool canSummon;
    [SerializeField]
    private GameObject[] objectType01;
    [SerializeField]
    public int value;
    [SerializeField]
    public int value_NON;
    [SerializeField]
    public int i;

    public void Start()
    {
        value = Random.Range(0, objectType01.Length - 1);
        value_NON = Random.Range(0, objectType01.Length - 1);

        if (value_NON == value)
        {
            value_NON = Random.Range(0, objectType01.Length - 1);
        }

        origin = new Vector2(-10, Random.Range(-4, 4));

        canSummon = true;

        cooldown = Random.Range(minCooldown, maxCooldown);

        gameTime = 20f;
    }

    private void Update()
    {

        gameTime -= Time.deltaTime;

        textTime.text = gameTime.ToString("0");

        if (gameTime >= 2.5f)
        {
            if (origin == prevOrigin)
            {
                canSummon = false;

                origin = new Vector2(-10, Random.Range(-4, 4));
            }
            else
            {
                canSummon = true;
            }

            if (canSummon)
            {
                timer += Time.deltaTime;

                if (timer >= cooldown)
                {
                    i = Random.Range(0, 1);

                    if (i == 0)
                    {
                        Instantiate(objectType01[value], origin, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(objectType01[value_NON], origin, Quaternion.identity);
                    }

                    prevOrigin = origin;

                    origin = new Vector2(-10, Random.Range(-4, 4));

                    amount++;

                    ResetTimer();
                }
            }
        }
        else if (gameTime <= 0f)
        {
            EndLevel_01();
            textTime.text = "0";
        }
    }

    private void ResetTimer()
    {
        cooldown = Random.Range(minCooldown, maxCooldown);

        timer = 0;
    }

    private void EndLevel_01()
    {
        canvas.SetActive(true);
        textTime.gameObject.SetActive(false);
    }
}
