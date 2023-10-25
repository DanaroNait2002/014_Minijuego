using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levels;
    [SerializeField]
    private float timer;
    [SerializeField] 
    private int value;
    [SerializeField]
    private bool buttonPressed;
    [SerializeField]
    public int currentLevel;
    [SerializeField]
    private LoadScene scene;

    private void Update()
    {
        if (buttonPressed)
        {
            timer += Time.deltaTime;

            if (value >= 0 && value <= levels.Length - 1)
            {
                if (value == currentLevel)
                {
                    value++;
                }

                if (timer >= 0.35f)
                {
                    LeanTween.moveLocalY(levels[value], -1230, 0.35f);

                    value++;

                    timer = 0;
                }
            }

            if (value > levels.Length - 1 && timer >= 0.35f)
            {
                LeanTween.moveLocalX(levels[currentLevel], 0f, 0.35f);
                LeanTween.scale(levels[currentLevel], new Vector3(5f, 5f, 5f), 0.35f).setOnComplete(Loader);
            }
        }
    }

    public void ButtonPressed(int i)
    {
        buttonPressed = true;
        currentLevel = i;
    }

    private void Loader()
    {
        scene.Load(currentLevel);
    }
}
