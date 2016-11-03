using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BaseSoundController : MonoBehaviour
{

    public bool IsInGameSound = false;

    void Awake()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.volume = SoundManager.instance.GetSoundValue();
            SoundManager.ValueChanged soundChanged = delegate(float value)
            {
                if (audioSource != null)
                    audioSource.volume = value;
            };
            if (IsInGameSound)
            {
                SoundManager.instance.GameSoundChanged += soundChanged;
            }
            else
            {
                SoundManager.instance.SoundChanged += soundChanged;
            }

        }
    }
}
