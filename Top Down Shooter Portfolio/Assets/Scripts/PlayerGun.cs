using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] Transform firingPoint;

    public static PlayerGun Instance;

    public float firingSpeed;
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
            ObjectPooler.Instance.SpawnFromPool("Bullet", firingPoint.position, firingPoint.rotation);
        }         
    }
}
