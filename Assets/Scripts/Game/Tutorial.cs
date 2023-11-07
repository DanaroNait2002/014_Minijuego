using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public void Cheat()
    {
        PlayerPrefs.SetString("TutorialDone", "True");
    }
}
