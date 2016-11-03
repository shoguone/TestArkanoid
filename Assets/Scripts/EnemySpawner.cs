using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{

    public GameObject enemyPrefab;
    public int numEnemies;
    public float x = 8f;

    float y = 5f;

    public override void OnStartServer()
    {
        if (!ScreenUtils.singleton.isInited)
            ScreenUtils.singleton.Init();
        x = ScreenUtils.singleton.x;
        y = ScreenUtils.singleton.y;
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    public Vector3 GetRandomPosition()
    {
        var pos = new Vector3(
            Random.Range(-x, x),
            y
        );

        return pos;
    }

    public Quaternion GetRandomRotation()
    {
//        return Quaternion.Euler( Random.Range(0,180), Random.Range(0,180), Random.Range(0,180));
        return Quaternion.identity;
    }

    public void SpawnEnemy()
    {
        var pos = GetRandomPosition();
        var rotation = GetRandomRotation();

        var enemyObject = (GameObject)Instantiate(enemyPrefab, pos, rotation);
        var enemy = enemyObject.GetComponent<Enemy>();
        if (enemy != null)
            enemy.enemySpawner = this;
        NetworkServer.Spawn(enemyObject);
    }
}
