using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speedMove;
    void Start()
    {
        Destroy(gameObject, 1);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speedMove);
    }
}
