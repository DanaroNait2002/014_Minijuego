using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBlock : MonoBehaviour
{
    #region VARIABLES

    [Header("Arrays & Values")]
    [SerializeField] private GameObject[] medals01;
    [SerializeField] private GameObject[] medals02;
    [SerializeField] private GameObject[] medals03;
    [SerializeField] private GameObject blockLevel01;
    [SerializeField] private GameObject blockLevel02;
    [SerializeField] private GameObject blockLevel03;
    [SerializeField] private Button buttonLevel01;
    [SerializeField] private Button buttonLevel02;
    [SerializeField] private Button buttonLevel03;

    #endregion

    #region METHODS

    private void Start()
    {
        //PLAYER PREFBS CHECKING IF THE PLAYER HAVE REACH THREE STARS IN THE PREVIOUS LEVEL
        if (PlayerPrefs.GetString("TutorialDone") == "True")
        {
            blockLevel01.SetActive(false);
            buttonLevel01.interactable = true;

            //INSERT ANIMATION FOR UNLOCKING LEVEL 01
            
        }
        else
        {
            blockLevel01.SetActive(true);
            buttonLevel01.interactable = false;
        }


        if (PlayerPrefs.GetInt("AmmountMedals01") == 3)
        {
            blockLevel02.SetActive(false);
            buttonLevel02.interactable = true;

            medals01[0].SetActive(true);
            medals01[1].SetActive(true);
            medals01[2].SetActive(true);

            //INSERT ANIMATION FOR UNLOCKING LEVEL 02
        }
        else
        {
            blockLevel02.SetActive(true);
            buttonLevel02.interactable = false;

            if (PlayerPrefs.GetInt("AmmountMedals01") == 2)
            {
                medals01[0].SetActive(true);
                medals01[1].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("AmmountMedals01") == 1)
            {
                medals01[0].SetActive(true);
            }
            else
            {
                medals01[0].SetActive(false);
                medals01[1].SetActive(false);
                medals01[2].SetActive(false);
            }
        }


        if (PlayerPrefs.GetInt("AmmountMedals02") == 3)
        {
            blockLevel03.SetActive(false);
            buttonLevel03.interactable = true;

            medals02[0].SetActive(true);
            medals02[1].SetActive(true);
            medals02[2].SetActive(true);

            //INSERT ANIMATION FOR UNLOCKING LEVEL 03
        }
        else
        {
            blockLevel03.SetActive(true);
            buttonLevel03.interactable = false;

            if (PlayerPrefs.GetInt("AmmountMedals02") == 2)
            {
                medals02[0].SetActive(true);
                medals02[1].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("AmmountMedals02") == 1)
            {
                medals02[0].SetActive(true);
            }
            else
            {
                medals02[0].SetActive(false);
                medals02[1].SetActive(false);
                medals02[2].SetActive(false);
            }
        }


        if (PlayerPrefs.GetInt("AmmountMedals03") == 3)
        { 
            medals03[0].SetActive(true);
            medals03[1].SetActive(true);
            medals03[2].SetActive(true);

            //INSERT ANIMATION FOR UNLOCKING LEVEL 03
        }
        else
        {
            if (PlayerPrefs.GetInt("AmmountMedals03") == 2)
            {
                medals03[0].SetActive(true);
                medals03[1].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("AmmountMedals03") == 1)
            {
                medals03[0].SetActive(true);
            }
            else
            {
                medals03[0].SetActive(false);
                medals03[1].SetActive(false);
                medals03[2].SetActive(false);
            }
        }
    }


    #endregion
}
