using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force;

    private void Start()
    {
        _rigidbody.AddForce(transform.right * _force);
    }
}
