using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHUD : NetworkBehaviour
{
    public Button pauseButton;
    public Button menuButton;

    void Awake()
    {
        if (pauseButton == null)
        {
            pauseButton = this.FindUiComponentByName<Button>("PauseButton");
        }

        if (menuButton == null)
        {
            menuButton = this.FindUiComponentByName<Button>("MenuButton");
        }

        if (isClient)
        {
            pauseButton.gameObject.SetActive(false);
        }
    }

    public void StopHost()
    {
        if (isServer)
        {
            MyNetworkManager.singleton.StopHost();
        }
        else
        {
            MyNetworkManager.singleton.client.Disconnect();
            SceneManager.LoadScene("offline");
        }
    }

    public void Pause()
    {
        if (isClient)
            return;
        
        Time.timeScale = 0;
    }

    public void Resume()
    {
        if (isClient)
            return;

        Time.timeScale = 1;
    }

}
