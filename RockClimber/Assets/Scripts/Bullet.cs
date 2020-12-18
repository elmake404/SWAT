using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speedMove;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward*_speedMove);
    }
}
