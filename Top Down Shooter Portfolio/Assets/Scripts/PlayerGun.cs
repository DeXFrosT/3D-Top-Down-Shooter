using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] Transform firingPoint;
    [SerializeField] GameObject buletPrefab;
    public float firingSpeed;

    public static PlayerGun Instance;

    private float lastTimeShot = 0;

    void Awake()
    {
        Instance = GetComponent<PlayerGun>();
    }

    public void Shoot()  // Calculates time since last shot and spawn the projectile.
    {
        if(lastTimeShot + firingSpeed <= Time.time)
        {
            lastTimeShot = Time.time;
            Instantiate(buletPrefab, firingPoint.position, firingPoint.rotation);
        }         
    }
}
