using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //CONTINUAR CAMBIANDO COSAS EN ESTE SCRIPT, LA IDEA ESTA, PERO HAY COSAS QUE HAY QUE CAMBIAR PARA QUE FUNCIONE CORRECTAMENTE

    [SerializeField]
    private GameObject canvasMainMenu;

    [SerializeField]
    private GameObject textTittle;
    [SerializeField]
    private GameObject[] gridButton;

    [SerializeField] 
    private int value;
    [SerializeField] 
    private float timer;
    [SerializeField]
    private bool animationIn;
    [SerializeField] 
    private bool animationOut;
    
    [SerializeField]
    private float locationTittle;
    [SerializeField]
    private float[] location;


    private void Start()
    {
        LeanTween.init(1800);

        canvasMainMenu.SetActive(true);

        textTittle.SetActive(true);

        locationTittle = textTittle.transform.position.y;
        location[0] = 0f;
        location[1] = -150f;
        location[2] = -300f;
        location[3] = -450f;

        value = 0;

        AnimationIn();
    }

    private void Update()
    {
        if (animationIn)
        {
            LeanTween.moveLocalY(textTittle, 336, 1f);

            timer += Time.deltaTime;

            if (value >= 0 && value <= gridButton.Length - 1)
            {
                if (timer >= 1)
                {
                    LeanTween.moveLocalY(gridButton[value], location[value], 0.5f);

                    value++;
                    timer = 0;
                }
            }

            if (value > gridButton.Length - 1)
            {
                value = gridButton.Length - 1;

                timer = 0;

                animationIn = false;
            }
        }

        if (animationOut)
        {
            LeanTween.moveLocalY(textTittle, locationTittle, 1f);

            timer += Time.deltaTime;

            if (value >= 0 && value <= gridButton.Length - 1)
            {
                if (timer >= 1)
                {
                    LeanTween.moveLocalY(gridButton[value], -1230f, 0.5f);

                    value--;
                    timer = 0;
                }
            }

            if (value < gridButton.Length - 1)
            {
                value = 0;

                timer = 0;

                animationIn = false;
            }
        }
    }


    public void AnimationIn()
    {
        animationIn = true;
    }

    public void AnimationOut()
    {
        animationOut = true;
    }
}
