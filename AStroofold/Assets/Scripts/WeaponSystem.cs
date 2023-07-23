using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    //public ParticleSystem shootingParticle;

    public float fireRate; // Cadência fixa de tiro
    public float nextFireTime;
    public float speed;
    public bool shootReady;

    public void Start()
    {
        nextFireTime = Time.time;
    }

    public void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot(firePoint1);
            Shoot(firePoint2);
            nextFireTime = Time.time + fireRate;
        }
    }

    public void Shoot(Transform firePoint)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        shootReady = true;
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.velocity = transform.forward * speed;
        
        //ParticleSystem particle = Instantiate(shootingParticle, firePoint.position, Quaternion.identity);
        //particle.transform.parent = projectile.transform;
        //Destroy(particle.gameObject, particle.main.duration);
        Destroy(projectile, 1.5f);
    }
}
