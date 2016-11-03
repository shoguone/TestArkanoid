using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundSliderController : MonoBehaviour
{
    public SoundManager.SoundType SoundType;

    void Awake()
    {
        Slider slider = GetComponent<Slider>();
        if (slider != null)
        {
            slider.value = SoundManager.instance.GetValueByType(SoundType);
        }
    }

}
