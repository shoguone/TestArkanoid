using UnityEngine;
using UnityEngine.Networking;

public class EnemyMove : NetworkBehaviour
{
    public ConstantForce2D force;
    public float direction = 0;
    public float rotationSpeed = 30f;

    public float changeDirectionPeriod = 1f;
    float changeDirectionTimer = 0f;
    public float timerFromSceneStart = 0;

    public float speedUpPeriod = 30f;
    public float speedUpRating = 1.5f;
    static Vector2 forceValue;
    static int speedUpLevel = 1;

    new Rigidbody2D rigidbody2D;
    new AudioSource audio;

    void Start()
    {
        if (!isServer)
            return;

        if (force == null)
            force = GetComponent<ConstantForce2D>();

        rigidbody2D = GetComponent<Rigidbody2D>();

        audio = GetComponent<AudioSource>();

        speedUpLevel = 1;
        forceValue = force.relativeForce;

        ChangeDirection();
    }

    void Update()
    {
        if (!isServer)
            return;

        timerFromSceneStart += Time.deltaTime;
        changeDirectionTimer += Time.deltaTime;
        if (changeDirectionTimer > changeDirectionPeriod)
        {
            ChangeDirection();
        }
        var rotation = direction * Time.deltaTime * rigidbody2D.velocity.magnitude;
        transform.Rotate(Vector3.forward, rotation);

        if (timerFromSceneStart > speedUpPeriod * speedUpLevel)
        {
            Debug.Log("Speeding up!");
            forceValue *= speedUpRating;
            ++speedUpLevel;
        }
    }

    void ChangeDirection()
    {
        changeDirectionTimer = 0;
        direction = Random.Range(-rotationSpeed, rotationSpeed);
        force.relativeForce = forceValue;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (audio != null)
            audio.Play();
    }
}
