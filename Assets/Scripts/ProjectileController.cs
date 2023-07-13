using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool hit = false,hitPlayer = false,hitEnemy = false;
    public bool isFromEnemy;
    public int damage;
    private PlayerHealthController healthController;

    private void Start()
    {
        healthController = PlayerHealthController.Instance;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(isFromEnemy && collision.gameObject.CompareTag("Player")) hitPlayer = true;
        if (!isFromEnemy && collision.gameObject.CompareTag("Enemy")) hitEnemy = true;
        hit = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (hit)
        {
            if(hitPlayer)
            {
                healthController.ReceiveDamage(damage);
            }
            if(hitEnemy)
            {

            }
            Destroy(gameObject);
        }
    }
}
