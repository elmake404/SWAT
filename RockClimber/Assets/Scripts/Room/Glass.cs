using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _meshRenderer;
    [SerializeField]
    private Collider _collider;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag=="Player")
    //    {
    //        other.GetComponent<Graviti>().RevertGraviti();
    //    }
    //}
    public void Breaking()
    {
        _meshRenderer.enabled = false;
        _collider.isTrigger=true;
    }
}
