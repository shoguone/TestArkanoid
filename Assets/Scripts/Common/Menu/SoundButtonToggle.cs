using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonToggle : MonoBehaviour
{

    public Slider ValueSlider;
    public SoundManager.SoundType Type;

	void Awake ()
	{
	    SoundManager.instance.AddValueChangeByType(Type, delegate(float value)
	    {
	        if (this != null)
	            ValueChanged(value);           
	    });

	}

    void Start()
    {
        ValueChanged(SoundManager.instance.GetValueByType(Type));
    }


    private void ValueChanged(float value)
    {
        Toggle toggle = GetComponent<Toggle>();
        if (toggle != null)
        {
            toggle.isOn = (value > 0f);
        }

    }

    public void ToggleAction(bool isChecked)
    {
        float value;
        if (isChecked)
        {
            float volume = SoundManager.instance.GetValueByType(Type);
            value = volume > 0f ? volume : 0.5f;
        }
        else
        {
            value = 0f;
        }
        SoundManager.instance.SetValueByType(value, Type);

        if (ValueSlider != null)
        {
            if (!isChecked && ValueSlider.value > 0f)
                ValueSlider.value = 0f;
            if (isChecked && ValueSlider.value == 0f)
                ValueSlider.value = value;

        }
    }

}
