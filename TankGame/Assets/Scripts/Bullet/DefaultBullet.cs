using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DefaultBullet : Bullet
{
    private void Start()
    {
        DestroyBullet(delay);
    }
}
