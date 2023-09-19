using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Vector2 origin;
    [SerializeField] 
    private Vector2 prevOrigin;
    [SerializeField] 
    private Vector2 spawnPos;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float maxTimer;
    [SerializeField]
    private float minTimer;
    [SerializeField] 
    private float cooldown;

    [SerializeField]
    public int amount;
    [SerializeField]
    private int maxAmount;
    [SerializeField]
    private int minAmount;
    [SerializeField]
    private int counter;

    [SerializeField]
    private bool canSummon;
    [SerializeField]
    private GameObject objectType01;

    public void Start()
    {
        counter = 0;
        amount = Random.Range(minAmount, maxAmount);

        origin = new Vector2(-10, Random.Range(-4, 4));

        canSummon = true;

        cooldown = Random.Range(minTimer, maxTimer);
    }

    private void Update()
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
                Instantiate(objectType01, origin, Quaternion.identity);

                prevOrigin = origin;

                origin = new Vector2(-10, Random.Range(-4, 4));

                counter++;

                ResetTimer();
            }
        }

        if (counter == amount)
        {
            canSummon = false;
        }
    }

    private void ResetTimer()
    {
        cooldown = Random.Range(minTimer, maxTimer);

        timer = 0;
    }
}
