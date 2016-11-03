using System;
using UnityEngine;
using System.Collections;

public class LocalSoundManager : MonoBehaviour
{

    void Start()
    {
        SetSoundVolume(SoundManager.instance.GetSoundValue());
        SetMusicVolume(SoundManager.instance.GetMusicValue());
    }

    public void SetSoundVolume(float value)
    {        
        SoundManager.instance.SetSoundValue(value);
    }

    public void SetMusicVolume(float value)
    {
        SoundManager.instance.SetMusicValue(value);
    }

}
