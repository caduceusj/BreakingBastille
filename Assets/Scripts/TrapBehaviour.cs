using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectile,firePoint;
    [SerializeField] private bool vertical;
    [SerializeField] private float velocity;
    private GameObject newProjectile;
    private ProjectileController projectileController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shoot()
    {
        newProjectile = Instantiate(projectile,firePoint.transform.position,firePoint.transform.rotation);
        projectileController = newProjectile.GetComponent<ProjectileController>();

        projectileController.moving = true;
        projectileController.isFromEnemy = true;
        projectileController.damage = 1;
        projectileController.velocity = Mathf.Abs(velocity);
        projectileController.vertical = vertical;        
    }
}
