using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    private int _heals;

    public void Headshot()
    {
        Debug.Log("Headshot");
        Destroy(gameObject);
    }
    public void BodyShot()
    {
        _heals--;
        if (_heals == 0)
        {
            Debug.Log("BodyShot");

            Destroy(gameObject);
        }
    }
}
