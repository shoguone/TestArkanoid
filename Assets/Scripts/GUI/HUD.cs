using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public static class HUD
{
    public static T FindUiComponentByName<T>(this MonoBehaviour script, string name) where T : UIBehaviour
    {
        T component = script.GetComponentsInChildren<T>()
            .FirstOrDefault(e => e.name == name);
        if (component == null)
        {
            Debug.LogError(string.Format("Can't find {0}!", name));
            Debug.Break();
        }
        return component;
    }

}