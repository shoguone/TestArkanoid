using UnityEngine;
using UnityEngine.Networking;

public class ScreenUtils : NetworkBehaviour
{
    public static ScreenUtils singleton
    {
        get
        {
            if (_singleton == null)
                _singleton = FindObjectOfType<ScreenUtils>();
            return _singleton;
        }
    }
    private static ScreenUtils _singleton;

    Camera mainCamera;

    [SyncVar]
    public float y;
    [SyncVar]
    public float x;
    [SyncVar]
    public float aspect;

    public bool isInited;

    void Awake()
    {
        _singleton = this;
    }

    public override void OnStartServer()
    {
        if (!isInited)
            Init();
    }

    public void Init()
    {
        isInited = true;
        mainCamera = Camera.main;
        y = mainCamera.orthographicSize;
        aspect = mainCamera.aspect;
        x = aspect * y;
    }
}
