using UnityEngine;
using UnityEngine.Networking;

public class SetBorders : NetworkBehaviour
{
    public Transform top;
    public Transform left;
    public Transform right;

    public override void OnStartServer()
    {
        if (!ScreenUtils.singleton.isInited)
            ScreenUtils.singleton.Init();
        var width = ScreenUtils.singleton.x;
        left.position = new Vector3(-width, left.position.y);
        right.position = new Vector3(width, right.position.y);
	}
}
