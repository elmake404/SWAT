using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGan : MonoBehaviour
{
    [SerializeField]
    private Transform _shotPos, _arm;
    [SerializeField]
    private Bullet _bullet;
    private Player _player;
    private RaycastHit _hit;
    [SerializeField]
    private float _speedRot, _delayShot;
    private float _constDelayShot;
    private bool _isAtGunpoint = false, _isActivation = false;
    [SerializeField]
    private LayerMask _layerMask;
    void Start()
    {
        _constDelayShot = _delayShot;
        _player = Player.PlayerMain;
    }
    void FixedUpdate()
    {
        if (_player != null&&_isActivation)
        {
            if (!_isAtGunpoint)
            {
                Quaternion rot = Quaternion.LookRotation(_player.transform.position - transform.position);
                _arm.rotation = Quaternion.Slerp(_arm.rotation, rot, _speedRot);
                if (Physics.Raycast(_shotPos.position, _shotPos.forward, out _hit, 9))
                {
                    if (_hit.collider.tag == "Player")
                    {
                        _isAtGunpoint = true;
                    }
                }
            }
            else
            {
                if (_delayShot <= 0)
                {
                    Instantiate(_bullet, _shotPos.position, _shotPos.rotation);
                    _isAtGunpoint = false;
                    _delayShot = _constDelayShot;
                }
                else
                {
                    _delayShot -= Time.fixedDeltaTime;
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="ActivationZone")
        {
            _isActivation = true;
        }
        if (other.tag == "BulletOfJustice")
        {
            Destroy(gameObject);
        }
    }
}
