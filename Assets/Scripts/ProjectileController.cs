using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool hit = false,hitPlayer = false,hitEnemy = false;
    public bool isFromEnemy, moving,vertical;
    public int damage = 4;
    public float direction,velocity;
    private PlayerHealthController healthController;

    [SerializeField] GameObject Target;

    private void Start()
    {
        healthController = PlayerHealthController.Instance;
    }
    private void OnTriggerEnter(Collider collision)
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
        var step = velocity * Time.deltaTime; // calculate distance to move
        


        // GetComponent<Rigidbody>().velocity = new Vector3(direction, 0f, 0f) * velocity * Time.deltaTime;
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
                // GetComponent<Rigidbody>().velocity = new Vector3(direction, 0f, 0f) * velocity * Time.deltaTime;
                //'GetComponent<Rigidbody>().AddForce(new Vector3(direction * velocity, 0f, 0f),ForceMode.Impulse);
                
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, 11f), step);
                if(transform.position.z >= 11f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        
        
    }
}
