using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCatsIn : MonoBehaviour
{
    private Rigidbody2D rg;

    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject cat;
    [SerializeField]
    private GameObject limitIn;
    [SerializeField] 
    private GameObject limitOut;

    [SerializeField]
    private float posIn;

    [SerializeField]
    private bool entry;
    [SerializeField]
    private bool exit;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();

        posIn = gameObject.transform.localPosition.y;

        rg.velocity = new Vector2(speed, 0);

        entry = true;
    }

    private void Update()
    {
        if (entry)
        {
            limitIn.SetActive(true);

            rg.velocity = new Vector2(speed, 0);
        }

        if (exit)
        {
            cat.SetActive(false);

            limitOut.SetActive(true);

            rg.velocity = new Vector2(speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            cat.SetActive(true);
            gameObject.SetActive(false);

            entry = false;
            collision.gameObject.SetActive(false);
        }
    }

    public void Exit()
    {
        gameObject.SetActive(true);

        exit = true;
    }
}
