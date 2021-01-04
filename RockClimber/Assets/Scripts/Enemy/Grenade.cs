﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private RaycastHit _hit;
    [SerializeField]
    private ParticleSystem _explosion;
    [SerializeField]
    private SphereCollider _sphereCollider;
    [SerializeField]
    private MeshRenderer _mesh;
    private BezierSpline _spline;

    private float _pointPos;
    [SerializeField]
    private float _speed, _explosionRadius;
    void Start()
    {
        _sphereCollider.enabled = false;
    }

    void FixedUpdate()
    {
        if (_pointPos < 1)
        {
            transform.position = _spline.GetPoint(_pointPos);
            _pointPos += _speed;
        }
        else if(_mesh.enabled)
        {
            StartCoroutine(Destroy());
        }
    }
    private IEnumerator Destroy()
    {
        _sphereCollider.radius = _explosionRadius;
        _sphereCollider.enabled = true;
        _mesh.enabled = false;
        _explosion.Play();
        yield return new WaitForSeconds(0.7f);
        _sphereCollider.enabled = false;
        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
    public void InitializationSpline(BezierSpline spline)
    {
        _spline = spline;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //if (other.tag =="Player")
    //    //{
    //    //    Destroy(other.transform.parent.gameObject);
    //    //}
    //}
}
