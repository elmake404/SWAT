using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private RaycastHit _hit;
    [SerializeField]
    private SphereCollider _sphereCollider;
    private BezierSpline _spline;
    private float _pointPos;
    [SerializeField]
    private float _speed, _explosionRadius;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (_pointPos < 1)
        {
            transform.position = _spline.GetPoint(_pointPos);
            _pointPos += _speed;
        }
        else
        {
            _sphereCollider.radius = _explosionRadius;
            Destroy(gameObject,0.5f);
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            Destroy(other.gameObject);
        }
    }
}
