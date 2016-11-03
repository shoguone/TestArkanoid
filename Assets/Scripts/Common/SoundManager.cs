using UnityEngine;
using System.Collections;

public class SoundManager {

    public enum SoundType
    {
        Sound, Music, GameSound
    }

    static SoundManager _instance;

    public static SoundManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SoundManager();
            }
            return _instance;
        }
    }

    public delegate void ValueChanged (float newValue);

    public ValueChanged SoundChanged;
    public ValueChanged GameSoundChanged;
    public ValueChanged MusicChanged;

    private bool _soundMuted = false;
    private bool _gameSoundMuted = false;
    private bool _musicMuted = false;

    private float _soundValue = -1;
    private float _musicValue = -1;


    private SoundManager()
    {
        _soundValue = BaseProfile.SoundVolume;
        _musicValue = BaseProfile.MusicVolume;
    }

    public static void PlaySoundAtPosition(AudioClip clip, Vector3 position, SoundType soundType)
    {
        AudioSource.PlayClipAtPoint(clip, position, instance.GetValueByType(soundType));
    }

    public ValueChanged AddValueChangeByType(SoundType type, ValueChanged valueChanged)
    {
        if (type == SoundType.Sound)
            SoundChanged += valueChanged;
        if (type == SoundType.Music)
            MusicChanged += valueChanged;
        if (type == SoundType.GameSound)
            GameSoundChanged += valueChanged;

        return SoundChanged;
    }

    public void SetSoundValue(float value)
    {
        if (SoundChanged != null)
        {
            SoundChanged(_soundMuted ? 0f : value);            
        }
            
        if (GameSoundChanged != null)
            GameSoundChanged(_gameSoundMuted ? 0f : value);

        BaseProfile.SoundVolume = value;
    }

    public void SetMusicValue(float value)
    {
        if (MusicChanged != null)
            MusicChanged(_musicMuted ? 0f : value);
        BaseProfile.MusicVolume = value;
    }

    public float GetSoundValue()
    {
        return BaseProfile.SoundVolume;
    }
    public float GetMusicValue()
    {
        return BaseProfile.MusicVolume;
    }

    public float GetValueByType(SoundType type)
    {
        switch (type)
        {
            case SoundType.Sound:
                return GetSoundValue();
            case SoundType.Music:
                return GetMusicValue();
            case SoundType.GameSound:
                return GetSoundValue();
            default:
                return GetSoundValue();
        }
    }

    public void SetValueByType(float value, SoundType type)
    {
        switch (type)
        {
            case SoundType.Sound:
                SetSoundValue(value);
                break;
            case SoundType.Music:
                SetMusicValue(value);
                break;
            case SoundType.GameSound:
                SetSoundValue(value);
                break;
            default:
                SetSoundValue(value);
                break;
        }
    }


    public bool SoundMuted
    {
        get { return _soundMuted; }
        set
        {
            _soundMuted = value;
            instance.SetSoundValue(_soundValue);
        }
    }

    public bool GameSoundMuted
    {
        get { return _gameSoundMuted; }
        set
        {
            _gameSoundMuted = value;
            instance.SetSoundValue(_soundValue);
        }
    }

    public bool MusicMuted
    {
        get { return _musicMuted; }
        set { 
            _musicMuted = value;
            instance.SetMusicValue(_musicValue); 
        }
    }
}

