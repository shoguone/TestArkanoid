using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuHUD : MonoBehaviour
{
    public InputField addressInput;
    public MenuPanelManager panelManager;
    public Animator connectPanel;

    private bool isConnecting = false;

    void Awake()
    {
        Time.timeScale = 1f;

        if (addressInput == null)
        {
            addressInput = this.FindUiComponentByName<InputField>("AddressInputField");
        }
    }

    void Start()
    {
        addressInput.text = ObservingNetworkManager.singleton.networkAddress;
    }

    public void StartHost()
    {
        ObservingNetworkManager.singleton.StartHost();
    }

    public void StartClient()
    {
        ObservingNetworkManager.singleton.StartClient();
        isConnecting = true;
        ObservingNetworkManager.observingSingleton.ClientStopped += delegate()
        {
            if (isConnecting && panelManager != null && connectPanel != null)
            {
                panelManager.OpenPanel(connectPanel);
            }
            isConnecting = false;
        };
    }

    public void OnAddressChanged()
    {
        ObservingNetworkManager.singleton.networkAddress = addressInput.text;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
