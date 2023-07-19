using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private float velocity;
    [SerializeField] private int damage;

    private GameObject newProjectile;
    private ProjectileController projectileController;

    public void shoot()
    {
        newProjectile = Instantiate(projectile,firePoint.transform.position,firePoint.transform.rotation);
        
        projectileController = newProjectile.GetComponent<ProjectileController>();
        projectileController.damage = damage;
        projectileController.velocity = Mathf.Abs(velocity);
    }
}
