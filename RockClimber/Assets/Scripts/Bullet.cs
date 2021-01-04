using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speedMove;
    [SerializeField]
    private ParticleSystem _break;
    void Start()
    {
        Destroy(gameObject, 2);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speedMove);
        RaycastHit hit;
        if (Physics.Raycast(transform.position,-transform.forward,out hit,10))
        {
            if (hit.collider.tag == "Wall")
            {
                BulletHit();
            }
            else if (hit.collider.tag == "Glass")
            {
                hit.collider.GetComponent<Glass>().Breaking();
            }
            else if (hit.collider.tag == "Head")
            {
                hit.collider.GetComponentInParent<EnemyLife>().Headshot();
                BulletHit();
            }
            else if (hit.collider.tag == "Enemy")
            {
                hit.collider.GetComponent<EnemyLife>().BodyShot();
                BulletHit();
            }
        }
    }
    private void BulletHit()
    {
        _break.Play();
        _break.transform.SetParent(null);
        Destroy(gameObject);
    }
}
