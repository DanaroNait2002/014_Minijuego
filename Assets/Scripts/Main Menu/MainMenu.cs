using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //CONTINUAR CAMBIANDO COSAS EN ESTE SCRIPT, LA IDEA ESTA, PERO HAY COSAS QUE HAY QUE CAMBIAR PARA QUE FUNCIONE CORRECTAMENTE

    #region VARIABLES

    [SerializeField]
    private GameObject canvasMainMenu;

    [SerializeField]
    private GameObject textTittle;
    [SerializeField]
    private GameObject buttonBack;
    [SerializeField]
    private GameObject[] gridButton;
    [SerializeField]
    private GameObject[] gridButtonGame;
    [SerializeField] 
    private GameObject[] gridButtonOptions;
    [SerializeField]
    private GameObject[] gridCredits;

    [SerializeField] 
    private int value;
    [SerializeField] 
    private float timer;
    [SerializeField]
    private float timeAnimation;
    [SerializeField]
    private bool animationIn;
    [SerializeField] 
    private bool animationOut;
    [SerializeField]
    private bool animationInGame;
    [SerializeField]
    private bool animationOutGame;
    [SerializeField]
    private bool animationInOptions;
    [SerializeField]
    private bool animationOutOptions;
    [SerializeField]
    private bool animationInCredits;
    [SerializeField]
    private bool animationOutCredits;

    [SerializeField]
    private float locationTittle;
    [SerializeField] 
    private float locationButtonBack;
    [SerializeField]
    private float[] location;
    [SerializeField]
    private float locationGame;
    [SerializeField]
    private float[] locationOptions;
    [SerializeField]
    private float[] locationCredits;

    #endregion

    #region METHODS

    #region START

    private void Start()
    {
        LeanTween.init(1800);

        canvasMainMenu.SetActive(true);

        textTittle.SetActive(true);

        locationTittle = textTittle.transform.position.y;

        locationButtonBack = 880f;

        location[0] = 0f;
        location[1] = -150f;
        location[2] = -300f;
        location[3] = -450f;

        locationGame = -185f;

        value = 0;

        AnimationIn();
    }

    #endregion

    #region UPDATE

    private void Update()
    {
        #region ANIMATIONS IN

        if (animationIn && value >= 0)
        {
            LeanTween.moveLocalY(textTittle, 336, 1f);

            timer += Time.deltaTime;

            if (value >= 0 && value <= gridButton.Length - 1)
            {
                if (timer >= timeAnimation)
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

        if (animationInGame && value >= 0)
        {
            timer += Time.deltaTime;

            if (value >= 0 && value <= gridButtonGame.Length - 1)
            {
                if (timer >= timeAnimation)
                {
                    LeanTween.moveLocalY(gridButtonGame[value], locationGame, 0.5f);

                    value++;
                    timer = 0;
                }
            }

            if (value > gridButtonGame.Length - 1)
            {
                LeanTween.moveLocalY(buttonBack, locationButtonBack, 0.5f);

                value = gridButtonGame.Length - 1;

                timer = 0;

                animationInGame = false;
            }
        }

        if (animationInOptions && value >= 0)
        {
            timer += Time.deltaTime;

            if (value >= 0 && value <= gridButtonOptions.Length - 1)
            {
                if (timer >= timeAnimation)
                {
                    LeanTween.moveLocalY(gridButtonOptions[value], location[value], 0.5f);

                    value++;
                    timer = 0;
                }
            }

            if (value > gridButtonGame.Length - 1)
            {
                value = gridButtonGame.Length - 1;

                timer = 0;

                animationIn = false;
            }
        }

        if (animationInCredits && value >= 0)
        {
            LeanTween.moveLocalY(textTittle, 336, 1f);

            timer += Time.deltaTime;

            if (value >= 0 && value <= gridCredits.Length - 1)
            {
                if (timer >= timeAnimation)
                {
                    LeanTween.moveLocalY(gridCredits[value], location[value], 0.5f);

                    value++;
                    timer = 0;
                }
            }

            if (value > gridCredits.Length - 1)
            {
                value = gridCredits.Length - 1;

                timer = 0;

                animationIn = false;
            }
        }

        #endregion

        #region ANIMATIONS OUT

        if (animationOut)
        {
            //LeanTween.moveLocalY(textTittle, locationTittle, 1f);

            timer += Time.deltaTime;

            if (value >= 0 && value <= gridButton.Length - 1)
            {
                if (timer >= timeAnimation)
                {
                    LeanTween.moveLocalY(gridButton[value], -1230f, 0.5f);

                    value--;
                    timer = 0;
                }
            }

            if (value <= -1)
            {
                value = 0;

                timer = 0;

                animationOut = false;
            }
        }

        if (animationOutGame)
        {
            //LeanTween.moveLocalY(textTittle, locationTittle, 1f);

            timer += Time.deltaTime;

            if (value >= 0 && value <= gridButton.Length - 1)
            {
                if (timer >= timeAnimation)
                {
                    LeanTween.moveLocalY(gridButtonGame[value], -1230f, 0.5f);

                    value--;
                    timer = 0;
                }
            }

            if (value <= -1)
            {
                value = 0;

                timer = 0;

                animationOutGame = false;
            }
        }

        #endregion
    }

    #endregion

    public void AnimationIn()
    {
        animationIn = true;
    }

    public void AnimationOut()
    {
        animationOut = true;
    }

    public void AnimationInGame()
    {
        animationInGame = true;
    }

    public void AnimationOutGame()
    {
        animationOutGame = true;
    }

    public void AnimationInOptions()
    {
        animationInOptions = true;
    }

    public void AnimationOutOptions()ti
    {
        animationOutOptions = true;
    }

    public void AnimationInCredits()
    {
        animationInCredits = true;
    }

    public void AnimationOutCredits()
    {
        animationOutCredits = true;
    }

    #endregion
}
