using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrenade : MonoBehaviour
{
    [SerializeField]
    private BezierSpline _spline;
    private Vector3 _spawnPos;
    [SerializeField]
    private Grenade _grenade;
    [SerializeField]
    private float _timeSpawnGrenade;

    void Start()
    {        
        _spawnPos = _spline.GetPoint(0);
        StartCoroutine(SpawnGrenade());
    }
    private IEnumerator SpawnGrenade()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeSpawnGrenade);
            Grenade grenade = Instantiate(_grenade,_spawnPos,Quaternion.identity);
            grenade.InitializationSpline(_spline);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BulletOfJustice")
        {
            Destroy(gameObject);
            _spline.transform.SetParent(null);
        }
    }

}
