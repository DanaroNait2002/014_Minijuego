using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rg;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float minSpeed;
    [SerializeField] 
    private float maxSpeed;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();

        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        rg.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
}