using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool hit = false,hitPlayer = false,hitEnemy = false;
    public bool isFromEnemy, moving,vertical;
    public int damage;
    public float direction,velocity;
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
        if (moving)
        {
            if (vertical)
            {
                //transform.Translate(Vector3.forward * direction * velocity * Time.deltaTime);
                GetComponent<Rigidbody>().velocity = new Vector3(0f, direction, 0f) * velocity * Time.deltaTime;
                //GetComponent<Rigidbody>().AddForce(new Vector3(0f, direction * velocity, 0f), ForceMode.Impulse);
            }
            else
            {
                //transform.Translate(Vector3.up * direction * velocity * Time.deltaTime);
                GetComponent<Rigidbody>().velocity = new Vector3(direction, 0f, 0f) * velocity * Time.deltaTime;
                //'GetComponent<Rigidbody>().AddForce(new Vector3(direction * velocity, 0f, 0f),ForceMode.Impulse);
            }
        }
    }
    private void FixedUpdate()
    {
        
        
    }
}
