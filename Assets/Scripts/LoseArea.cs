using UnityEngine;
using System.Collections;

public class LoseArea : MonoBehaviour
{
    GameHUD GameHud
    {
        get {
            if (gameHud == null)
                gameHud = FindObjectOfType<GameHUD>();
            return gameHud;
        }
    }
    GameHUD gameHud;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameHud.RpcComplete(false);
    }
}
