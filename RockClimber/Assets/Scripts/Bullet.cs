using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speedMove;
    void Start()
    {
        Destroy(gameObject, 1);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speedMove);
        RaycastHit hit;
        if (Physics.Raycast(transform.position,-transform.forward,out hit,10))
        {
            if (hit.collider.tag == "Wall")
            {
                Destroy(gameObject);
            }
            else if (hit.collider.tag == "Head")
            {
                hit.collider.GetComponentInParent<EnemyLife>().Headshot();
            }
            else if (hit.collider.tag == "Enemy")
            {
                hit.collider.GetComponent<EnemyLife>().BodyShot();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Wall")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Head")
        {
            other.GetComponentInParent<EnemyLife>().Headshot();
            Destroy(gameObject);
        }
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyLife>().BodyShot();
            Destroy(gameObject);
        }

        //if (other.tag =="Glass")
        //{
        //    other.GetComponent<Glass>().Breaking();
        //}
    }
}
