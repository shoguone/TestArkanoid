﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var hitPlayer = hit.GetComponent<PlayerMove>();
        if (hitPlayer != null)
        {
            Destroy(gameObject);
        }
    }
}
