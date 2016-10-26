using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuHUD : MonoBehaviour
{
    public InputField addressInput;

    void Awake()
    {
        if (addressInput == null)
        {
            addressInput = this.FindUiComponentByName<InputField>("AddressInputField");
        }
//        addressInput.text = MyNetworkManager.singleton.networkAddress;
//        var manager = FindObjectOfType<MyNetworkManager>();
//        if (manager != null)
//        {
//            addressInput.text = manager.networkAddress;
//        }
//        else
//        {
//            addressInput.text = "Where is MyNetworkManager?!";
//        }
    }

    void Start()
    {
        addressInput.text = MyNetworkManager.singleton.networkAddress;
    }

    public void StartHost()
    {
        MyNetworkManager.singleton.StartHost();
    }

    public void StartClient()
    {
        MyNetworkManager.singleton.StartClient();
    }

    public void OnAddressChanged()
    {
        MyNetworkManager.singleton.networkAddress = addressInput.text;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
