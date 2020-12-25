using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarrel : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _explosion;
    [SerializeField]
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private float radius, force;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BulletOfJustice")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (var c in colliders)
            {
                if (c.tag == "PlayerAdditional")
                {
                    //var Player = c.GetComponent<PlayerAdditional>();
                    //Player.Deactivation();
                    //Player.rd.AddExplosionForce(force, transform.position, radius);
                }
            }
            _explosion.Play();
            _meshRenderer.enabled = false;
            Destroy(gameObject,1);

        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
