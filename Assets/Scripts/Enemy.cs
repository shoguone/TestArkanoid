using UnityEngine;
using UnityEngine.Networking;

public class Enemy : NetworkBehaviour
{
    public GameObject explosionPrefab;
    public EnemySpawner enemySpawner;

    public void GetExploded()
    {
        if (!isServer)
            return;

        var explosion = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        NetworkServer.Spawn(explosion);
        RpcRespawn();
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (!isServer)
            return;
        enemySpawner.SpawnEnemy();
        Destroy(gameObject);
    }

}

