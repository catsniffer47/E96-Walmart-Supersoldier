using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Runtime.InteropServices;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;

    public float minSliderValue = 0f;
    public float maxSliderValue = 1f;

    private float sliderVal;

    public void Start()
    {
        mixer.GetFloat("MasterVolume", out sliderVal);
        volumeSlider.value = sliderVal;
    }

    public void SetVolume()
    {
        float sliderValue = volumeSlider.value;
        if (sliderValue > -50)
        {
            mixer.SetFloat("MasterVolume", sliderValue);
        }
        else
        {
            mixer.SetFloat("MasterVolume", -80);
        }

    }
}
