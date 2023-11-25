using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    #region VARIABLES

    [Header("Canvas")]
    [SerializeField] private GameObject canvas;

    [Header("Times")]
    [SerializeField] private float timer;
    [SerializeField] private float timeAnimate;
    [SerializeField] private float timeMove;

    [Header("Array & Values")]
    //To animate
    [SerializeField] private GameObject textTittle;
    [SerializeField] private GameObject buttonBack;
    [SerializeField] private GameObject[] gridMainMenu;
    [SerializeField] private GameObject[] gridLevelSelection;
    [SerializeField] private GameObject[] gridOptions;
    [SerializeField] private GameObject[] gridCredits;
    //Values
    [SerializeField] private int valueMainMenu;
    [SerializeField] private int valueLevelSelection;
    [SerializeField] private int valueOptions;
    [SerializeField] private int valueCredits;
    //Locations
    [SerializeField] private float locationTittle;
    [SerializeField] private float locationButtonBack;
    [SerializeField] private float[] locationMainMenu;
    [SerializeField] private float[] locationLevelSelection;
    [SerializeField] private float[] locationOptions;
    [SerializeField] private float[] locationOptionsOut;

    [Header("Bools")]
    [SerializeField] private bool animationMainMenuIn;
    [SerializeField] private bool animationMainMenuOut;
    [SerializeField] private bool animationLevelSelectionIn;
    [SerializeField] private bool animationLevelSelectionOut;
    [SerializeField] private bool animationOptionsIn;
    [SerializeField] private bool animationOptionsOut;
    [SerializeField] private bool animationCreditsIn;
    [SerializeField] private bool animationCreditsOut;

    #endregion

    #region METHODS

    private void Start()
    {
        LeanTween.init(1800);

        //Activation Canvas
        canvas.SetActive(true);

        //Save Location
        locationMainMenu[0] = 0f;
        locationMainMenu[1] = -150f;
        locationMainMenu[2] = -300f;
        locationMainMenu[3] = -450f;

        locationButtonBack = -455f;

        locationLevelSelection[0] = -130f;
        locationLevelSelection[1] = -130f;
        locationLevelSelection[2] = -130f;
        locationLevelSelection[3] = -470f;


        locationOptions[0] = -555f;
        locationOptions[1] = 555f;
        locationOptionsOut[0] = -1480f;
        locationOptionsOut[1] = 1480f;


        //Start Animation
        AnimationMainMenuIn();
    }

    private void Update()
    {
        #region ANIMATION IN

        if (animationMainMenuIn && !animationLevelSelectionOut && !animationOptionsOut && !animationCreditsOut)
        {
            //Move the Tittle
            LeanTween.moveLocalY(textTittle, 418, 1f);
            LeanTween.moveLocalY(buttonBack, -1230, timeMove);

            //Set Timer
            timer += Time.deltaTime;

            if (valueMainMenu >= 0 && valueMainMenu <= gridMainMenu.Length - 1)
            {
                if (timer >= timeAnimate)
                {
                    LeanTween.moveLocalY(gridMainMenu[valueMainMenu], locationMainMenu[valueMainMenu], timeMove);

                    valueMainMenu++;
                    timer = 0;
                }
            }

            if (valueMainMenu > gridMainMenu.Length - 1)
            {
                valueMainMenu = gridMainMenu.Length - 1;

                timer = 0;

                animationMainMenuIn = false;
            }
        }
        if (animationLevelSelectionIn && !animationMainMenuOut)
        {
            //Set Timer
            timer += Time.deltaTime;

            if (valueLevelSelection >= 0 && valueLevelSelection <= gridLevelSelection.Length - 1)
            {
                if (timer >= timeAnimate)
                {
                    if (valueLevelSelection == gridLevelSelection.Length - 1)
                    {
                        LeanTween.moveLocalY(buttonBack, locationButtonBack, timeMove);
                    }

                    LeanTween.moveLocalY(gridLevelSelection[valueLevelSelection], locationLevelSelection[valueLevelSelection], timeMove);

                    valueLevelSelection++;
                    timer = 0;
                }
            }

            if (valueLevelSelection > gridLevelSelection.Length - 1)
            {
                valueLevelSelection = gridLevelSelection.Length - 1;

                timer = 0;

                animationLevelSelectionIn = false;
            }
        }
        if (animationOptionsIn && !animationMainMenuOut)
        {
            timer += Time.deltaTime;

            if (valueOptions >= 0 && valueOptions <= gridOptions.Length - 1)
            {
                if (timer >= timeAnimate)
                {
                    if (valueOptions == gridOptions.Length - 1)
                    {
                        LeanTween.moveLocalY(buttonBack, locationButtonBack, timeMove);
                    }

                    LeanTween.moveLocalX(gridOptions[valueOptions], locationOptions[valueOptions], timeMove);

                    valueOptions++;
                    timer = 0;
                }
            }

            if (valueOptions > gridOptions.Length - 1)
            {
                valueOptions = gridOptions.Length - 1;

                timer = 0;

                animationOptionsIn = false;
            }
        }

        if (animationCreditsIn && !animationMainMenuOut)
        {
            timer += Time.deltaTime;

            if (valueCredits >= 0 && valueCredits <= gridCredits.Length - 1)
            {
                if(timer >= timeAnimate)
                {
                    if (valueCredits <= 2)
                    {
                        LeanTween.moveLocalX(gridCredits[valueCredits], -495f, timeMove);
                    }

                    else if (valueCredits == gridCredits.Length - 1)
                    {
                        LeanTween.moveLocalY(buttonBack, locationButtonBack, timeMove);
                    }

                    else
                    {
                        LeanTween.moveLocalX(gridCredits[valueCredits], 495f, timeMove);
                    }

                    valueCredits++;
                    timer = 0;
                }
            }

            if (valueCredits > gridCredits.Length - 1)
            {
                valueCredits = gridCredits.Length - 1;

                timer = 0;

                animationCreditsIn = false;
            }
        }

        #endregion

        #region ANIMATION OUT

        if (animationMainMenuOut)
        {
            timer += Time.deltaTime;

            if (valueMainMenu >= 0 && valueMainMenu <= gridMainMenu.Length - 1)
            {
                if (timer >= timeAnimate)
                {
                    LeanTween.moveLocalY(gridMainMenu[valueMainMenu], -1230f, timeMove);

                    valueMainMenu--;

                    timer = 0;
                }
            }

            if (valueMainMenu < 0)
            {
                valueMainMenu = 0;

                timer = 0;

                animationMainMenuOut = false;
            }
        }
        if (animationLevelSelectionOut)
        {
            timer += Time.deltaTime;

            if (valueLevelSelection >= 0 && valueLevelSelection <= gridLevelSelection.Length - 1)
            {
                if (timer >= timeAnimate)
                {
                    LeanTween.moveLocalY(gridLevelSelection[valueLevelSelection], -1230f, timeMove);

                    valueLevelSelection--;

                    timer = 0;
                }
            }

            if (valueLevelSelection < 0)
            {
                valueLevelSelection = 0;

                timer = 0;

                animationLevelSelectionOut = false;
            }
        }
        if (animationOptionsOut)
        {
            timer += Time.deltaTime;

            if (valueOptions >= 0 && valueOptions <= gridOptions.Length - 1)
            {
                if (timer >= timeAnimate)
                {
                    LeanTween.moveLocalX(gridOptions[valueOptions], locationOptionsOut[valueOptions], timeMove);

                    valueOptions--;

                    timer = 0;
                }
            }

            if (valueOptions < 0)
            {
                valueOptions = 0;

                timer = 0;

                animationOptionsOut = false;
            }
        }

        if (animationCreditsOut)
        {
            timer += Time.deltaTime;

            if (valueCredits >= 0 && valueCredits <= gridCredits.Length - 1)
            {
                if (timer >= timeAnimate)
                {
                    if (valueCredits <= 2)
                    {
                        LeanTween.moveLocalX(gridCredits[valueCredits], -1450, timeMove);
                    }
                    else
                    {
                        LeanTween.moveLocalX(gridCredits[valueCredits], 1450f, timeMove);
                    }

                    valueCredits--;
                    timer = 0;
                }
            }

            if (valueCredits < 0)
            {
                valueCredits = 0;

                timer = 0;

                animationCreditsOut = false;
            }
        }
        #endregion
    }

    #region BUTTON FUNCTIONS

    public void AnimationMainMenuIn()
    {
        animationMainMenuIn = true;
    }
    public void AnimationMainMenuOut()
    {
        animationMainMenuOut = true;
    }
    public void AnimationLevelSelectionIn()
    {
        animationLevelSelectionIn = true;
    }
    public void AnimationLevelSelectionOut()
    {
        animationLevelSelectionOut = true;
    }
    public void AnimationOptionsIn()
    {
        animationOptionsIn = true;
    }
    public void AnimationOptionsOut()
    {
        animationOptionsOut = true;
    }
    public void AnimationCreditsIn()
    {
        animationCreditsIn = true;
    }
    public void AnimationCreditsOut()
    {
        animationCreditsOut = true;
    }

    #endregion

    #endregion
}
