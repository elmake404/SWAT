using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other == Player.PlayerMain.GetFeet())
        {
            other.GetComponentInParent<Graviti>().RevertGraviti();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other == Player.PlayerMain.GetFeet())
        {
            other.GetComponentInParent<Graviti>().AddForceGraviti(20);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == Player.PlayerMain.GetFeet())
        {
            other.GetComponentInParent<Graviti>().RevertGraviti();
        }
    }
}
