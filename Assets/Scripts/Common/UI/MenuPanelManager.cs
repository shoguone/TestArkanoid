using UnityEngine;

public class MenuPanelManager : MonoBehaviour
{

    public Animator FirstOpen;
    private Animator _currentPanelAnimator;

    private const string AnimKey = "Open";

    public void Start()
    {        
        OpenPanel(FirstOpen);
    }

    public void OpenPanel(Animator panelAnimator)
    {
        if (_currentPanelAnimator == panelAnimator)
        {
            return;
        }

        panelAnimator.gameObject.SetActive(true);
        panelAnimator.SetBool(AnimKey, true);
        if (_currentPanelAnimator != null)
        {
            _currentPanelAnimator.SetBool(AnimKey, false);
            _currentPanelAnimator.gameObject.SetActive(false);
        }

        _currentPanelAnimator = panelAnimator;

        if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
    }

}
