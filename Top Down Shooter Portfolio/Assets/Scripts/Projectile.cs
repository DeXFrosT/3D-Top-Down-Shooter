using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float maxProjectileDistance;
    public float projectileSpeed = 10;

    private Vector3 firingPoint;

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
            this.gameObject.SetActive(false);
        }
        else
        {
            transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collider)  // Disable object upon collision with Enemy tag object.
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
