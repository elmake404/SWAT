using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _meshRenderer;
    [SerializeField]
    private Collider _collider;
    public void Breaking()
    {
        _meshRenderer.enabled = false;
        _collider.isTrigger=true;
        tag = "Thorns";
    }
}
