using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
    [SerializeField] private AudioMixer audioMixer;

    private Slider slider;


    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volume", volume);
    }

    public void ToogleFullScreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}
