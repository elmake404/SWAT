﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper : MonoBehaviour
{
    [SerializeField]
    private Transform _shotPos, _arm, _shotgunMod, _shotgunPos;
    [SerializeField]
    private BulletEnemy _bullet;
    private Player _player;
    
    [SerializeField]
    private float _speedRot, _delayShot;
    private float _constDelayShot;
    private bool _isAtGunpoint = false;
    [SerializeField]
    private LayerMask _layerMask;
    void Start()
    {
        _constDelayShot = _delayShot;
        _player = Player.PlayerMain;
    }
    void FixedUpdate()
    {
        _shotgunMod.SetPositionAndRotation(_shotgunPos.position,_shotgunPos.rotation);
        if (_player != null)
        {
            if (!_isAtGunpoint)
            {
                RaycastHit[] _hit;
                Quaternion rot = Quaternion.LookRotation(_player.transform.position - transform.position);
                _arm.rotation = Quaternion.Slerp(_arm.rotation, rot, _speedRot);
                _hit = Physics.RaycastAll(_shotPos.position, _shotPos.forward,100);
                for (int i = 0; i < _hit.Length; i++)
                {
                    if (_hit[i].collider.gameObject.layer == 9)
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
}
