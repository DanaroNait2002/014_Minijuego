using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetAll : MonoBehaviour
{
    public void ResetAllValues()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(0);
    }
}
