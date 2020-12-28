using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    private Collider[] _colliders;
    [SerializeField]
    private Rigidbody _rbMain, _rbHead, _rbBodies;
    [SerializeField]
    private GameObject _ragdoll;


    [SerializeField]
    private float _forseShot;
    [SerializeField]
    private int _heals;

    [HideInInspector]
    public bool Life;
    private void Awake()
    {
        Life = true;
    }
    public void Headshot()
    {
        Death();
        ShotHeand();
    }
    public void BodyShot()
    {
        _heals--;
        if (_heals == 0)
        {
            Death();
            BodyHeand();
        }
    }
    public void Death()
    {
        Life = false;
        _rbBodies.isKinematic = false;
        for (int i = 0; i < _colliders.Length; i++)
        {
            _colliders[i].enabled = false;
        }
        _ragdoll.SetActive(true);
        _ragdoll.transform.parent.SetParent(null);
    }
    public Rigidbody GetRigidbody()
    {
        return _rbBodies;
    }
    private void ShotHeand()
    {
        _rbHead.AddForce(Vector3.left*_forseShot);
    }
    private void BodyHeand()
    {
        _rbBodies.AddForce(Vector3.left * _forseShot);
    }
}
