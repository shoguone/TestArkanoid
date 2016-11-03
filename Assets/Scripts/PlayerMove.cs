using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 10f;

    void Update()
    {
        if (!isLocalPlayer)
            return;
        
        var x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
            CmdFire();

        var xLimit = ScreenUtils.singleton.x;
        if ((transform.position.x > -xLimit && x < 0)
            || (transform.position.x < xLimit && x > 0)
            )
            transform.Translate(x, 0f, 0f);
    }

    [Command]
    void CmdFire()
    {
        // create the bullet object from the bullet prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position - transform.forward,
            Quaternion.identity);

        // make the bullet move away in front of the player
        bullet.GetComponent<Rigidbody>().velocity = -transform.forward*4;

        NetworkServer.Spawn(bullet);

        // make bullet disappear after 2 seconds
        Destroy(bullet, 2.0f);        
    }

    void Fire()
    {
        // create the bullet object from the bullet prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position - transform.forward,
            Quaternion.identity);

        // make the bullet move away in front of the player
        bullet.GetComponent<Rigidbody>().velocity = -transform.forward*4;

        // make bullet disappear after 2 seconds
        Destroy(bullet, 2.0f);        
    }
}
