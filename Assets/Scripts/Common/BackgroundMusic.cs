using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{

    private static BackgroundMusic instance;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().volume = SoundManager.instance.GetMusicValue();
            SoundManager.instance.MusicChanged += delegate(float value)
            {
                if (GetComponent<AudioSource>() != null)
                    GetComponent<AudioSource>().volume = value;
            };
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    
}
