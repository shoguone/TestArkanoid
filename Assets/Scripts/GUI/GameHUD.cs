using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHUD : NetworkBehaviour
{
    public MenuPanelManager PanelManager;
    public Animator LosePanel;
    public Animator WinPanel;

    public Text ScoreText;
    public Text WinText;
    public Text LoseText;

    string resultFormat = "{0}\nВаш результат - {1}";

    [SyncVar]
    private int score = 0;

    [SyncVar]
    private float currentTimeScale = 1f;

    private bool isCompleted;

    [SyncVar]
    private float timescale;

    void Start()
    {
        if (isServer)
        {
            RpcResumeGame();
            timescale = Time.timeScale;
        }
        else
        {
            Time.timeScale = timescale;
        }
    }

    public void Menu()
    {
        if (isServer)
        {
            ObservingNetworkManager.singleton.StopHost();
        }
        else
        {
            ObservingNetworkManager.singleton.client.Disconnect();
            SceneManager.LoadScene("offline");
        }
    }

    public void Pause()
    {
        if (!isServer)
            return;
        
        RpcPauseGame();
//        isCompleted = false;
    }

    public void Resume()
    {
        if (!isServer)
            return;

        RpcResumeGame();
    }

    [ClientRpc]
    public void RpcSetScore(int score)
    {
        if (ScoreText != null)
            ScoreText.text = score.ToString();
    }

    public void IncrementScore()
    {
        if (!isServer)
            return;
        
        RpcSetScore(++score);
    }

    [ClientRpc]
    public void RpcComplete(bool won)
    {
//        if (!isServer)
//            return;

        if (isCompleted)
            return;

        isCompleted = true;

        RpcPauseGame();
        if (won)
        {
            PanelManager.OpenPanel(WinPanel);

            AudioSource wonAudio = WinPanel.gameObject.GetComponent<AudioSource>();
            if (wonAudio != null)
            {
                wonAudio.Play();
            }

            if (WinText != null)
            {
                WinText.text = string.Format(resultFormat, WinText.text, score);
            }
        }
        else
        {
            PanelManager.OpenPanel(LosePanel);
            AudioSource loseAudio = LosePanel.gameObject.GetComponent<AudioSource>();
            if (loseAudio != null)           
                loseAudio.Play();            
            LoseText.text = string.Format(resultFormat, LoseText.text, score);
        }

    }

    [ClientRpc]
    public void RpcPauseGame()
    {
        if (Time.timeScale > 0)
            currentTimeScale = Time.timeScale;
        Time.timeScale = 0;
        timescale = Time.timeScale;

        SoundManager.instance.GameSoundMuted = true;
    }

    [ClientRpc]
    public void RpcResumeGame()
    {
        SoundManager.instance.GameSoundMuted = false;

        Time.timeScale = currentTimeScale;
        timescale = Time.timeScale;
    }

}
