using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float maxProjectileDistance;
    private Vector3 firingPoint;
    public float projectileSpeed = 10;

    void Start()
    {
        firingPoint = transform.position;
    }

    void Update()
    {
        MoveProjectile();  // Set the direction, motion, and max travel distance of the projecctile.
    }

    void MoveProjectile()
    {
        if (Vector3.Distance(firingPoint, transform.position) > maxProjectileDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collider)  // Destroy object with Enemy tag.
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
