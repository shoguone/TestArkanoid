using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public static class HUD
{
    /// <summary>
    /// Finds the first UIBehaviour component with given name within given MonoBehaviour instance' children.
    /// </summary>
    /// <returns>The user interface component by name.</returns>
    /// <param name="script">Script.</param>
    /// <param name="name">Name.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public static T FindUiComponentByName<T>(this MonoBehaviour script, string name) where T : UIBehaviour
    {
        T component = script.GetComponentsInChildren<T>()
            .FirstOrDefault(e => e.name == name);
        if (component == null)
        {
            var errorText = string.Format("Can't find {0}!", name);
            #if UNITY_EDITOR
            Debug.LogError(errorText);
            Debug.Break();
            #else
            // throw new Exception(errorText);
            Application.Quit();
            #endif
        }
        return component;
    }

}