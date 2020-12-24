using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player PlayerMain;

    [SerializeField]
    private Rigidbody _rbMain;
    [SerializeField]
    private Bullet _bullet;
    private Camera _cam;
    [SerializeField]
    private Vector3 _startMosePos, _currentMosePos, _direcrionVector;
    [SerializeField]
    private Transform _shotPos, _arm;
    private GameObject _enemyTarget;

    [SerializeField]
    private float _forceJump, _speedShot, _speedMoveDown, _speedMoveUp;
    private float _constSpeedShot;
    private bool _isEnemyAtGunpoint;
    private void Awake()
    {
        _constSpeedShot = _speedShot;
        PlayerMain = this;
        _cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            if (_startMosePos == Vector3.zero)
            {
                _startMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
            }

            _currentMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);

            if (Mathf.Abs(_startMosePos.y - _currentMosePos.y) >= 0.01f)
            {

                if (Mathf.Abs((_currentMosePos.y - _startMosePos.y) * 7) > 1)
                {

                    float yStart = ((_currentMosePos.y - _startMosePos.y) > 0 ? 0.14f : -0.14f);
                    _startMosePos.y = _currentMosePos.y - yStart;
                }

                float Y = 0;

                if (((_currentMosePos.y - _startMosePos.y) * 7) <= 0)
                {
                    //Debug.Log();
                    Y = ((_currentMosePos.y - _startMosePos.y) * 7) * _speedMoveDown;
                }
                else
                {
                    Y = ((_currentMosePos.y - _startMosePos.y) * 7) * _speedMoveUp;
                }

                _direcrionVector = new Vector3(0, Y, 0);
            }
            else
            {
                _direcrionVector = _rbMain.velocity;
            }

        }
        else
        {
            _direcrionVector = _rbMain.velocity;
            _direcrionVector.y = 0;
        }
    }
    private void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        _direcrionVector.x = _rbMain.velocity.x;
        _rbMain.velocity = _direcrionVector;

        if (_isEnemyAtGunpoint && Mathf.Round(_rbMain.velocity.y) == 0&&_enemyTarget!=null)
        {
            if (_speedShot <= 0)
            {
                Instantiate(_bullet, _shotPos.position, _shotPos.rotation);
                _speedShot = _constSpeedShot;
            }
            else
            {
                _speedShot -= Time.fixedDeltaTime;
            }
        }
        if (_enemyTarget != null)
        {
            Vector3 PosEnemy = _enemyTarget.transform.position;
            PosEnemy.y = transform.position.y;
            _arm.LookAt(PosEnemy);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            _rbMain.velocity = (transform.up * _forceJump);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Thorns")
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && _enemyTarget == null)
        {
            _enemyTarget = other.gameObject;
            _isEnemyAtGunpoint = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _enemyTarget = null;
            _isEnemyAtGunpoint = false;
        }
    }
}
