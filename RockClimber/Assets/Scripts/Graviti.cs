using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graviti : MonoBehaviour
{
    
    [SerializeField]
    private Rigidbody _rbMain;
    [SerializeField]
    private Vector3 _directionGraviti;
    private void Start()
    {
        if (_directionGraviti==Vector3.zero)
        {
            _directionGraviti = Vector3.down;
        }
        if (_rbMain==null)
        {
            Debug.Log(name+ " absent Rigidbody");
        }
    }

    private void FixedUpdate()
    {
        _rbMain.AddForce(_directionGraviti*9.8f,ForceMode.Acceleration);
    }
    public void RevertGraviti()
    {
        _directionGraviti *= -1;
    }
    public void AddForceGraviti(float forse)
    {
        _rbMain.AddForce(_directionGraviti * forse, ForceMode.Acceleration);

    }
    [ContextMenu("GetRigidbody")]
    public void GetRigidbody()
    {
        _rbMain = GetComponent<Rigidbody>();
    }

}
