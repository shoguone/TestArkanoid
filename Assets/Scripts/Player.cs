using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isLocalPlayer)
            return;
        
        var hit = collision.gameObject;
        var enemy = hit.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.GetExploded();

            GameHud.IncrementScore();
        }
    }

}

