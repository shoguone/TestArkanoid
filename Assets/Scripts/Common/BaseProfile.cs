using System;
using UnityEngine;

public class BaseProfile {

    static bool IsBasicType(Type tp)
    {
        return tp.IsPrimitive || tp == typeof (string) || tp.IsEnum || tp == typeof (DateTime) ||
            tp == typeof (TimeSpan) || tp == typeof (Guid) || tp == typeof (decimal);
    }

    public static void StoreValue<T>(T value, string key)
    {
        object v;
        if (IsBasicType(typeof(T)))
            v = BasicTypeWrapper.FromEntry(value);
        else
            v = value;
        string serialized = JsonUtility.ToJson(v);
        PlayerPrefs.SetString(key, serialized);
        PlayerPrefs.Save();
    }

    public static T ResolveValue<T>(string key, T defaultValue)
    {
        string value = PlayerPrefs.GetString(key);
        if (String.IsNullOrEmpty(value))
        {
            return defaultValue;
        }

        T deserialized;
        if (IsBasicType(typeof(T)))
        {
            Type basicType = BasicTypeWrapper.ResolveType(typeof(T));
            var obj = JsonUtility.FromJson(value, basicType);
            deserialized = (T)BasicTypeWrapper.GetValue(obj, basicType);
        }
        else
        {
            deserialized = JsonUtility.FromJson<T>(value);
            return deserialized;
        }

        return deserialized;
    }


    public static float SoundVolume
    {
        get
        {
            return ResolveValue<float>("SoundVolume", 1f);            
        }
        set
        {
            StoreValue<float>(value, "SoundVolume");
        }
    }

    public static float MusicVolume
    {
        get
        {
            return ResolveValue<float>("MusicVolume", 1f);
        }
        set
        {
            StoreValue<float>(value, "MusicVolume");
        }
    }

    public static void ClearProfile()
    {
        PlayerPrefs.DeleteAll();
    }
}
