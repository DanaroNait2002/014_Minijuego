using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorial_Canvas;
    [SerializeField]
    private GameObject text;

    [SerializeField]
    private bool startTutorial;
    [SerializeField]
    private string hasSeenTutorial_Level01_Text;

    private void Awake()
    {
        hasSeenTutorial_Level01_Text = PlayerPrefs.GetString("hasSeenTutorial_Level01", "false");

        if (hasSeenTutorial_Level01_Text == "true" )
        {
            Destroy(this);
        }
        else
        {
            tutorial_Canvas.SetActive(true);
            startTutorial = true;
        }
    }

    private void Update()
    {
        if (startTutorial)
        {
            LeanTween.alphaCanvas(text.GetComponent<CanvasGroup>(), 100f, 0.25f);
        }
    }
}
