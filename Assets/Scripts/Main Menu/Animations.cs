using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    #region VARIABLES

    //CANVAS
    [SerializeField]
    private GameObject canvas;

    //TO ANIMATE
    [SerializeField]
    private GameObject textTittle;
    [SerializeField]
    private GameObject buttonBack;
    [SerializeField]
    private GameObject[] gridMainMenu;
    [SerializeField]
    private GameObject[] gridLevelSelection;
    [SerializeField]
    private GameObject[] gridOptions;
    [SerializeField]
    private GameObject[] gridCredits;

    //VALUES
    [SerializeField]
    private int valueMainMenu;
    [SerializeField]
    private int valueLevelSelection;
    [SerializeField]
    private int valueOptions;
    [SerializeField]
    private int valueCredits;

    //TIME
    [SerializeField]
    private float timer;
    [SerializeField]
    private float timeAnimate;

    //LOCATIONS
    [SerializeField]
    private float locationTittle;
    [SerializeField]
    private float locationButtonBack;
    [SerializeField]
    private float[] locationMainMenu;
    [SerializeField]
    private float locationLevelSelection;
    [SerializeField]
    private float locationOptions;
    [SerializeField]
    private float locationCredits;

    //BOOLS -> STATE SELECTOR
    [SerializeField]
    private bool animationMainMenuIn;
    [SerializeField]
    private bool animationMainMenuOut;
    [SerializeField]
    private bool animationLevelSelectionIn;
    [SerializeField]
    private bool animationLevelSelectionOut;
    [SerializeField]
    private bool animationOptionsIn;
    [SerializeField]
    private bool animationOptionsOut;
    [SerializeField]
    private bool animationCreditsIn;
    [SerializeField]
    private bool animationCreditsOut;

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

        locationLevelSelection = -185f;

        //Start Animation
        AnimationMainMenuIn();
    }

    private void Update()
    {
        #region ANIMATION IN

        if (animationMainMenuIn && valueMainMenu >= 0)
        {
            Debug.Log("AnimationInMainMenu");

            //Move the Tittle
            LeanTween.moveLocalY(textTittle, 336, 1f);

            //Set Timer
            timer += Time.deltaTime;

            if (valueMainMenu >= 0 && valueMainMenu <= gridMainMenu.Length - 1)
            {
                if (timer >= timeAnimate)
                {
                    Debug.Log("MOVING" + valueMainMenu);
                    LeanTween.moveLocalY(gridMainMenu[valueMainMenu], locationMainMenu[valueMainMenu], 0.5f);

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
        if (animationLevelSelectionIn && valueLevelSelection >= 0)
        {
            Debug.Log("AnimationLevelSelectionMenu");
          
            //Set Timer
            timer += Time.deltaTime;

            if (valueLevelSelection >= 0 && valueLevelSelection <= gridLevelSelection.Length - 1)
            {
                if (timer >= timeAnimate)
                {
                    Debug.Log("MOVING" + valueLevelSelection);
                    LeanTween.moveLocalY(gridLevelSelection[valueLevelSelection], locationLevelSelection, 0.5f);

                    valueMainMenu++;
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

        #endregion

        #region ANIMATION OUT

        if (animationMainMenuOut && valueMainMenu <= gridMainMenu.Length - 1)
        {
            timer += Time.deltaTime;

            if (valueMainMenu >= 0 && valueMainMenu <= gridMainMenu.Length - 1)
            {
                if (timer >= timeAnimate)
                {
                    LeanTween.moveLocalY(gridMainMenu[valueMainMenu], -1230f, 0.5f);

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
