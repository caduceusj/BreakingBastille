using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [field: SerializeField] public int damage { get; set; } = 4;
    [field: SerializeField] public float velocity { get; set; } = 0.5f;
    
    private Rigidbody rb;
    private PlayerHealthController healthController;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthController = PlayerHealthController.Instance;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthController.ReceiveDamage(damage);
        }

        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * velocity, ForceMode.Impulse);
    }
}
