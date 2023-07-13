using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectile,firePoint;
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

        newProjectile.GetComponent<Rigidbody>().velocity = new Vector3(1f, 0f,0f) * 10f;
        projectileController.isFromEnemy = false;
        projectileController.damage = 1;
        
      
    }
}
