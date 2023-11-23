using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    [Header("Mixer Groups")]
    [SerializeField] 
    private AudioMixerGroup ambienceMixerGroup;
    [SerializeField] 
    private AudioMixerGroup effectsMixerGroup;

    [Header("Volume Sliders")]
    [SerializeField]
    private Slider ambienceSlider;
    [SerializeField]
    private Slider effectsSlider;

    void Start()
    {
        LoadVolume();
    }

    //FUNTIONS

    public void Update()
    {
        ambienceMixerGroup.audioMixer.SetFloat("Background", Mathf.Log10(ambienceSlider.value) * 20);

        effectsMixerGroup.audioMixer.SetFloat("Effects", Mathf.Log10(effectsSlider.value) * 20);
    }

    public void LoadVolume()
    {
        //At the start the value in the slider is set to the one that has been save or to 1f in case there's none
        ambienceSlider.value = PlayerPrefs.GetFloat("ambienceVolume", 1f);
        effectsSlider.value = PlayerPrefs.GetFloat("effectsVolume", 1f);
    }

    //BUTTONS FUNTIONS
    public void SaveVolume()
    {
        //The value given to the slider is saved
        PlayerPrefs.SetFloat("ambienceVolume", ambienceSlider.value);
        PlayerPrefs.SetFloat("effectsVolume", effectsSlider.value);
    }

    public void ResetVolume()
    {
        PlayerPrefs.SetFloat("ambienceVolume", 1f);
        PlayerPrefs.SetFloat("effectsVolume", 1f);

        LoadVolume();
    }
}
