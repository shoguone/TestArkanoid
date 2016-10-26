using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MyNetworkManager : NetworkManager
{
    NetworkConnection hostPlayerConnection = null;

    bool RememberHostPlayer(NetworkConnection conn)
    {
        var isRemembered = true;
        if (hostPlayerConnection == null)
        {
            hostPlayerConnection = conn;
            Debug.Log("host player is remembered");
        }
        else
        {
            isRemembered = false;
            Debug.Log("doesn't add a player");
        }
        return isRemembered;
    }

    void ForgetHostPlayer()
    {
        Debug.Log(string.Format("host player ({0}) is forgotten", hostPlayerConnection));
        hostPlayerConnection = null;
    }

//    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log("OnServerAddPlayer(2)");
        if (RememberHostPlayer(conn))
            base.OnServerAddPlayer(conn, playerControllerId);
    }

    public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player)
    {
        Debug.Log("OnServerRemovePlayer");
//        if (hostPlayerConnection == conn) {
//            base.OnServerRemovePlayer(conn, player);
//            Debug.Log("OnServerRemovePlayer");
//        }
//        else
//        {
//            Debug.Log("doesn't remove a player");
//        }
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("OnClientConnect");
        base.OnClientConnect(conn);
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("OnClientDisconnect");
        base.OnClientDisconnect(conn);
    }

    public override void OnClientError(NetworkConnection conn, int errorCode)
    {
        Debug.Log("OnClientError");
        base.OnClientError(conn, errorCode);
    }

    public override void OnClientNotReady(NetworkConnection conn)
    {
        Debug.Log("OnClientNotReady");
        base.OnClientNotReady(conn);
    }

    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        Debug.Log("OnClientSceneChanged");
        base.OnClientSceneChanged(conn);
    }

    public override void OnDestroyMatch(bool success, string extendedInfo)
    {
        Debug.Log("OnDestroyMatch");
        base.OnDestroyMatch(success, extendedInfo);
    }

    public override void OnDropConnection(bool success, string extendedInfo)
    {
        Debug.Log("OnDropConnection");
        base.OnDropConnection(success, extendedInfo);
    }

    public override void OnMatchCreate(bool success, string extendedInfo, UnityEngine.Networking.Match.MatchInfo matchInfo)
    {
        Debug.Log("OnMatchCreate");
        base.OnMatchCreate(success, extendedInfo, matchInfo);
    }

    public override void OnMatchJoined(bool success, string extendedInfo, UnityEngine.Networking.Match.MatchInfo matchInfo)
    {
        Debug.Log("OnMatchJoined");
        base.OnMatchJoined(success, extendedInfo, matchInfo);
    }

    public override void OnMatchList(bool success, string extendedInfo, System.Collections.Generic.List<UnityEngine.Networking.Match.MatchInfoSnapshot> matchList)
    {
        Debug.Log("OnMatchList");
        base.OnMatchList(success, extendedInfo, matchList);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        Debug.Log("OnServerAddPlayer(3)");
        if (RememberHostPlayer(conn))
            base.OnServerAddPlayer(conn, playerControllerId, extraMessageReader);
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("OnServerConnect");
        base.OnServerConnect(conn);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        Debug.Log("OnServerDisconnect");
        base.OnServerDisconnect(conn);
    }

    public override void OnServerError(NetworkConnection conn, int errorCode)
    {
        Debug.Log("OnServerError");
        base.OnServerError(conn, errorCode);
    }

    public override void OnServerReady(NetworkConnection conn)
    {
        Debug.Log("OnServerReady");
        base.OnServerReady(conn);
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        Debug.Log("OnServerSceneChanged");
        base.OnServerSceneChanged(sceneName);
    }

    public override void OnSetMatchAttributes(bool success, string extendedInfo)
    {
        Debug.Log("OnSetMatchAttributes");
        base.OnSetMatchAttributes(success, extendedInfo);
    }

    public override void OnStartClient(NetworkClient client)
    {
        Debug.Log("OnStartClient");
        base.OnStartClient(client);
    }

    public override void OnStartHost()
    {
        Debug.Log("OnStartHost");
        base.OnStartHost();
    }

    public override void OnStartServer()
    {
        Debug.Log("OnStartServer");
        base.OnStartServer();
    }

    public override void OnStopClient()
    {
        Debug.Log("OnStopClient");
        base.OnStopClient();
    }

    public override void OnStopHost()
    {
        Debug.Log("OnStopHost");
        base.OnStopHost();
    }

    public override void OnStopServer()
    {
        Debug.Log("OnStopServer");
        ForgetHostPlayer();
        base.OnStopServer();
    }

    public override void ServerChangeScene(string newSceneName)
    {
        Debug.Log("ServerChangeScene");
        base.ServerChangeScene(newSceneName);
    }

    public override NetworkClient StartHost()
    {
        Debug.Log("StartHost");
        return base.StartHost();
    }

    public override NetworkClient StartHost(ConnectionConfig config, int maxConnections)
    {
        Debug.Log("StartHost(2)");
        return base.StartHost(config, maxConnections);
    }

    public override NetworkClient StartHost(UnityEngine.Networking.Match.MatchInfo info)
    {
        Debug.Log("StartHost(1)");
        return base.StartHost(info);
    }

}
