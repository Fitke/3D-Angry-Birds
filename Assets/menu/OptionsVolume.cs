using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer SfxaudioMixer;
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
    public void SetSfxVolume(float volume)
    {
        SfxaudioMixer.SetFloat("SfxVolume", Mathf.Log10(volume) * 20);
    }
}
