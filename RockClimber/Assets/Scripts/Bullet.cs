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
            else if (hit.collider.tag == "Glass")
            {
                hit.collider.GetComponent<Glass>().Breaking();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Wall")
        {
            Destroy(gameObject);
        }
        if (other.tag =="Glass")
        {
            other.GetComponent<Glass>().Breaking();
        }
    }
}
