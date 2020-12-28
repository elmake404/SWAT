using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrenade : MonoBehaviour
{
    [SerializeField]
    private EnemyLife _lifeMain;

    [SerializeField]
    private BezierSpline _spline;
    [SerializeField]
    private Animator _animator;
    private Vector3 _spawnPos;
    [SerializeField]
    private Grenade _grenade;
    [SerializeField]
    private float _timeSpawnGrenade;

    void Start()
    {        
        _spawnPos = _spline.GetPoint(0);
        _spline.transform.SetParent(null);

        StartCoroutine(SpawnGrenade());
    }
    private void FixedUpdate()
    {
        if (!_lifeMain.Life)
        {
            Death();
        }
    }
    private IEnumerator SpawnGrenade()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            _animator.SetBool("Throw", true);
            yield return new WaitForSeconds(0.7f);
            _animator.SetBool("Throw", false);

            Grenade grenade = Instantiate(_grenade,_spawnPos,Quaternion.identity);
            grenade.InitializationSpline(_spline);
            yield return new WaitForSeconds(1.5f);
            yield return new WaitForSeconds(_timeSpawnGrenade);
        }
    }
    private void Death()
    {
        _animator.enabled = false;
        //Debug.Log(_animator.enabled);
        Destroy(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "BulletOfJustice")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
